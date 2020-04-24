using Apache.Ignite.Core;
using Apache.Ignite.Core.Cluster;
using System;
using System.Collections.Generic;

namespace ApacheIgniteClusters
{
    class Program
    {
        static void Main(string[] args)
        {
            IIgnite ignite = Ignition.Start();

            ICluster cluster = ignite.GetCluster();
            var cfg = new IgniteConfiguration
            {
                UserAttributes = new Dictionary<string, object> { { "ROLE", "worker" } }
            };
            // Local Ignite node.
            IClusterNode localNode = cluster.GetLocalNode();

            // Node metrics.
            IClusterMetrics metrics = localNode.GetMetrics();

            // Get some metric values.
            double cpuLoad = metrics.CurrentCpuLoad;
            long usedHeap = metrics.HeapMemoryUsed;
            int numberOfCores = metrics.TotalCpus;
            int activeJobs = metrics.CurrentActiveJobs;
            Console.WriteLine(cpuLoad);
            Console.WriteLine(numberOfCores);
            Console.ReadKey();
        }
    }
}
