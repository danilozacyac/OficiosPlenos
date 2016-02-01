using System;
using System.Collections.ObjectModel;
using System.Linq;
using OficiosPlenos.Dto;
using OficiosPlenos.Model;

namespace OficiosPlenos.Singletons
{
    public class TituloSingleton
    { 
        private static ObservableCollection<Titulo> titulos;

        private TituloSingleton()
        {
        }

        public static ObservableCollection<Titulo> Titulos
        {
            get
            {
                if (titulos == null)
                    titulos = new TituloModel().GetTitulo();

                return titulos;
            }
        }
    }
}
