﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Application
{
    public abstract class Response : IResponse
    {
    }

    public abstract class Response<TId> : IResponse<TId>
    {
        public TId Id { get; set; }
    }
}