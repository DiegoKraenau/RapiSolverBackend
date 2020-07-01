using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.ServiceDetails.Command;
using RapiSolver.Infrastructure.Mediatr.ServiceDetails.Handler;
using RapiSolver.Infrastructure.Mediatr.ServiceDetails.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ServiceDetailsTest
    {
        private static List<ServiceDetailsDTO> listaServiceDetailsDTO = new List<ServiceDetailsDTO>();
        private static CancellationToken ct = new CancellationToken();
        Mock<IServiceDetailsRepository> mockRepository = new Mock<IServiceDetailsRepository>();

        [ClassInitialize()]
        public static void Setup(TestContext context)
        {

            ServiceDetailsDTO sd1 = new ServiceDetailsDTO
            {
                ServiceDetailsId = 1,
                ServiceName = "Jardinero",
                UsuarioId = 1,
                CategoryName = "Jardineria",
                LocationId = 1
            };

            ServiceDetailsDTO sd2 = new ServiceDetailsDTO
            {
                ServiceDetailsId = 2,
                ServiceName = "Electricista",
                UsuarioId = 1,
                CategoryName = "Electricidad",
                LocationId = 1
            };

            listaServiceDetailsDTO.Add(sd1);
            listaServiceDetailsDTO.Add(sd2);

        }

        [TestMethod]
        public void SearchServiceDetailsTest()
        {
            mockRepository.Setup(x => x.SearchServiceDetails(1))
                        .Returns(listaServiceDetailsDTO.Where(y => y.ServiceDetailsId == 1));

            var handler = new SearchServiceDetailsHandler(mockRepository.Object);

            SearchServiceDetails ssd = new SearchServiceDetails(1);

            var res = handler.Handle(ssd, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowLastServicesDetailsTest()
        {
            mockRepository.Setup(x => x.ShowLastServicesDetails())
                .Returns(listaServiceDetailsDTO.Take(3));

            var handler = new ShowLastServicesDetailsHandler(mockRepository.Object);

            // Act
            ShowLastServicesDetails sld = new ShowLastServicesDetails();

            var res = handler.Handle(sld, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowServiceByLowCostAndNameTest()
        {
            string nombre = "Electricista";
            mockRepository.Setup(x => x.ShowServiceByLowCostAndName(nombre))
                .Returns(listaServiceDetailsDTO.Where(y => y.ServiceName == nombre).OrderByDescending(y => y.Cost));

            var handler = new ShowServiceByLowCostAndNameHandler(mockRepository.Object);

            // Act
            ShowServiceByLowCostAndName ssbln = new ShowServiceByLowCostAndName(nombre);

            var res = handler.Handle(ssbln, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowServiceDetails()
        {
            mockRepository.Setup(x => x.ShowServiceDetails())
                .Returns(listaServiceDetailsDTO);

            var handler = new ShowServiceDetailsHandler(mockRepository.Object);

            // Act
            ShowServiceDetails ssd = new ShowServiceDetails();

            var res = handler.Handle(ssd, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowServicesByLowCostTest()
        {
            mockRepository.Setup(x => x.ShowServicesByLowCost())
                .Returns(listaServiceDetailsDTO.OrderByDescending(y => y.Cost));

            var handler = new ShowServicesByLowCostHandler(mockRepository.Object);

            // Act
            ShowServicesByLowCost ssblc = new ShowServicesByLowCost();

            var res = handler.Handle(ssblc, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowServicesByNameTest()
        {
            string nombre = "Electricista";
            mockRepository.Setup(x => x.ShowServicesByName(nombre))
                .Returns(listaServiceDetailsDTO.Where(y=>y.ServiceName==nombre));

            var handler = new ShowServicesByNameHandler(mockRepository.Object);

            // Act
            ShowServicesByName ssbn = new ShowServicesByName(nombre);

            var res = handler.Handle(ssbn, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void RegisterServiceDetailTest()
        {
            ServiceDetailsDTO sd3 = new ServiceDetailsDTO
            {
                ServiceDetailsId = 3,
                ServiceName = "Gasfitero",
                UsuarioId = 1,
                CategoryName = "Gasfiteria",
                LocationId = 1
            };


            mockRepository.Setup(x => x.RegisterServiceDetail(sd3))
                        .Returns(true);

            var handler = new RegisterServiceDetailHandler(mockRepository.Object);

            RegisterServiceDetail rsd = new RegisterServiceDetail(sd3);

            var res = handler.Handle(rsd, ct);

            Assert.IsTrue(res.Result);
        }

    }
}
