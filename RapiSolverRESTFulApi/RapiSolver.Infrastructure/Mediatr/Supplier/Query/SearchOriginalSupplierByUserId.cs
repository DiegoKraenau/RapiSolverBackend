using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Supplier.Query
{
    public class SearchOriginalSupplierByUserId : IRequest<Core.Entities.Supplier>
    {
        public SearchOriginalSupplierByUserId(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
