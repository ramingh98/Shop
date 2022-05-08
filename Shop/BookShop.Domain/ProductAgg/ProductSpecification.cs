﻿using System;
using Common.Domain;
using Common.Domain.Exceptions;

namespace BookShop.Domain.ProductAgg
{
    public class ProductSpecification : AggregateRoot
    {
        public long ProductId { get; internal set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public ProductSpecification(string key, string value)
        {
            NullOrEmptyDomainDataException.CheckString(key, nameof(key));
            NullOrEmptyDomainDataException.CheckString(value, nameof(value));
            Key = key;
            Value = value;
        }
    }
}