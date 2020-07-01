using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.ServiceCategory.Command
{
    public class RegisterCategory : IRequest<Boolean>
    {
        public RegisterCategory(Core.Entities.ServiceCategory entity)
        {
            ServiceCategory = entity;
        }
        public Core.Entities.ServiceCategory ServiceCategory;
    }
}
