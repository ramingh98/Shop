using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BookShop.Application.Sellers.Add
{
    public class AddSellerCommandValidator : AbstractValidator<AddSellerCommand>
    {
        public AddSellerCommandValidator()
        {
            RuleFor(r => r.ShopName)
                .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

            RuleFor(r => r.NationalCode)
                .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
                .ValidNationalId();
        }
    }
}
