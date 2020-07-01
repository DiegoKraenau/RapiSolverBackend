using MediatR;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Customer.Query;

using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Customer.Handler
{
    public class SearchCustomerHandler : IRequestHandler<SearchCustomer, CustomerDTO>
    {
        private readonly ICustomerRepository customerRepository;

        public SearchCustomerHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<CustomerDTO> Handle(SearchCustomer request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return customerRepository.SearchCustomer(request.Id);
            });
        }
    }

}
