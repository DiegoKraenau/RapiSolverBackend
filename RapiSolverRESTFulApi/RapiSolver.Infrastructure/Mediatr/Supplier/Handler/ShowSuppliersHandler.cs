using MediatR;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Supplier.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Supplier.Handler
{
    public class ShowSuppliersHandler : IRequestHandler<ShowSuppliers, IEnumerable<SupplierDTO>>
    {
        private readonly ISupplierRepository supplierRepository;

        public ShowSuppliersHandler(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public Task<IEnumerable<SupplierDTO>> Handle(ShowSuppliers request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return supplierRepository.ShowSuppliers();
            });
        }
    }
}
