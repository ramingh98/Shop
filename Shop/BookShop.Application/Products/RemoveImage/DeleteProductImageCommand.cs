using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookShop.Application.Products.RemoveImage
{
    public record DeleteProductImageCommand(long ProductId, long ImageId) : IBaseCommand;
}
