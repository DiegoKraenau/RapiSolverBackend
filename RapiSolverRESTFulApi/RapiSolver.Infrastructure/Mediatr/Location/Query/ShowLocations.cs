using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Location.Query
{
    public class ShowLocations : IRequest<IEnumerable<RapiSolver.Core.Entities.Location>>
    {

    }
}
