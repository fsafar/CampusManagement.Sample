using System.ComponentModel.DataAnnotations;

namespace CampusManagement.Web.Models.PaymentOptions
{
    public class PaypalViewModel : PaymentBaseModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
