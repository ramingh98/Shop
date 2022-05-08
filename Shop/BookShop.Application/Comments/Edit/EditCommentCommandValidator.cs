using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace BookShop.Application.Comments.Edit
{
    public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
    {
        public EditCommentCommandValidator()
        {
            {
                RuleFor(r => r.Text)
                    .NotNull()
                    .MinimumLength(4).WithMessage(ValidationMessages.minLength("متن", 4));
            }
        }
    }
}
