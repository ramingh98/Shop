﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Query
{
    public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class
    {

    }
}