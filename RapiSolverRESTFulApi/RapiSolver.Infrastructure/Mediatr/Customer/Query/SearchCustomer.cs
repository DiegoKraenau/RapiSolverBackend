using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Customer.Query
{
    public class SearchCustomer : IRequest<RapiSolver.Core.DTOs.CustomerDTO>
    {
        public SearchCustomer(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
