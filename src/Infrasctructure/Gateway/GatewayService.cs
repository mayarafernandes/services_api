using System;

namespace Company.Services.Infrasctructure.Gateway
{
    public class GatewayService : IGatewayService
    {
        private readonly IServiceProvider _serviceProvider;

        public GatewayService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T To<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}
