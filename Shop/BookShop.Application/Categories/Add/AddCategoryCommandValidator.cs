using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace BookShop.Application.Categories.Add
{
    internal partial class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(q => q.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(r => r.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
