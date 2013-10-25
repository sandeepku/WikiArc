using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WikiArc.Model.Operations;
using WikiArc.Model.Types;

namespace WikiArc.Interface
{

    public class FeatureLayerQuery : ServiceStack.ServiceInterface.Service
    {
        public object Any(FeatureServerQuery request)
        {
            FeatureServerQueryResponse featureserverqueryresponse = new FeatureServerQueryResponse();

            //first get the geometry thing working with the spatial filters 
            if ((request.geometryType != null) && (request.geometryType == "esriGeometryEnvelope"))
            {
                //as of now the supported interface is only for the envelope
                try
                {
                    var client = new RestClient();
                    string wikiendpoint = "http://api.wikimapia.org";
                    string geomserverendpoint = "http://services.geodataonline.no/arcgis/rest/services/Utilities/Geometry/GeometryServer";
                    Extent extGeometry = null;
                    Field fld;

                    #region deserialize the geometry and project it if required
                    extGeometry = ServiceStack.Text.JsonSerializer.DeserializeFromString<Extent>(request.geometry);
                    geometryextent ext = new geometryextent();
                    ext.geometryType = "esriGeometryEnvelope";
                    ext.geometries.Add(extGeometry);

                    string geometries = ServiceStack.Text.JsonSerializer.SerializeToString(ext);
                    //first get the envelope geometry in the right projection.
                    if (request.inSR == "4326")
                    {
                    }
                    else
                    {
                        //project it.
                        client = new RestClient();
                        var queryrequest = new RestRequest(geomserverendpoint + "/project", Method.POST);
                        queryrequest.AddParameter("f", "pjson");
                        //string geometries = String.Format("{\"geometryType\" : \"esriGeometryEnvelope\", \"geometries\" : [ {\"xmin\":{0},\"ymin\":{1},\"xmax\":{2},\"ymax\":{3}} ]}", extGeometry.xmin, extGeometry.ymin, extGeometry.xmax, extGeometry.ymax);
                        queryrequest.AddParameter("geometries", geometries);
                        queryrequest.AddParameter("inSR", request.inSR);
                        queryrequest.AddParameter("outSR", 4326);
                        queryrequest.AddParameter("transformForward", false);
                        queryrequest.AddHeader("Content-Type", "text/plain;charset=utf-8");
                        queryrequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

                        // IRestResponse res = client.Execute(queryrequest);
                        IRestResponse<geometryextent> response2 = client.Execute<geometryextent>(queryrequest);
                        if ((response2.Data != null) && (response2.Data.geometries != null))
                        {
                            extGeometry = new Extent();
                            extGeometry.xmin = response2.Data.geometries[0].xmin;
                            extGeometry.ymin = response2.Data.geometries[0].ymin;
                            extGeometry.xmax = response2.Data.geometries[0].xmax;
                            extGeometry.ymax = response2.Data.geometries[0].ymax;
                        }

                    }
                    #endregion



                    if (extGeometry != null)
                    {

                        //now its time to send the request to wikimap api.
                        //send the request to wikimaps and collect the response.
                        client = new RestClient();
                        var queryrequest = new RestRequest(wikiendpoint, Method.GET);
                        queryrequest.AddParameter("format", "json");

                        queryrequest.AddParameter("function", "place.getbyarea");
                        queryrequest.AddParameter("coordsby", "latlon");
                        //queryrequest.AddParameter("data_blocks", "main,edit,photos,comments,location,translate");
                        queryrequest.AddParameter("data_blocks", "main,location");
                        /*queryrequest.AddParameter("latlon", String.Format("{0:0.#######}", extGeometry.xmin).Replace(",", ".") 
                            + "," + String.Format("{0:0.#######}", extGeometry.ymin).Replace(",",".") 
                            + "," + String.Format("{0:0.#######}", extGeometry.xmax).Replace(",",".") 
                            + "," + String.Format("{0:0.#######}", extGeometry.ymax).Replace(",","."));
                         * */

                        queryrequest.AddParameter("lon_min", String.Format("{0:0.#######}", extGeometry.xmin).Replace(",", "."));
                        queryrequest.AddParameter("lat_min", String.Format("{0:0.#######}", extGeometry.ymin).Replace(",", "."));
                        queryrequest.AddParameter("lon_max", String.Format("{0:0.#######}", extGeometry.xmax).Replace(",", "."));
                        queryrequest.AddParameter("lat_max", String.Format("{0:0.#######}", extGeometry.ymax).Replace(",", "."));

                        queryrequest.AddParameter("categories_and", "");
                        queryrequest.AddParameter("categories_or", "");
                        queryrequest.AddParameter("category", "");
                        queryrequest.AddParameter("key", "E10A5E44-95CC8BC-25C4D749-50B6C3A2-F8F1EE8F-EB2F0803-37FD3C8F-CE9B8627");
                        queryrequest.AddParameter("language", "en");
                        queryrequest.AddParameter("name", "");
                        queryrequest.AddParameter("pack", "");
                        queryrequest.AddParameter("count", "100");
                        //queryrequest.AddParameter("options", "mercator");

                        queryrequest.AddParameter("page", "1");


                        queryrequest.AddHeader("Content-Type", "text/plain;charset=utf-8");
                        queryrequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

                        IRestResponse<PlaceResponse> placeresponse = client.Execute<PlaceResponse>(queryrequest);

                        //IRestResponse placeresponse = client.Execute(queryrequest);

                        //had to use the service stack deserilizer cause the others wr not working
                        PlaceResponse placestruct = ServiceStack.Text.JsonSerializer.DeserializeFromString<PlaceResponse>(placeresponse.Content);





                        if (placestruct != null)
                        {


                            //add the fields

                            #region fields collection
                            //something need to be done for this one.
                            fld = new Field();
                            fld.name = "OBJECTID";
                            fld.alias = "OBJECTID";
                            fld.type = "esriFieldTypeOID";
                            featureserverqueryresponse.fields.Add(fld);


                            fld = new Field();
                            fld.name = "NAME";
                            fld.alias = "NAME";
                            fld.type = "esriFieldTypeString";
                            fld.length = 100;
                            featureserverqueryresponse.fields.Add(fld);

                            //DESCRIPTION
                            fld = new Field();
                            fld.name = "DESCRIPTION";
                            fld.alias = "DESCRIPTION";
                            fld.type = "esriFieldTypeString";
                            fld.length = 500;
                            featureserverqueryresponse.fields.Add(fld);

                            fld = new Field();
                            fld.name = "CATEGORY";
                            fld.alias = "CATEGORY";
                            fld.type = "esriFieldTypeString";
                            featureserverqueryresponse.fields.Add(fld);

                            fld = new Field();
                            fld.name = "CATEGORYID";
                            fld.alias = "CATEGORYID";
                            fld.type = "esriFieldTypeInteger";
                            featureserverqueryresponse.fields.Add(fld);
                            #endregion

                            #region features collection


                            if (placestruct.places != null)
                            {
                                //add the features with attributes
                                //assume tht u got something.
                                foreach (var place in placestruct.places)
                                {
                                    //make sure u get the deleted tag correct so tht can avoid some junk data.
                                    if (!place.is_deleted)
                                    {

                                        var feature = new PointFeature();
                                        feature.geometry = new PointGeometry();
                                        feature.attributes = new PointAttributes();

                                        feature.geometry.x = place.location.lon;
                                        feature.geometry.y = place.location.lat;

                                        feature.attributes.OBJECTID = place.id;

                                        if ((place.tags != null) && (place.tags.Count > 0))
                                        {
                                            //i am only taking the first category listing available..and ignoring the rest.
                                            feature.attributes.CATEGORY = place.tags[0].title;
                                            feature.attributes.CATEGORYID = place.tags[0].id;
                                        }

                                        feature.attributes.TITLE = place.title;

                                        feature.attributes.DESCRIPTION = place.description;

                                        featureserverqueryresponse.features.Add(feature);
                                    }

                                }
                            }
                            #endregion

                        }
                        else
                        {
                            featureserverqueryresponse.ResponseStatus.Message = placeresponse.ErrorMessage;
                            featureserverqueryresponse.ResponseStatus.StackTrace = placeresponse.ErrorException.StackTrace;

                        }


                        #region other tit bits for the output
                        featureserverqueryresponse.objectIdFieldName = "OBJECTID";
                        featureserverqueryresponse.globalIdFieldName = "";
                        featureserverqueryresponse.geometryType = "esriGeometryPoint";
                        spatialReference sp = new spatialReference();
                        sp.latestWkid = 4326;
                        sp.wkid = 4326;
                        featureserverqueryresponse.spatialReference = sp;
                        #endregion

                    }


                }
                catch (Exception ex)
                {
                    featureserverqueryresponse.ResponseStatus.Message = ex.Message;
                    featureserverqueryresponse.ResponseStatus.StackTrace = ex.StackTrace;
                }

                return featureserverqueryresponse;



            }


            //the secondf thing woutl be to query using the where clause and enable ids




            return featureserverqueryresponse;
        }
    }
}
