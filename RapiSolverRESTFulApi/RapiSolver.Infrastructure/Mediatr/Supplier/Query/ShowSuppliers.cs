using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Supplier.Query
{
    public class ShowSuppliers : IRequest<IEnumerable<SupplierDTO>>
    {

    }
}
