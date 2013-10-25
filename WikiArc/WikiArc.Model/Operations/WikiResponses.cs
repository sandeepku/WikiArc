using ServiceStack.ServiceInterface.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WikiArc.Model.Types;

namespace WikiArc.Model.Operations
{
    [DataContract]
    public class CategoryResponse 
    {
        [DataMember]
        public List<Category> categories { get; set; }
        [DataMember]
        public int found { get; set; }
        [DataMember]
        public int page { get; set; }
        [DataMember]
        public int count { get; set; }
    }


    [DataContract]
    public class PlaceResponse
    {
        [DataMember]
        public List<Place> places { get; set; }
        [DataMember]
        public int found { get; set; }
        [DataMember]
        public int page { get; set; }
        [DataMember]
        public int count { get; set; }
        [DataMember]
        public int language { get; set; }
    }
}
