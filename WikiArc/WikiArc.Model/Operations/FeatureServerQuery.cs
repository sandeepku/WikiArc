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
    [Route("/services/{MapName}/FeatureServer/{LayerID}/query")]
    public class FeatureServerQuery
    {
        [DataMember]
        public string MapName { get; set; }
        [DataMember]
        public string LayerID { get; set; }
        [DataMember]
        public string objectIds { get; set; } //Syntax: objectIds=<objectId1>, <objectId2>
        [DataMember]
        public string where { get; set; }
        [DataMember]
        public string geometry { get; set; }
        [DataMember]
        public string geometryType { get; set; }
        [DataMember]
        public string inSR { get; set; }
        [DataMember]
        public string spatialRel { get; set; }
        [DataMember]
        public string relationParam { get; set; }
        [DataMember]
        public string time { get; set; }
        [DataMember]
        public string outFields { get; set; }
        [DataMember]
        public bool returnGeometry { get; set; }
        [DataMember]
        public string outSR { get; set; }
        [DataMember]
        public string returnIdsOnly { get; set; }
        [DataMember]
        public string returnCountOnly { get; set; }
    }

    [DataContract]
    public class FeatureServerQueryResponse : IHasResponseStatus
    {
        public FeatureServerQueryResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.features = new List<PointFeature>();
            this.fields = new List<Field>();
         
        }
        [DataMember]
        public string objectIdFieldName { get; set; }
        [DataMember]
        public string globalIdFieldName { get; set; }
        [DataMember]
        public string geometryType { get; set; }
        [DataMember]
        public spatialReference spatialReference { get; set; }
        [DataMember]
        public List<Field> fields { get; set; }
        [DataMember]
        public List<WikiArc.Model.Types.PointFeature> features { get; set; }

        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }
    }
}
