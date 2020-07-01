using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Location.Command
{
    public class RegisterLocation : IRequest<Boolean>
    {
        public RegisterLocation(RapiSolver.Core.Entities.Location location)
        {
            Location = location;
        }

        public RapiSolver.Core.Entities.Location Location;
    }
}
