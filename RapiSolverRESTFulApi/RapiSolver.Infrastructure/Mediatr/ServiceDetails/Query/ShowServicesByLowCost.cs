using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.ServiceDetails.Query
{
    public class ShowServicesByLowCost: IRequest<IEnumerable<ServiceDetailsDTO>>
    {
    }
}
