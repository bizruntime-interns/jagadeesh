using Contracts;
using FabricActorService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController: Controller
    {
        [HttpGet]
        public async Task<Products> GetProductById(
            [FromQuery]int ID)
        {
            var actorId = new ActorId(ID);
            var proxy= ActorProxy.Create<IFabricActorService>(actorId, new Uri("fabric:/ServiceFabricActor/FabricActorServiceActorService"));
            var product=await proxy.GetProductAsync(new CancellationToken());
            return product;
        }

        [HttpPost]
        public async Task  AddProduct(
            [FromQuery]Products product)
        {
            var actorId = new ActorId(product.ID);
            var proxy = ActorProxy.Create<IFabricActorService>(actorId, new Uri("fabric:/ServiceFabricActor/FabricActorServiceActorService"));
            await proxy.AddProductAsync(product,new CancellationToken());
           
        }
        [HttpDelete]
        public async Task DeleteActorByID(
            [FromQuery]int id)
        {
            var actorid = new ActorId(id);
            var actorServiceProxy = ActorServiceProxy.Create(new Uri("fabric:/ServiceFabricActor/FabricActorServiceActorService"),actorid);
            await actorServiceProxy.DeleteActorAsync(actorid, new CancellationToken());
        }
    }
}
