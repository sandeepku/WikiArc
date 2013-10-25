using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WikiArc.Model.Types
{
    [DataContract]
    public class geometryextent
    {
        [DataMember]
        public string geometryType { get; set; }
        [DataMember]
        public List<Extent> geometries { get; set; }

        public geometryextent()
        {
            this.geometryType = "esriGeometryEnvelope";
            this.geometries = new List<Extent>();
        }
    }


    [DataContract]
    public class spatialReference
    {
        [DataMember]
        public int wkid { get; set; }
        [DataMember]
        public int latestWkid { get; set; }
    }
    [DataContract]
    public class InitialExtent
    {
        [DataMember]
        public double xmin { get; set; }
        [DataMember]
        public double ymin { get; set; }
        [DataMember]
        public double xmax { get; set; }
        [DataMember]
        public double ymax { get; set; }
        [DataMember]
        public spatialReference spatialReference { get; set; }
    }
    [DataContract]
    public class FullExtent
    {
        [DataMember]
        public double xmin { get; set; }
        [DataMember]
        public double ymin { get; set; }
        [DataMember]
        public double xmax { get; set; }
        [DataMember]
        public double ymax { get; set; }
        [DataMember]
        public spatialReference spatialReference { get; set; }
    }
    [DataContract]
    public class DocumentInfo
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Comments { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Keywords { get; set; }
    }
    [DataContract]
    public class OwnershipBasedAccessControlForFeatures
    {
        [DataMember]
        public bool allowOthersToQuery { get; set; }
    }
    [DataContract]
    public class Layer
    {
        [DataMember]
        public double? currentVersion { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string definitionExpression { get; set; }
        [DataMember]
        public string geometryType { get; set; }
        [DataMember]
        public string copyrightText { get; set; }
        [DataMember]
        public Layer parentLayer { get; set; }
        [DataMember]
        public List<Layer> subLayers { get; set; }
        [DataMember]
        public int? minScale { get; set; }
        [DataMember]
        public int? maxScale { get; set; }
        [DataMember]
        public DrawingInfo drawingInfo { get; set; }
        [DataMember]
        public bool? defaultVisibility { get; set; }
        [DataMember]
        public Extent extent { get; set; }
        [DataMember]
        public bool? hasAttachments { get; set; }
        [DataMember]
        public string htmlPopupType { get; set; }
        [DataMember]
        public string displayField { get; set; }
        [DataMember]
        public object typeIdField { get; set; }
        [DataMember]
        public List<Field> fields { get; set; }
        [DataMember]
        public List<Relationship> relationships { get; set; }
        [DataMember]
        public bool? canModifyLayer { get; set; }
        [DataMember]
        public bool? canScaleSymbols { get; set; }
        [DataMember]
        public bool? hasLabels { get; set; }
        [DataMember]
        public string capabilities { get; set; }
        [DataMember]
        public int? maxRecordCount { get; set; }
        [DataMember]
        public bool? supportsStatistics { get; set; }
        [DataMember]
        public bool? supportsAdvancedQueries { get; set; }
        [DataMember]
        public string supportedQueryFormats { get; set; }
        [DataMember]
        public bool? isDataVersioned { get; set; }
        [DataMember]
        public OwnershipBasedAccessControlForFeatures ownershipBasedAccessControlForFeatures { get; set; }

    }
    [DataContract]
    public class PointGeometry
    {
        [DataMember]
        public double x { get; set; }
        [DataMember]
        public double y { get; set; }
    }
    [DataContract]
    public class PointAttributes
    {
        [DataMember]
        public int OBJECTID { get; set; }
        [DataMember]
        public string DESCRIPTION { get; set; }
        [DataMember]
        public int CATEGORYID { get; set; }
        [DataMember]
        public string CATEGORY { get; set; }
        [DataMember]
        public string TITLE { get; set; }
    }

    [DataContract]
    public class PointFeature
    {
        [DataMember]
        public PointGeometry geometry { get; set; }
        [DataMember]
        public PointAttributes attributes { get; set; }
    }

    [DataContract]
    public class Legend
    {
        [DataMember]
        public string label { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string imageData { get; set; }
        [DataMember]
        public string contentType { get; set; }
        [DataMember]
        public int height { get; set; }
        [DataMember]
        public int width { get; set; }
    }

    [DataContract]
    public class Table
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
        public object description { get; set; }
        [DataMember]
        public string definitionExpression { get; set; }
        [DataMember]
        public bool hasAttachments { get; set; }
        [DataMember]
        public string htmlPopupType { get; set; }
        [DataMember]
        public string displayField { get; set; }
        [DataMember]
        public object typeIdField { get; set; }
        [DataMember]
        public List<Field> fields { get; set; }
        [DataMember]
        public List<Relationship> relationships { get; set; }
        [DataMember]
        public string capabilities { get; set; }
        [DataMember]
        public int maxRecordCount { get; set; }
        [DataMember]
        public bool supportsStatistics { get; set; }
        [DataMember]
        public bool supportsAdvancedQueries { get; set; }
        [DataMember]
        public string supportedQueryFormats { get; set; }
        [DataMember]
        public bool isDataVersioned { get; set; }
    }
    [DataContract]
    public class Extent
    {
        [DataMember]
        public double xmin { get; set; }
        [DataMember]
        public double ymin { get; set; }
        [DataMember]
        public double xmax { get; set; }
        [DataMember]
        public double ymax { get; set; }
        [DataMember]
        public spatialReference spatialReference { get; set; }
    }
    [DataContract]
    public class Outline
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string style { get; set; }
        [DataMember]
        public List<int> color { get; set; }
        [DataMember]
        public double width { get; set; }
    }
    [DataContract]
    public class Symbol
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string imageData { get; set; }
        [DataMember]
        public string contentType { get; set; }
        [DataMember]
        public int width { get; set; }
        [DataMember]
        public int height { get; set; }
        [DataMember]
        public int angle { get; set; }
        [DataMember]
        public int xoffset { get; set; }
        [DataMember]
        public int yoffset { get; set; }
        [DataMember]
        public string style { get; set; }
        [DataMember]
        public List<int> color { get; set; }
        [DataMember]
        public Outline outline { get; set; }
    }
    [DataContract]
    public class Renderer
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public Symbol symbol { get; set; }
        [DataMember]
        public string label { get; set; }
        [DataMember]
        public string description { get; set; }
    }
    [DataContract]
    public class DrawingInfo
    {
        [DataMember]
        public Renderer renderer { get; set; }
        [DataMember]
        public int transparency { get; set; }
        [DataMember]
        public object labelingInfo { get; set; }
    }
    [DataContract]
    public class CodedValue
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public object code { get; set; }
    }
    [DataContract]
    public class Domain
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public List<CodedValue> codedValues { get; set; }
    }
    [DataContract]
    public class Field
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string alias { get; set; }
        [DataMember]
        public Domain domain { get; set; }
        [DataMember]
        public bool? editable { get; set; }
        [DataMember]
        public bool? nullable { get; set; }
        [DataMember]
        public int? length { get; set; }
    }
    [DataContract]
    public class Relationship
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int relatedTableId { get; set; }
        [DataMember]
        public string cardinality { get; set; }
        [DataMember]
        public string role { get; set; }
        [DataMember]
        public string keyField { get; set; }
        [DataMember]
        public bool composite { get; set; }
    }
    [DataContract]
    public class Prototype
    {
        [DataMember]
        public Dictionary<string, object> attributes { get; set; }
    }
    [DataContract]
    public class Template
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public Prototype prototype { get; set; }
        [DataMember]
        public string drawingTool { get; set; }
    }
}
