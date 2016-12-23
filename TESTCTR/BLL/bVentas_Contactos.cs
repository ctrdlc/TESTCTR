using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TESTCTR.DAL;
using TESTCTR.Models;

namespace TESTCTR.BLL
{
    public class bVentas_Contactos
    {
        public static List<mVentas_Contacto> ObtenerContactos()
        {
            return dVentas_Contactos.DatObtenerContactos();
        }

        public static mVentas_Contacto Actualizar(mVentas_Contacto Contacto)
        {
            if (Contacto.ID_contacto == 50)
            {
                throw new Exception("El contacto no puede ser el 50");
            }

            return dVentas_Contactos.DatActualizar(Contacto);
        }

        public static bool Borrar(Int32 intID_Contacto)
        {
            return dVentas_Contactos.DatBorrar(intID_Contacto);
        }


    }
}