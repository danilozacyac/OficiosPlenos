using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using OficiosPlenos.Dto;
using OficiosPlenos.Model;
using Telerik.Windows.Controls;
using System.IO;
using System.Configuration;
using System.Windows.Controls;
using ScjnUtilities;

namespace OficiosPlenos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Contradiccion> listaContradicciones;
        Contradiccion selectedContradiccion;

        public MainWindow()
        {
            InitializeComponent();
            StyleManager.ApplicationTheme = new Windows8Theme();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (!Directory.Exists(ConfigurationManager.AppSettings["BasePath"].ToString()))
            {
                Directory.CreateDirectory(ConfigurationManager.AppSettings["BasePath"].ToString());
            }


            listaContradicciones = new ContradiccionModel().GetContradiccion();

            GContra.DataContext = listaContradicciones;
        }

        private void BtnAgregarContra_Click(object sender, RoutedEventArgs e)
        {
            AgregaAsunto agrega = new AgregaAsunto();
            agrega.Owner = this;
            agrega.ShowDialog();
        }

        private void AddEncargado_Click(object sender, RoutedEventArgs e)
        {
            AgregarEncargado agrega = new AgregarEncargado();
            agrega.Owner = this;
            agrega.ShowDialog();
        }

        private void BtnSga_Click(object sender, RoutedEventArgs e)
        {
            if(selectedContradiccion == null){
                MessageBox.Show("Primero debes seleccionar la contradicción de la cual se generará la información de la Secretaria General de Acuerdos");
                return;
            }

            SecGeneral general = new SecGeneral(selectedContradiccion);
            general.Owner = this;
            general.ShowDialog();

        }

        private void GContra_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            selectedContradiccion = GContra.SelectedItem as Contradiccion;
        }

        private void BtnOficioPlenos_Click(object sender, RoutedEventArgs e)
        {
            if (selectedContradiccion == null)
            {
                MessageBox.Show("Primero debes seleccionar la contradicción de la cual se generará la información de la Secretaria General de Acuerdos");
                return;
            }

            OficiosPleno plenos = new OficiosPleno(selectedContradiccion);
            plenos.Owner = this;
            plenos.ShowDialog();
        }

        private void BtnEditaContra_Click(object sender, RoutedEventArgs e)
        {
            if (selectedContradiccion == null)
            {
                MessageBox.Show("Primero debes seleccionar la contradicción que quieres modificar");
                return;
            }

            AgregaAsunto edita = new AgregaAsunto(selectedContradiccion);
            edita.Owner = this;
            edita.ShowDialog();
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
            {
                var resultado = (from n in listaContradicciones
                                 where StringUtilities.PrepareToAlphabeticalOrder(n.EncargadoStr).Contains(StringUtilities.PrepareToAlphabeticalOrder(tempString))
                                 select n).ToList();
                GContra.DataContext = resultado;
            }
            else
            {
                GContra.DataContext = listaContradicciones;
            }
        }
    }
}
