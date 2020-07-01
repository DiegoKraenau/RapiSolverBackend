using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Interfaces
{
    public interface ILocationRepository
    {
        Location SearchLocation(int id);

        IEnumerable<Location> ShowLocations();

        bool RegisterLocation(Location entity);
    }
}
