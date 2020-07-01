using MediatR;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Customer.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Customer.Handler
{

    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomer, Boolean>
    {

        private readonly ICustomerRepository customerRepository;

        public UpdateCustomerHandler(ICustomerRepository
            customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<Boolean> Handle(UpdateCustomer request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return customerRepository.UpdateCustomer(request.Customer);
            });
        }
    }
}
