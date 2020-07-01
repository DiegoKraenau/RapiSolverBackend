using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Customer.Command
{
    public class RegisterCustomer: IRequest<Boolean>
    {
        public RegisterCustomer(RapiSolver.Core.Entities.Customer customer)
        {
            Customer = customer;
        }

        public RapiSolver.Core.Entities.Customer Customer;
    }
}
