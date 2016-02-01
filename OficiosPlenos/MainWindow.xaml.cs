using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using OficiosPlenos.Dto;
using OficiosPlenos.Model;
using Telerik.Windows.Controls;

namespace OficiosPlenos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Contradiccion> listaContradicciones;


        public MainWindow()
        {
            InitializeComponent();
            StyleManager.ApplicationTheme = new Windows8Theme();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

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
    }
}
