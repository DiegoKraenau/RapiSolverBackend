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
    public class SearchSupplierByUserIdHandler : IRequestHandler<SearchSupplierByUserId, IEnumerable<SupplierDTO>>
    {
        private readonly ISupplierRepository supplierRepository;

        public SearchSupplierByUserIdHandler(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public Task<IEnumerable<SupplierDTO>> Handle(SearchSupplierByUserId request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return supplierRepository.SearchSupplierByUserId(request.Id);
            });
        }
    }
}
