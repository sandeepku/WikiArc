using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WikiArc.Model.Types
{
    [DataContract]
    public class FeatureLayerAll
    {
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
        public object editFieldsInfo { get; set; } //this object thing need to be looked into
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
        public List<object> types { get; set; }
        [DataMember]
        public List<Template> templates { get; set; }
        [DataMember]
        public int maxRecordCount { get; set; }
        [DataMember]
        public string supportedQueryFormats { get; set; }
        [DataMember]
        public string capabilities { get; set; }
    }
}
