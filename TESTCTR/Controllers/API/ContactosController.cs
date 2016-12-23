using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TESTCTR.BLL;
using TESTCTR.Models;

namespace TESTCTR.Controllers.API
{
    public class ContactosController : ApiController
    {
        private List<mVentas_Contacto> lstContactos = new List<mVentas_Contacto>();
        // GET: api/Contactos
        public IEnumerable<mVentas_Contacto> Get()
        {
            lstContactos = bVentas_Contactos.ObtenerContactos();
            return lstContactos;
        }

        // GET: api/Contactos/5
        public mVentas_Contacto Get(int id)
        {
            lstContactos = bVentas_Contactos.ObtenerContactos();
            return lstContactos.Find(p => p.ID_contacto == id);
        }

        //// POST: api/Contactos
        //public void Post([FromBody]string value)
        //{
        //}

        public IHttpActionResult PostNuevoContacto(mVentas_Contacto contacto)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        sb.Append(error.ErrorMessage);
                    }
                };
                throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = sb.ToString()
                });
            }

            bVentas_Contactos.Actualizar(contacto);
            return Ok();
        }

        //// PUT: api/Contactos/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Contactos/5
        public void Delete(int id)
        {
            bVentas_Contactos.Borrar(id);
        }
    }
}
