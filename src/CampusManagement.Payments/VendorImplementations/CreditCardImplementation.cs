using CampusManagement.Payments.Models;

namespace CampusManagement.Payments.VendorImplementations
{
    public class CreditCardImplementation : PaymentService<CreditCardModel>
    {
        protected override PaymentResult MakePayment(CreditCardModel model)
        {
            // call third party API to process CC info.

            return new PaymentResult { Status = true };
        }
    }
}
