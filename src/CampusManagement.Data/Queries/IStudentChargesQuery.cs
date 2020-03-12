using System.Collections.Generic;
using CampusManagement.Data.Models;

namespace CampusManagement.Data.Queries
{
    public interface IStudentChargesQuery
    {
        IList<StudentChargeModel> Execute(int studentId, int customerId);
    }
}
