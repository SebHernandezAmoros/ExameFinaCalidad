using ContFinanci.web.Models;
using ContFinanci.web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContFinanci.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICuentaRepositories cuentaRepositories;
        private readonly ITransaccionRepositories transaccionRepositories;
        private readonly ITipoCambioRepositories tipoCambioRepositories;

        public HomeController(ILogger<HomeController> logger, ICuentaRepositories cuentaRepositories
            ,ITransaccionRepositories transaccionRepositories, ITipoCambioRepositories tipoCambioRepositories)
        {
            _logger = logger;
            this.cuentaRepositories = cuentaRepositories;
            this.transaccionRepositories = transaccionRepositories;
            this.tipoCambioRepositories = tipoCambioRepositories;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.TotalDolares = ObtenerTotalDolares();
            ViewBag.TotalSoles = ObtenerTotalSoles();
            ViewBag.TotalSolesConvert = ObtenerTotalSolesConvertidos();
            var listaCuenta = cuentaRepositories.ObtenerTodos();
            return View(listaCuenta);
        }
        [HttpGet]
        public IActionResult ViewIngresos(int id)
        {
            var cuentaAux = cuentaRepositories.ObtenerPorID(id).Nombre;
            var listaGastos = transaccionRepositories.ObtenerTodosCuentaIngreso(cuentaAux);
            return View(listaGastos);
        }
        [HttpGet]
        public IActionResult CreateIngreso()
        {
            ViewBag.cuentas = cuentaRepositories.ObtenerTodos();
            return View(new Transaccion());
        }
        [HttpPost]
        public IActionResult CreateIngreso(Transaccion transaccion)
        {
            ViewBag.cuentas = cuentaRepositories.ObtenerTodos();
            transaccion.Gasto = false;
            if (transaccion.Cuenta == null || transaccion.Cuenta == "")
            {
                ModelState.AddModelError("Cuenta", "La cuenta es obligatoria");
            }
            if (transaccion.Descripcion == null || transaccion.Descripcion == "")
            {
                ModelState.AddModelError("Descripcion", "La descripcion es obligatoria");
            }
            if (transaccion.Monto == 0)
            {
                ModelState.AddModelError("Monto", "El monto es obligatoria");
            }
            if (!ModelState.IsValid)
            {
                return View("CreateIngreso", transaccion);
            }
            var aux = cuentaRepositories.ObtenerNombre(transaccion.Cuenta);
            aux.SaldoInicial = aux.SaldoInicial + transaccion.Monto;
            cuentaRepositories.Actualizar(aux);
            transaccionRepositories.Guardar(transaccion);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ViewGastos(int id)
        {
            var cuentaAux = cuentaRepositories.ObtenerPorID(id).Nombre;
            var listaGastos = transaccionRepositories.ObtenerTodosCuentaGasto(cuentaAux);
            return View(listaGastos);
        }
        [HttpGet]
        public IActionResult CreateGasto()
        {
            ViewBag.cuentas = cuentaRepositories.ObtenerTodos();
            return View(new Transaccion());
        }
        [HttpPost]
        public IActionResult CreateGasto(Transaccion transaccion)
        {
            ViewBag.cuentas = cuentaRepositories.ObtenerTodos();
            transaccion.Gasto = true;
            if (transaccion.Monto > cuentaRepositories.ObtenerNombre(transaccion.Cuenta).SaldoInicial)
            {
                ModelState.AddModelError("Gasto", "El gasto es superior al monto total en esta cuenta");
            }
            if (transaccion.Cuenta == null || transaccion.Cuenta == "")
            {
                ModelState.AddModelError("Cuenta", "La cuenta es obligatoria");
            }
            if (transaccion.Descripcion == null || transaccion.Descripcion == "")
            {
                ModelState.AddModelError("Descripcion", "La descripcion es obligatoria");
            }
            if (transaccion.Monto == 0)
            {
                ModelState.AddModelError("Monto", "El monto es obligatoria");
            }
            if (!ModelState.IsValid)
            {
                return View("CreateGasto", transaccion);
            }
            var aux = cuentaRepositories.ObtenerNombre(transaccion.Cuenta);
            aux.SaldoInicial = aux.SaldoInicial - transaccion.Monto;
            cuentaRepositories.Actualizar(aux);
            transaccionRepositories.Guardar(transaccion);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCuenta()
        {
            return View(new Cuenta());
        }
        [HttpPost]
        public IActionResult CreateCuenta(Cuenta cuenta)
        {
            if (cuenta.Nombre == null || cuenta.Nombre == "")
            {
                ModelState.AddModelError("Nombre", "El nombre es obligatorio");
            }
            if (cuenta.SaldoInicial == 0)
            {
                ModelState.AddModelError("SaldoInicial", "El Saldo es obligatorio");
            }
            if (!ModelState.IsValid)
            {
                return View("CreateCuenta", cuenta);
            }
            cuentaRepositories.Guardar(cuenta);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public double ObtenerTotalDolares()
        {
            var listDolares = cuentaRepositories.ObtenerTodos();
            listDolares = listDolares.Where(o => o.Dolares == true).ToList();
            double aux=0;
            foreach (var item in listDolares)
            {
                aux = aux + item.SaldoInicial;
            }
            return aux;
        }
        public double ObtenerTotalSoles()
        {
            var list = cuentaRepositories.ObtenerTodos();
            list = list.Where(o => o.Dolares == false).ToList();
            double aux = 0;
            foreach (var item in list)
            {
                aux = aux + item.SaldoInicial;
            }
            return aux;
        }
        public double ObtenerTotalSolesConvertidos()
        {
            double TotalSoles = ObtenerTotalSoles();
            double TotalDolares = ObtenerTotalDolares();
            TotalDolares = TotalDolares * tipoCambioRepositories.ObtenerUltimo().DolarSol;
            return TotalDolares + TotalSoles;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
