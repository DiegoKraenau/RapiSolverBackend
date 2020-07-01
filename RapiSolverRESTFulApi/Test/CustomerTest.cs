using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Customer.Command;
using RapiSolver.Infrastructure.Mediatr.Customer.Handler;
using RapiSolver.Infrastructure.Mediatr.Customer.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class CustomerTest
	{

        private static List<CustomerDTO> listaCustomers = new List<CustomerDTO>();
        private static CancellationToken ct = new CancellationToken();
        Mock<ICustomerRepository> mockRepository = new Mock<ICustomerRepository>();
        [ClassInitialize()]
        public static void Setup(TestContext context)
        {

            CustomerDTO customer1 = new CustomerDTO
            {
                CustomerId = 1,
                Country = "Perú",
                Email = "costumer1@gmail.com"
            };

            CustomerDTO customer2 = new CustomerDTO
            {
                CustomerId = 2,
                Country = "Perú",
                Email = "costumer2@gmail.com"
            };

            listaCustomers.Add(customer1);
            listaCustomers.Add(customer2);

        }


        [TestMethod]
        public void ShowCustomersTest()
        {


            // Arrange

            mockRepository.Setup(x => x.ShowCustomers())
                .Returns(listaCustomers);

            var handler = new ShowCustomersHandler(mockRepository.Object);

            // Act
            ShowCustomers sc = new ShowCustomers();

            var res = handler.Handle(sc, ct);


            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void SearchCustomerTest()
        {
            mockRepository.Setup(x => x.SearchCustomer(1))
                        .Returns(listaCustomers.Where(y => y.CustomerId == 1).First);

            var handler = new SearchCustomerHandler(mockRepository.Object);

            SearchCustomer sc = new SearchCustomer(1);

            var res = handler.Handle(sc, ct);

            Assert.IsNotNull(res.Result);


        }

        [TestMethod]
        public void RegisterCustomerTest()
        {
            Customer customer3 = new Customer
            {
                CustomerId = 3,
                Country = "Perú",
                Email = "costumer3@gmail.com"
            };

            mockRepository.Setup(x => x.RegisterCustomer(customer3))
                        .Returns(true);

            var handler = new RegisterCustomerHandler(mockRepository.Object);

            RegisterCustomer rc = new RegisterCustomer(customer3);

        
            var res = handler.Handle(rc, ct);

            Assert.IsTrue(res.Result);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void BuySubscriptionTest()
        {
            mockRepository.Setup(x => x.BuySubscription(1))
                        .Returns(true);

            var handler = new BuySubscriptionHandler(mockRepository.Object);

            BuySubscription bs = new BuySubscription(1);


            var res = handler.Handle(bs, ct);
     
            Assert.IsTrue(res.Result);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            Customer customer3 = new Customer
            {
                CustomerId = 3,
                Country = "Argentina",
                Email = "costumer3@gmail.com"
            };
            mockRepository.Setup(x => x.UpdateCustomer(customer3))
                        .Returns(true);

            var handler = new UpdateCustomerHandler(mockRepository.Object);

            UpdateCustomer uc = new UpdateCustomer(customer3);

            var res = handler.Handle(uc, ct);

            Assert.IsTrue(res.Result);
        }
    }
}
