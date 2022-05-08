using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BookShop.Application.Sellers.Edit
{
    public class EditSellerCommandValidator : AbstractValidator<EditSellerCommand>
    {
        public EditSellerCommandValidator()
        {
            RuleFor(r => r.ShopName)
                .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

            RuleFor(r => r.NationalCode)
                .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
                .ValidNationalId();
        }
    }
}
