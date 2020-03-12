using System.Collections.Generic;
using CampusManagement.Data.Models;

namespace CampusManagement.Data.Queries
{
    public class PaymentOptionsQuery : IPaymentOptionsQuery
    {
        public IList<PaymentOptionModel> Execute(int customerId)
        {
            // this query would return different results depending on the configurations of the customerId parameter
            return new List<PaymentOptionModel>
            {
                new PaymentOptionModel
                {
                    Id = 1,
                    Code = "paypal",
                    Name = "PayPal"
                },
                new PaymentOptionModel
                {
                    Id = 2,
                    Code = "creditcard",
                    Name = "Credit Card"
                },
                new PaymentOptionModel
                {
                    Id = 3,
                    Code = "bank",
                    Name = "Bank"
                }
            };
        }
    }
}
