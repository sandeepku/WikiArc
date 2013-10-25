using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WikiArc.Model.Types;

namespace WikiArc.Model.Operations
{

    [DataContract]
    [Route("/services/{ServiceName}/FeatureServer")]
    public class FeatureServers
    {
        [DataMember]
        public string ServiceName { get; set; }
    }
    [DataContract]
    public class FeatureServersResponse : IHasResponseStatus
    {
        
        public FeatureServersResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.currentVersion = 10.11;
            this.layers = new List<Layer>();
            this.tables = new List<Table>();
            this.spatialReference = new spatialReference();
            this.documentInfo = new DocumentInfo();
            this.initialExtent = new InitialExtent();
            this.fullExtent = new FullExtent();
            this.supportedQueryFormats = "JSON";
            this.capabilities = "Query";

        }
        [DataMember]
        public double currentVersion { get; set; }
        [DataMember]
        public string serviceDescription { get; set; }
        [DataMember]
        public bool hasVersionedData { get; set; }
        [DataMember]
        public bool supportsDisconnectedEditing { get; set; }
        [DataMember]
        public string supportedQueryFormats { get; set; }
        [DataMember]
        public int maxRecordCount { get; set; }
        [DataMember]
        public string capabilities { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string copyrightText { get; set; }
        [DataMember]
        public spatialReference spatialReference { get; set; }
        [DataMember]
        public InitialExtent initialExtent { get; set; }
        [DataMember]
        public FullExtent fullExtent { get; set; }
        [DataMember]
        public bool allowGeometryUpdates { get; set; }
        [DataMember]
        public string units { get; set; }
        [DataMember]
        public DocumentInfo documentInfo { get; set; }
        [DataMember]
        public List<Layer> layers { get; set; }
        [DataMember]
        public List<Table> tables { get; set; }
        [DataMember]
        public bool enableZDefaults { get; set; }




        [DataMember]
        public string ServiceName { get; set; }
         
          
         
        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }
    }
}
