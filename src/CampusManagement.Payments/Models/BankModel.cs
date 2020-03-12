using CampusManagement.Payments.Interfaces;

namespace CampusManagement.Payments.Models
{
    public class BankModel : IPaymentModel
    {
        public string Name { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal ChargeAmount { get; set; }
    }
}
