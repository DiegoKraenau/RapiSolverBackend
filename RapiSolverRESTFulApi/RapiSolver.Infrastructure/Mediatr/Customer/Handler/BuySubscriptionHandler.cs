using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Customer.Command;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Customer.Handler
{

    public class BuySubscriptionHandler : IRequestHandler<BuySubscription, bool>
    {
        private readonly ICustomerRepository customerRepository;

        public BuySubscriptionHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public Task<bool> Handle(BuySubscription request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return customerRepository.BuySubscription(request.Id);
            });
        }
    }
}
