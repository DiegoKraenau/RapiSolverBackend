using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Customer.Query
{

	public class ShowCustomers : IRequest<IEnumerable<RapiSolver.Core.DTOs.CustomerDTO>>
	{

	}
}
