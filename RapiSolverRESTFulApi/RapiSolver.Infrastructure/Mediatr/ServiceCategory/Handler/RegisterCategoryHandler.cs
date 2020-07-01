using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.ServiceCategory.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.ServiceCategory.Handler
{
    public class RegisterCategoryHandler : IRequestHandler<RegisterCategory, Boolean>
    {
        private readonly IServiceCategoryRepository serviceCategoryRepository;

        public RegisterCategoryHandler(IServiceCategoryRepository serviceCategoryRepository)
        {
            this.serviceCategoryRepository = serviceCategoryRepository;
        }

        public Task<bool> Handle(RegisterCategory request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return serviceCategoryRepository.RegisterCategory(request.ServiceCategory);
            });
        }
    }
}
