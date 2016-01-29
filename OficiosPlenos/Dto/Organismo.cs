using System;
using System.Linq;

namespace OficiosPlenos.Dto
{
    public class Organismo
    {
        private int idOrganismo;
        private String organismoDesc;
        private int idEncargado;
        private string nombreEncargado;
       

        public int IdOrganismo
        {
            get
            {
                return this.idOrganismo;
            }
            set
            {
                this.idOrganismo = value;
            }
        }

        public string OrganismoDesc
        {
            get
            {
                return this.organismoDesc;
            }
            set
            {
                this.organismoDesc = value;
            }
        }

        public int IdEncargado
        {
            get
            {
                return this.idEncargado;
            }
            set
            {
                this.idEncargado = value;
            }
        }

        public string NombreEncargado
        {
            get
            {
                return this.nombreEncargado;
            }
            set
            {
                this.nombreEncargado = value;
            }
        }
    }
}
