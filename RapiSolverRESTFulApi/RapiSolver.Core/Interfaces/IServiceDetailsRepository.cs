using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Interfaces
{
    public interface IServiceDetailsRepository
    {
       // ServiceDetails SearchServiceDeatil(int id);
        
        IEnumerable<ServiceDetailsDTO> ShowLastServicesDetails();

        IEnumerable<ServiceDetailsDTO> ShowServiceDetails();

        IEnumerable<ServiceDetailsDTO> SearchServiceDetails(int id);

        IEnumerable<ServiceDetailsDTO> ShowServicesByLowCost();

        IEnumerable<ServiceDetailsDTO> ShowServiceByLowCostAndName(string name);

        IEnumerable<ServiceDetailsDTO> ShowServicesByName(string name);

        bool RegisterServiceDetail(ServiceDetailsDTO entity);
    }
}
