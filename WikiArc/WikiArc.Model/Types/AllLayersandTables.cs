using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WikiArc.Model.Types
{
    [DataContract]
    public class AllLayersandTables
    {
        [DataMember]
        public List<Layer> layers { get; set; }
        [DataMember]
        public List<Table> tables { get; set; }
    }
}
