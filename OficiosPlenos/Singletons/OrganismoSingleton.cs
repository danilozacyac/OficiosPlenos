using System;
using System.Collections.ObjectModel;
using System.Linq;
using OficiosPlenos.Dto;
using OficiosPlenos.Model;
using System.Collections.Generic;

namespace OficiosPlenos.Singletons
{
    public class OrganismoSingleton
    {

       private static ObservableCollection<Organismo> plenos;

       private OrganismoSingleton()
        {
        }

       public static ObservableCollection<Organismo> Plenos
        {
            get
            {
                if (plenos == null)
                    plenos = new OrganismoModel().GetOrganismo(4);

                return plenos;
            }
        }
    }
}
