using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting;

[assembly: FabricTransportActorRemotingProvider(RemotingListenerVersion = RemotingListenerVersion.V2_1, RemotingClientVersion = RemotingClientVersion.V2_1)]
namespace FabricActorService.Interfaces
{
    public interface IFabricActorService : IActor
    {
        Task<Products> GetProductAsync(CancellationToken cancellationToken);


        Task AddProductAsync(Products product, CancellationToken cancellationToken);
    }
}
