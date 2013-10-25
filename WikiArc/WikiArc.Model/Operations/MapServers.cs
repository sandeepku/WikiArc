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
    [Route("/services/{MapName}/MapServer")]
    [Route("/services/{MapName}/MapServer/{LayerID}")]
    public class MapServers
    {
        [DataMember]
        public string MapName { get; set; }
        [DataMember]
        public string LayerID { get; set; }
    }
    [DataContract]
    public class MapServersResponse : IHasResponseStatus
    {
        public MapServersResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.MapServer = new MapServer();
        }
        [DataMember]
        public MapServer MapServer { get; set; }
        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }
    }
}
