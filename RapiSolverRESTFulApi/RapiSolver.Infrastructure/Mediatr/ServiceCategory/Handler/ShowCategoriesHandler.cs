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
    public class ShowCategoriesHandler : IRequestHandler<ShowCategories, IEnumerable<Core.Entities.ServiceCategory>>
    {
        private readonly IServiceCategoryRepository serviceCategoryRepository;

        public ShowCategoriesHandler(IServiceCategoryRepository serviceCategoryRepository)
        {
            this.serviceCategoryRepository = serviceCategoryRepository;
        }

        public Task<IEnumerable<Core.Entities.ServiceCategory>> Handle(ShowCategories request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return serviceCategoryRepository.ShowCategories();
            });
        }
    }
}
