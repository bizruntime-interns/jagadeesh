using Apache.Ignite.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApacheIgnite
{
    public class PersonFilter : ICacheEntryFilter<int, person>
    {
        public bool Invoke(ICacheEntry<int, person> entry)
        {
            return entry.Value.Age > 30;
        }

    }
}
