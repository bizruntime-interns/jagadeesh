using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testing_log_asp.net.Models
{
   public interface Iuser
    {
        bool Get(string name);
        bool Get1(string password, string name);

    }
}
