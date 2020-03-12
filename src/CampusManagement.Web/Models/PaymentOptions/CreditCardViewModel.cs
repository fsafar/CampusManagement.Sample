using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CampusManagement.Web.Models.PaymentOptions
{
    public class CreditCardViewModel : PaymentBaseModel
    {
        [Required]
        [DisplayName("Card Holder's Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [DisplayName("Expiration Month")]
        [Range(1, 12, ErrorMessage = "Please enter valid month")]
        public int ExpirationMonth { get; set; }

        [Required]
        [DisplayName("Expiration Year")]
        [Range(2019, int.MaxValue, ErrorMessage = "Please enter valid year")]
        public int ExpirationYear { get; set; }

        [Required]
        [DisplayName("Security Code")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Please enter a valid security code")]
        public int SecurityCode { get; set; }

        [Required]
        [DisplayName("Street Address")]
        
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
    }
}
