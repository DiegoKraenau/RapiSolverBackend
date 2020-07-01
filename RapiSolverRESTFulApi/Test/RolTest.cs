using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Rol.Command;
using RapiSolver.Infrastructure.Mediatr.Rol.Handler;
using RapiSolver.Infrastructure.Mediatr.Rol.Query;

namespace Test
{
    [TestClass]
    public class RolTest
    {
        private static List<Rol> listaRoles=new List<Rol>();
        private static CancellationToken ct = new CancellationToken();
        Mock<IRolRepository> mockRepository = new Mock<IRolRepository>();
        [ClassInitialize()]
        public static void Setup(TestContext context)
        {
            
            Rol rol1 = new Rol
            {
                RolId = 1,
                RolDescription = "No puede publicar",
                Publish = false
            };

            Rol rol2 = new Rol
            {
                RolId = 2,
                RolDescription = "Puede publicar",
                Publish = false
            };

            listaRoles.Add(rol1);
            listaRoles.Add(rol2);

        }


        [TestMethod]
        public void ShowRolesTest()
        {
            
            
            // Arrange
            
            mockRepository.Setup(x=>x.ShowRoles())
                .Returns(listaRoles);

            var handler = new ShowRolesHandler(mockRepository.Object);

            // Act
            ShowRoles sr = new ShowRoles();
            
            var res = handler.Handle(sr, ct);
           
          
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void SearchRolTest()
        {
            mockRepository.Setup(x => x.SearchRol(1))
                        .Returns(listaRoles.Where(y=>y.RolId==1).First);

            var handler = new SearchRolHandler(mockRepository.Object);

            SearchRol sr = new SearchRol(1);

            var res = handler.Handle(sr, ct);

            Assert.IsNotNull(res.Result);


        }

        [TestMethod]
        public void RegisterRolTest()
        {
            Rol rol3 = new Rol
            {
                RolId=3,
                RolDescription="Prueba",
                Publish=false
            };

            mockRepository.Setup(x => x.RegisterRol(rol3))
                        .Returns(true);

            var handler = new RegisterRolHandler(mockRepository.Object);

            RegisterRol rr = new RegisterRol(rol3);

            var res = handler.Handle(rr, ct);

            Assert.IsTrue(res.Result);

        }

        [TestMethod]
        public void UnregisterRolTest()
        {
            mockRepository.Setup(x => x.UnregisterRol(1))
                        .Returns(true);

            var handler = new UnregisterRolHandler(mockRepository.Object);

            UnregisterRol ur = new UnregisterRol(1);

            var res = handler.Handle(ur, ct);

            Assert.IsTrue(res.Result);
        }

    }
}
