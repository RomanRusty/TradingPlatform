﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TradingPlatform.Services.Abstractions;

namespace TradingPlatform.Presentation
{
    [ApiController]
    public class DefaultApiController : ControllerBase
    {
        private IServiceManager _serviceManager;
        public IServiceManager ServiceManager => _serviceManager ??= HttpContext.RequestServices.GetRequiredService<IServiceManager>();
    }
}