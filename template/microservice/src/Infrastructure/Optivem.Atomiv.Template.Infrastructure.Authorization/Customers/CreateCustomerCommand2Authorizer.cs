﻿using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Authorization.Customers
{
    public class CreateCustomerCommand2Authorizer : IRequestAuthorizer<CreateCustomerCommand>
    {
        public Task<RequestAuthorizationResult> AuthorizeAsync(CreateCustomerCommand request)
        {
            // TODO: VC: Create BaseRequestAuthorizer for returning these results

            var result = new RequestAuthorizationResult(true, new List<RequestAuthorizationError>());
            // var result = new RequestAuthorizationResult(false, new List<RequestAuthorizationError>());

            return Task.FromResult(result);
        }
    }
}