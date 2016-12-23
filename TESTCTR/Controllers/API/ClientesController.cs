using System;
using System.Collections.Generic;
using System.Linq;


using System.Web.Http;
using System.Web.Mvc;
using System.Text;
using System.Net.Http;


using TESTCTR.Models;
using TESTCTR.BLL;
using Newtonsoft.Json;

namespace TESTCTR.Controllers.API
{
    public class ClientesController : ApiController
    {
        private List<mVentas_Cliente> lstClientes = new List<mVentas_Cliente>(); 

        // GET: api/Clientes
        public IEnumerable<mVentas_Cliente> Get()
        {
            lstClientes = bVentas_Clientes.ObtenerClientes();
            return lstClientes;
        }

        // GET: api/Clientes/5
        public mVentas_Cliente Get(int id)
        {
            lstClientes = bVentas_Clientes.ObtenerClientes();
            return lstClientes.Find(p => p.ID_Cliente == id);

            throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
        }


        public HttpResponseMessage PostNuevoCliente(mVentas_Cliente cliente)
        {
            if (!ModelState.IsValid)
            {           
                var erroresmodelo = ModelState.Values
                                .Where(e => e.Errors.Any())
                                .Select(e => e.Errors.First().ErrorMessage)
                                .ToArray();

               var errores =  JsonConvert.SerializeObject(erroresmodelo);
                //foreach (var state in ModelState)
                //{
                //    foreach (var error in state.Value.Errors)
                //    {
                //        sb.Append(error.ErrorMessage);
                //    }
                //};
                //var message = sb.ToString();
                HttpError err = new HttpError(errores);
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, err);
            }
           
                bVentas_Clientes.Actualizar(cliente);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, cliente);
        }

        //public HttpResponseMessage Put(mVentas_Cliente cliente)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var erroresmodelo = ModelState.Values
        //                        .Where(e => e.Errors.Any())
        //                        .Select(e => e.Errors.First().ErrorMessage)
        //                        .ToArray();

        //        var errores = JsonConvert.SerializeObject(erroresmodelo);

        //        HttpError err = new HttpError(errores);
        //        return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, err);
        //    }

        //    bVentas_Clientes.Actualizar(cliente);
        //    return Request.CreateResponse(System.Net.HttpStatusCode.OK, cliente);
        //}


        public void Delete(int id)
        {
            bVentas_Clientes.Borrar(id);
        }
    }
}
