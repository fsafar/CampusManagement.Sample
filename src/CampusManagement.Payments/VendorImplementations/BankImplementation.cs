using CampusManagement.Payments.Models;

namespace CampusManagement.Payments.VendorImplementations
{
    public class BankImplementation : PaymentService<BankModel>
    {
        protected override PaymentResult MakePayment(BankModel model)
        {
            // send payment information to the bank

            return new PaymentResult { Status = true };
        }
    }
}
