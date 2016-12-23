using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TESTCTR.Models;
using TESTCTR.DAL;

namespace TESTCTR.BLL
{
    public class bVentas_Clientes
    {
        public static List<mVentas_Cliente> ObtenerClientes()
        {
            return dVentas_Clientes.DatObtenerClientes();
        }


        public static mVentas_Cliente AgregarCliente(mVentas_Cliente Cliente)
        {

            if (Cliente.ID_Contacto == 50)
            {
                throw new Exception("El contacto no puede ser el 50");
            }

            return dVentas_Clientes.DatActualizar(Cliente);
        }

        public static mVentas_Cliente Actualizar(mVentas_Cliente Cliente)
        {

            if (Cliente.ID_Contacto == 50)
            {
                throw new Exception("El contacto no puede ser el 50");
            }

            return dVentas_Clientes.DatActualizar(Cliente);
        }

        public static bool Borrar(Int32 IntID_Cliente)
        {
            return dVentas_Clientes.DatBorrar(IntID_Cliente);
        }

    }
}