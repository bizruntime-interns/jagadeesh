using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace communication
{
    public interface IStatelessInterface:IService
    {
        Task<string> GetServiceDetails();
    }
}
