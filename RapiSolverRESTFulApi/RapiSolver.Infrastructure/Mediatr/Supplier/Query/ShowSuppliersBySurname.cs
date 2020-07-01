using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Supplier.Query
{
    public class ShowSuppliersBySurname : IRequest<IEnumerable<SupplierDTO>>
    {
        public ShowSuppliersBySurname(string surname)
        {
            Surname = surname;
        }
        public string Surname;
    }
}
