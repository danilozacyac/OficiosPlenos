using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using OficiosPlenos.Dto;
using OficiosPlenos.Model;
using ScjnUtilities;
using OficiosPlenos.OficiosFolder;

namespace OficiosPlenos
{
    /// <summary>
    /// Interaction logic for SecGeneral.xaml
    /// </summary>
    public partial class SecGeneral : Window
    {
        private Contradiccion contradiccion;
        private string basePath = ConfigurationManager.AppSettings["BasePath"].ToString();

        public SecGeneral(Contradiccion contradiccion)
        {
            InitializeComponent();
            this.contradiccion = contradiccion;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = contradiccion;

            if (String.IsNullOrEmpty(contradiccion.OfRespuestaSgaFilePath))
                BtnVerRespuesta.IsEnabled = false;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            

            string respuestaPath = basePath + "SgaR" + DateTimeUtilities.DateToInt(contradiccion.FRespuestaSga) + contradiccion.AnioAsunto + StringUtilities.SetCeros(contradiccion.NumAsunto.ToString()) + contradiccion.IdPleno + Path.GetExtension(contradiccion.OfRespuestaSgaFilePath);

            if (!respuestaPath.Equals(contradiccion.OfRespuestaSgaFilePath) && !String.IsNullOrEmpty(contradiccion.OfRespuestaSgaFilePath))
            {
                if (!CopyToLocalResource(contradiccion.OfRespuestaSgaFilePath, respuestaPath))
                {
                    MessageBox.Show("No se pudo copiar el archivo, intentelo de nuevo");
                    return;
                }
                else
                {
                    contradiccion.OfRespuestaSgaFilePath = respuestaPath ;
                }
            }

            ContradiccionModel model = new ContradiccionModel();
            bool completed = model.UpdateSga(contradiccion);

            if (!completed)
            {
                MessageBox.Show("No se pudo completar la operación, favor de volver a intentarlo");
                return;
            }

            this.Close();
        }

        private void BtnFileRespuesta_Click(object sender, RoutedEventArgs e)
        {
            contradiccion.OfRespuestaSgaFilePath = this.GetFilePath();
        }

        private string GetFilePath()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Documents|*.doc;*.docx;*.pdf";

            dialog.InitialDirectory = @"C:\Users\" + Environment.UserName + @"\Documents";
            dialog.Title = "Selecciona el archivo del proyecto";
            dialog.ShowDialog();

            return dialog.FileName;
        }


        public static bool CopyToLocalResource(string currentPath, string newPath)
        {

            try
            {
                File.Copy(currentPath, newPath,true);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void BtnVerRespuesta_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(contradiccion.OfRespuestaSgaFilePath);
        }

        private void BtnGenerarOficio_Click(object sender, RoutedEventArgs e)
        {
            string oficioGenPath = basePath + "SgaE" + DateTimeUtilities.DateToInt(contradiccion.FRespuestaSga) + contradiccion.AnioAsunto + StringUtilities.SetCeros(contradiccion.NumAsunto.ToString()) + contradiccion.IdPleno + Path.GetExtension(contradiccion.OfRespuestaSgaFilePath);

            Oficios oficio = new OficiosModel().GetOficioSga();

            GeneraOficio genera = new GeneraOficio(oficio, oficioGenPath);
            genera.Sga();
        }

    }
}
