using OficiosPlenos.Dto;
using ScjnUtilities;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Windows;

namespace OficiosPlenos.Model
{
   public  class OrganismoModel
    {

       private readonly string connectionString = ConfigurationManager.ConnectionStrings["Directorio"].ToString();

        public ObservableCollection<Organismo> GetOrganismo(int tipoOrganismo)
        {
            ObservableCollection<Organismo> listaOrganismos = new ObservableCollection<Organismo>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT O.*, C.Ciudad, E.Abrev " +
                               "FROM Organismos O INNER JOIN (Ciudades C INNER JOIN Estados E ON C.IdEstado = E.IdEstado) " +
                               " ON O.Ciudad = C.IdCiudad WHERE TpoOrg = " + tipoOrganismo + " ORDER BY OrdenImpr";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //int age = reader["Age"] as int? ?? -1;
                        Organismo organismoAdd = new Organismo();
                        organismoAdd.IdOrganismo = reader["IdOrg"] as int? ?? -1;
                        organismoAdd.OrganismoDesc = reader["Organismo"].ToString();

                        listaOrganismos.Add(organismoAdd);
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismoModel", "OficiosPleno");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismoModel", "OficiosPleno");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return listaOrganismos;
        }

        public Organismo GetOrganismoPorId(int idOrganismo)
        {
            Organismo organismo = new Organismo();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT O.*, C.Ciudad, E.Abrev " +
                               "FROM Organismos O INNER JOIN (Ciudades C INNER JOIN Estados E ON C.IdEstado = E.IdEstado) ON O.Ciudad = C.IdCiudad WHERE IdOrg = " + idOrganismo + " ORDER BY OrdenImpr";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //int age = reader["Age"] as int? ?? -1;
                        organismo.IdOrganismo = reader["IdOrg"] as int? ?? -1;
                        organismo.OrganismoDesc = reader["Organismo"].ToString();
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismoModel", "OficiosPleno");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismoModel", "OficiosPleno");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return organismo;
        }

    }
}
