using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Supplier.Command;
using RapiSolver.Infrastructure.Mediatr.Supplier.Handler;
using RapiSolver.Infrastructure.Mediatr.Supplier.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class SupplierTest
    {
        private static List<SupplierDTO> listaSuppliersDTO = new List<SupplierDTO>();
        private static List<Supplier> listaSuppliers = new List<Supplier>();
        private static CancellationToken ct = new CancellationToken();
        Mock<ISupplierRepository> mockRepository = new Mock<ISupplierRepository>();

        [ClassInitialize()]
        public static void Setup(TestContext context)
        {

            SupplierDTO supplierDto1 = new SupplierDTO
            {
                SupplierId = 1,
                Name = "Juan",
                LastName = "Ortega",
                Email = "juanortega@gmail.com",
                Phone = "956123546",
                Age = 28,
                Gender = "Masculino",
                UsuarioId = 1,
                LocationId = 1,
                UserName = "User",
                Country = "Peru"
            };

            SupplierDTO supplierDto2 = new SupplierDTO
            {
                SupplierId = 2,
                Name = "Roberto",
                LastName = "Galvez",
                Email = "roberto@gmail.com",
                Phone = "978456123",
                Age = 30,
                Gender = "Masculino",
                UsuarioId = 1,
                LocationId = 1,
                UserName = "User",
                Country = "Peru"
            };

            listaSuppliersDTO.Add(supplierDto1);
            listaSuppliersDTO.Add(supplierDto2);


            Supplier supplier1 = new Supplier
            {
                SupplierId = 1,
                Name = "Juan",
                LastName = "Ortega",
                Email = "juanortega@gmail.com",
                Phone = "956123546",
                Age = 28,
                Gender = "Masculino",
                UsuarioId = 1,
                LocationId = 1,
                Country = "Peru",
                State = "Lima",
                City = "Lima",
                Address = "Lima av. 20",
                Contraseña = "123456"
            };

            Supplier supplier2 = new Supplier
            {
                SupplierId = 2,
                Name = "Roberto",
                LastName = "Galvez",
                Email = "roberto@gmail.com",
                Phone = "978456123",
                Age = 30,
                Gender = "Masculino",
                UsuarioId = 1,
                LocationId = 1,
                Country = "Peru",
                State = "Lima",
                City = "Lima",
                Address = "Lima av. 30",
                Contraseña = "1597535"
            };

            listaSuppliers.Add(supplier1);
            listaSuppliers.Add(supplier2);

        }

        [TestMethod]
        public void ShowSuppliersTest()
        {
            mockRepository.Setup(x => x.ShowSuppliers())
                .Returns(listaSuppliersDTO);

            var handler = new ShowSuppliersHandler(mockRepository.Object);

            // Act
            ShowSuppliers su = new ShowSuppliers();

            var res = handler.Handle(su, ct);


            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowSuppliersBySurnameTest()
        {
            string surname = "Galvez";
            mockRepository.Setup(x => x.ShowSuppliersBySurname(surname))
                .Returns(listaSuppliersDTO);

            var handler = new ShowSuppliersBySurnameHandler(mockRepository.Object);

            // Act
            ShowSuppliersBySurname su = new ShowSuppliersBySurname(surname);

            var res = handler.Handle(su, ct);


            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void RegisterSupplierTest()
        {
            Supplier supplier3 = new Supplier
            {
                SupplierId = 3,
                Name = "Luis",
                LastName = "Perez",
                Email = "luisito@gmail.com",
                Phone = "9456789",
                Age = 45,
                Gender = "Masculino",
                UsuarioId = 1,
                LocationId = 1,
                Country = "Peru",
                State = "Lima",
                City = "Lima",
                Address = "Lima av. 25",
                Contraseña = "456789"
            };


            mockRepository.Setup(x => x.RegisterSupplier(supplier3))
                        .Returns(true);

            var handler = new RegisterSupplierHandler(mockRepository.Object);

            RegisterSupplier ru = new RegisterSupplier(supplier3);

            var res = handler.Handle(ru, ct);

            Assert.IsTrue(res.Result);
        }

        [TestMethod]
        public void SearchSupplierTest()
        {
            mockRepository.Setup(x => x.SearchSupplier(1))
                        .Returns(listaSuppliers.Where(y => y.SupplierId == 1).First);

            var handler = new SearchSupplierHandler(mockRepository.Object);

            SearchSupplier su = new SearchSupplier(1);

            var res = handler.Handle(su, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void SearchSupplierByUserIdTest()
        {
            mockRepository.Setup(x => x.SearchSupplierByUserId(1))
                        .Returns(listaSuppliersDTO.Where(y => y.UsuarioId == 1));

            var handler = new SearchSupplierByUserIdHandler(mockRepository.Object);

            SearchSupplierByUserId su = new SearchSupplierByUserId(1);

            var res = handler.Handle(su, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void SearchOriginalSupplierByUserIdTest()
        {
            mockRepository.Setup(x => x.SearchOriginalSupplierByUserId(1))
                        .Returns(listaSuppliers.Where(y => y.UsuarioId == 1).First);

            var handler = new SearchOriginalSupplierByUserIdHandler(mockRepository.Object);

            SearchOriginalSupplierByUserId su = new SearchOriginalSupplierByUserId(1);

            var res = handler.Handle(su, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void UpdateSupplierTest()
        {
            Supplier supplier2 = new Supplier
            {
                SupplierId = 2,
                Name = "Roberto",
                LastName = "Galvez",
                Email = "roberto@gmail.com",
                Phone = "978456123",
                Age = 31,
                Gender = "Masculino",
                UsuarioId = 1,
                LocationId = 1,
                Country = "Peru",
                State = "Lima",
                City = "Lima",
                Address = "Lima av. 30",
                Contraseña = "1597535"
            };

            mockRepository.Setup(x => x.UpdateSupplier(supplier2))
                        .Returns(true);

            var handler = new UpdateSupplierHandler(mockRepository.Object);
            UpdateSupplier us = new UpdateSupplier(supplier2);
            var res = handler.Handle(us, ct);

            Assert.IsTrue(res.Result);
        }
    }
}
