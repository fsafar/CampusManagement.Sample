using CampusManagement.Payments.Interfaces;

namespace CampusManagement.Payments.Models
{
    public class PayPalModel : IPaymentModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal ChargeAmount { get; set; }
    }
}
