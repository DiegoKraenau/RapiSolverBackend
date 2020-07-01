using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Supplier.Query
{
    public class SearchSupplierByUserId : IRequest<IEnumerable<SupplierDTO>>
    {
        public SearchSupplierByUserId(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
