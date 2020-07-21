using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace testing_log_asp.net.Models
{
    public class validation : Iuser
    {
        private readonly ConnectionStringClass _cc;



        public validation(ConnectionStringClass cc)
        {
            _cc = cc;
        }
        public bool Get(string name)
        {
            login c = _cc.login.Where(p => p.Name == name).FirstOrDefault();

            if (c != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Get1(string password, string name)
        {

            login c = _cc.login.Where(p => p.Name == name).FirstOrDefault();

            if (c != null)
            {
                if (c.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            else
            {
                return false;
            }

        }

    }
}
