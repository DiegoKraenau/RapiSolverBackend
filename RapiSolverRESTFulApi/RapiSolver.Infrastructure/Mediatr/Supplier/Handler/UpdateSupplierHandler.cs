using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Supplier.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Supplier.Handler
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplier, Boolean>
    {
        private readonly ISupplierRepository supplierRepository;

        public UpdateSupplierHandler(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public Task<bool> Handle(UpdateSupplier request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return supplierRepository.UpdateSupplier(request.Supplier);
            });
        }
    }
}
