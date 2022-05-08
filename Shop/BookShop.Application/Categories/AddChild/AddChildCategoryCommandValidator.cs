using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace BookShop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandValidator : AbstractValidator<AddChildCategoryCommand>
    {
        public AddChildCategoryCommandValidator()
        {
            RuleFor(q => q.Title).NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(q => q.Title).NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
