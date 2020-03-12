using CampusManagement.Payments.Models;

namespace CampusManagement.Payments.Interfaces
{
    public interface IPaymentStrategy
    {
        PaymentResult MakePayment<T>(T model) where T : IPaymentModel;
    }
}
