using CampusManagement.Data.Models;

namespace CampusManagement.Data.Queries
{
    public class StudentChargeLookupQuery : IStudentChargeLookupQuery
    {
        public StudentChargeModel Execute(int chargeId)
        {
            return new StudentChargeModel
            {
                Id = 2,
                CustomerId = 4,
                StudentId = 2,
                ChargeName = "Fall Semester 2018",
                ChargeAmount = 6525
            };
        }
    }
}
