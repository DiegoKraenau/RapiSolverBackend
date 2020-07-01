using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Interfaces
{
    public interface ISupplierRepository
    {
        Supplier SearchSupplier(int id);

        IEnumerable<SupplierDTO> ShowSuppliersBySurname(string surname);

        IEnumerable<SupplierDTO> ShowSuppliers();

        IEnumerable<SupplierDTO> SearchSupplierByUserId(int id);

        Supplier SearchOriginalSupplierByUserId(int id);

        bool RegisterSupplier(Supplier entity);

        bool UpdateSupplier(Supplier entity);
    }
}
