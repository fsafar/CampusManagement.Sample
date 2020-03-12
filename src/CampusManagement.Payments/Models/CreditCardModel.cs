using CampusManagement.Payments.Interfaces;

namespace CampusManagement.Payments.Models
{
    public class CreditCardModel : IPaymentModel
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int SecurityCode { get; set; }
        public AddressModel BillingAddress { get; set; }
        public decimal ChargeAmount { get; set; }
    }
}
