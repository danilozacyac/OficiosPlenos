using System;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using OficiosPlenos.Dto;
using ScjnUtilities;

namespace OficiosPlenos.Model
{
    public class OficiosModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Contra"].ToString();


        public Oficios GetOficioSga()
        {
            Oficios oficio = new Oficios();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Oficios WHERE TipoOficio = 1";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        oficio.Parrafo1 = reader["Parrafo1"].ToString();
                        oficio.Parrafo2 = reader["Parrafo2"].ToString();
                        oficio.Parrafo3 = reader["Parrafo3"].ToString();
                        oficio.Parrafo4 = reader["Parrafo4"].ToString();
                        oficio.Parrafo5 = reader["Parrafo5"].ToString();
                        oficio.Firma = reader["Firma"].ToString();
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OficiosModel", "OficiosPleno");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OficiosModel", "OficiosPleno");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return oficio;
        }

    }
}
