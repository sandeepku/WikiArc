using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WikiArc.Model.Types;

namespace WikiArc.Model.Operations
{
    /// <summary>
    /// Featurelayer specific endpoint to get the details of the layer
    /// </summary>
    [DataContract]
    [Route("/services/{ServiceName}/FeatureServer/{LayerID}")]
    public class FeatureLayer
    {
        [DataMember]
        public string ServiceName { get; set; }
        [DataMember]
        public int? LayerID { get; set; }
    }
    [DataContract]
    public class FeatureLayerResponse : IHasResponseStatus
    {
        public FeatureLayerResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.currentVersion = 10.11;
            this.type = "Feature Layer";
            this.description = "";
            this.copyrightText = "";
            this.defaultVisibility = false;
            this.editFieldsInfo = null;
            this.ownershipBasedAccessControlForFeatures = null;
            this.syncCanReturnChanges = false;
            this.relationships=new List<Relationship>();
            this.isDataVersioned=false;
            this.supportsRollbackOnFailureParameter=false;
            this.supportsStatistics=false;
            this.minScale=0;
            this.maxScale=0;
            this.extent=new Extent();
            this.drawingInfo=new DrawingInfo();
            this.hasM=false;
            this.hasZ=false;
            this.allowGeometryUpdates=false;
            this.hasAttachments=false;
            this.htmlPopupType="esriServerHTMLPopupTypeAsHTMLText";
            this.globalIdField="";
            this.typeIdField="";
            this.objectIdField = "OBJECTID";
            this.displayField = "DESCRIPTION";
            this.fields=new List<Field>();
            this.types=new List<object>();
            this.templates = new List<Template>();
            this.maxRecordCount = 100;//make a note of this one,..cause it depends upong the wiki apis
            this.supportedQueryFormats = "JSON, AMF";
            this.capabilities = "Query";

        }


        //members..
        [DataMember]
        public double currentVersion { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string copyrightText { get; set; }
        [DataMember]
        public bool defaultVisibility { get; set; }
        [DataMember]
        public object editFieldsInfo { get; set; }
        [DataMember]
        public object ownershipBasedAccessControlForFeatures { get; set; }
        [DataMember]
        public bool syncCanReturnChanges { get; set; }
        [DataMember]
        public List<Relationship> relationships { get; set; }
        [DataMember]
        public bool isDataVersioned { get; set; }
        [DataMember]
        public bool supportsRollbackOnFailureParameter { get; set; }
        [DataMember]
        public bool supportsStatistics { get; set; }
        [DataMember]
        public bool supportsAdvancedQueries { get; set; }
        [DataMember]
        public string geometryType { get; set; }
        [DataMember]
        public int minScale { get; set; }
        [DataMember]
        public int maxScale { get; set; }
        [DataMember]
        public Extent extent { get; set; }
     
        [DataMember]
        public DrawingInfo drawingInfo { get; set; }
        [DataMember]
        public bool hasM { get; set; }
        [DataMember]
        public bool hasZ { get; set; }
        [DataMember]
        public bool allowGeometryUpdates { get; set; }
        [DataMember]
        public bool hasAttachments { get; set; }
        [DataMember]
        public string htmlPopupType { get; set; }
        [DataMember]
        public string objectIdField { get; set; }
        [DataMember]
        public string globalIdField { get; set; }
        [DataMember]
        public string displayField { get; set; }
        [DataMember]
        public string typeIdField { get; set; }
        [DataMember]
        public List<Field> fields { get; set; }
        [DataMember]
        public List<object> types { get; set; } //i am little doubtfull for this value.
        [DataMember]
        public List<Template> templates { get; set; }
        [DataMember]
        public int maxRecordCount { get; set; }
        [DataMember]
        public string supportedQueryFormats { get; set; }
        [DataMember]
        public string capabilities { get; set; }



        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }


    }
}
