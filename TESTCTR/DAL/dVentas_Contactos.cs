using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TESTCTR.Models;

namespace TESTCTR.DAL
{
    public class dVentas_Contactos
    {
        public static List<mVentas_Contacto> DatObtenerContactos()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Server=.;Database=TEST;User ID=sa;Password=ctranddlcmp1.;";

            cn.Open();
            //Declarammos sqlcommand
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Ventas_Contactos";

            var Resultado = new System.Collections.Generic.List<mVentas_Contacto>();
            dynamic dataread = cm.ExecuteReader();
            while (dataread.Read())
            {
                var dataContacto = new mVentas_Contacto();
                dataContacto.ID_contacto = Convert.ToInt32(dataread.GetValue(0));
                dataContacto.Apellido_paterno = dataread.GetValue(1).ToString();
                dataContacto.Apellido_materno = dataread.GetValue(2).ToString();
                dataContacto.Nombres = dataread.GetValue(3).ToString();
                dataContacto.Correo_electronico = dataread.GetValue(4).ToString();
                dataContacto.Direccion = dataread.GetValue(5).ToString();
                dataContacto.Telefono_movil = dataread.GetValue(6).ToString();

                dataContacto.Telefono_fijo = dataread.GetValue(7).ToString();
                dataContacto.Fecha_registro = dataread.GetValue(8);

                Resultado.Add(dataContacto);
            }
            cn.Close();
            return Resultado;
        }

        public static mVentas_Contacto DatActualizar(mVentas_Contacto Contacto)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.;Database=TEST;User ID=sa;Password=ctranddlcmp1.;";
            try
            {
                SqlCommand cm = new SqlCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "sp_VentasClientesCUD";
                cm.Connection = myConnection;

                cm.Parameters.AddWithValue("@ID_Contacto", Contacto.ID_contacto);
                cm.Parameters.AddWithValue("@Apellido_paterno", Contacto.Apellido_paterno);
                cm.Parameters.AddWithValue("@Apellido_materno", Contacto.Apellido_materno);
                cm.Parameters.AddWithValue("@Nombres", Contacto.Nombres);
                cm.Parameters.AddWithValue("@Correo_electronico", Contacto.Correo_electronico);
                cm.Parameters.AddWithValue("@Direccion", Contacto.Direccion);
                cm.Parameters.AddWithValue("@Telefono_movil", Contacto.Telefono_movil);
                cm.Parameters.AddWithValue("@Telefono_fijo", Contacto.Telefono_fijo);
                //cm.Parameters.AddWithValue("@Fecha_registro", Contacto.Fecha_registro);

                SqlParameter outputIdParam = new SqlParameter("@ID_ContactoOUT", SqlDbType.Int);
                outputIdParam.Direction = ParameterDirection.Output;
                cm.Parameters.Add(outputIdParam);

                myConnection.Open();
                int rowInserted = cm.ExecuteNonQuery();

                Contacto.ID_contacto = Convert.ToInt32(outputIdParam.Value);

                return Contacto;
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

        public static bool DatBorrar(Int32 intID_Contacto)
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.;Database=TEST;User ID=sa;Password=ctranddlcmp1.;";
            try
            {
                SqlCommand cm = new SqlCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "sp_VentasContactosBorrar";
                cm.Connection = myConnection;

                cm.Parameters.AddWithValue("@ID_Contacto", intID_Contacto);


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


