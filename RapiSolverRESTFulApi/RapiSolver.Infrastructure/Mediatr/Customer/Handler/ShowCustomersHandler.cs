using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Customer.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Customer.Handler
{

    public class ShowCustomersHandler : IRequestHandler<ShowCustomers, IEnumerable<Core.DTOs.CustomerDTO>>
    {

        private readonly ICustomerRepository customerRepository;

        public ShowCustomersHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<IEnumerable<Core.DTOs.CustomerDTO>> Handle(ShowCustomers request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return customerRepository.ShowCustomers();
            });
        }
    }
}
