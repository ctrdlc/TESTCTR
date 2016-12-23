using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TESTCTR.Models
{
    public class mVentas_Contacto
    {
        [Key]
        public int ID_contacto { get; set; }

        public string Apellido_paterno { get; set; }
        public string Apellido_materno { get; set; }
        public string Nombres { get; set; }
        public string Correo_electronico { get; set; }
        public string Direccion { get; set; }
        public string Telefono_movil { get; set; }
        public string Telefono_fijo { get; set; }
        public DateTime Fecha_registro { get; set; }
    }
}