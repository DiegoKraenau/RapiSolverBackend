using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Interfaces
{
    public interface IServiceCategoryRepository
    {
        ServiceCategory SearchCategory(int id);

        IEnumerable<ServiceCategory> ShowCategories();

        bool RegisterCategory(ServiceCategory entity);
    }
}
