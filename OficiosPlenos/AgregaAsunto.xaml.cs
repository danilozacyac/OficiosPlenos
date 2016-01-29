using Microsoft.Win32;
using OficiosPlenos.Dto;
using OficiosPlenos.Model;
using OficiosPlenos.Singletons;
using ScjnUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OficiosPlenos
{
    /// <summary>
    /// Interaction logic for AgregaAsunto.xaml
    /// </summary>
    public partial class AgregaAsunto : Window
    {

        private Contradiccion contradiccion;
        private bool isUpdating = false;
        Organismo selectedOrganismo;

        public AgregaAsunto()
        {
            InitializeComponent();
            contradiccion = new Contradiccion();
        }

        public AgregaAsunto(Contradiccion contradiccion)
        {
            InitializeComponent();
            this.contradiccion = contradiccion;
            this.isUpdating = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxPlenos.DataContext = OrganismoSingleton.Plenos;
            this.DataContext = contradiccion;
        }

        private void TxtNumAsunto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = StringUtilities.IsTextAllowed(e.Text);
        }

        private void BtnOficio_Click(object sender, RoutedEventArgs e)
        {
           contradiccion.OficioFilePath = GetFilePath();
        }

        private void BtnCorreoFile_Click(object sender, RoutedEventArgs e)
        {
           contradiccion.CorreoFilePath = GetFilePath();
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

        private void CbxPlenos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedOrganismo = CbxPlenos.SelectedItem as Organismo;

            contradiccion.Encargado = (from n in EncargadoSingleton.Encargados
                                       where n.IdPleno == selectedOrganismo.IdOrganismo
                                       select n).ToList()[0];

        }

        private void TxtOficioAd_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(TxtOficioAd.Text))
            {
                DtpOficio.SelectedValue = null;
                DtpOficio.IsEnabled = false;
                BtnOficio.IsEnabled = false;
            }
            else
            {
                DtpOficio.IsEnabled = true;
                BtnOficio.IsEnabled = true;
            }
        }

        private void DtpCorreo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnCorreoFile.IsEnabled = true;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (isUpdating)
            {

            }
            else
            {
                if (selectedOrganismo == null)
                {
                    MessageBox.Show("Para ingresar una contradicción es necesario seleccionar el Pleno que la emite", "Atención:", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                contradiccion.IdPleno = selectedOrganismo.IdOrganismo;

                if (contradiccion.NumAsunto < 1)
                {
                    MessageBox.Show("Verifica el número de asunto", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (contradiccion.AnioAsunto < 2000 || contradiccion.AnioAsunto > DateTime.Now.Year)
                {
                    MessageBox.Show("Verifica que el año de asunto este entre 2000 y " + DateTime.Now.Year, "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!String.IsNullOrEmpty(contradiccion.OficioAdmision))
                {
                    if (contradiccion.FechaOficioAdmin == null)
                    {
                        MessageBox.Show("Ingresa la fecha de recepción del oficio", "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (String.IsNullOrEmpty(contradiccion.OficioFilePath))
                    {
                        MessageBox.Show("Selecciona la ubicación del oficio recibido", "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                if (contradiccion.FechaCorreo != null && String.IsNullOrEmpty(contradiccion.CorreoFilePath))
                {
                    MessageBox.Show("Selecciona la ubicación del oficio recibido por correo", "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                ContradiccionModel model = new ContradiccionModel();

                bool existe = model.ContradiccionExists(contradiccion.NumAsunto, contradiccion.AnioAsunto, contradiccion.IdPleno);

                if (existe)
                {
                    MessageBox.Show("El asunto que deseas ingresar ya fue capturado previamente", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    model.InsertaContradiccion(contradiccion);
                    this.Close();
                }
            }
        }

       

        
    }
}
