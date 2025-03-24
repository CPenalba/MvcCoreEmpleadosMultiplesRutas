using Microsoft.AspNetCore.Mvc;
using MvcCoreEmpleadosMultiplesRutas.Services;
using NugetApiModelsCPC;

namespace MvcCoreEmpleadosMultiplesRutas.Controllers
{
    public class EmpleadosController : Controller
    {
        private ServiceEmpleados service;

        public EmpleadosController(ServiceEmpleados service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Empleado> empleados = await this.service.GetEmpleadosAsync();
            List<string> oficios = await this.service.GetOficiosAsync();
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string oficio)
        {
            List<Empleado> empleados = await this.service.GetEmpleadosOficioAsync(oficio);
            List<string> oficios = await this.service.GetOficiosAsync();
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }
    }
}
