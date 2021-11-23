using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Services.Abstractions;

namespace TradingPlatform.ClientService.Presentation
{
    public class ControllerBase:Controller
    {
        private IServiceManager _serviceManager;
        public IServiceManager ServiceManager => _serviceManager ??= HttpContext.RequestServices.GetRequiredService<IServiceManager>();
    }
}
