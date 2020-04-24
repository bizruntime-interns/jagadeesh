using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace communication
{
    [DataContract]
   public  class Products
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Type { get; set; }
    }
}
