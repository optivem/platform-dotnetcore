﻿using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handlers
{
    public class FindProductHandler : FindAggregateRootHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public FindProductHandler(DatabaseContext context, IGetAggregateRootMapper<Product, ProductRecord> getAggregateRootMapper) : base(context, getAggregateRootMapper)
        {
        }
    }
}