using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Supplier.Command
{
    public class RegisterSupplier : IRequest<Boolean>
    {
        public RegisterSupplier(Core.Entities.Supplier entity)
        {
            Supplier = entity;
        }
        public Core.Entities.Supplier Supplier;
    }
}
