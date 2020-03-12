using System.Linq;
using CampusManagement.Data.Queries;
using CampusManagement.Web.Models.StudentCharges;
using Microsoft.AspNetCore.Mvc;

namespace CampusManagement.Web.Controllers
{
    public class StudentChargesController : Controller
    {
        private readonly IStudentChargesQuery studentChargesQuery;

        private static int studentId = 2;
        private static int customerId = 4;
        public StudentChargesController(IStudentChargesQuery studentChargesQuery)
        {
            this.studentChargesQuery = studentChargesQuery;
        }

        public IActionResult Index()
        {
            var studentCharges = studentChargesQuery.Execute(studentId, customerId);

            var viewModel = new StudentChargesViewModel
            {
                StudentChargesList = studentCharges.Select(sc => new StudentChargeModel
                {
                    ChargeId = sc.Id,
                    ChargeAmount = sc.ChargeAmount,
                    ChargeName = sc.ChargeName
                }).ToList()
            };

            return View(viewModel);
        }
    }
}