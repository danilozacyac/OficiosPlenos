using System;
using System.Linq;

namespace OficiosPlenos.Dto
{
    public class Encargado
    {
        private int idEncargado;
        private int idPleno;
        private int idTitulo;
        private string nombre;
        private string nombreAlpha;
        private string apellido;
        private string apellidoAlpha;
        private string completo;
        private string completoAlpha;
        
        public int IdTitulo
        {
            get
            {
                return this.idTitulo;
            }
            set
            {
                this.idTitulo = value;
            }
        }

        public int IdPleno
        {
            get
            {
                return this.idPleno;
            }
            set
            {
                this.idPleno = value;
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

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string NombreAlpha
        {
            get
            {
                return this.nombreAlpha;
            }
            set
            {
                this.nombreAlpha = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public string ApellidoAlpha
        {
            get
            {
                return this.apellidoAlpha;
            }
            set
            {
                this.apellidoAlpha = value;
            }
        }

        public string Completo
        {
            get
            {
                return this.completo;
            }
            set
            {
                this.completo = value;
            }
        }

        public string CompletoAlpha
        {
            get
            {
                return this.completoAlpha;
            }
            set
            {
                this.completoAlpha = value;
            }
        }
    }
}
