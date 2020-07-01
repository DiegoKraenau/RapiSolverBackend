using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Location.Query
{
    public class SearchLocation : IRequest<RapiSolver.Core.Entities.Location>
    {
        public SearchLocation(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
