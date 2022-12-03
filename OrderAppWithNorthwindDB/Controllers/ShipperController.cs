using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using OrderAppWithNorthwindDB.Models;
using OrderAppWithNorthwindDB.Validators;
using System.Text.RegularExpressions;

namespace OrderAppWithNorthwindDB.Controllers
{
    public class ShipperController : Controller
    {
        private readonly NORTHWNDContext _context;
        public ShipperController(NORTHWNDContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Shipper shipper)
        {
            ShipperValidator validator = new ShipperValidator();
            ValidationResult validationResult = validator.Validate(shipper);
            if (validationResult.IsValid ==false)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
            shipper.Phone = Regex.Replace(shipper.Phone, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");

            _context.Shippers.Add(shipper);
            _context.SaveChanges();
            ViewBag.message = "Success!";
            return View();
        }
    }
}
