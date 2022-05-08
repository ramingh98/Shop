using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BookShop.Application.Orders.AddItem
{
    public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemCommandValidator()
        {
            RuleFor(q => q.Count).GreaterThanOrEqualTo(1)
                .WithMessage("تعداد باید بیشتر از 0 باشد");
        }
    }
}
