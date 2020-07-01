using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Service.Query
{
    public class ShowServicesByCategory: IRequest<IEnumerable<ServiceDTO>>
    {
        public ShowServicesByCategory(string name)
        {
            Name = name;
        }

        public string Name;
    }
}
