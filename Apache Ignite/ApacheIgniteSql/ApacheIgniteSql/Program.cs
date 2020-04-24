using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Query;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ApacheIgniteSql
{
    public class Sql
    {
        static void Main()
        {
           
            IIgnite ignite = Ignition.Start();

            ICache<int, Person> cache = ignite.GetOrCreateCache<int, Person>(
                new CacheConfiguration("persons", typeof(Person)));
            cache[1] = new Person { Name = "John Doe", Age = 27 };
            cache[2] = new Person { Name = "Jane Moe", Age = 43 };

            var sqlQuery = new SqlQuery(typeof(Person),"where Age > ?",30);
            IQueryCursor<ICacheEntry<int, Person>> queryCursor = cache.Query(sqlQuery);

            foreach (ICacheEntry<int, Person> cacheEntry in queryCursor)
                Console.WriteLine(cacheEntry);
            var fieldsQuery = new SqlFieldsQuery("select name from Person where Age > ? ", 30);
            IQueryCursor<IList> quertCursor = cache.QueryFields(fieldsQuery);
            foreach(IList fieldsList in quertCursor)
            {
                Console.WriteLine(fieldsList[0]);
            }
            var fieldsquery = new SqlFieldsQuery("select sum(Age) from Person");
            IQueryCursor<IList> queryCursor1 = cache.QueryFields(fieldsquery);
            Console.WriteLine(queryCursor1.GetAll()[0][0]);
        }

        class Person
        {
            [QuerySqlField]
            public string Name { get; set; }
            [QuerySqlField]
            public int Age { get; set; }

            public override string ToString()
            {
                return $"Person [Name={Name}, Age={Age}]";
            }
        }

        class PersonFilter : ICacheEntryFilter<int, Person>
        {
            public bool Invoke(ICacheEntry<int, Person> entry)
            {
                return entry.Value.Age > 30;
            }
        }

    }
}