using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TradingPlatform.ClientService.Services.Abstractions;
using Stripe;
using TradingPlatform.ClientService.Domain.HttpInterfaces;

namespace TradingPlatform.ClientService.Services
{
    public class PaymentService : ServiceBase, IPaymentService
    {
        private readonly IConfiguration _configuration;

        public PaymentService(IHttpClientManager client, IHttpContextAccessor contextAccessor, IMapper mapper, IConfiguration configuration) : base(client, contextAccessor, mapper)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration.GetSection("Stripe")["SecretKey"];
        }
        public async Task<string> CreateAsync(int orderId)
        {
            var paymentIntentService = new PaymentIntentService();
            var order = await _client.OrderHttpClient.GetByIdAsync(orderId);
            var amount = (long)order.ProductOrders.Select(item => item.Product).Select(item => item.Price).Sum();
            var paymentIntent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
            {
                Amount = amount,
                Currency = "uan",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            });
            return paymentIntent.ClientSecret;
        }







    }
}