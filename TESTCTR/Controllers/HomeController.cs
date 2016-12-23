using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TESTCTR.BLL;
using TESTCTR.Models;

namespace TESTCTR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult GetVentasClientes(string nombre, string direccion,string ciudad, string region, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {

            try
            {
                IEnumerable<mVentas_Cliente> lstClientes;
                lstClientes = bVentas_Clientes.ObtenerClientes();

                //if (!string.IsNullOrEmpty(nombre))
                //{
                //    lstClientes = lst.Where(p => p.Secuencia == (Int64)datosbusqueda.Campo01);
                //}
                //Nombre
                if (!string.IsNullOrEmpty(nombre))
                {
                    lstClientes = lstClientes.Where(p => p.NombreCliente.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                if (!string.IsNullOrEmpty(direccion))
                {
                    lstClientes = lstClientes.Where(p => p.Direccion.IndexOf(direccion, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                if (!string.IsNullOrEmpty(ciudad))
                {
                    lstClientes = lstClientes.Where(p => p.Ciudad.IndexOf(ciudad, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                if (!string.IsNullOrEmpty(region))
                {
                    lstClientes = lstClientes.Where(p => p.Region.IndexOf(region, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                
                return Json(new { Result = "OK", Records = lstClientes }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        //Apellido Paterno  Apellido Materno Nombre Contacto    Correo electronico  Telefono
        public JsonResult GetVentasContactos(string apellidop, string apellidom, string nombre, string correoe, string telefono, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                List<mVentas_Contacto> lstContactos = new List<mVentas_Contacto>();
                lstContactos = bVentas_Contactos.ObtenerContactos();
                return Json(new { Result = "OK", Records = lstContactos }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Funcionamiento de la aplicacion";

            return View();
        }

    }
}