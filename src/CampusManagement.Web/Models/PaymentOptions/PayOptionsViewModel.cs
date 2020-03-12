using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CampusManagement.Web.Models.PaymentOptions
{
    public class PayOptionsViewModel
    {
        public int ChargeId { get; set; }
        [DisplayName("Charge Amount")]
        [DataType(DataType.Currency)]
        public decimal ChargeAmount { get; set; }
        public string SelectedPaymentOption { get; set; }
        public IEnumerable<SelectListItem> PaymentOptions { get; set; }
    }
}
