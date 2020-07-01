using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Recommendation.Command;
using RapiSolver.Infrastructure.Mediatr.Recommendation.Handler;
using RapiSolver.Infrastructure.Mediatr.Recommendation.Query;

namespace Test
{
    [TestClass]
    public class RecommendationTest
    {
        private static List<RecommendationDTO> listaRecommendationsDTO = new List<RecommendationDTO>();
        private static List<Recommendation> listaRecommendations = new List<Recommendation>();
        private static CancellationToken ct = new CancellationToken();
        Mock<IRecommendationRepository> mockRepository = new Mock<IRecommendationRepository>();

        [ClassInitialize()]
        public static void Setup(TestContext context)
        {

            RecommendationDTO recommendationDto1 = new RecommendationDTO
            {
                RecommendationId = 1,
                Note = "Esta bien",
                Mark = 10,
                SupplierId = 1,
                NameSupllier = "Juan",
                LastNameSupllier = "Ortega",
                EmailSupllier = "juanortega@gmail.com",
                UsuarioId = 1,
                UserName = "juanO"
            };

            RecommendationDTO recommendationDto2 = new RecommendationDTO
            {
                RecommendationId = 2,
                Note = "Esta bien",
                Mark = 8,
                SupplierId = 2,
                NameSupllier = "Luis",
                LastNameSupllier = "Gonzales",
                EmailSupllier = "luisgonzales@gmail.com",
                UsuarioId = 2,
                UserName = "luisG"
            };

            listaRecommendationsDTO.Add(recommendationDto1);
            listaRecommendationsDTO.Add(recommendationDto2);


            Recommendation recommendation1 = new Recommendation
            {
                RecommendationId = 1,
                UsuarioId = 1,
                SupplierId = 1,
                Note = "Esta bien",
                Mark = 10
            };

            Recommendation recommendation2 = new Recommendation
            {
                RecommendationId = 2,
                UsuarioId = 2,
                SupplierId = 2,
                Note = "Esta bien",
                Mark = 8
            };

            listaRecommendations.Add(recommendation1);
            listaRecommendations.Add(recommendation2);
        }

        [TestMethod]
        public void ShowRecommendationsTest()
        {
            mockRepository.Setup(x => x.ShowRecommendations())
                .Returns(listaRecommendations);

            var handler = new ShowRecommendationsHandler(mockRepository.Object);

            ShowRecommendations re = new ShowRecommendations();

            var res = handler.Handle(re, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowRecommendationsBySupplierTest()
        {
            int supplierId = 1;

            mockRepository.Setup(x => x.ShowRecommendationsBySupplier(supplierId))
                .Returns(listaRecommendationsDTO.Where(y => y.SupplierId == supplierId));

            var handler = new ShowRecommendationsBySupplierHandler(mockRepository.Object);

            ShowRecommendationsBySupplier re = new ShowRecommendationsBySupplier(supplierId);

            var res = handler.Handle(re, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void RegisterRecommendationTest()
        {
            Recommendation recommendation3 = new Recommendation
            {
                RecommendationId = 3,
                UsuarioId = 2,
                SupplierId = 2,
                Note = "Esta bien",
                Mark = 10
            };


            mockRepository.Setup(x => x.RegisterRecommendation(recommendation3))
                        .Returns(true);

            var handler = new RegisterRecommendationHandler(mockRepository.Object);

            RegisterRecommendation re = new RegisterRecommendation(recommendation3);

            var res = handler.Handle(re, ct);

            Assert.IsTrue(res.Result);
        }

        [TestMethod]
        public void SearchRecommendationTest()
        {
            int recommendationId = 1;

            mockRepository.Setup(x => x.SearchRecommendation(recommendationId))
                        .Returns(listaRecommendations.Where(y => y.RecommendationId == recommendationId).First);

            var handler = new SearchRecommendationHandler(mockRepository.Object);

            SearchRecommendation re = new SearchRecommendation(recommendationId);

            var res = handler.Handle(re, ct);

            Assert.IsNotNull(res.Result);
        }

    }
}
