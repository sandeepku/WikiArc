using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WikiArc.Model.Types
{

    #region Main Types

    [DataContract]
    public class Category
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int amount { get; set; }
        [DataMember]
        public string icon { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Place
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int language_id { get; set; }
        [DataMember]
        public string language_iso { get; set; }
        [DataMember]
        public string urlhtml { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public List<Tag> tags { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string wikipedia { get; set; }
        [DataMember]
        public bool is_building { get; set; }
        [DataMember]
        public bool is_region { get; set; }
        [DataMember]
        public bool is_deleted { get; set; }
        [DataMember]
        public string parent_id { get; set; }
        [DataMember]
        public EditInfo edit_info { get; set; }
        [DataMember]
        public bool is_protected { get; set; }
        [DataMember]
        public List<object> photos { get; set; }
        [DataMember]
        public List<object> comments { get; set; }
        [DataMember]
        public Location location { get; set; }
        //[DataMember]
        //public AvailableLanguages availableLanguages { get; set; }

    }
    #endregion

    #region Supporting Types
    [DataContract]
    public class Tag
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string title { get; set; }
    }
    [DataContract]
    public class EditInfo
    {
        [DataMember]
        public int user_id { get; set; }
        [DataMember]
        public string user_name { get; set; }
        [DataMember]
        public int date { get; set; }
        [DataMember]
        public object is_unbindable { get; set; }
        [DataMember]
        public bool deletion_state { get; set; }
        [DataMember]
        public bool is_in_deletion_queue { get; set; }
        [DataMember]
        public bool is_in_undeletion_queue { get; set; }
    }
    [DataContract]
    public class Gadm
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string level { get; set; }
        [DataMember]
        public string is_last_level { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public object iso { get; set; }
        [DataMember]
        public object type { get; set; }
        [DataMember]
        public string translation { get; set; }
    }
    [DataContract]
    public class Location
    {
        [DataMember]
        public double lon { get; set; }
        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double north { get; set; }
        [DataMember]
        public double south { get; set; }
        [DataMember]
        public double east { get; set; }
        [DataMember]
        public double west { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string place { get; set; }
        [DataMember]
        public int country_adm_id { get; set; }
        [DataMember]
        public List<Gadm> gadm { get; set; }
        [DataMember]
        public string city_id { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public int zoom { get; set; }
    }
    #endregion
}
