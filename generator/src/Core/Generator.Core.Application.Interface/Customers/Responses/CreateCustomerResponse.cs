﻿using Atomiv.Core.Application;

namespace Generator.Core.Application.Customers.Responses
{
    public class CreateCustomerResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}