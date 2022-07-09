using ContFinanci.web.Controllers;
using ContFinanci.web.DB;
using ContFinanci.web.Models;
using ContFinanci.web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContFinanci.test.Controller
{
    class HomeControllerTest
    {
        HomeController homeController;
        Mock mockLogger;
        ILogger<HomeController> logger;
        private IQueryable data1;
        private IQueryable data2;
        private IQueryable data3;
        [SetUp]
        public void Setup()
        {
            mockLogger = new Mock<ILogger<HomeController>>();
            logger = (ILogger<HomeController>)mockLogger.Object;
            //------------------------------------------------------------------------------------------------------------------------
            data1 = new List<Cuenta>
            {
                new Cuenta{ CuentaId= 1, Dolares = false, Nombre= "Efectivo", 
                    Propio=true, SaldoInicial=300},
                new Cuenta{ CuentaId=2, Dolares = false, Nombre="Targeta de credito BCP",
                    Propio=false, SaldoInicial=200},
                new Cuenta{ CuentaId= 3, Dolares=true, Nombre="Targeta de credito BBVA",
                    Propio=false, SaldoInicial=300},
                new Cuenta{CuentaId= 4, Dolares=false, Nombre="Targeta Debito XYZ", 
                    Propio=true, SaldoInicial=50}
            }.AsQueryable();
            var mockDbsetCuenta = new Mock<DbSet<Cuenta>>();
            mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.Provider).Returns(data1.Provider);
            mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.Expression).Returns(data1.Expression);
            mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.ElementType).Returns(data1.ElementType);
            mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.GetEnumerator()).Returns((IEnumerator<Cuenta>)data1.GetEnumerator());
            var mockDB = new Mock<DbEntities>();
            mockDB.Setup(o => o.Cuentas).Returns(mockDbsetCuenta.Object);
            CuentaRepositories cuentaRepositorio = new CuentaRepositories(mockDB.Object);
            //------------------------------------------------------------------------------------------------------------------------
            data2 = new List<Transaccion>
            {
                new Transaccion{ TransaccionId=1, Cuenta="Efectivo", Descripcion="Compra lego", 
                    Fecha=DateTime.Now, Gasto=true, Monto=50},
                new Transaccion{ TransaccionId=2, Cuenta="Efectivo", Descripcion="Viveres", 
                    Fecha=DateTime.Now, Gasto=true, Monto=100},
                new Transaccion{ TransaccionId=3, Cuenta="Efectivo", Descripcion="Ahorro", 
                    Fecha=DateTime.Now, Gasto=false, Monto=25},
                new Transaccion{ TransaccionId=4, Cuenta="Targeta de credito BCP", Descripcion="Cine",
                    Fecha=DateTime.Now, Gasto=true, Monto=25},
            }.AsQueryable();
            var mockDbsetTransaccion = new Mock<DbSet<Transaccion>>();
            mockDbsetTransaccion.As<IQueryable<Transaccion>>().Setup(o => o.Provider).Returns(data2.Provider);
            mockDbsetTransaccion.As<IQueryable<Transaccion>>().Setup(o => o.Expression).Returns(data2.Expression);
            mockDbsetTransaccion.As<IQueryable<Transaccion>>().Setup(o => o.ElementType).Returns(data2.ElementType);
            mockDbsetTransaccion.As<IQueryable<Transaccion>>().Setup(o => o.GetEnumerator()).Returns((IEnumerator<Transaccion>)data2.GetEnumerator());
            var mockDB2 = new Mock<DbEntities>();
            mockDB2.Setup(o => o.Transaccions).Returns(mockDbsetTransaccion.Object);
            TransaccionRepositories transaccionRepositorio = new TransaccionRepositories(mockDB2.Object);
            //------------------------------------------------------------------------------------------------------------------------
            data3 = new List<TipoCambio>
            {
                new TipoCambio{ TipoCambioId=1, DolarSol=4.1, SolDolar=4.5},
                new TipoCambio{ TipoCambioId=1, DolarSol=4, SolDolar=4.3}
            }.AsQueryable();
            var mockDbsetTipoCambio = new Mock<DbSet<TipoCambio>>();
            mockDbsetTipoCambio.As<IQueryable<TipoCambio>>().Setup(o => o.Provider).Returns(data3.Provider);
            mockDbsetTipoCambio.As<IQueryable<TipoCambio>>().Setup(o => o.Expression).Returns(data3.Expression);
            mockDbsetTipoCambio.As<IQueryable<TipoCambio>>().Setup(o => o.ElementType).Returns(data3.ElementType);
            mockDbsetTipoCambio.As<IQueryable<TipoCambio>>().Setup(o => o.GetEnumerator()).Returns((IEnumerator<TipoCambio>)data3.GetEnumerator());
            var mockDB3 = new Mock<DbEntities>();
            mockDB3.Setup(o => o.TipoCambios).Returns(mockDbsetTipoCambio.Object);
            TipoCambioRepositories tipoCambioRepositorio = new TipoCambioRepositories(mockDB3.Object);
            //------------------------------------------------------------------------------------------------------------------------
            homeController = new HomeController(logger, cuentaRepositorio, transaccionRepositorio, tipoCambioRepositorio);
        }
        [Test]
        public void IndexTest()
        {
            var view = homeController.Index() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void ViewIngresosTest()
        {
            var view = homeController.ViewIngresos(2);
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void CreateIngresoCorrectTest()
        {
            var view = homeController.CreateIngreso(new Transaccion {
                TransaccionId=6, Cuenta= "Efectivo", Descripcion="Ahorro", Fecha=DateTime.Now , 
                Monto=100
            });
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
        [Test]
        public void CreateIngresoIncorrectTest()
        {
            var view = homeController.CreateIngreso(new Transaccion
            {
                TransaccionId = 6,
                Monto = 100
            });
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void ViewGastosTest()
        {
            var view = homeController.ViewGastos(2);
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void CreateGastoCorrectTest()
        {
            var view = homeController.CreateGasto(new Transaccion
            {
                TransaccionId = 7,
                Cuenta = "Efectivo",
                Descripcion = "Ahorro",
                Fecha = DateTime.Now,
                Monto = 100
            });
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
        [Test]
        public void CreateGastoIncorrectTest()
        {
            var view = homeController.CreateGasto(new Transaccion
            {
                Cuenta = "Efectivo",
                TransaccionId = 7,
                Monto = 100
            });
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void CreateCuentaCorrectTest()
        {
            var view = homeController.CreateCuenta(new Cuenta
            {
                CuentaId = 8,
                Dolares = true,
                Nombre = "Cuenta en el banco de la felicidad",
                Propio = true,
                SaldoInicial = 20
            });
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
        [Test]
        public void CreateCuentaIncorrectTest()
        {
            var view = homeController.CreateCuenta(new Cuenta
            {
                CuentaId = 8,
                Dolares = true,
                Propio = true,
                SaldoInicial = 20
            });
            Assert.IsInstanceOf<ViewResult>(view);
        }
    }
}
