using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg;
using BookShop.Domain.CommentAgg.Repositories;
using Common.Application;
using Common.Application.Validation;
using FluentValidation;

namespace BookShop.Application.Comments.Add
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(r => r.Text)
                .NotNull()
                .MinimumLength(4).WithMessage(ValidationMessages.minLength("متن", 4));
        }
    }
}
