using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CampusManagement.Web.Models.PaymentOptions
{
    public class PaymentBaseModel
    {
        public int ChargeId { get; set; }

        [DisplayName("Charge Amount")]
        [DataType(DataType.Currency)]
        public decimal ChargeAmount { get; set; }
    }
}
