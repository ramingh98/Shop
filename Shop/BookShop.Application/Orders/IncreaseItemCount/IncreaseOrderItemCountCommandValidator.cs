using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BookShop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderItemCountCommandValidator : AbstractValidator<IncreaseOrderItemCountCommand>
    {
        public IncreaseOrderItemCountCommandValidator()
        {
            RuleFor(q => q.Count).GreaterThanOrEqualTo(1)
                .WithMessage("تعداد باید بیشتر از 0 باشد");
        }
    }
}
