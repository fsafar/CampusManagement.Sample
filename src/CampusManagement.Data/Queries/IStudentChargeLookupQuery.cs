using CampusManagement.Data.Models;

namespace CampusManagement.Data.Queries
{
    public interface IStudentChargeLookupQuery
    {
        StudentChargeModel Execute(int chargeId);
    }
}
