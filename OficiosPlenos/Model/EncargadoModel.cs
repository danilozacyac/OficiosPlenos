using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using OficiosPlenos.Dto;
using ScjnUtilities;

namespace OficiosPlenos.Model
{
    public class EncargadoModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Contra"].ToString();

        public ObservableCollection<Encargado> GetEncargados()
        {
            ObservableCollection<Encargado> listaEncargados = new ObservableCollection<Encargado>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM EncargadoPleno ORDER BY Apellidos";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Encargado encargado = new Encargado();
                        encargado.IdEncargado = Convert.ToInt32(reader["IdEncargado"]);
                        encargado.IdPleno = Convert.ToInt32(reader["IdPleno"]);
                        encargado.Nombre = reader["Nombre"].ToString();
                        encargado.NombreAlpha = StringUtilities.PrepareToAlphabeticalOrder(encargado.Nombre);
                        encargado.Apellido = reader["Apellidos"].ToString();
                        encargado.ApellidoAlpha = StringUtilities.PrepareToAlphabeticalOrder(encargado.Apellido);
                        encargado.Completo = reader["NombreCompleto"].ToString();
                        encargado.CompletoAlpha = StringUtilities.PrepareToAlphabeticalOrder(encargado.Completo);

                        listaEncargados.Add(encargado);
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadoModel", "OficiosPleno");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadoModel", "OficiosPleno");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return listaEncargados;
        }



        public Encargado GetEncargados(int idPleno)
        {
            Encargado encargado = null;

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM EncargadoPleno WHERE IdPleno = @IdPleno ORDER BY Apellidos";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdPleno", idPleno);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        encargado = new Encargado();
                        encargado.IdEncargado = Convert.ToInt32(reader["IdEncargado"]);
                        encargado.IdPleno = Convert.ToInt32(reader["IdPleno"]);
                        encargado.Nombre = reader["Nombre"].ToString();
                        encargado.NombreAlpha = StringUtilities.PrepareToAlphabeticalOrder(encargado.Nombre);
                        encargado.Apellido = reader["Apellidos"].ToString();
                        encargado.ApellidoAlpha = StringUtilities.PrepareToAlphabeticalOrder(encargado.Apellido);
                        encargado.Completo = reader["NombreCompleto"].ToString();
                        encargado.CompletoAlpha = StringUtilities.PrepareToAlphabeticalOrder(encargado.Completo);

                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadoModel", "OficiosPleno");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadoModel", "OficiosPleno");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return encargado;
        }



        public bool InsertaEncargado(Encargado encargado)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

            encargado.IdEncargado = DataBaseUtilities.GetNextIdForUse("EncargadoPleno", "IdEncargado", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO EncargadoPleno(IdEncargado, IdPleno,Nombre,Apellidos,NombreCompleto)" +
                                  "VALUES (@IdEncargado,@IdPleno,@Nombre,@Apellidos,@NombreCompleto)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdEncargado", encargado.IdEncargado);
                cmd.Parameters.AddWithValue("@IdPleno", encargado.IdPleno);
                cmd.Parameters.AddWithValue("@Nombre", encargado.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", encargado.Apellido);
                cmd.Parameters.AddWithValue("@NombreCompleto", encargado.Nombre + " " + encargado.Apellido);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                insertCompleted = true;
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadoModel", "OficiosPleno");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadoModel", "OficiosPleno");
            }
            finally
            {
                connection.Close();
            }

            return insertCompleted;
        }

    }
}
