using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using OficiosPlenos.Dto;
using ScjnUtilities;
using System.Data;
using OficiosPlenos.Singletons;

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

            String sqlCadena = "SELECT * FROM Contradicciones " +
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

            String sqlCadena = "SELECT C.*, E.NombreCompleto, T.Abreviatura FROM (Contradicciones AS C INNER JOIN EncargadoPleno AS E " + 
                " ON C.IdEncargado = E.IdEncargado) INNER JOIN C_Titulo T ON E.IdTitulo = T.IdTitulo " +
                " ORDER BY C.AnioAsunto DESC , C.NumAsunto";

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
                        contradiccion.IdContradiccion = Convert.ToInt32(reader["IdContradiccion"]);
                        contradiccion.IdEncargado = Convert.ToInt32(reader["IdEncargado"]);
                        contradiccion.EncargadoStr = reader["NombreCompleto"].ToString();
                        contradiccion.Titulo = reader["Abreviatura"].ToString();
                        contradiccion.IdPleno = Convert.ToInt32(reader["IdPleno"]);
                        contradiccion.NumAsunto = Convert.ToInt32(reader["NumAsunto"]);
                        contradiccion.AnioAsunto = Convert.ToInt32(reader["AnioAsunto"]);
                        contradiccion.OficioAdmision = reader["OficioAdmision"].ToString();
                        contradiccion.FechaOficioAdmin = DateTimeUtilities.GetDateFromReader(reader, "FechaAdminOficio");
                        contradiccion.OficioFilePath = reader["RutaArchivoOficio"].ToString();
                        contradiccion.FechaCorreo = DateTimeUtilities.GetDateFromReader(reader, "FechaAdminCorreo");
                        contradiccion.CorreoFilePath = reader["RutaArchivoCorreo"].ToString();
                        contradiccion.OficioSga = reader["OficioSga"].ToString();
                        contradiccion.FEnvioOfSga = DateTimeUtilities.GetDateFromReader(reader, "FEnvioOfSga");
                        contradiccion.FEnvioOfSgaInt = Convert.ToInt32(reader["FEnvioOfSgaInt"]);
                        contradiccion.OfEnviadoSgaFilePath = reader["OfEnviadoSgaFilePath"].ToString();
                        contradiccion.OficioRespuestaSga = reader["OficioRespuestaSga"].ToString();
                        contradiccion.FRespuestaSga = DateTimeUtilities.GetDateFromReader(reader, "FRespuestaSga");
                        contradiccion.FRespuestaSgaInt = Convert.ToInt32(reader["FRespuestaSgaInt"]);
                        contradiccion.ExisteContradiccion = Convert.ToBoolean(reader["ExisteContradiccion"]);
                        contradiccion.OfRespuestaSgaFilePath = reader["ArchivoRespuestaSga"].ToString();
                        contradiccion.OficioSgaGenerado = Convert.ToBoolean(reader["OficioGeneradoSga"]);

                        contradiccion.OficioPlenos = reader["OficioPleno"].ToString();
                        contradiccion.FEnvioOfPlenos = DateTimeUtilities.GetDateFromReader(reader, "FEnvioOfPleno");
                        contradiccion.FEnvioOfPlenosInt = Convert.ToInt32(reader["FEnvioOfPlenoInt"]);
                        contradiccion.OficioPlenoGenerado = Convert.ToBoolean(reader["OficioGeneradoPleno"]);
                        contradiccion.OPlenoFilePath = reader["RutaOficioPleno"].ToString();
                        contradiccion.PlenoStr = (from n in OrganismoSingleton.Plenos
                                                  where n.IdOrganismo == contradiccion.IdPleno
                                                  select n.OrganismoDesc).ToList()[0];



                        contradiccion.Tema = reader["Tema"].ToString();
                        
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

                string sqlQuery = "INSERT INTO Contradicciones(IdContradiccion,IdPleno,IdEncargado,NumAsunto,AnioAsunto,OficioAdmision,FechaAdminOficio,FechaAdminOficioInt,RutaArchivoOficio,FechaAdminCorreo,FechaAdminCorreoInt,RutaArchivoCorreo,Tema)" +
                                  "VALUES (@IdContradiccion,@IdPleno,@IdEncargado,@NumAsunto,@AnioAsunto,@OficioAdmision,@FechaAdminOficio,@FechaAdminOficioInt,@RutaArchivoOficio,@FechaAdminCorreo,@FechaAdminCorreoInt,@RutaArchivoCorreo,@Tema)";

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
                cmd.Parameters.AddWithValue("@Tema", contradiccion.Tema);

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


        public bool UpdateContradiccion(Contradiccion contradiccion)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            bool completed = false;

            try
            {
                string sqlCadena = "SELECT * FROM Contradicciones WHERE IdContradiccion = @IdContradiccion";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@IdContradiccion", contradiccion.IdContradiccion);
                dataAdapter.Fill(dataSet, "Contradicciones");

                dr = dataSet.Tables["Contradicciones"].Rows[0];
                dr.BeginEdit();
                dr["NumAsunto"] = contradiccion.NumAsunto;
                dr["AnioAsunto"] = contradiccion.AnioAsunto;
                dr["OficioAdmision"] = contradiccion.OficioAdmision;
                if (contradiccion.FechaOficioAdmin != null)
                {
                    dr["FechaAdminOficio"] = contradiccion.FechaOficioAdmin;
                    dr["FechaAdminOficioInt"] = DateTimeUtilities.DateToInt(contradiccion.FechaOficioAdmin);
                }
                else
                {
                    dr["FechaAdminOficio"] = System.DBNull.Value;
                    dr["FechaAdminOficioInt"] = 0;
                }
                dr["@RutaArchivoOficio"] = contradiccion.OficioFilePath;

                if (contradiccion.FechaCorreo != null)
                {
                    dr["@FechaAdminCorreo"] = contradiccion.FechaCorreo;
                    dr["@FechaAdminCorreoInt"] = contradiccion.FechaCorreoInt;
                }
                else
                {
                    dr["@FechaAdminCorreo"] = System.DBNull.Value;
                    dr["@FechaAdminCorreoInt"] = 0;
                }

                dr["@RutaArchivoCorreo"] = contradiccion.CorreoFilePath;
                dr["@Tema"] = contradiccion.Tema;
                dr["IdContradiccion"] = contradiccion.IdContradiccion;

                dr.EndEdit();

                dataAdapter.UpdateCommand = connection.CreateCommand();

                dataAdapter.UpdateCommand.CommandText = "UPDATE Contradicciones SET NumAsunto = @NumAsunto, AnioAsunto = @AnioAsunto, OficioAdmision = @OficioAdmision " +
                    " FechaAdminOficio = @FechaAdminOficio, FechaAdminOficioInt = @FechaAdminOficioInt, RutaArchivoOficio = @RutaArchivoOficio," +
                    " FechaAdminCorreo = @FechaAdminCorreo, FechaAdminCorreoInt = @FechaAdminCorreoInt, RutaArchivoCorreo = @RutaArchivoCorreo, Tema = @Tema " +
                                                        " WHERE IdContradiccion = @IdContradiccion";

                dataAdapter.UpdateCommand.Parameters.Add("@NumAsunto", OleDbType.VarChar, 0, "NumAsunto");
                dataAdapter.UpdateCommand.Parameters.Add("@AnioAsunto", OleDbType.VarChar, 0, "AnioAsunto");
                dataAdapter.UpdateCommand.Parameters.Add("@OficioAdmision", OleDbType.VarChar, 0, "OficioAdmision");
                dataAdapter.UpdateCommand.Parameters.Add("@FechaAdminOficio", OleDbType.Date, 0, "FechaAdminOficio");
                dataAdapter.UpdateCommand.Parameters.Add("@FechaAdminOficioInt", OleDbType.Numeric, 0, "FechaAdminOficioInt");
                dataAdapter.UpdateCommand.Parameters.Add("@RutaArchivoOficio", OleDbType.VarChar, 0, "RutaArchivoOficio");
                dataAdapter.UpdateCommand.Parameters.Add("@FechaAdminCorreo", OleDbType.Date, 0, "FechaAdminCorreo");
                dataAdapter.UpdateCommand.Parameters.Add("@FechaAdminCorreoInt", OleDbType.Numeric, 0, "FechaAdminCorreoInt");
                dataAdapter.UpdateCommand.Parameters.Add("@RutaArchivoCorreo", OleDbType.VarChar, 0, "RutaArchivoCorreo");
                dataAdapter.UpdateCommand.Parameters.Add("@Tema", OleDbType.VarChar, 0, "Tema");
                dataAdapter.UpdateCommand.Parameters.Add("@IdContradiccion", OleDbType.Numeric, 0, "IdContradiccion");

                dataAdapter.Update(dataSet, "Contradicciones");
                dataSet.Dispose();
                dataAdapter.Dispose();
                completed = true;
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
            return completed;
        }


        public bool UpdateSga(Contradiccion contradiccion)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            bool completed = false;

            try
            {
                string sqlCadena = "SELECT * FROM Contradicciones WHERE IdContradiccion = @IdContradiccion";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@IdContradiccion", contradiccion.IdContradiccion);
                dataAdapter.Fill(dataSet, "Contradicciones");

                dr = dataSet.Tables["Contradicciones"].Rows[0];
                dr.BeginEdit();
                dr["OficioSga"] = contradiccion.OficioSga;
                if (contradiccion.FEnvioOfSga != null)
                {
                    dr["FEnvioOfSga"] = contradiccion.FEnvioOfSga;
                    dr["FEnvioOfSgaInt"] = DateTimeUtilities.DateToInt(contradiccion.FEnvioOfSga);
                }
                else
                {
                    dr["FEnvioOfSga"] = System.DBNull.Value;
                    dr["FEnvioOfSgaInt"] = 0;
                }
                dr["OfEnviadoSgaFilePath"] = contradiccion.OfEnviadoSgaFilePath;
                dr["OficioRespuestaSga"] = contradiccion.OficioRespuestaSga;
                if (contradiccion.FRespuestaSga != null)
                {
                    dr["FRespuestaSga"] = contradiccion.FRespuestaSga;
                    dr["FRespuestaSgaInt"] = DateTimeUtilities.DateToInt(contradiccion.FRespuestaSga);
                }
                else
                {
                    dr["FRespuestaSga"] = System.DBNull.Value;
                    dr["FRespuestaSgaInt"] = 0;
                }
                dr["ExisteContradiccion"] = Convert.ToInt16(contradiccion.ExisteContradiccion);
                dr["ArchivoRespuestaSga"] = contradiccion.OfRespuestaSgaFilePath;
                dr["OficioGeneradoSga"] = Convert.ToInt16(contradiccion.OficioSgaGenerado);
                dr["IdContradiccion"] = contradiccion.IdContradiccion;

                dr.EndEdit();

                dataAdapter.UpdateCommand = connection.CreateCommand();

                dataAdapter.UpdateCommand.CommandText = "UPDATE Contradicciones SET OficioSga = @OficioSga,FEnvioOfSga = @FEnvioOfSga, FEnvioOfSgaInt = @FEnvioOfSgaInt, OfEnviadoSgaFilePath = @OfEnviadoSgaFilePath," +
                                                        "OficioRespuestaSga = @OficioRespuestaSga,FRespuestaSga = @FRespuestaSga,FRespuestaSgaInt = @FRespuestaSgaInt,ExisteContradiccion = @ExisteContradiccion, ArchivoRespuestaSga = @ArchivoRespuestaSga,OficioGeneradoSga = @OficioGeneradoSga " +
                                                        " WHERE IdContradiccion = @IdContradiccion";

                dataAdapter.UpdateCommand.Parameters.Add("@OficioSga", OleDbType.VarChar, 0, "OficioSga");
                dataAdapter.UpdateCommand.Parameters.Add("@FEnvioOfSga", OleDbType.Date, 0, "FEnvioOfSga");
                dataAdapter.UpdateCommand.Parameters.Add("@FEnvioOfSgaInt", OleDbType.Numeric, 0, "FEnvioOfSgaInt");
                dataAdapter.UpdateCommand.Parameters.Add("@OfEnviadoSgaFilePath", OleDbType.VarChar, 0, "OfEnviadoSgaFilePath");
                dataAdapter.UpdateCommand.Parameters.Add("@OficioRespuestaSga", OleDbType.VarChar, 0, "OficioRespuestaSga");
                dataAdapter.UpdateCommand.Parameters.Add("@FRespuestaSga", OleDbType.Date, 0, "FRespuestaSga");
                dataAdapter.UpdateCommand.Parameters.Add("@FRespuestaSgaInt", OleDbType.Numeric, 0, "FRespuestaSgaInt");
                dataAdapter.UpdateCommand.Parameters.Add("@ExisteContradiccion", OleDbType.Numeric, 0, "ExisteContradiccion");
                dataAdapter.UpdateCommand.Parameters.Add("@ArchivoRespuestaSga", OleDbType.VarChar, 0, "ArchivoRespuestaSga");
                dataAdapter.UpdateCommand.Parameters.Add("@OficioGeneradoSga", OleDbType.Numeric, 0, "OficioGeneradoSga");
                dataAdapter.UpdateCommand.Parameters.Add("@IdContradiccion", OleDbType.Numeric, 0, "IdContradiccion");

                dataAdapter.Update(dataSet, "Contradicciones");
                dataSet.Dispose();
                dataAdapter.Dispose();
                completed = true;
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
            return completed;
        }

        public bool UpdatePlenos(Contradiccion contradiccion)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            bool completed = false;

            try
            {
                string sqlCadena = "SELECT * FROM Contradicciones WHERE IdContradiccion = @IdContradiccion";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@IdContradiccion", contradiccion.IdContradiccion);
                dataAdapter.Fill(dataSet, "Contradicciones");

                dr = dataSet.Tables["Contradicciones"].Rows[0];
                dr.BeginEdit();
                dr["OficioPleno"] = contradiccion.OficioPlenos;
                if (contradiccion.FEnvioOfPlenos != null)
                {
                    dr["FEnvioOfPleno"] = contradiccion.FEnvioOfPlenos;
                    dr["FEnvioOfPlenoInt"] = DateTimeUtilities.DateToInt(contradiccion.FEnvioOfPlenos);
                }
                else
                {
                    dr["FEnvioOfPleno"] = System.DBNull.Value;
                    dr["FEnvioOfPlenoInt"] = 0;
                }
                dr["OficioGeneradoPleno"] = Convert.ToInt16(contradiccion.OficioPlenoGenerado);
                dr["RutaOficioPleno"] = contradiccion.OPlenoFilePath;
                dr["IdContradiccion"] = contradiccion.IdContradiccion;
                
                dr.EndEdit();

                dataAdapter.UpdateCommand = connection.CreateCommand();

                dataAdapter.UpdateCommand.CommandText = "UPDATE Contradicciones SET OficioPleno = @OficioPleno,FEnvioOfPleno = @FEnvioOfPleno," +
                                                        "FEnvioOfPlenoInt = @FEnvioOfPlenoInt, OficioGeneradoPleno = @OficioGeneradoPleno,RutaOficioPleno = @RutaOficioPleno " +
                                                        " WHERE IdContradiccion = @IdContradiccion";

                dataAdapter.UpdateCommand.Parameters.Add("@OficioPleno", OleDbType.VarChar, 0, "OficioPleno");
                dataAdapter.UpdateCommand.Parameters.Add("@FEnvioOfPleno", OleDbType.Date, 0, "FEnvioOfPleno");
                dataAdapter.UpdateCommand.Parameters.Add("@FEnvioOfPlenoInt", OleDbType.Numeric, 0, "FEnvioOfPlenoInt");
                dataAdapter.UpdateCommand.Parameters.Add("@OficioGeneradoPleno", OleDbType.Numeric, 0, "OficioGeneradoPleno");
                dataAdapter.UpdateCommand.Parameters.Add("@RutaOficioPleno", OleDbType.VarChar, 0, "RutaOficioPleno");
                dataAdapter.UpdateCommand.Parameters.Add("@IdContradiccion", OleDbType.Numeric, 0, "IdContradiccion");

                dataAdapter.Update(dataSet, "Contradicciones");
                dataSet.Dispose();
                dataAdapter.Dispose();
                completed = true;
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
            return completed;
        }
    }
}