using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Customer.Handler;
using RapiSolver.Infrastructure.Mediatr.Customer.Query;
using RapiSolver.Infrastructure.Mediatr.User.Command;
using RapiSolver.Infrastructure.Mediatr.User.Handler;
using RapiSolver.Infrastructure.Mediatr.User.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class UsuerTest
    {
        private static List<UsuarioDTO> listaUsuariosDTO = new List<UsuarioDTO>();
        private static List<Usuario> listaUsuarios = new List<Usuario>();
        private static CancellationToken ct = new CancellationToken();
        Mock<IUsuarioRepository> mockRepository = new Mock<IUsuarioRepository>();

        [ClassInitialize()]
        public static void Setup(TestContext context)
        {

            UsuarioDTO user1 = new UsuarioDTO
            {
                UserName="diegokraenau@gmail.com",
                RolId = 1,
                UserPassword="diego2009",
                UsuarioId=1
            };

            UsuarioDTO user2 = new UsuarioDTO
            {
                UserName="juancito@gmail.com",
                RolId = 2,
                UserPassword = "juancito2009",
                UsuarioId = 2
            };

            listaUsuariosDTO.Add(user1);
            listaUsuariosDTO.Add(user2);


            Usuario u1 = new Usuario
            {
                UserName = "diegokraenau@gmail.com",
                RolId = 1,
                UserPassword = "diego2009",
                UsuarioId = 1
            };

            Usuario u2 = new Usuario
            {
                UserName = "juancito@gmail.com",
                RolId = 2,
                UserPassword = "juancito2009",
                UsuarioId = 2
            };


            listaUsuarios.Add(u1);
            listaUsuarios.Add(u2);

        }

        [TestMethod]
        public void ShowUsersTest()
        {
            // Arrange

            mockRepository.Setup(x => x.ShowUsers())
                .Returns(listaUsuariosDTO);

            var handler = new ShowUsersHandler(mockRepository.Object);

            // Act
            ShowUsers su = new ShowUsers();

            var res = handler.Handle(su, ct);


            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void SearchUserTest()
        {
            mockRepository.Setup(x => x.SearchUser(1))
                        .Returns(listaUsuarios.Where(y=>y.UsuarioId==1).First);

            var handler = new SearchUserHandler(mockRepository.Object);

            SearchUser su = new SearchUser(1);

            var res = handler.Handle(su, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void LoginTest()
        {
            string correo = "diegokraenau@gmail.com";
            string contraseña = "diego2009";

            mockRepository.Setup(x => x.Login(correo, contraseña))
                        .Returns(listaUsuariosDTO.Single(y=>y.UserName==correo && y.UserPassword==contraseña));

            var handler = new LoginHandler(mockRepository.Object);

            Login lo = new Login(correo, contraseña);

            var res = handler.Handle(lo, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public  void RegisterRolTest()
        {
            Usuario u3 = new Usuario
            {
                UserName = "pedrito@gmail.com",
                RolId = 2,
                UserPassword = "pedrito2009",
                UsuarioId = 3
            };


            mockRepository.Setup(x => x.RegisterUser(u3))
                        .Returns(true);

            var handler = new RegisterUserHandler(mockRepository.Object);

            RegisterUser ru = new RegisterUser(u3);

            var res = handler.Handle(ru, ct);

            Assert.IsTrue(res.Result);
        }

        [TestMethod]
        public void UnregisterRolTest()
        {
            mockRepository.Setup(x => x.UnregisterUser(1))
                        .Returns(true);

            var handler = new UnregisterUserHandler(mockRepository.Object);

            UnregisterUser uu = new UnregisterUser(1);

            var res = handler.Handle(uu, ct);

            Assert.IsTrue(res.Result);
        }

    }
}
