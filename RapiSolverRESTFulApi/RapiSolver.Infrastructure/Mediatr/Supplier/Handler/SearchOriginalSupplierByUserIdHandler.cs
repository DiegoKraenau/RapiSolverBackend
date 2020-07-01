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
    public class SearchOriginalSupplierByUserIdHandler : IRequestHandler<SearchOriginalSupplierByUserId, Core.Entities.Supplier>
    {
        private readonly ISupplierRepository supplierRepository;

        public SearchOriginalSupplierByUserIdHandler(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public Task<Core.Entities.Supplier> Handle(SearchOriginalSupplierByUserId request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return supplierRepository.SearchOriginalSupplierByUserId(request.Id);
            });
        }
    }
}
