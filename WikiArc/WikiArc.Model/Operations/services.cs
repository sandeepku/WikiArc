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
    /// <summary>
    /// operation to list the available services and folders
    /// </summary>
    [DataContract]
    [Route("/services")]
    public class services
    {
        //no member items yet??TODO..think about it 
    }

    [DataContract]
    public class servicesResponse : IHasResponseStatus
    {
        public servicesResponse()
        {
            this.folders = new List<string>();
            this.currentVersion = 10.11;
            this.services = new List<service>();
            this.ResponseStatus = new ResponseStatus();
        }

        [DataMember]
        public double currentVersion { get; set; }

        [DataMember]
        public List<service> services { get; set; }

        [DataMember]
        public List<string> folders { get; set; }

        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }
    }
}
