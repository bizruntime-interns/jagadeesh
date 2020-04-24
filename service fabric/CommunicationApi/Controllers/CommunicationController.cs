using System;
using System.Collections.Generic;
using System.Fabric.Query;
using System.Linq;
using System.Threading.Tasks;
using communication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace CommunicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommunicationController : ControllerBase
    {
       [HttpGet]
       [Route("sateless")]

       public async Task<string> StatelessGet()
        {
            var statelessProxy = ServiceProxy.Create<IStatelessInterface>(
                 new Uri("fabric:/JumpStartApplication/CustomerAnalytics")
                );
            var serviceName = await statelessProxy.GetServiceDetails();
            return serviceName;
               
        }
        [HttpGet]
        [Route("statefull")]
        public async Task<string> StatefullGet(
                   [FromQuery]int Productid)
        {
            var PartitionId =  Productid % 3;
            
            var statefullProxy = ServiceProxy.Create<Istatefullinterface>(
                new Uri("fabric:/JumpStartApplication/Stateful1"),
                new Microsoft.ServiceFabric.Services.Client.ServicePartitionKey(PartitionId));
            var serviceName = await statefullProxy.GetServiceDetails();
            return serviceName;
        }
        [HttpPost]
        [Route("addproduct")]
        public async Task AddProduct(
                   [FromQuery]Products product)
        {
            var PartitionId = product.ID % 3;

            var statefullProxy = ServiceProxy.Create<Istatefullinterface>(
                new Uri("fabric:/JumpStartApplication/Stateful1"),
                new Microsoft.ServiceFabric.Services.Client.ServicePartitionKey(PartitionId));

            await statefullProxy.AddProduct(product);
        }
        [HttpPost]
        [Route("addtoqueue")]
        public async Task AddToQueue(
                  [FromQuery]int PartitionId,
                  [FromBody]Products product)
        {
           

            var statefullProxy = ServiceProxy.Create<Istatefullinterface>(
                new Uri("fabric:/JumpStartApplication/Stateful1"),
                new Microsoft.ServiceFabric.Services.Client.ServicePartitionKey(PartitionId));

            await statefullProxy.AddToQueue(product);
        }
        [HttpGet]
        [Route("getproduct")]
        public async Task<Products> GetProduct(
                  [FromQuery]int Productid)
        {
            var PartitionId = Productid % 3;

            var statefullProxy = ServiceProxy.Create<Istatefullinterface>(
                new Uri("fabric:/JumpStartApplication/Stateful1"),
                new Microsoft.ServiceFabric.Services.Client.ServicePartitionKey(PartitionId));
            var product = await statefullProxy.GetProductById(PartitionId);
            return product;
        }
        [HttpGet]
        [Route("getfromqueue")]
        public async Task<Products> GetFromQueue(
                 [FromQuery]int PartitionId)
        {
          var statefullProxy = ServiceProxy.Create<Istatefullinterface>(
                new Uri("fabric:/JumpStartApplication/Stateful1"),
                new Microsoft.ServiceFabric.Services.Client.ServicePartitionKey(PartitionId));
            var product = await statefullProxy.GetFromQueue();
            return product;
        }
    }
}
