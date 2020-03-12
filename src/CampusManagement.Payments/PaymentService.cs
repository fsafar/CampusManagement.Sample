using System;
using CampusManagement.Payments.Interfaces;
using CampusManagement.Payments.Models;

namespace CampusManagement.Payments
{
    public abstract class PaymentService<TModel> : IPaymentService where TModel : IPaymentModel
    {
        public virtual bool AppliesTo(Type provider)
        {
            return typeof(TModel) == provider;
        }

        public PaymentResult MakePayment<T>(T model) where T : IPaymentModel
        {
            return MakePayment((TModel)(object)model);
        }

        protected abstract PaymentResult MakePayment(TModel model);
    }
}
