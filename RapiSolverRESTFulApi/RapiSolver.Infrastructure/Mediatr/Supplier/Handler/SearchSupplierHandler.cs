using MediatR;
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
    public class SearchSupplierHandler : IRequestHandler<SearchSupplier, Core.Entities.Supplier>
    {
        private readonly ISupplierRepository supplierRepository;

        public SearchSupplierHandler(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }


        public Task<Core.Entities.Supplier> Handle(SearchSupplier request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return supplierRepository.SearchSupplier(request.Id);
            });
        }
    }
}
