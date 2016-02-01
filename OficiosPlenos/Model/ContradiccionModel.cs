using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using OficiosPlenos.Dto;
using ScjnUtilities;

namespace OficiosPlenos.Model
{
    public class ContradiccionModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Contra"].ToString();

        /// <summary>
        /// Verifica si la contradicción que se pretende ingresar ya fue capturada previamente
        /// </summary>
        /// <param name="asunto">Número de asunto de la contradicción</param>
        /// <param name="anio">Año del asunto de la contradicción</param>
        /// <param name="idPleno">Identificador de el pleno que emite la contradicción</param>
        /// <returns></returns>
        public bool ContradiccionExists(int asunto, int anio, int idPleno)
        {
            bool existe = false;

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Contradicciones "+ 
                "WHERE IdPleno = @IdPleno AND NumAsunto = @NumAsunto AND AnioAsunto = @AnioAsunto";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdPleno", idPleno);
                cmd.Parameters.AddWithValue("@NumAsunto", asunto);
                cmd.Parameters.AddWithValue("@AnioAsunto", anio);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        existe = true;
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ContradiccionModel", "OficiosPleno");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ContradiccionModel", "OficiosPleno");
            }
            finally
            {
                oleConne.Close();
            }

            return existe;
        }


        public ObservableCollection<Contradiccion> GetContradiccion()
        {
            ObservableCollection<Contradiccion> listaContradicciones = new ObservableCollection<Contradiccion>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Contradicciones ORDER BY AnioAsunto desc,NumAsunto asc";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Contradiccion contradiccion = new Contradiccion();
                        contradiccion.IdEncargado = Convert.ToInt32(reader["IdEncargado"]);
                        contradiccion.IdPleno = Convert.ToInt32(reader["IdPleno"]);
                        contradiccion.NumAsunto = Convert.ToInt32(reader["NumAsunto"]);
                        contradiccion.AnioAsunto = Convert.ToInt32(reader["AnioAsunto"]);
                        contradiccion.OficioAdmision = reader["OficioAdmision"].ToString();

                        listaContradicciones.Add(contradiccion);
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ContradiccionModel", "OficiosPleno");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ContradiccionModel", "OficiosPleno");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return listaContradicciones;
        }


        public bool InsertaContradiccion(Contradiccion contradiccion)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

            contradiccion.IdContradiccion = DataBaseUtilities.GetNextIdForUse("Contradicciones", "IdContradiccion", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Contradicciones(IdContradiccion,IdPleno,IdEncargado,NumAsunto,AnioAsunto,OficioAdmision,FechaAdminOficio,FechaAdminOficioInt,RutaArchivoOficio,FechaAdminCorreo,FechaAdminCorreoInt,RutaArchivoCorreo)" +
                                  "VALUES (@IdContradiccion,@IdPleno,@IdEncargado,@NumAsunto,@AnioAsunto,@OficioAdmision,@FechaAdminOficio,@FechaAdminOficioInt,@RutaArchivoOficio,@FechaAdminCorreo,@FechaAdminCorreoInt,@RutaArchivoCorreo)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdContradiccion", contradiccion.IdContradiccion);
                cmd.Parameters.AddWithValue("@IdPleno", contradiccion.IdPleno);
                cmd.Parameters.AddWithValue("@IdEncargado", contradiccion.Encargado.IdEncargado);
                cmd.Parameters.AddWithValue("@NumAsunto", contradiccion.NumAsunto);
                cmd.Parameters.AddWithValue("@AnioAsunto", contradiccion.AnioAsunto);
                cmd.Parameters.AddWithValue("@OficioAdmision", contradiccion.OficioAdmision);

                if (contradiccion.FechaOficioAdmin != null)
                {
                    
                    cmd.Parameters.AddWithValue("@FechaAdminOficio", contradiccion.FechaOficioAdmin);
                    cmd.Parameters.AddWithValue("@FechaAdminOficioInt", contradiccion.FechaOficioAdminInt);
                    
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FechaAdminOficio", System.DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaAdminOficioInt", 0);
                }
                cmd.Parameters.AddWithValue("@RutaArchivoOficio", contradiccion.OficioFilePath);

                if (contradiccion.FechaCorreo != null)
                {
                    cmd.Parameters.AddWithValue("@FechaAdminCorreo", contradiccion.FechaCorreo);
                    cmd.Parameters.AddWithValue("@FechaAdminCorreoInt", contradiccion.FechaCorreoInt);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FechaAdminCorreo", System.DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaAdminCorreoInt", 0);
                }

                cmd.Parameters.AddWithValue("@RutaArchivoCorreo", contradiccion.CorreoFilePath);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                insertCompleted = true;
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ContradiccionModel", "OficiosPleno");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ContradiccionModel", "OficiosPleno");
            }
            finally
            {
                connection.Close();
            }

            return insertCompleted;
        }
    }
}
