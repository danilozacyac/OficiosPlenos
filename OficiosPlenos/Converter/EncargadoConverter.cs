using System;
using System.Linq;
using System.Windows.Data;
using OficiosPlenos.Singletons;

namespace OficiosPlenos.Converter
{
    class EncargadoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    int number = 0;
                    int.TryParse(value.ToString(), out number);



                    return (from n in EncargadoSingleton.Encargados
                            where n.IdEncargado == number
                            select n.Completo).ToList()[0];
                }

                return " ";
            }
            catch (ArgumentOutOfRangeException) { return " "; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
