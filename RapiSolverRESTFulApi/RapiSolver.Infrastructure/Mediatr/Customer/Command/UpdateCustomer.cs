using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Customer.Command
{
    public class UpdateCustomer : IRequest<Boolean>
    {
        public UpdateCustomer(RapiSolver.Core.Entities.Customer customer)
        {
            Customer = customer;
        }

        public RapiSolver.Core.Entities.Customer Customer;
    }
}
