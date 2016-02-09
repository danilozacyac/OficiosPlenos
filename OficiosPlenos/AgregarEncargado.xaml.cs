using System;
using System.Linq;
using System.Windows;
using OficiosPlenos.Dto;
using OficiosPlenos.Model;
using OficiosPlenos.Singletons;

namespace OficiosPlenos
{
    /// <summary>
    /// Interaction logic for AgregarEncargado.xaml
    /// </summary>
    public partial class AgregarEncargado : Window
    {

        private Encargado encargado;
        private bool isUpdating = false;

        public AgregarEncargado()
        {
            InitializeComponent();
            encargado = new Encargado();
        }


        public AgregarEncargado(Encargado encargado)
        {
            InitializeComponent();
            this.encargado = encargado;
            isUpdating = true;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxTitulo.DataContext = TituloSingleton.Titulos;
            CbxPlenos.DataContext = OrganismoSingleton.Plenos;
            this.DataContext = encargado;

            if (isUpdating)
                CbxPlenos.SelectedValue = encargado.IdEncargado;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (CbxTitulo.SelectedIndex == -1)
            {
                MessageBox.Show("Debes de seleccionar título del funcionario ");
                return;
            }

            if (CbxPlenos.SelectedIndex == -1)
            {
                MessageBox.Show("Debes de seleccionar el Pleno de Circuito del cual será encargado a partir de este momento");
                return;
            }

            encargado.IdPleno = Convert.ToInt32(CbxPlenos.SelectedValue);

            if (!isUpdating)
            {
                bool exito = new EncargadoModel().InsertaEncargado(encargado);

                if (!exito)
                {
                    MessageBox.Show("No se pudo completar la operación, vuelva a intentarlo más tarde"); 
                    return;
                }
                else
                {
                    EncargadoSingleton.Encargados.Add(encargado);
                    this.Close();
                }
            }

        }

        
    }
}
