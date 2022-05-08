using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BookShop.Application.SiteEntities.Sliders.Add
{
    public class AddSliderCommandValidator : AbstractValidator<AddSliderCommand>
    {
        public AddSliderCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(r => r.Link)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("لینک"));

            RuleFor(r => r.Title)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}
