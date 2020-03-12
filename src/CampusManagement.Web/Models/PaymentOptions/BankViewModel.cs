using System.ComponentModel;

namespace CampusManagement.Web.Models.PaymentOptions
{
    public class BankViewModel : PaymentBaseModel
    {
        public string Name { get; set; }

        [DisplayName("Routing Number")]
        public string RoutingNumber { get; set; }

        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }
    }
}
