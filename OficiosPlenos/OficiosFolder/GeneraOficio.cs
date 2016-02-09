using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Office.Interop.Word;
using ScjnUtilities;
using Telerik.Windows.Data;
using OficiosPlenos.Dto;
using System.IO;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using OficiosPlenos.Singletons;

namespace OficiosPlenos.OficiosFolder
{
    public class GeneraOficio
    {
        private int fila = 1;

        //Microsoft.Office.Interop.Word.Application oWord;
        //Microsoft.Office.Interop.Word.Document oDoc;
        object oMissing = System.Reflection.Missing.Value;
        //object oEndOfDoc = "\\endofdoc";

        private readonly Oficios oficio;
        private readonly Contradiccion contradiccion;
        private readonly string newFileName;

        public GeneraOficio(Oficios oficio, Contradiccion contradiccion, string newFileName)
        {
            this.oficio = oficio;
            this.newFileName = newFileName;
            this.contradiccion = contradiccion;
        }


        public bool GetOficioSga()
        {
            bool isComplete = false;

            string rutaBase = @"C:\Seguimiento\";

            string machote = rutaBase + "Machote.docx";
            string nuevoDoc = rutaBase + newFileName;
           
            try
            {
                //  Just to kill WINWORD.EXE if it is running
                //  copy letter format to temp.doc
                File.Copy(machote, nuevoDoc, true);   
                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                //  create Word document object
                Word.Document aDoc = null;
                //  create & define filename object with temp.doc
                object filename = nuevoDoc;
                //  if temp.doc available
                if (File.Exists((string)filename))  
                {
                    object readOnly = false;
                    object isVisible = false;
                    //  make visible Word application
                    wordApp.Visible = false;
                    //  open Word document named temp.doc
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);
                    aDoc.Activate();


                    Microsoft.Office.Interop.Word.Paragraph oPara1;
                    oPara1 = aDoc.Content.Paragraphs.Add(ref oMissing);
                    //oPara1.Range.ParagraphFormat.Space1;
                    oPara1.Range.Text = "OFICIO " + contradiccion.OficioAdmision;
                    oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    oPara1.Range.Font.Size = 12;
                    oPara1.Range.Font.Name = "Arial";
                    oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.Text = "Ciudad de México, " + DateTimeUtilities.ToLongDateFormat(contradiccion.FEnvioOfSga);
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    oPara1.Range.Text = oficio.Parrafo1;
                    
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.Text = "Distinguido Licenciado Rafael Coello Cetina";
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    oPara1.Range.Text = oficio.Parrafo2;
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.FirstLineIndent = 40;
                    oPara1.Range.Text = oficio.Parrafo3;
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.Text = oficio.Parrafo4;
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.Text = oficio.Parrafo5;
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    oPara1.Range.ParagraphFormat.FirstLineIndent = 0;
                    oPara1.Range.Text = oficio.Firma;
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    oPara1.Range.Font.Size = 10;
                    oPara1.Range.Text = "C.c.p. " + contradiccion.EncargadoStr + ".- Secretario de Acuerdos del " +
                        "<Pleno>.- Para su conocimiento y en seguimiento a su oficio " + contradiccion.OficioAdmision +
                        ", recibido el " + DateTimeUtilities.ToLongDateFormat(contradiccion.FechaOficioAdmin)
                        + " del año en curso (contradicción de tesis " + contradiccion.NumAsunto + "/" + contradiccion.AnioAsunto + ").";
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();

                    FindAndReplace(wordApp, "<Tema>", contradiccion.Tema);
                    FindAndReplace(wordApp, "<Pleno>", contradiccion.PlenoStr);
                    FindAndReplace(wordApp, "<NumAsunto>", contradiccion.NumAsunto + "/" + contradiccion.AnioAsunto);

                    if (contradiccion.FechaOficioAdmin == contradiccion.FEnvioOfSga)
                        FindAndReplace(wordApp, "<InicioTermino>", "dia de hoy");
                    else
                        FindAndReplace(wordApp, "<InicioTermino>", DateTimeUtilities.ToLongDateFormat(contradiccion.FechaOficioAdmin).Replace("de 2016", "").ToLower() + "del año en curso");

                    aDoc.Save();
                    
                    aDoc.Close();

                   // wordApp.Documents.Close();
                    wordApp = null;
                }
                //    else
                //        MessageBox.Show("File does not exist.", 
                //"No File", MessageBoxButtons.OK, 
                //MessageBoxIcon.Information);
                //    killprocess("winword");

                isComplete = true;
                contradiccion.OfEnviadoSgaFilePath = nuevoDoc;
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GeneraOficio", "OficiosPleno");
            }
            return isComplete;
        }


