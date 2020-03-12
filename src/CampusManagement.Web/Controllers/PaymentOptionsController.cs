using System.Collections.Generic;
using System.Linq;
using CampusManagement.Data.Queries;
using CampusManagement.Payments.Interfaces;
using CampusManagement.Payments.Models;
using CampusManagement.Web.Models.PaymentOptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CampusManagement.Web.Controllers
{
    public class PaymentOptionsController : Controller
    {
        private readonly IPaymentStrategy paymentStrategy;
        private readonly IPaymentOptionsQuery paymentOptionsQuery;

        private readonly IStudentChargeLookupQuery studentChargeLookupQuery;

        // this customerId would probably be coming from a configurable setting in a real application.
        private static int customerId = 4;

        public PaymentOptionsController(IPaymentStrategy paymentStrategy, IPaymentOptionsQuery paymentOptionsQuery,
            IStudentChargeLookupQuery studentChargeLookupQuery)
        {
            this.paymentStrategy = paymentStrategy;
            this.paymentOptionsQuery = paymentOptionsQuery;
            this.studentChargeLookupQuery = studentChargeLookupQuery;
        }

        public IActionResult Index(int chargeId)
        {
            var studentCharge = studentChargeLookupQuery.Execute(chargeId);

            var viewModel = new PayOptionsViewModel
            {
                PaymentOptions = GetPaymentOptionDropdownItems(),
                ChargeId = chargeId,
                ChargeAmount = studentCharge.ChargeAmount
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreditCard(int chargeId)
        {
            var studentCharge = studentChargeLookupQuery.Execute(chargeId);

            var viewModel = new CreditCardViewModel
            {
                ChargeAmount = studentCharge.ChargeAmount
            };

            return View("CreditCard", viewModel);
        }

        [HttpGet]
        public IActionResult PayPal(int chargeId)
        {
            var studentCharge = studentChargeLookupQuery.Execute(chargeId);

            var viewModel = new PaypalViewModel
            {
                ChargeAmount = studentCharge.ChargeAmount
            };

            return View("PayPal", viewModel);
        }

        [HttpGet]
        public IActionResult Bank(int chargeId)
        {
            var studentCharge = studentChargeLookupQuery.Execute(chargeId);
            
            var viewModel = new BankViewModel
            {
                ChargeAmount = studentCharge.ChargeAmount
            };

            return View("Bank", viewModel);
        }

        public IActionResult PaymentThankYou()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreditCard(CreditCardViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreditCard", viewModel);
            }

            var studentCharge = studentChargeLookupQuery.Execute(viewModel.ChargeId);

            var creditCardModel = new CreditCardModel
            {
                Name = viewModel.Name,
                CardNumber = viewModel.CardNumber,
                ExpirationMonth = viewModel.ExpirationMonth,
                ExpirationYear = viewModel.ExpirationYear,
                SecurityCode = viewModel.SecurityCode,
                ChargeAmount = studentCharge.ChargeAmount,
                BillingAddress = new AddressModel
                {
                    StreetAddress = viewModel.StreetAddress,
                    City = viewModel.City,
                    State = viewModel.State,
                    ZipCode = viewModel.ZipCode
                }
            };

            var paymentResult = paymentStrategy.MakePayment(creditCardModel);

            if (paymentResult.Status == false)
            {
                this.ModelState.AddModelError("paymentError", paymentResult.Message);
                return View("CreditCard", viewModel);
            }

            return RedirectToAction("PaymentThankYou");
        }

        [HttpPost]
        public IActionResult PayPal(PaypalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("PayPal", viewModel);
            }
            var studentCharge = studentChargeLookupQuery.Execute(viewModel.ChargeId);

            var payPalModel = new PayPalModel
            {
                Username = viewModel.Username,
                Password = viewModel.Password,
                ChargeAmount = studentCharge.ChargeAmount
            };

            var paymentResult = paymentStrategy.MakePayment(payPalModel);

            if (paymentResult.Status == false)
            {
                this.ModelState.AddModelError("paymentError", paymentResult.Message);

                return View("PayPal", viewModel);
            }

            return RedirectToAction("PaymentThankYou");
        }

        [HttpPost]
        public IActionResult Bank(BankViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Bank", viewModel);
            }
            var studentCharge = studentChargeLookupQuery.Execute(viewModel.ChargeId);

            var bankModel = new BankModel
            {
                Name = viewModel.Name,
                AccountNumber = viewModel.AccountNumber,
                RoutingNumber = viewModel.RoutingNumber,
                ChargeAmount = studentCharge.ChargeAmount
            };

            var paymentResult = paymentStrategy.MakePayment(bankModel);

            if (paymentResult.Status == false)
            {
                this.ModelState.AddModelError("paymentError", paymentResult.Message);
                return View("Bank", viewModel);
            }

            return RedirectToAction("PaymentThankYou");
        }

        private IList<SelectListItem> GetPaymentOptionDropdownItems()
        {
            var paymentOptions = paymentOptionsQuery
                .Execute(customerId)
                .Select(o => new SelectListItem
                {
                    Text = o.Name,
                    Value = o.Code
                }).ToList();

            paymentOptions.Insert(0, new SelectListItem
            {
                Text = "Select an option",
                Value = string.Empty
            });

            return paymentOptions;
        }
    }
}