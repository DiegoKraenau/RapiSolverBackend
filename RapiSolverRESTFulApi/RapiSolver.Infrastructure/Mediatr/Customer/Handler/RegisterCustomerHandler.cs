using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Customer.Command;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Customer.Handler
{
    public class RegisterCustomerHandler :IRequestHandler<RegisterCustomer, bool>
    {
        private readonly ICustomerRepository customerRepository;

        public RegisterCustomerHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<bool> Handle(RegisterCustomer request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return customerRepository.RegisterCustomer(request.Customer);
            });
        }
    }
}
