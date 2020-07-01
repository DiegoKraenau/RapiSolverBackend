using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Interfaces
{
    public interface IServiceRepository
    {
        bool UnregisterService(int id);

        Servicio SearchService(int id);

        IEnumerable<ServiceDTO> ShowServicesByCategory(string name);

        IEnumerable<ServiceDTO> ShowServicesBySupplier(int id);

        IEnumerable<ServiceDTO> ShowServicesByUser(int id);

        IEnumerable<ServiceDTO> ShowServices();

        bool RegisterService(Servicio entity);

        bool UpdateService(ServiceDTO serviceDTO);
    }
}
