﻿using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using static ProvaPub.Services.OrderService;

namespace ProvaPub.Controllers
{
	
	/// <summary>
	/// Esse teste simula um pagamento de uma compra.
	/// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
	/// Sabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
	/// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class Parte3Controller :  ControllerBase
	{
		// . payment by pix
		[HttpGet("OrdersByPix")]
		public async Task<Order> PlaceOrderByPix(decimal paymentValue, int customerId)
		{
            OrderService.PixPaymentType orderServiceByPix = new OrderService.PixPaymentType();
            return await orderServiceByPix.PixPayment(paymentValue, customerId);            
        }

        // . payment by credit card
        [HttpGet("OrdersByCreditcard")]
        public async Task<Order> PlaceOrderByCreditCard(decimal paymentValue, int customerId)
        {
            OrderService.CreditCardPaymentType orderServiceByCreditCard = new OrderService.CreditCardPaymentType();
            return await orderServiceByCreditCard.CreditCardPayment(paymentValue, customerId);
        }

        //[HttpGet("orders")]
        //public async Task<Order> PlaceOrder(string paymentMethod, decimal paymentValue, int customerId)
        //{
        //    return await new OrderService().PayOrder(paymentMethod, paymentValue, customerId);            
        //}
    }
}
