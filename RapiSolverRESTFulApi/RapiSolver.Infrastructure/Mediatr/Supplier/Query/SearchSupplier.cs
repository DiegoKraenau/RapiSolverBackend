using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Supplier.Query
{
    public class SearchSupplier : IRequest<Core.Entities.Supplier>
    {
        public SearchSupplier(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
