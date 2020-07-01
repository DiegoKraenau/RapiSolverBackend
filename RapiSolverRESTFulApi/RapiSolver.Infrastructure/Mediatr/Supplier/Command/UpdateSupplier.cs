using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Supplier.Command
{
    public class UpdateSupplier : IRequest<Boolean>
    {
        public UpdateSupplier(Core.Entities.Supplier entity)
        {
            Supplier = entity;
        }
        public Core.Entities.Supplier Supplier;
    }
}
