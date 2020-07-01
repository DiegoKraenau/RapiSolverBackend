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
using RapiSolver.Infrastructure.Mediatr.Reservation.Command;
using RapiSolver.Infrastructure.Mediatr.Reservation.Handler;
using RapiSolver.Infrastructure.Mediatr.Reservation.Query;

namespace Test
{
    [TestClass]
    public class ReservationTest
    {
        private static List<ReservationDTO> listaReservationsDTO = new List<ReservationDTO>();
        private static List<Reservation> listaReservations = new List<Reservation>();
        private static CancellationToken ct = new CancellationToken();
        Mock<IReservationRepository> mockRepository = new Mock<IReservationRepository>();

        [ClassInitialize()]
        public static void Setup(TestContext context)
        {

            ReservationDTO reservationDto1 = new ReservationDTO
            {
                ReservationId = 1,
                ServicioId = 1,
                ServicioName = "nombre servicio 1",
                ServicioCategory = "categoria 1",
                UsuarioId = 1,
                UsuarioName = "Juan",
                UsuarioLastName = "Ortega",
                SupplierId = 1,
                SupplierName = "Luis",
                SupplierLastName = "Gonzales",
                Fecha = "23/06/2020",
                Note = "Esta bien",
                NameSolicitante = "Ana",
            };

            ReservationDTO reservationDto2 = new ReservationDTO
            {
                ReservationId = 2,
                ServicioId = 2,
                ServicioName = "nombre servicio 2",
                ServicioCategory = "categoria 2",
                UsuarioId = 2,
                UsuarioName = "Marcos",
                UsuarioLastName = "Ramirez",
                SupplierId = 2,
                SupplierName = "Carlos",
                SupplierLastName = "Perez",
                Fecha = "23/06/2020",
                Note = "Esta bien",
                NameSolicitante = "Maria",
            };

            listaReservationsDTO.Add(reservationDto1);
            listaReservationsDTO.Add(reservationDto2);


            Reservation reservation1 = new Reservation
            {
                ReservationId = 1,
                ServicioId = 1,
                UsuarioId = 1,
                SupplierId = 1,
                Fecha = "23/06/2020",
                Note = "Esta bien"
            };

            Reservation reservation2 = new Reservation
            {
                ReservationId = 2,
                ServicioId = 2,
                UsuarioId = 2,
                SupplierId = 2,
                Fecha = "23/06/2020",
                Note = "Esta bien"
            };

            listaReservations.Add(reservation1);
            listaReservations.Add(reservation2);
        }

        [TestMethod]
        public void ShowReservationsTest()
        {
            mockRepository.Setup(x => x.ShowReservations())
                .Returns(listaReservations);

            var handler = new ShowReservationsHandler(mockRepository.Object);

            ShowReservations re = new ShowReservations();

            var res = handler.Handle(re, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void ShowReservationsByUserTest()
        {
            int userId = 1;

            mockRepository.Setup(x => x.ShowReservationsByUser(userId))
                .Returns(listaReservationsDTO.Where(y => y.UsuarioId == userId));

            var handler = new ShowReservationsByUserHandler(mockRepository.Object);

            ShowReservationsByUser re = new ShowReservationsByUser(userId);

            var res = handler.Handle(re, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void RegisterReservationTest()
        {
            Reservation reservation3 = new Reservation
            {
                ReservationId = 3,
                ServicioId = 3,
                UsuarioId = 3,
                SupplierId = 3,
                Fecha = "23/06/2020",
                Note = "Esta bien"
            };


            mockRepository.Setup(x => x.RegisterReservation(reservation3))
                        .Returns(true);

            var handler = new RegisterReservationHandler(mockRepository.Object);

            RegisterReservation re = new RegisterReservation(reservation3);

            var res = handler.Handle(re, ct);

            Assert.IsTrue(res.Result);
        }

        [TestMethod]
        public void SearchReservationTest()
        {
            int reservationId = 1;

            mockRepository.Setup(x => x.SearchReservation(reservationId))
                        .Returns(listaReservations.Where(y => y.ReservationId == reservationId).First);

            var handler = new SearchReservationHandler(mockRepository.Object);

            SearchReservation re = new SearchReservation(reservationId);

            var res = handler.Handle(re, ct);

            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void UnregisterReservation()
        {
            int reservationId = 1;

            mockRepository.Setup(x => x.UnregisterReservation(reservationId))
                        .Returns(true);

            var handler = new UnregisterReservationHandler(mockRepository.Object);

            UnregisterReservation ur = new UnregisterReservation(reservationId);

            var res = handler.Handle(ur, ct);

            Assert.IsTrue(res.Result);
        }


    }
}
