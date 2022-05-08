using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BookShop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommandValidator : AbstractValidator<EditSliderCommand>
    {
        public EditSliderCommandValidator()
        {
            RuleFor(r => r.ImageFile)
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
