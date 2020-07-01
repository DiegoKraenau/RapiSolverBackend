using MediatR;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Service.Command
{
    public class RegisterService: IRequest<Boolean>
    {
        public RegisterService(Servicio service)
        {
            Service = service;
        }

        public Servicio Service;
    }
}
