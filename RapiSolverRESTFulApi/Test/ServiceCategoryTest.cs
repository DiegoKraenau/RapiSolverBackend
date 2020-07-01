using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.ServiceCategory.Command;
using RapiSolver.Infrastructure.Mediatr.ServiceCategory.Handler;
using RapiSolver.Infrastructure.Mediatr.ServiceCategory.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ServiceCategoryTest
    {
        private static List<ServiceCategory> listaServiceCategory = new List<ServiceCategory>();
        private static CancellationToken ct = new CancellationToken();
        Mock<IServiceCategoryRepository> mockRepository = new Mock<IServiceCategoryRepository>();

        [ClassInitialize()]
        public static void Setup(TestContext context)
        {
            ServiceCategory category1 = new ServiceCategory
            {
                ServiceCategoryId = 1,
                CategoryName = "categoria 1",
                CategoryDescription = "Descripcion de la categoria 1."
            };
            ServiceCategory category2 = new ServiceCategory
            {
                ServiceCategoryId = 2,
                CategoryName = "categoria 2",
                CategoryDescription = "Descripcion de la categoria 2."
            };

            listaServiceCategory.Add(category1);
            listaServiceCategory.Add(category2);
        }

        [TestMethod]
        public void RegisterCategoryTest()
        {
            ServiceCategory category3 = new ServiceCategory
            {
                ServiceCategoryId = 3,
                CategoryName = "categoria 3",
                CategoryDescription = "Descripcion de la categoria 3."
            };

            mockRepository.Setup(x => x.RegisterCategory(category3)).Returns(true);

            var handler = new RegisterCategoryHandler(mockRepository.Object);
            RegisterCategory rs = new RegisterCategory(category3);
            var res = handler.Handle(rs, ct);

            Assert.IsTrue(res.Result);
        }

        [TestMethod]
        public void ShowCategoriesTest()
        {
            mockRepository.Setup(x => x.ShowCategories()).Returns(listaServiceCategory);

            var handler = new ShowCategoriesHandler(mockRepository.Object);
            ShowCategories ss = new ShowCategories();
            var res = handler.Handle(ss, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void SearchCategoryTest()
        {
            mockRepository.Setup(x => x.SearchCategory(1))
                        .Returns(listaServiceCategory.Single(y => y.ServiceCategoryId == 1));

            var handler = new SearchCategoryHandler(mockRepository.Object);
            SearchCategory ss = new SearchCategory(1);
            var res = handler.Handle(ss, ct);

            Assert.IsNotNull(res.Result);
        }
    }
}
