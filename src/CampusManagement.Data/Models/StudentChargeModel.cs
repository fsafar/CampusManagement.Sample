namespace CampusManagement.Data.Models
{
    public class StudentChargeModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StudentId { get; set; }
        public string ChargeName { get; set; }
        public decimal ChargeAmount { get; set; }
    }
}
