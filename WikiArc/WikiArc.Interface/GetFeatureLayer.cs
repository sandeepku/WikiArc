using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WikiArc.Model.Operations;
using WikiArc.Model.Types;

namespace WikiArc.Interface
{
    [ClientCanSwapTemplates]
    [DefaultView("featurelayer")]
    public class GetFeatureLayer : ServiceStack.ServiceInterface.Service
    {

        public object Any(FeatureLayer request)
        {
            FeatureLayerResponse featurelayerresponse = new FeatureLayerResponse();

            try
            {
                //wht do u get here..
                //get the layer id and based on tht change the geometry types and others..
                string esriGeometryType = "esriGeometryPoint";
                string esriFeatureLayerName = "Place";
                switch (request.LayerID)
                {
                    case 0:
                        esriGeometryType = "esriGeometryPoint";
                        esriFeatureLayerName = "Place";
                        break;
                    case 1:
                        esriGeometryType = "esriGeometryPolyline";
                        esriFeatureLayerName = "Street";
                        break;
                    case 2:
                        esriGeometryType = "esriGeometryPolygon";
                        esriFeatureLayerName = "Region";
                        break;
                }
                featurelayerresponse.name = esriFeatureLayerName;
                featurelayerresponse.geometryType = esriGeometryType;

                #region Define Fields for the layer
                Field fld;
                //OID
                fld = new Field();
                fld.name = "OBJECTID";
                fld.alias = "OBJECTID";
                fld.editable = false;
                fld.nullable = false;
                fld.domain = null;
                fld.type = "esriFieldTypeOID";
                featurelayerresponse.fields.Add(fld);
                
                //DESCRIPTION
                fld = new Field();
                fld.name = "DESCRIPTION";
                fld.alias = "DESCRIPTION";
                fld.editable = false;
                fld.nullable = true;
                fld.domain = null;
                fld.type = "esriFieldTypeString";
                fld.length = 500;
                featurelayerresponse.fields.Add(fld);

                fld = new Field();
                fld.name = "CATEGORY";
                fld.alias = "CATEGORY";
                fld.editable = false;
                fld.nullable = true;
                fld.domain = null;
                fld.length = 100;
                fld.type = "esriFieldTypeString";
                featurelayerresponse.fields.Add(fld);

                fld = new Field();
                fld.name = "CATEGORYID";
                fld.alias = "CATEGORYID";
                fld.editable = false;
                fld.nullable = true;
                fld.domain = null;
                fld.type = "esriFieldTypeInteger";
                featurelayerresponse.fields.Add(fld);

                fld = new Field();
                fld.name = "TITLE";
                fld.alias = "TITLE";
                fld.editable = false;
                fld.nullable = true;
                fld.domain = null;
                fld.type = "esriFieldTypeString";
                fld.length = 100;
                featurelayerresponse.fields.Add(fld);
                #endregion

                spatialReference sp = new spatialReference();
                sp.latestWkid = 4326;
                sp.wkid = 4326;

                //map extent.
                Extent mapExtent;
                mapExtent = new Extent();
                mapExtent.xmin = -180;
                mapExtent.ymin = -90;
                mapExtent.xmax = 180;
                mapExtent.ymax = 90;

                mapExtent.spatialReference = sp;

                featurelayerresponse.extent = mapExtent;
               

                //drawing info.
                DrawingInfo drawInfo = new DrawingInfo();
                Renderer renderer=new Renderer();
                Symbol symbol=new Symbol();

                symbol.type = "esriPMS";
                symbol.url = "5bb08731ea7927efe0e8b84659a9b825";
                symbol.imageData = "iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAAAAXNSR0IB2cksfwAAAAlwSFlzAAAOxAAADsQBlSsOGwAAApVJREFUOI2tlG9IE3EYx5/bzs1zKGyOzYne7Zw2txXNtNkERRD/Jb7pTeQYZkViCEqIEfTnVUQE9qYEo1eVb6IikUN8k6VgWImHBC7K1nJibON3YObluc1eNMeduw2Lvq9+d8/z/fye5+HuweE/C88Qw9RqdePxgoKGgySpJ5RK1TrPb06z7JpPo3mBEGL3DdTpdNW95eVXOioqLAf0ehsmisWam4W3KyutjxcWloZZ9hoAfMsIbNPpTve1tPQ3lpUdlrtMiWEqN0m6XMXFVQ6Tib46NzeIEJqTBTpLSxsG3O6B+pISR/pJJMGKCy5XHa5QDHUzzKndSsVAVRdNX98PTKyzlZU1Xznu9s3Z2ZMSoIeiejxO55G/gSUqhRN2+9ERn8+JEGKTwGq7vSk/J0cjZ1pdX4cAx4HNYAAtQaTEKwoL6Q6S7LqLUF8SaMzOLpKD+cJhcA4PwxYA1JtM8NzrTYEqMQxsRiMNIGo5G8dz5YDvV1dhK3F+tbYGS6EQ1FBUSp4m4U8C4wBxOaBFq02e1QBAip7FisXjMQnwZzTKySUeoyiY7uyET5EIuEkSivLyUnJ2AIDjeU4CDG1sfOCj0SoCl37rGADUms1QazbLVgYAEOC4OBeLPZUAgwhderm83N5mteandabRlN//+cbMzBMJcGh+PmQ1GB4GOK6f0mqx9Hap3gQCv7YEYRD+dC799bonJi4+UCgcDRZLkznN8MV6FwwKvnD4Ts/k5Njuu5TlcI5hmh+1t498jES8dTRN7J0pAADieZjy+xEvCJfPMMx9cUx2fXnHx7sZj+fWs8XFe7kEcUiTlaVXAKiiOzubP7a3v/OC8JoniN7zY2P8Xm/aBds2OvoFAFozN52qTBv7n/QbfOTYgHWKQf8AAAAASUVORK5CYII=";
                symbol.contentType = "image/png";
                symbol.width = 15;
                symbol.height = 15;
                symbol.angle = 0;
                symbol.xoffset = 0;
                symbol.yoffset = 0;
                
                renderer.symbol = symbol;
                renderer.type = "simple";
                renderer.label = "";
                renderer.description = "";
                
                drawInfo.renderer = renderer;
                drawInfo.transparency = 0;
                drawInfo.labelingInfo = null;

                featurelayerresponse.drawingInfo = drawInfo;

                featurelayerresponse.editFieldsInfo = null;
                featurelayerresponse.ownershipBasedAccessControlForFeatures = null;




            }   
            catch (Exception ex)
            {
                featurelayerresponse.ResponseStatus.Message = ex.Message;
                featurelayerresponse.ResponseStatus.StackTrace = ex.StackTrace;
            }

            return featurelayerresponse;
        }
    }
}
