using System.Collections.Generic;
using CampusManagement.Data.Models;

namespace CampusManagement.Data.Queries
{
    public class StudentChargesQuery : IStudentChargesQuery
    {
        public IList<StudentChargeModel> Execute(int studentId, int customerId)
        {
            return new List<StudentChargeModel>
            {
                new StudentChargeModel
                {
                    Id = 1,
                    CustomerId = 4,
                    StudentId = 2,
                    ChargeName = "Summer Semester 2018",
                    ChargeAmount = 3000
                },
                new StudentChargeModel
                {
                    Id = 2,
                    CustomerId = 4,
                    StudentId = 2,
                    ChargeName = "Fall Semester 2018",
                    ChargeAmount = 6525
                },
                new StudentChargeModel
                {
                    Id = 3,
                    CustomerId = 4,
                    StudentId = 2,
                    ChargeName = "Spring Semester 2019",
                    ChargeAmount = 3245
                }
            };
        }
    }
}
