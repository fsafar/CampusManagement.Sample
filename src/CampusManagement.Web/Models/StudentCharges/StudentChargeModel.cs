using System.ComponentModel.DataAnnotations;

namespace CampusManagement.Web.Models.StudentCharges
{
    public class StudentChargeModel
    {
        public int ChargeId { get; set; }
        public string ChargeName { get; set; }

        [DisplayFormat(DataFormatString = "C")]
        public decimal ChargeAmount { get; set; }
    }
}
