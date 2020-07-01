using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.ServiceDetails.Query
{
    public class SearchServiceDetails: IRequest<IEnumerable<ServiceDetailsDTO>>
    {
        public SearchServiceDetails(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
