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
        private readonly string newFileName;

        public GeneraOficio(Oficios oficio, string newFileName)
        {
            this.oficio = oficio;
            this.newFileName = newFileName;
        }

        //public void InformeGenerlaObras()
        //{
        //    oWord = new Microsoft.Office.Interop.Word.Application();
        //    oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        //    oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;

        //    try
        //    {
        //        //Insert a paragraph at the beginning of the document.
        //        Microsoft.Office.Interop.Word.Paragraph oPara1;
        //        oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
        //        //oPara1.Range.ParagraphFormat.Space1;
        //        oPara1.Range.Text = "SUPREMA CORTE DE JUSTICIA DE LA NACIÓN";

        //        oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //        oPara1.Range.Font.Bold = 1;
        //        oPara1.Range.Font.Size = 10;
        //        oPara1.Range.Font.Name = "Arial";
        //        oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
        //        oPara1.Range.InsertParagraphAfter();
        //        oPara1.Range.InsertParagraphAfter();
        //        oPara1.Range.Text = "COORDINACIÓN DE COMPILACIÓN Y ";
        //        oPara1.Range.InsertParagraphAfter();
        //        oPara1.Range.Text = "SISTEMATIZACIÓN DE TESIS";
        //        oPara1.Range.InsertParagraphAfter();
        //        oPara1.Range.InsertParagraphAfter();
        //        oPara1.Range.Text = "RELACIÓN DE TESIS PARA PUBLICAR EN EL SEMANARIO JUDICIAL DE LA FEDERACIÓN Y EN SU GACETA";
        //        oPara1.Range.InsertParagraphAfter();
        //        oPara1.Range.InsertParagraphAfter();
        //        oPara1.Range.Text = "TOTAL:   " + obrasImprimir.Count() + " Obras";
        //        oPara1.Range.InsertParagraphAfter();
        //        oPara1.Range.InsertParagraphAfter();

        //        fila = 1;
        //        Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

        //        Table oTable = oDoc.Tables.Add(wrdRng, obrasImprimir.Count + 1, 5, ref oMissing, ref oMissing);
        //        //oTable.Rows[1].HeadingFormat = 1;
        //        oTable.Range.ParagraphFormat.SpaceAfter = 6;
        //        oTable.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //        oTable.Range.Font.Size = 9;
        //        oTable.Range.Font.Name = "Arial";
        //        oTable.Range.Font.Bold = 0;
        //        oTable.Borders.Enable = 1;

        //        oTable.Columns[1].SetWidth(60, WdRulerStyle.wdAdjustSameWidth);
        //        oTable.Columns[2].SetWidth(400, WdRulerStyle.wdAdjustSameWidth);
        //        oTable.Columns[3].SetWidth(80, WdRulerStyle.wdAdjustSameWidth);
        //        oTable.Columns[4].SetWidth(60, WdRulerStyle.wdAdjustSameWidth);
        //        oTable.Columns[5].SetWidth(60, WdRulerStyle.wdAdjustSameWidth);

        //        oTable.Cell(fila, 1).Range.Text = "#";
        //        oTable.Cell(fila, 2).Range.Text = "Título";
        //        oTable.Cell(fila, 3).Range.Text = "Núm. de Material";
        //        oTable.Cell(fila, 4).Range.Text = "Año";
        //        oTable.Cell(fila, 5).Range.Text = "Tiraje";

        //        oTable.Cell(fila, 1).Range.Font.Bold = 1;
        //        oTable.Cell(fila, 2).Range.Font.Bold = 1;
        //        oTable.Cell(fila, 3).Range.Font.Bold = 1;
        //        oTable.Cell(fila, 4).Range.Font.Bold = 1;
        //        oTable.Cell(fila, 5).Range.Font.Bold = 1;

        //        fila++;
        //        int consecutivo = 1;

        //        foreach (Obra print in obrasImprimir)
        //        {
        //            oTable.Cell(fila, 1).Range.Text = consecutivo.ToString();
        //            oTable.Cell(fila, 2).Range.Text = print.Titulo;
        //            oTable.Cell(fila, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
        //            oTable.Cell(fila, 3).Range.Text = print.NumMaterial;
        //            oTable.Cell(fila, 4).Range.Text = print.AnioPublicacion.ToString();
        //            oTable.Cell(fila, 5).Range.Text = print.Tiraje.ToString();
        //            // oTable.Cell(fila, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

        //            fila++;
        //            consecutivo++;
        //        }

        //        foreach (Section wordSection in oDoc.Sections)
        //        {
        //            object pagealign = WdPageNumberAlignment.wdAlignPageNumberRight;
        //            object firstpage = true;
        //            wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.Add(ref pagealign, ref firstpage);
        //        }

        //        oWord.ActiveDocument.SaveAs(filePath);
        //        oWord.ActiveDocument.Saved = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //        ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,WordReports", "PadronApi");
        //    }
        //    finally
        //    {
        //        oWord.Visible = true;
        //        //oDoc.Close();

        //    }
        //}

        public void Sga()
        {
            string rutaBase = @"C:\Users\" + Environment.UserName + @"\";

            try
            {
                //  Just to kill WINWORD.EXE if it is running
                //  copy letter format to temp.doc
                File.Copy(rutaBase + "Machote.docx", rutaBase + newFileName, true);   
                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                //  create Word document object
                Word.Document aDoc = null;
                //  create & define filename object with temp.doc
                object filename = "c:\\temp.doc";
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
                    oPara1.Range.Text = "OFICIO";
                    oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    oPara1.Range.Font.Bold = 0;
                    oPara1.Range.Font.Size = 12;
                    oPara1.Range.Font.Name = "Arial";
                    oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
                    oPara1.Range.Text = "FECHA ";
                    oPara1.Range.InsertParagraphAfter();

                    //  Call FindAndReplace()function for each change
                    //    this.FindAndReplace(wordApp, "<Date>", dtpDate.Text);
                    //    this.FindAndReplace(wordApp, "<Name>", txName.Text.Trim());
                    //    this.FindAndReplace(wordApp, "<Subject>", 
                    //txtSubject.Text.Trim());
                    //  save temp.doc after modified
                    aDoc.Save();
                }
                //    else
                //        MessageBox.Show("File does not exist.", 
                //"No File", MessageBoxButtons.OK, 
                //MessageBoxIcon.Information);
                //    killprocess("winword");
            }
            catch (Exception)
            {
                //        MessageBox.Show("Error in process.", "Internal Error", 
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindAndReplace(Word.Application wordApp,
            object findText, object replaceText)
        { 
            object matchCase = true;
            object matchWholeWord = true;
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

        private WdColorIndex GetCellColor(int idColor)
        {
            if (idColor == 2)
                return WdColorIndex.wdRed;
            else if (idColor == 3)
                return WdColorIndex.wdBlue;
            else if (idColor == 4)
                return WdColorIndex.wdViolet;
            else if (idColor == 5)
                return WdColorIndex.wdDarkRed;
            else if (idColor == 6)
                return WdColorIndex.wdGreen;
            else
                return WdColorIndex.wdBlack;
        }
    }
}


