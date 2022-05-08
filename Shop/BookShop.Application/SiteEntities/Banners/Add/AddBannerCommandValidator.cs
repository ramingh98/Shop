using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BookShop.Application.SiteEntities.Banners.Add
{
    public class AddBannerCommandValidator : AbstractValidator<AddBannerCommand>
    {
        public AddBannerCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(r => r.Link)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("لینک"));
        }
    }
}
