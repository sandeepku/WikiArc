using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WikiArc.Model.Types
{
    /// <summary>
    /// ArcGIS Feature Service Structure
    /// </summary>
    [DataContract]
    public class FeatureServer
    {
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
    }
}
