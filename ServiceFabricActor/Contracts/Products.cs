using System;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class Products
    {
      [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Type { get; set; }

    }
}
