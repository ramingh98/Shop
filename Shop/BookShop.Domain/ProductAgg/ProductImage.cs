using System;
using System.Collections.Generic;
using Common.Domain;
using Common.Domain.Exceptions;

namespace BookShop.Domain.ProductAgg
{
    public class ProductImage : AggregateRoot
    {
        public ProductImage(string imageName, int sequence)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;
            Sequence = sequence;
        }
        public long ProductId { get; internal set; }
        public string ImageName { get; private set; }
        public int Sequence { get; private set; }
    }
}
