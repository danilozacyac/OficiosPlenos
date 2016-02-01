using System;
using System.Linq;

namespace OficiosPlenos.Dto
{
    public class Titulo
    {
        private int idTitulo;
        private string titulo;
        private string abreviatura;

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

        public string TituloDesc
        {
            get
            {
                return this.titulo;
            }
            set
            {
                this.titulo = value;
            }
        }

        public string Abreviatura
        {
            get
            {
                return this.abreviatura;
            }
            set
            {
                this.abreviatura = value;
            }
        }


    }
}
