using System;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Query;
using ApacheIgnite;

class Program
{
    static void Main(string[] args)
    {
        //IIgnite ignite = Ignition.Start();
        //ICache<int, String> cache = ignite.GetOrCreateCache<int, string>("Test");
        //cache.Put(1, "HelloWorld");
        //Console.WriteLine(cache.Get(1));
        //IIgnite ignite = Ignition.Start();
        //ICache<int, String> cache = ignite.GetOrCreateCache<int, String>("test");
        //if(cache.PutIfAbsent(1,"Hello World"))
        //{
        //    Console.WriteLine("Data added to cache");
        //}
        //else
        //{
        //    Console.WriteLine(cache.Get(1));
        //}
        var cfg = new IgniteConfiguration
        {
            BinaryConfiguration = new BinaryConfiguration(typeof(person),typeof(PersonFilter))
        };
        IIgnite ignite = Ignition.Start(cfg);
        ICache<int, person> cache = ignite.GetOrCreateCache<int, person>("persons");
        cache[1] = new person { Name = "Jonny", Age = 22 };
        cache[2] = new person { Name = "Rmi", Age = 33 };
        var scanQuery = new ScanQuery<int, person>(new PersonFilter());
        IQueryCursor<ICacheEntry<int, person>> queryCursor = cache.Query(scanQuery);
        foreach (ICacheEntry<int, person> cacheEntries in queryCursor)
            Console.WriteLine(cacheEntries);
        
        //var binCache = cache.WithKeepBinary<int, IBinaryObject>();
        //IBinaryObject binaryObject = binCache[1];
        //Console.WriteLine(binaryObject.GetField<String>("Name"));

      
    }
  
     

    }

