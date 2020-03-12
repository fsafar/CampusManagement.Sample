using CampusManagement.Payments.Models;

namespace CampusManagement.Payments.VendorImplementations
{
    public class PayPalImplementation : PaymentService<PayPalModel>
    {
        protected override PaymentResult MakePayment(PayPalModel model)
        {
            // call API to process paypal payment

            return new PaymentResult{ Status = true };
        }
    }
}
