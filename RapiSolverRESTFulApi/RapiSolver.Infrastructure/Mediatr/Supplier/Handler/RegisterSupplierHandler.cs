using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Supplier.Command;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Supplier.Handler
{
    public class RegisterSupplierHandler : IRequestHandler<RegisterSupplier, Boolean>
    {
        private readonly ISupplierRepository supplierRepository;

        public RegisterSupplierHandler(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public Task<bool> Handle(RegisterSupplier request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return supplierRepository.RegisterSupplier(request.Supplier);
            });
        }
    }
}
