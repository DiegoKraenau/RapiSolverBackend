using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.ServiceCategory.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.ServiceCategory.Handler
{
    public class SearchCategoryHandler : IRequestHandler<SearchCategory, Core.Entities.ServiceCategory>
    {
        private readonly IServiceCategoryRepository serviceCategoryRepository;

        public SearchCategoryHandler(IServiceCategoryRepository serviceCategoryRepository)
        {
            this.serviceCategoryRepository = serviceCategoryRepository;
        }

        public Task<Core.Entities.ServiceCategory> Handle(SearchCategory request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return serviceCategoryRepository.SearchCategory(request.Id);
            });
        }
    }
}
