using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WikiArc.Model.Types
{
    /// <summary>
    /// ArcGIS Services structure
    /// </summary>
    [DataContract]
    public class service
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string type { get; set; }
    }
}
