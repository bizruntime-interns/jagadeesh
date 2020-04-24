using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace communication
{
   public  interface Istatefullinterface:IService
    {
        Task<string> GetServiceDetails();

        Task<Products> GetProductById(int ID);
        Task AddProduct(Products product);
        Task<Products> GetFromQueue();
        Task AddToQueue(Products product);
    }
}