        public bool GetOficioNoContradiccion()
        {
            bool isComplete = false;

            string rutaBase = @"C:\Seguimiento\";

            string machote = rutaBase + "Machote.docx";
            string nuevoDoc = rutaBase + newFileName;

            try
            {
                //  Just to kill WINWORD.EXE if it is running
                //  copy letter format to temp.doc
                File.Copy(machote, nuevoDoc, true);
                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                //  create Word document object
                Word.Document aDoc = null;
                //  create & define filename object with temp.doc
                object filename = nuevoDoc;
                //  if temp.doc available
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    //  make visible Word application
                    wordApp.Visible = false;
                    //  open Word document named temp.doc
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);
                    aDoc.Activate();


                    Microsoft.Office.Interop.Word.Paragraph oPara1;
                    oPara1 = aDoc.Content.Paragraphs.Add(ref oMissing);
                    //oPara1.Range.ParagraphFormat.Space1;
                    oPara1.Range.Text = "OFICIO " + contradiccion.OficioPlenos;
                    oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    oPara1.Range.Font.Size = 12;
                    oPara1.Range.Font.Name = "Arial";
                    oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.Text = "Ciudad de México, " + DateTimeUtilities.ToLongDateFormat(contradiccion.FEnvioOfPlenos);
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    oPara1.Range.Text = oficio.Parrafo1;

                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    oPara1.Range.Text = oficio.Parrafo2;
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    //oPara1.Range.ParagraphFormat.FirstLineIndent = 40;
                    
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    oPara1.Range.ParagraphFormat.FirstLineIndent = 0;
                    oPara1.Range.Text = oficio.Firma;
                    
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    oPara1.Range.Font.Size = 10;
                    oPara1.Range.Text = "C.c.p. Lic. Rafael Coello Cetina.- Secretario General de Acuerdos de la " +
                        "Suprema Corte de Justicia de la Nación.- Para su conocimiento.";
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();


                    FindAndReplace(wordApp, "<Encargado>",contradiccion.Titulo + " " + contradiccion.EncargadoStr);
                    FindAndReplace(wordApp, "Distinguido Lic.", "Distinguido Licenciado");
                    FindAndReplace(wordApp, "<Pleno>", contradiccion.PlenoStr);

                    if (contradiccion.FechaOficioAdmin != null && contradiccion.FechaCorreo != null)
                    {
                        if (contradiccion.FechaOficioAdmin < contradiccion.FechaCorreo)
                        {
                            FindAndReplace(wordApp, "<oficiocorreo>", "oficio");
                            FindAndReplace(wordApp, "<FechaPrimera>", DateTimeUtilities.ToLongDateFormat(contradiccion.FechaOficioAdmin));
                        }
                        else
                        {
                            FindAndReplace(wordApp, "<oficiocorreo>", "correo electrónico");
                            FindAndReplace(wordApp, "<FechaPrimera>", DateTimeUtilities.ToLongDateFormat(contradiccion.FechaCorreo));
                        }
                    }
                    else if (contradiccion.FechaOficioAdmin != null)
                    {
                        FindAndReplace(wordApp, "<oficiocorreo>", "oficio");
                        FindAndReplace(wordApp, "<FechaPrimera>", DateTimeUtilities.ToLongDateFormat(contradiccion.FechaOficioAdmin));
                    }
                    else if (contradiccion.FechaCorreo != null)
                    {
                        FindAndReplace(wordApp, "<oficiocorreo>", "correo electrónico");
                        FindAndReplace(wordApp, "<FechaPrimera>", DateTimeUtilities.ToLongDateFormat(contradiccion.FechaCorreo));
                    }

                    FindAndReplace(wordApp, "<NumAsunto>", contradiccion.NumAsunto + "/" + contradiccion.AnioAsunto);
                    FindAndReplace(wordApp, "<RespuestaSga>", contradiccion.OficioRespuestaSga);
                    FindAndReplace(wordApp, "<FRespuestaSga>", DateTimeUtilities.ToLongDateFormat( contradiccion.FRespuestaSga));
                    FindAndReplace(wordApp, "<Tema>", contradiccion.Tema);

                    aDoc.Save();
                    aDoc.Close();

                    wordApp = null;
                }

