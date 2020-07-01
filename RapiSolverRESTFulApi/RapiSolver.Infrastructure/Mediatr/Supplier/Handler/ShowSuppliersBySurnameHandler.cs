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
    public class ShowSuppliersBySurnameHandler : IRequestHandler<ShowSuppliersBySurname, IEnumerable<SupplierDTO>>
    {
        private readonly ISupplierRepository supplierRepository;

        public ShowSuppliersBySurnameHandler(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public Task<IEnumerable<SupplierDTO>> Handle(ShowSuppliersBySurname request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return supplierRepository.ShowSuppliersBySurname(request.Surname);
            });
        }
    }
}
