using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace caja_fiscal
{
    class ConexionBD
    {
        //String cadena = "Data Source-192.168.1.14;Initial Catalog-HNE002; Integrated Security-True";
        private static SqlConnection conectarbd;
        private static SqlConnectionStringBuilder builder;

        public ConexionBD()
        {
            //conectarbd.ConnectionString = cadena;
        

        }

        public static SqlConnectionStringBuilder CadenaDeConexion(string strUsuario, string strPassword)
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = "192.168.1.14";
            builder.InitialCatalog = "HNE002";
            builder.PersistSecurityInfo = false;
            builder.UserID = strUsuario;
            builder.Password = strPassword;
            builder.ApplicationName = "CajaFiscal";


            return builder;
        }

        public static bool fnLogin(string strUsuario, string strPassword)
        {
            //conectarbd.ConnectionString = cadena;
            conectarbd = new SqlConnection(CadenaDeConexion(strUsuario, strPassword).ConnectionString);


            try
            {
                conectarbd.Open();
                return true;
            } catch (SqlException se)
            {
                MessageBox.Show(se.Message);
                return false;
            }


        }
        public static SqlDataAdapter almacenarDatos (string SQL)
        {
            SqlDataAdapter sda = new SqlDataAdapter(SQL, builder.ConnectionString); ;
            try
            {
                if (conectarbd.State != ConnectionState.Open)
                    conectarbd.Open();

             
                conectarbd.Close();

            }catch (SqlException se)
            {
                MessageBox.Show("FRM" + se.Number.ToString("000000") + " " + se.Message, "Informativo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informativo");
            }
            finally
            {
                if (conectarbd.State == ConnectionState.Open)
                    conectarbd.Close();
            }
            return sda;
        }
        public static DataSet ObtenerDatos(string SQL)
        {
            DataSet dt = new DataSet();
            try
            {
                if (conectarbd.State != ConnectionState.Open)
                    conectarbd.Open();

                SqlDataAdapter sda = new SqlDataAdapter(SQL, builder.ConnectionString);
                sda.Fill(dt);
                conectarbd.Close();

            }

            catch (SqlException se)
            {
                MessageBox.Show("FRM" + se.Number.ToString("000000") + " " + se.Message, "Informativo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informativo");
            }
            finally
            {
                if (conectarbd.State == ConnectionState.Open)
                    conectarbd.Close();
            }

                return dt;
        }

        public void abrir()
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("Conexion Abierta");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la BD "+ex.Message);
            }
         }
        public void cerrar()
        {
            conectarbd.Close();

        }
    }
}

