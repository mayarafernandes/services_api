using Company.Services.Infrasctructure.Gateway;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Company.Services.API.Utils
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ApiController<T> : ControllerBase
    {
        private IGatewayService _gatewayService;

        protected IGatewayService GatewayService => _gatewayService ??= HttpContext.RequestServices.GetService<IGatewayService>();

    }
}
