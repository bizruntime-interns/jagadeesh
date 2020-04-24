using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Query;
using System;

namespace ApacheIgniteSqlJoins
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new IgniteConfiguration
            {
                BinaryConfiguration = new BinaryConfiguration(typeof(Person), typeof(Organization))
            };
            IIgnite ignite = Ignition.Start(cfg);
            Environment.SetEnvironmentVariable("IGNITE_H2_DEBUG_CONSOLE", "true");
            ICache<int, Person> personCache = ignite.GetOrCreateCache<int, Person>(new CacheConfiguration("persons", typeof(Person)));
            var OrgCache = ignite.GetOrCreateCache<int, Organization>(new CacheConfiguration("orgs", typeof(Organization)));
            personCache[1] = new Person { Name = "Stan", Age = 55, OrgId = 2 };
            personCache[2] = new Person { Name = "Mike", Age = 54, OrgId = 1 };
            personCache[3] = new Person { Name = "Oprah", Age = 22, OrgId = 2 };

            OrgCache[1] = new Organization { Name = "Asha Foundation", Id = 2 };
            OrgCache[2] = new Organization { Name = "Okla Foundation", Id = 1 };

            var fieldsQuery = new SqlFieldsQuery("select Person.Name from Person " +
                                                    "join \"orgs\".Organization as org on (Person.OrgId = org.Id) " +
                                                    "where org.Name = ?", "Asha Foundation");
            foreach(var fieldList in personCache.QueryFields(fieldsQuery))
            {
                Console.WriteLine(fieldList[0]);
            }

            
        }
    }
    public class Person
    {
        [QuerySqlField]
        public string Name { get; set; }
        [QuerySqlField]
        public int Age { get; set; }
        [QuerySqlField]
        public int OrgId { get; set; }
    }
    public class Organization
    {
        [QuerySqlField]
        public string Name { get; set; }
        [QuerySqlField]
        public int Id { get; set; }
    }
}
