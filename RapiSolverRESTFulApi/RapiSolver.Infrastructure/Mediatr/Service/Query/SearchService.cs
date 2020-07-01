using MediatR;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Service.Query
{
    public class SearchService: IRequest<Servicio>
    {
        public SearchService(int id)
        {
            Id = id;
        }

        public int Id;
    }
}
