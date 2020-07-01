using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Service.Command;
using RapiSolver.Infrastructure.Mediatr.Service.Handler;
using RapiSolver.Infrastructure.Mediatr.Service.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ServiceTest
    {
        private static List<Servicio> listaService = new List<Servicio>();
        private static List<ServiceDTO> listaServiceDTO = new List<ServiceDTO>();
        private static CancellationToken ct = new CancellationToken();
        Mock<IServiceRepository> mockRepository = new Mock<IServiceRepository>();

        [ClassInitialize()]
        public static void Setup(TestContext context)
        {
            Servicio sv1 = new Servicio
            {
                ServicioId = 1,
                Name = "Tarrajeada",
                Description = "Se realiza el proceso de tarrajeo.",
                Cost = 800,
                ServiceCategoryId = 1
            };
            Servicio sv2 = new Servicio
            {
                ServicioId = 2,
                Name = "Desarrollo de aplicación de escritorio",
                Description = "Se realiza la implementación de una aplicación de escritorio.",
                Cost = 1500,
                ServiceCategoryId = 2
            };

            listaService.Add(sv1);
            listaService.Add(sv2);

            ServiceDTO sdto = new ServiceDTO
            {
                ServicioId = 1,
                Name = "Tarrajeada",
                Description = "Se realiza el proceso de tarrajeo.",
                Cost = 800,
                ServiceCategoryId = 1,
                CategoryName = "Electricista"
            };
            ServiceDTO sdto2 = new ServiceDTO
            {
                ServicioId = 2,
                Name = "Desarrollo de aplicación de escritorio",
                Description = "Se realiza la implementación de una aplicación de escritorio.",
                Cost = 1500,
                ServiceCategoryId = 2,
                CategoryName = "Developer"
            };
            listaServiceDTO.Add(sdto);
            listaServiceDTO.Add(sdto2);
        }

        [TestMethod]
        public void RegisterServiceTest()
        {
            Servicio sv3 = new Servicio
            {
                ServicioId = 3,
                Name = "Instalación electrica",
                Description = "Se realiza la instalación electrica.",
                Cost = 1100,
                ServiceCategoryId = 3
            };

            mockRepository.Setup(x => x.RegisterService(sv3)).Returns(true);

            var handler = new RegisterServiceHandler(mockRepository.Object);
            RegisterService rs = new RegisterService(sv3);
            var res = handler.Handle(rs, ct);

            Assert.IsTrue(res.Result);
        }

        [TestMethod]
        public void SearchServiceTest()
        {
            mockRepository.Setup(x => x.SearchService(1))
                        .Returns(listaService.Single(y => y.ServicioId == 1));

            var handler = new SearchServiceHandler(mockRepository.Object);
            SearchService ss = new SearchService(1);
            var res = handler.Handle(ss, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowServicesTest()
        {
            mockRepository.Setup(x => x.ShowServices()).Returns(listaServiceDTO);

            var handler = new ShowServiceHandler(mockRepository.Object);
            ShowServices ss = new ShowServices();
            var res = handler.Handle(ss, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowServicesByCategoryTest()
        {
            string nombre = "Electricista";

            mockRepository.Setup(x => x.ShowServicesByCategory(nombre))
                .Returns(listaServiceDTO.Where(y => y.CategoryName == nombre));

            var handler = new ShowServicesByCategoryHandler(mockRepository.Object);
            ShowServicesByCategory ssbc = new ShowServicesByCategory(nombre);
            var res = handler.Handle(ssbc, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowServicesBySupplierTest()
        {

            mockRepository.Setup(x => x.ShowServicesBySupplier(1))
                .Returns(listaServiceDTO.Where(y => y.ServicioId == 1));

            var handler = new ShowServicesBySupplierHandler(mockRepository.Object);
            ShowServicesBySupplier ssbs = new ShowServicesBySupplier(1);
            var res = handler.Handle(ssbs, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowServicesByUserTest()
        {

            mockRepository.Setup(x => x.ShowServicesByUser(1))
                .Returns(listaServiceDTO.Where(y => y.ServicioId == 1));

            var handler = new ShowServicesByUserHandler(mockRepository.Object);
            ShowServicesByUser ssbu = new ShowServicesByUser(1);
            var res = handler.Handle(ssbu, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void UnregisterServiceTest()
        {
            mockRepository.Setup(x => x.UnregisterService(1))
                        .Returns(true);

            var handler = new UnregisterServiceHandler(mockRepository.Object);
            UnregisterService us = new UnregisterService(1);
            var res = handler.Handle(us, ct);

            Assert.IsTrue(res.Result);
        }

        [TestMethod]
        public void UpdateServiceTest()
        {
            ServiceDTO sdto3 = new ServiceDTO
            {
                ServicioId = 2,
                Name = "Desarrollo de aplicación web",
                Description = "Se realiza la implementación de una aplicación web.",
                Cost = 1500,
                ServiceCategoryId = 2,
                CategoryName = "Developer"
            };

            mockRepository.Setup(x => x.UpdateService(sdto3))
                        .Returns(true);

            var handler = new UpdateServiceHandler(mockRepository.Object);
            UpdateService us = new UpdateService(sdto3);
            var res = handler.Handle(us, ct);

            Assert.IsTrue(res.Result);
        }
    }
}
