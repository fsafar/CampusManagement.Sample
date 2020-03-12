using System.Collections.Generic;
using System.Linq;
using CampusManagement.Payments.Interfaces;
using CampusManagement.Payments.Models;

namespace CampusManagement.Payments
{
    public class PaymentStrategy : IPaymentStrategy
    {
        private readonly IEnumerable<IPaymentService> paymentServices;

        public PaymentStrategy(IEnumerable<IPaymentService> paymentServices)
        {
            this.paymentServices = paymentServices;
        }

        public PaymentResult MakePayment<T>(T model) where T : IPaymentModel
        {
            try
            {
                var paymentService = paymentServices.First(p => p.AppliesTo(model.GetType()));

                var paymentResult = paymentService.MakePayment(model);

                return paymentResult;
            }
            catch
            {
                // errors should be logged here.

                return new PaymentResult
                {
                    Message = "Something went wrong.  Try Again later.",
                    Status = false
                };
            }
        }
    }
}
