using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using OficiosPlenos.Dto;
using OficiosPlenos.Model;
using OficiosPlenos.OficiosFolder;
using ScjnUtilities;

namespace OficiosPlenos
{
    /// <summary>
    /// Interaction logic for OficiosPleno.xaml
    /// </summary>
    public partial class OficiosPleno : Window
    {

        Contradiccion contradiccion;

        public OficiosPleno(Contradiccion contradiccion)
        {
            InitializeComponent();
            this.contradiccion = contradiccion;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = contradiccion;

            if (contradiccion.OficioPlenoGenerado)
            {
                BtnVeroficio.Visibility = Visibility.Visible;
            }
            else
            {
                BtnVeroficio.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ContradiccionModel model = new ContradiccionModel();
            model.UpdatePlenos(contradiccion);

            this.Close();
        }

        private void BtnGenerarOficio_Click(object sender, RoutedEventArgs e)
        {
            Oficios oficio = new OficiosModel().GetOficioNoContradiccion();
            string oficioGenPath = "SgaE" + DateTimeUtilities.DateToInt(contradiccion.FEnvioOfPlenos) + contradiccion.AnioAsunto + StringUtilities.SetCeros(contradiccion.NumAsunto.ToString()) + contradiccion.IdPleno + ".docx";
            GeneraOficio genera = new GeneraOficio(oficio,contradiccion, oficioGenPath);

            if (contradiccion.ExisteContradiccion)
                contradiccion.OficioPlenoGenerado = genera.GetOficioContradiccion();
            else
                contradiccion.OficioPlenoGenerado = genera.GetOficioNoContradiccion();

            if (contradiccion.OficioPlenoGenerado)
                BtnGenerarOficio.Visibility = Visibility.Collapsed;
            else
                MessageBox.Show("No se pudo generar correctamente el oficio");
        }

        private void BtnVeroficio_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(contradiccion.OficioPlenos);
        }
    }
}