                isComplete = true;
                contradiccion.OfEnviadoSgaFilePath = nuevoDoc;
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GeneraOficio", "OficiosPleno");
            }
            return isComplete;
        }


        public bool GetOficioContradiccion()
        {
            bool isComplete = false;

            string rutaBase = @"C:\Seguimiento\";

            string machote = rutaBase + "Machote.docx";
            string nuevoDoc = rutaBase + newFileName;

            try
            {
                //  Just to kill WINWORD.EXE if it is running
                //  copy letter format to temp.doc
                File.Copy(machote, nuevoDoc, true);
                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                //  create Word document object
                Word.Document aDoc = null;
                //  create & define filename object with temp.doc
                object filename = nuevoDoc;
                //  if temp.doc available
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    //  make visible Word application
                    wordApp.Visible = false;
                    //  open Word document named temp.doc
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);
                    aDoc.Activate();


                    Microsoft.Office.Interop.Word.Paragraph oPara1;
                    oPara1 = aDoc.Content.Paragraphs.Add(ref oMissing);
                    //oPara1.Range.ParagraphFormat.Space1;
                    oPara1.Range.Text = "OFICIO " + contradiccion.OficioPlenos;
                    oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    oPara1.Range.Font.Size = 12;
                    oPara1.Range.Font.Name = "Arial";
                    oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.Text = "Ciudad de México, " + DateTimeUtilities.ToLongDateFormat(contradiccion.FEnvioOfPlenos);
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    oPara1.Range.Text = oficio.Parrafo1;

                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    oPara1.Range.Text = oficio.Parrafo2;
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.Text = oficio.Parrafo3;
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    //oPara1.Range.ParagraphFormat.FirstLineIndent = 40;

                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    oPara1.Range.ParagraphFormat.FirstLineIndent = 0;
                    oPara1.Range.Text = oficio.Firma;

                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    oPara1.Range.Font.Size = 10;
                    oPara1.Range.Text = "C.c.p. Lic. Rafael Coello Cetina.- Secretario General de Acuerdos de la " +
                        "Suprema Corte de Justicia de la Nación.- Para su conocimiento.";
                    oPara1.Range.InsertParagraphAfter();
                    oPara1.Range.InsertParagraphAfter();


                    FindAndReplace(wordApp, "<Encargado>", contradiccion.Titulo + " " + contradiccion.EncargadoStr);
                    FindAndReplace(wordApp, "Distinguido Lic.", "Distinguido Licenciado");
                    FindAndReplace(wordApp, "<Pleno>", contradiccion.PlenoStr);

                    if (contradiccion.FechaOficioAdmin != null && contradiccion.FechaCorreo != null)
                    {
                        if (contradiccion.FechaOficioAdmin < contradiccion.FechaCorreo)
                        {
                            FindAndReplace(wordApp, "<oficiocorreo>", "oficio");
                            FindAndReplace(wordApp, "<FechaPrimera>", DateTimeUtilities.ToLongDateFormat(contradiccion.FechaOficioAdmin));
                        }
                        else
                        {
                            FindAndReplace(wordApp, "<oficiocorreo>", "correo electrónico");
                            FindAndReplace(wordApp, "<FechaPrimera>", DateTimeUtilities.ToLongDateFormat(contradiccion.FechaCorreo));
                        }
                    }
                    else if (contradiccion.FechaOficioAdmin != null)
                    {
                        FindAndReplace(wordApp, "<oficiocorreo>", "oficio");
                        FindAndReplace(wordApp, "<FechaPrimera>", DateTimeUtilities.ToLongDateFormat(contradiccion.FechaOficioAdmin));
                    }
                    else if (contradiccion.FechaCorreo != null)
                    {
                        FindAndReplace(wordApp, "<oficiocorreo>", "correo electrónico");
                        FindAndReplace(wordApp, "<FechaPrimera>", DateTimeUtilities.ToLongDateFormat(contradiccion.FechaCorreo));
                    }

                    FindAndReplace(wordApp, "<NumAsunto>", contradiccion.NumAsunto + "/" + contradiccion.AnioAsunto);
                    FindAndReplace(wordApp, "<RespuestaSga>", contradiccion.OficioRespuestaSga);
                    FindAndReplace(wordApp, "<FRespuestaSga>", DateTimeUtilities.ToLongDateFormat(contradiccion.FRespuestaSga));
                    FindAndReplace(wordApp, "<Tema>", contradiccion.Tema);

                    aDoc.Save();
                    aDoc.Close();

                    wordApp = null;
                }

                isComplete = true;
                contradiccion.OfEnviadoSgaFilePath = nuevoDoc;
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GeneraOficio", "OficiosPleno");
            }
            return isComplete;
        }

        private void FindAndReplace(Word.Application wordApp,
            object findText, object replaceText)
        { 
            object matchCase = true;
            object matchWholeWord = false;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }

     
    }
}


