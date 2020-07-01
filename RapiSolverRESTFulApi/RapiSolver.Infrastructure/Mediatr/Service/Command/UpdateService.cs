using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Service.Command
{
    public class UpdateService: IRequest<Boolean>
    {
        public UpdateService(ServiceDTO serviceDTO)
        {
            ServiceDTO = serviceDTO;
        }
        public ServiceDTO ServiceDTO;
    }
}
