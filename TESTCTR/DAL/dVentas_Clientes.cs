using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TESTCTR.Models;

namespace TESTCTR.DAL
{
    public class dVentas_Clientes
    {
        public static List<mVentas_Cliente> DatObtenerClientes()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Server=.;Database=TEST;User ID=sa;Password=ctranddlcmp1.;";

            cn.Open();
            //Declarammos sqlcommand
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM ventas_clientes";

            var Resultado = new System.Collections.Generic.List<mVentas_Cliente>();
            dynamic dataread = cm.ExecuteReader();
            while (dataread.Read())
            {
                var dataCliente = new mVentas_Cliente();
                dataCliente.ID_Cliente = Convert.ToInt32(dataread.GetValue(0));
                dataCliente.NombreCliente = dataread.GetValue(1).ToString();
                dataCliente.ID_Contacto = Convert.ToInt32(dataread.GetValue(2));
                dataCliente.Direccion = dataread.GetValue(3).ToString();
                dataCliente.Ciudad = dataread.GetValue(4).ToString();
                dataCliente.Region = dataread.GetValue(5).ToString();
                dataCliente.CodigoPostal = dataread.GetValue(6).ToString();

                dataCliente.Pais = dataread.GetValue(7).ToString();
                dataCliente.Telefono = dataread.GetValue(8).ToString();
                dataCliente.email = dataread.GetValue(9).ToString();

                Resultado.Add(dataCliente);

            }
            cn.Close();
            return Resultado;
        }

        public static mVentas_Cliente DatActualizar(mVentas_Cliente Cliente)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.;Database=TEST;User ID=sa;Password=ctranddlcmp1.;";
            try
            {
                SqlCommand cm = new SqlCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "sp_VentasClientesCUD";
                cm.Connection = myConnection;

                cm.Parameters.AddWithValue("@ID_Cliente", Cliente.ID_Cliente);
                cm.Parameters.AddWithValue("@NombreCliente", Cliente.NombreCliente);
                cm.Parameters.AddWithValue("@ID_Contacto", Cliente.ID_Contacto);
                cm.Parameters.AddWithValue("@Direccion", Cliente.Direccion);
                cm.Parameters.AddWithValue("@Ciudad", Cliente.Ciudad);
                cm.Parameters.AddWithValue("@Region", Cliente.Region);
                cm.Parameters.AddWithValue("@CodigoPostal", Cliente.CodigoPostal);
                cm.Parameters.AddWithValue("@Pais", Cliente.Pais);
                cm.Parameters.AddWithValue("@Telefono", Cliente.Telefono);
                cm.Parameters.AddWithValue("@email", Cliente.email);

                SqlParameter outputIdParam = new SqlParameter("@ID_ClienteOUT", SqlDbType.Int);
                outputIdParam.Direction = ParameterDirection.Output;
                cm.Parameters.Add(outputIdParam);

                myConnection.Open();
                int rowInserted = cm.ExecuteNonQuery();

                Cliente.ID_Cliente = Convert.ToInt32(outputIdParam.Value);

                return Cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }


        }

        public static bool DatBorrar(Int32 IntID_Cliente)
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.;Database=TEST;User ID=sa;Password=ctranddlcmp1.;";
            try
            {
                SqlCommand cm = new SqlCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "sp_VentasClientesBorrar";
                cm.Connection = myConnection;

                cm.Parameters.AddWithValue("@ID_Cliente", IntID_Cliente);


                myConnection.Open();
                int rowInserted = cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }


        }

    }
}