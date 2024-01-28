using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ProvaPub.Models;
using System.ComponentModel.DataAnnotations.Schema;
using static ProvaPub.Services.OrderService;

namespace ProvaPub.Services
{
	public class OrderService
    {
        public abstract class PaymentTypeBase 
        {
            public PayingOrder PayingOrder { get; set; }            
        }

        public class PixPaymentType : PaymentTypeBase
        {
            public Task<Order> PixPayment(decimal paymentValue, int customerId) 
            {
                // . Faz Pagamento

                return PayingOrder.PayOrder(paymentValue, customerId);
            }

        }

        public class CreditCardPaymentType : PaymentTypeBase
        {
            public Task<Order> CreditCardPayment(decimal paymentValue, int customerId)
            {
                // . Faz Pagamento

                return PayingOrder.PayOrder(paymentValue, customerId);
            }
        }

        public abstract class PayingOrder
        {
            public async Task<Order> PayOrder(decimal paymentValue, int customerId)
            {
                //if (paymentMethod == "pix")
                //{
                //    //Faz pagamento...
                //}
                //else if (paymentMethod == "creditcard")
                //{
                //    //Faz pagamento...
                //}
                //else if (paymentMethod == "paypal")
                //{
                //    //Faz pagamento...
                //}

                return await Task.FromResult(new Order()
                {
                    CustomerId = customerId,
                    Value = paymentValue
                });
            }
        }
    }
}
