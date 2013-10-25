using RestSharp;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WikiArc.Model.Operations;
using WikiArc.Model.Types;

namespace WikiArc.Interface
{

    /// <summary>
    /// Get the service listing for the wikiarc 
    /// available for the "/services/{MapName}/FeatureServer" & /services/{MapName}/FeatureServer/{LayerID} endpoint
    /// </summary>
    [ClientCanSwapTemplates]
    [DefaultView("featureserver")]
    public class GetFeatureServers : ServiceStack.ServiceInterface.Service
    {
        public object Any(FeatureServers request)
        {
            FeatureServersResponse featureserverresponse = new FeatureServersResponse();
            
            Layer arcgisLayer;
            try
            {
                //string wikiendpoint = "http://api.wikimapia.org";
                #region Commented Wiki Category
                /*
                //send the request to wikimaps and collect the response.
                var client = new RestClient();
                var queryrequest = new RestRequest(wikiendpoint, Method.GET);
                queryrequest.AddParameter("format", "json");
                queryrequest.AddParameter("count", "100");
                queryrequest.AddParameter("function", "category.getall");
                queryrequest.AddParameter("key", "example");
                queryrequest.AddParameter("language", "en");
                queryrequest.AddParameter("name", "");
                queryrequest.AddParameter("pack", "");
                queryrequest.AddParameter("page", "1");


                queryrequest.AddHeader("Content-Type", "text/plain;charset=utf-8");
                queryrequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

                IRestResponse<CategoryResponse> response = client.Execute<CategoryResponse>(queryrequest);
                if (response.Data != null)
                {
                    //if u found the data then we should desifer it.
                    foreach(Category wikicat in response.Data.categories)
                    {
                        Layer arcgisLayer = new Layer();
                        arcgisLayer.name = wikicat.name;
                        arcgisLayer.id = wikicat.id;
                        featureserverresponse.layers.Add(arcgisLayer);
                    }
                }
                else
                {
                    featureserverresponse.ResponseStatus.Message = response.ErrorMessage;
                    featureserverresponse.ResponseStatus.StackTrace =response.ErrorException.StackTrace;

                }
                */
                #endregion
           
                //add only 2 layers... the Locations and Regions
                arcgisLayer= new Layer();
                arcgisLayer.name = "Place";
                arcgisLayer.id = 0;
                featureserverresponse.layers.Add(arcgisLayer);

                /* for later as and when i understdn the point thingi
                arcgisLayer = new Layer();
                arcgisLayer.name = "Region";
                arcgisLayer.id = 2;
                featureserverresponse.layers.Add(arcgisLayer);

                arcgisLayer = new Layer();
                arcgisLayer.name = "Street";
                arcgisLayer.id = 1;
                featureserverresponse.layers.Add(arcgisLayer);
                */
                featureserverresponse.ServiceName = request.ServiceName;

                spatialReference sp = new spatialReference();
                sp.latestWkid = 4326;
                sp.wkid = 4326;

                InitialExtent mapExtent= new InitialExtent();
                mapExtent.xmin = -180;
                mapExtent.ymin = -90;
                mapExtent.xmax = 180;
                mapExtent.ymax = 90;

                FullExtent mapExtentFull = new FullExtent();
                mapExtentFull.xmin = -180;
                mapExtentFull.ymin = -90;
                mapExtentFull.xmax = 180;
                mapExtentFull.ymax = 90;


                featureserverresponse.serviceDescription = "WikiMap";
                featureserverresponse.supportedQueryFormats = "JSON, AMF";
                featureserverresponse.maxRecordCount = 100;
                featureserverresponse.description = "";
                featureserverresponse.copyrightText = "Sandeep Kuniel";
                featureserverresponse.spatialReference=sp;
                

                featureserverresponse.initialExtent = mapExtent;
                featureserverresponse.initialExtent.spatialReference = sp;
                featureserverresponse.fullExtent = mapExtentFull;
                featureserverresponse.fullExtent.spatialReference = sp;


                featureserverresponse.units = "esriDecimalDegrees";

                featureserverresponse.documentInfo.Comments = "WikiMap";
                featureserverresponse.documentInfo.Subject = "WikiMap";
                featureserverresponse.documentInfo.Keywords = "WikiMap";


                


            }
            catch (Exception ex)
            {
                featureserverresponse.ResponseStatus.Message = ex.Message;
                featureserverresponse.ResponseStatus.StackTrace = ex.StackTrace;
            }

            return featureserverresponse;

        }
    }
}
