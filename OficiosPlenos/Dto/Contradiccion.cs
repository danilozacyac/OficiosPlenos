using System;
using System.ComponentModel;
using System.Linq;

namespace OficiosPlenos.Dto
{
    public class Contradiccion : INotifyPropertyChanged
    {
        private int idContradiccion;
        private int idPleno;
        private int idEncargado;
        private string encargadoStr;
        private int numAsunto = 0;
        private int anioAsunto = DateTime.Now.Year;
        private string oficioAdmision = String.Empty;
        private DateTime? fechaOficioAdmin;
        private int fechaOficioAdminInt;
        private string oficioFilePath = String.Empty;
        private DateTime? fechaCorreo;
        private int fechaCorreoInt;
        private string correoFilePath = String.Empty;
        private string oficioSga;
        private DateTime? fEnvioOfSga;
        private int fEnvioOfSgaInt;
        private string ofEnviadoSgaFilePath; 
        private string oficioRespuestaSga;
        private DateTime? fRespuestaSga;
        private int fRespuestaSgaInt;
        private bool oficioSgaGenerado;
        private bool existeContradiccion;
        private string ofRespuestaSgaFilePath;
        private string oficioPlenos;
        private DateTime? fEnvioOfPlenos;
        private int fEnvioOfPlenosInt;
        private bool oficioPlenoGenerado;
        private string oPlenoFilePath;
        private Encargado encargado;
        private string tema;

        

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

        public string EncargadoStr
        {
            get
            {
                return this.encargadoStr;
            }
            set
            {
                this.encargadoStr = value;
            }
        }

        public string OfRespuestaSgaFilePath
        {
            get
            {
                return this.ofRespuestaSgaFilePath;
            }
            set
            {
                this.ofRespuestaSgaFilePath = value;
                this.OnPropertyChanged("OfRespuestaSgaFilePath");
            }
        }

        public string OficioRespuestaSga
        {
            get
            {
                return this.oficioRespuestaSga;
            }
            set
            {
                this.oficioRespuestaSga = value;
            }
        }

        public int IdContradiccion
        {
            get
            {
                return this.idContradiccion;
            }
            set
            {
                this.idContradiccion = value;
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

        public int NumAsunto
        {
            get
            {
                return this.numAsunto;
            }
            set
            {
                this.numAsunto = value;
            }
        }

        public int AnioAsunto
        {
            get
            {
                return this.anioAsunto;
            }
            set
            {
                this.anioAsunto = value;
            }
        }

        public string OficioAdmision
        {
            get
            {
                return this.oficioAdmision;
            }
            set
            {
                this.oficioAdmision = value;
            }
        }

        public DateTime? FechaOficioAdmin
        {
            get
            {
                return this.fechaOficioAdmin;
            }
            set
            {
                this.fechaOficioAdmin = value;
            }
        }

        public int FechaOficioAdminInt
        {
            get
            {
                return this.fechaOficioAdminInt;
            }
            set
            {
                this.fechaOficioAdminInt = value;
            }
        }

        public string OficioFilePath
        {
            get
            {
                return this.oficioFilePath;
            }
            set
            {
                this.oficioFilePath = value;
                this.OnPropertyChanged("OficioFilePath");
            }
        }

        public DateTime? FechaCorreo
        {
            get
            {
                return this.fechaCorreo;
            }
            set
            {
                this.fechaCorreo = value;
            }
        }

        public int FechaCorreoInt
        {
            get
            {
                return this.fechaCorreoInt;
            }
            set
            {
                this.fechaCorreoInt = value;
            }
        }

        public string CorreoFilePath
        {
            get
            {
                return this.correoFilePath;
            }
            set
            {
                this.correoFilePath = value;
                this.OnPropertyChanged("CorreoFilePath");
            }
        }

        public string OficioSga
        {
            get
            {
                return this.oficioSga;
            }
            set
            {
                this.oficioSga = value;
            }
        }

        public DateTime? FEnvioOfSga
        {
            get
            {
                return this.fEnvioOfSga;
            }
            set
            {
                this.fEnvioOfSga = value;
            }
        }

        public int FEnvioOfSgaInt
        {
            get
            {
                return this.fEnvioOfSgaInt;
            }
            set
            {
                this.fEnvioOfSgaInt = value;
            }
        }

        public string OfEnviadoSgaFilePath
        {
            get
            {
                return this.ofEnviadoSgaFilePath;
            }
            set
            {
                this.ofEnviadoSgaFilePath = value;
            }
        }

        public DateTime? FRespuestaSga
        {
            get
            {
                return this.fRespuestaSga;
            }
            set
            {
                this.fRespuestaSga = value;
            }
        }

        public int FRespuestaSgaInt
        {
            get
            {
                return this.fRespuestaSgaInt;
            }
            set
            {
                this.fRespuestaSgaInt = value;
            }
        }

        public bool OficioSgaGenerado
        {
            get
            {
                return this.oficioSgaGenerado;
            }
            set
            {
                this.oficioSgaGenerado = value;
            }
        }

        public bool ExisteContradiccion
        {
            get
            {
                return this.existeContradiccion;
            }
            set
            {
                this.existeContradiccion = value;
            }
        }

        public string OficioPlenos
        {
            get
            {
                return this.oficioPlenos;
            }
            set
            {
                this.oficioPlenos = value;
            }
        }

        public DateTime? FEnvioOfPlenos
        {
            get
            {
                return this.fEnvioOfPlenos;
            }
            set
            {
                this.fEnvioOfPlenos = value;
            }
        }

        public int FEnvioOfPlenosInt
        {
            get
            {
                return this.fEnvioOfPlenosInt;
            }
            set
            {
                this.fEnvioOfPlenosInt = value;
            }
        }

        public bool OficioPlenoGenerado
        {
            get
            {
                return this.oficioPlenoGenerado;
            }
            set
            {
                this.oficioPlenoGenerado = value;
            }
        }

        public string OPlenoFilePath
        {
            get
            {
                return this.oPlenoFilePath;
            }
            set
            {
                this.oPlenoFilePath = value;
            }
        }

        public Encargado Encargado
        {
            get
            {
                return this.encargado;
            }
            set
            {
                this.encargado = value;
                this.OnPropertyChanged("Encargado");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}
