using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace BookShop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommandValidator : AbstractValidator<ChargeUserWalletCommand>
    {
        public ChargeUserWalletCommandValidator()
        {
            RuleFor(r => r.Description)
                .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(1000);
        }
    }
}
