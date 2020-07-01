using MediatR;
using System;


namespace RapiSolver.Infrastructure.Mediatr.Customer.Command
{
	public class BuySubscription: IRequest<Boolean>
	{
		public BuySubscription(int id)
		{
			Id = id;
		}

		public int Id;
	}
}
