using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.ServiceCategory.Query
{
    public class ShowCategories : IRequest<IEnumerable<Core.Entities.ServiceCategory>>
    {

    }
}
