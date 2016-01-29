using System;
using System.Collections.ObjectModel;
using System.Linq;
using OficiosPlenos.Dto;
using OficiosPlenos.Model;

namespace OficiosPlenos.Singletons
{
    public class EncargadoSingleton
    {
        private static ObservableCollection<Encargado> encargados;

        private EncargadoSingleton()
        {
        }

        public static ObservableCollection<Encargado> Encargados
        {
            get
            {
                if (encargados == null)
                    encargados = new EncargadoModel().GetEncargados();

                return encargados;
            }
        }
    }
}
