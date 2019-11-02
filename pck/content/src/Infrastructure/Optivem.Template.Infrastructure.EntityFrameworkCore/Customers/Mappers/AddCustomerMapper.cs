﻿using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Mappers
{
    public class AddCustomerMapper : IAddAggregateRootMapper<Customer, CustomerRecord>
    {
        public CustomerRecord Map(Customer customer)
        {
            var id = customer.Id.Id;
            var firstName = customer.FirstName;
            var lastName = customer.LastName;

            return new CustomerRecord
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
            };
        }
    }
}