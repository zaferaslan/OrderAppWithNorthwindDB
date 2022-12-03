using FluentValidation;
using OrderAppWithNorthwindDB.Models;

namespace OrderAppWithNorthwindDB.Validators
{
    public class ShipperValidator:AbstractValidator<Shipper>
    {
        public ShipperValidator()
        {
            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
              .NotNull().WithMessage("Company Name is required.");

            RuleFor(p => p.Phone)
       .NotEmpty().WithMessage("Phone Number is required.")
       .NotNull().WithMessage("Phone Number is required.")
       .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.");
        }
    }
}
