using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Location.Command;
using RapiSolver.Infrastructure.Mediatr.Location.Handler;
using RapiSolver.Infrastructure.Mediatr.Location.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
	[TestClass]
	public class LocationTest
	{
        private static List<Location> listaLocations = new List<Location>();
        private static CancellationToken ct = new CancellationToken();
        Mock<ILocationRepository> mockRepository = new Mock<ILocationRepository>();
        [ClassInitialize()]
        public static void Setup(TestContext context)
        {

            Location location1 = new Location
            {
                LocationId = 1,
                Address = "Av. Jamas 1",
                City = "Lima"
            };

            Location location2 = new Location
            {
                LocationId = 2,
                Address = "Av. Jamas 2",
                City = "Ica"
            };

            listaLocations.Add(location1);
            listaLocations.Add(location2);

        }


        [TestMethod]
        public void ShowLocationsTest()
        {


            // Arrange

            mockRepository.Setup(x => x.ShowLocations())
                .Returns(listaLocations);

            var handler = new ShowLocationsHandler(mockRepository.Object);

            // Act
            ShowLocations sl = new ShowLocations();

            var res = handler.Handle(sl, ct);


            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void SearchLocationTest()
        {
            mockRepository.Setup(x => x.SearchLocation(1))
                        .Returns(listaLocations.Where(y => y.LocationId == 1).First);

            var handler = new SearchLocationHandler(mockRepository.Object);

            SearchLocation sl = new SearchLocation(1);

            var res = handler.Handle(sl, ct);

            Assert.IsNotNull(res.Result);


        }

        [TestMethod]
        public void RegisterLocationTest()
        {
            Location location3 = new Location
            {
                LocationId = 3,
                Address = "Av. Jamas 3",
                City = "Arequipa"
            };

            mockRepository.Setup(x => x.RegisterLocation(location3))
                        .Returns(true);

            var handler = new RegisterLocationHandler(mockRepository.Object);
            RegisterLocation rc = new RegisterLocation(location3);
            var res = handler.Handle(rc, ct);

            Assert.IsTrue(res.Result);
 
        }
    }
}
