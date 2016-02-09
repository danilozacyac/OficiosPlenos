using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficiosPlenos.Dto
{
    public class Oficios
    {

        private string encargado;
        private DateTime? fechaOficio;
        private string asunto;
        private string tema;

        private string parrafo1;
        private string parrafo2;
        private string parrafo3;
        private string parrafo4;
        private string parrafo5;
        private string parrafo6;
        private string firma;

        public string Encargado
        {
            get
            {
                return this.encargado;
            }
            set
            {
                this.encargado = value;
            }
        }

        public DateTime? FechaOficio
        {
            get
            {
                return this.fechaOficio;
            }
            set
            {
                this.fechaOficio = value;
            }
        }

        public string Asunto
        {
            get
            {
                return this.asunto;
            }
            set
            {
                this.asunto = value;
            }
        }

        public string Tema
        {
            get
            {
                return this.tema;
            }
            set
            {
                this.tema = value;
            }
        }

        public string Firma
        {
            get
            {
                return this.firma;
            }
            set
            {
                this.firma = value;
            }
        }

        public string Parrafo1
        {
            get
            {
                return this.parrafo1;
            }
            set
            {
                this.parrafo1 = value;
            }
        }

        public string Parrafo2
        {
            get
            {
                return this.parrafo2;
            }
            set
            {
                this.parrafo2 = value;
            }
        }

        public string Parrafo3
        {
            get
            {
                return this.parrafo3;
            }
            set
            {
                this.parrafo3 = value;
            }
        }

        public string Parrafo4
        {
            get
            {
                return this.parrafo4;
            }
            set
            {
                this.parrafo4 = value;
            }
        }

        public string Parrafo5
        {
            get
            {
                return this.parrafo5;
            }
            set
            {
                this.parrafo5 = value;
            }
        }

        public string Parrafo6
        {
            get
            {
                return this.parrafo6;
            }
            set
            {
                this.parrafo6 = value;
            }
        }
    }
}
