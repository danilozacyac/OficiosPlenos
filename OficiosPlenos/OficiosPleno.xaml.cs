using OficiosPlenos.Dto;
using OficiosPlenos.Model;
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
    }
}
