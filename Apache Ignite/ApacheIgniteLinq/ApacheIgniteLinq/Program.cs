using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using System;
using System.Linq;

namespace ApacheIgniteLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new IgniteConfiguration
            {
                BinaryConfiguration = new BinaryConfiguration(typeof(Person),
        typeof(Organization))
            };
            IIgnite ignite = Ignition.Start(cfg);

            ICache<int, Person> personCache = ignite.GetOrCreateCache<int, Person>(
                new CacheConfiguration("persons", typeof(Person)));

            var orgCache = ignite.GetOrCreateCache<int, Organization>(
                new CacheConfiguration("orgs", typeof(Organization)));
            personCache[1] = new Person { Name = "John Doe", Age = 27, OrgId = 1 };
            personCache[2] = new Person { Name = "Jane Moe", Age = 43, OrgId = 2 };
            personCache[3] = new Person { Name = "Ivan Petrov", Age = 59, OrgId = 2 };

            orgCache[1] = new Organization { Id = 1, Name = "Contoso" };
            orgCache[2] = new Organization { Id = 2, Name = "Apache" };
            IQueryable<ICacheEntry<int, Person>> persons = personCache.AsQueryable();
            IQueryable<ICacheEntry<int, Organization>> orgs = orgCache.AsQueryable();
           //Simple Filtering
            IQueryable<ICacheEntry<int, Person>> query = persons.Where(e => e.Value.Age > 30);
            //Fields query
            IQueryable<string> fieldQuery = persons
                .Where(e => e.Value.Age > 30)
                .Select(e => e.Value.Name);

            //Agregate
            int sum = persons.Sum(e => e.Value.Age);
            //join
            IQueryable<string> joins = persons.Join(orgs.Where(org => org.Value.Name == "Apache"),
                person => person.Value.OrgId,
                org => org.Value.Id,
                (person, org) => person.Value.Name);
            //JOIN WITH QUERY SYNTEX
            var join2 = from person in persons
                        from org in orgs
                        where person.Value.OrgId == org.Value.Id && org.Value.Name == "Apache"
                        select person.Value.Name;
        }



    }
    class Person
    {
        [QuerySqlField]
        public string Name { get; set; }

        [QuerySqlField]
        public int Age { get; set; }

        [QuerySqlField]
        public int OrgId { get; set; }
    }

    class Organization
    {
        [QuerySqlField]
        public string Name { get; set; }

        [QuerySqlField]
        public int Id { get; set; }
    }
}
