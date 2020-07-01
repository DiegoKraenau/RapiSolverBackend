using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.ServiceDetails.Command
{
    public class RegisterServiceDetail: IRequest<bool>
    {
        public RegisterServiceDetail(ServiceDetailsDTO entity)
        {
            Entity = entity;
        }
        public ServiceDetailsDTO Entity;
    }
}
