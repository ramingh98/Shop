using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using FluentValidation;

namespace BookShop.Application.Orders.DecreaseItemCount
{
    public class DecreaseOrderItemCountCommandValidator : AbstractValidator<DecreaseOrderItemCountCommand>
    {
        public DecreaseOrderItemCountCommandValidator()
        {
            RuleFor(q => q.Count).GreaterThanOrEqualTo(1)
                .WithMessage("تعداد باید بیشتر از 0 باشد");
        }
    }
}
