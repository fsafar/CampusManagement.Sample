using System.Collections.Generic;

namespace CampusManagement.Web.Models.StudentCharges
{
    public class StudentChargesViewModel
    {
        public StudentChargesViewModel()
        {
            StudentChargesList = new List<StudentChargeModel>();
        }
        public IList<StudentChargeModel> StudentChargesList { get; set; }
    }
}
