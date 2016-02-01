using System;
using System.Data.OleDb;
using System.Linq;
using OficiosPlenos.Dto;
using ScjnUtilities;
using System.Configuration;
using System.Collections.ObjectModel;

namespace OficiosPlenos.Model
{
    public class TituloModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Contra"].ToString();

        public ObservableCollection<Titulo> GetTitulo()
        {
            ObservableCollection<Titulo> listaTitulo = new ObservableCollection<Titulo>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM C_Titulo ORDER BY IdTitulo";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Titulo titulo = new Titulo();
                        titulo.IdTitulo = Convert.ToInt32(reader["IdTitulo"]);
                        titulo.TituloDesc = reader["Titulo"].ToString();
                        titulo.Abreviatura = reader["Abreviatura"].ToString();

                        listaTitulo.Add(titulo);
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TituloModel", "OficiosPleno");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TituloModel", "OficiosPleno");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return listaTitulo;
        }

    }
}
