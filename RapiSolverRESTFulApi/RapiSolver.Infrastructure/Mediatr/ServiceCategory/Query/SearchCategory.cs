using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.ServiceCategory.Query
{
    public class SearchCategory : IRequest<Core.Entities.ServiceCategory>
    {
        public SearchCategory(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
