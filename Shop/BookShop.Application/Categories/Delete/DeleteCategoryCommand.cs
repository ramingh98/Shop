using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookShop.Application.Categories.Delete
{
    public record DeleteCategoryCommand(long CategoryId) : IBaseCommand;
}