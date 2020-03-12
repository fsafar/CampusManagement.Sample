using System;
using CampusManagement.Payments.Models;

namespace CampusManagement.Payments.Interfaces
{
    public interface IPaymentService
    {
        PaymentResult MakePayment<T>(T model) where T : IPaymentModel;
        bool AppliesTo(Type provider);
    }
}
