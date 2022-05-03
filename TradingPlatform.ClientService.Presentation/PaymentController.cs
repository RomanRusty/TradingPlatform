using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Services.Abstractions;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
namespace TradingPlatform.ClientService.Presentation
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IActionResult> Checkout(int orderId)
        {
            await _paymentService.CreateAsync(orderId);



            return View();
        }
    }
}