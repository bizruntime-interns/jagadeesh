using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors.Client;
using FabricActorService.Interfaces;
using Contracts;

namespace FabricActorService
{
    
    [StatePersistence(StatePersistence.Persisted)]
    internal class FabricActorService : Actor, IFabricActorService
    {
        private string ProductStateName = "ProductState";

        private IActorTimer _actortimer;
        public FabricActorService(ActorService actorService, ActorId actorId) 
            : base(actorService, actorId)
        {
        }

        public async Task AddProductAsync(Products product, CancellationToken cancellationToken)
        {
           await  this.StateManager.AddOrUpdateStateAsync(ProductStateName, product,(k,v)=>product,cancellationToken   );
            await this.StateManager.SaveStateAsync(cancellationToken);
        }

        public async Task<Products> GetProductAsync(CancellationToken cancellationToken)
        {
            
            var product = await this.StateManager.GetStateAsync<Products>(ProductStateName, cancellationToken);

            return product;
        }

        protected override Task OnPostActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            ActorEventSource.Current.ActorMessage(this, $"{actorMethodContext.MethodName} has finished..");
            return base.OnPostActorMethodAsync(actorMethodContext);
        }
        protected override Task OnPreActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            ActorEventSource.Current.ActorMessage(this, $"{actorMethodContext.MethodName} will start soonn..");
            return base.OnPostActorMethodAsync(actorMethodContext);
        }
        protected override Task OnActivateAsync()
        {
            _actortimer = RegisterTimer(DoWork, null, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(15)
                );
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");
            return this.StateManager.TryAddStateAsync("count", 0);
        }
        protected override Task OnDeactivateAsync()
        {
            if (_actortimer != null)
            {
                UnregisterTimer(_actortimer);
            }
            ActorEventSource.Current.ActorMessage(this, "Actor Deactivated.");
            return base.OnDeactivateAsync();
        }
        private Task DoWork(object work)
        {
             ActorEventSource.Current.ActorMessage(this, $"Actor will do work.");
            return Task.CompletedTask;

        }



    }
}
