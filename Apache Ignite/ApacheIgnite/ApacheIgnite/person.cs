using System;
using System.Collections.Generic;
using System.Text;

namespace ApacheIgnite
{
   public  class person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override String ToString()
        {
            return $"Person [Name={Name}, Age={Age}]";
        }
    }
}
