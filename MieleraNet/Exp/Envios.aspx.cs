using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MieleraNet.DAL;
using DevExpress.Web;
/*using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxUploadControl;*/
using System.IO;
using MieleraNet.Reportes;
using DevExpress.XtraReports.UI;


namespace MieleraNet.Exp
{
    public partial class Envios : System.Web.UI.Page
    {
        const string UploadDirectory = "~/Exportaciones/";
        //const string UploadTmpDirectory = "~/Exportaciones/Temp/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //gridPlan.AddNewRow();
                btnGrabaBK.Enabled = false;
                btnGrabaOS.Enabled = false;
                Session["ContExp"] = 0;
            }
            //btnImprimeReport.ClientSideEvents.Click = "function(s, e) {window.open(../Reportes/OrdenSalida.aspx, width=800,height=600&quot;); return false;}";
        }

        /// <summary>
        /// Funcion que graba el documento en la ruta especificada (año, mes) y el nombre del archivo lo relaciona con el numero de contrato
        /// </summary>
        /// <param name="uploadedFile">Recibe el nonbre del archivo cargado</param>
        /// <returns>Regresa el nombre del archivo guardado</returns>
        protected string SavePostedFile(UploadedFile uploadedFile)
        {
            string ret = "";
            string ruta = "";
            if (uploadedFile.IsValid)
            {
                double idcont = (double)hfCargaArch["idcont"];
                double idtipo = (double)hfCargaArch["idtipo"];
                double iddoc = (double)hfCargaArch["iddoc"];
                ExportDS export = new ExportDS();
                //DataTable MesAnioDT = export.ObtenMesAnioContrato(idcont.ToString())
                DataTable MesAnioDT = export.ObtenMesAnioContrato("2");

                ruta = UploadDirectory;

                if (MesAnioDT.Rows.Count > 0)
                {
                    ruta = String.Format("{0}{1}/{2}/", ruta, MesAnioDT.Rows[0][1], MesAnioDT.Rows[0][0]);
                }

                ruta = MapPath(ruta);
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                
                string extencion = Path.GetExtension(uploadedFile.FileName);
                //string archivo = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
                string rutaarch = ruta + hfCargaArch["idcont"].ToString() + hfCargaArch["nomarch"].ToString() + extencion;
                uploadedFile.SaveAs(rutaarch);
                export.ActualizaContratoExportArch((int)idcont, (int)idtipo, (int)iddoc, rutaarch);
                gridContExp.DataBind();
                ret = uploadedFile.FileName;
            }
            return ret;
        }


        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            ExportDS export = new ExportDS();
            export.ExportaContrato(cmbContrato.KeyValue.ToString(), cmbTipExp.Value.ToString());
            //Se agrega en la tabla EXPORT_CONTRATO todos los documentos a los que se realizará un seguimiento
            cmbContrato.Text = "";
            cmbTipExp.Text = "";

        }

        protected void gridContratos_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)cmbContrato.FindControl("gridContratos");

            if (grid != null)
            {
                object[] Contratos = new object[grid.VisibleRowCount];
                object[] keyValues = new object[grid.VisibleRowCount];
                for (int i = 0; i < grid.VisibleRowCount; i++)
                {
                    Contratos[i] = grid.GetRowValues(i, "NUMCONTRATO");
                    keyValues[i] = grid.GetRowValues(i, "IDCONTRATO");
                }
                e.Properties["cpContratos"] = Contratos;
                e.Properties["cpKeyValues"] = keyValues;
            }
        }

        protected void gridContExp_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "OK")
            {
                string strListo = (string)gridContExp.GetRowValues(e.VisibleRowIndex, "LISTO");
                ASPxButton btn = (ASPxButton)gridContExp.FindRowTemplateControl(e.VisibleRowIndex, "btnCargaArch");
                /*int idTambor = (int)gridTambEnv.GetRowValues(e.VisibleRowIndex, "IDTAMBOR");
                int idTrans = (int)gridTambEnv.GetRowValues(e.VisibleRowIndex, "IDTRANS");
                int valor = (int)e.Value;*/
                if (strListo == "N")
                {
                    btn.Visible = false;
                    e.DisplayText = String.Format("<a Target=\"_blank\" href=\"../Reportes/ImpMuestras.aspx\">{0}</a>", e.Column.FieldName);
                }
            }
        }

        protected void gridContExp_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
        {
            //var txt = (ASPxTextBox)gridJackets.FindRowCellTemplateControl(e.ListSourceRowIndex, (GridViewDataColumn)gridJackets.Columns["LISTO"], "btnCargaArch");
            if (e.Column.FieldName == "OK")
            {
                ASPxButton btn = (ASPxButton)gridContExp.FindRowTemplateControl(e.ListSourceRowIndex, "btnCargaArch");
                ASPxButton btn2 = (ASPxButton)gridContExp.FindRowCellTemplateControl(e.ListSourceRowIndex, (GridViewDataColumn)gridContExp.Columns["LISTO"], "btnCargaArch");
            }
        }

        protected void gridContExp_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType == GridViewRowType.Data)
            {
                string strVal = (string)e.GetValue("LISTO");
                ASPxButton btn2 = (ASPxButton)gridContExp.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gridContExp.Columns["LISTO"], "btnCargaArch");
                ASPxButton btnYes = (ASPxButton)gridContExp.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gridContExp.Columns["LISTO"], "btnYes");

                int idcontrato = (int)gridContExp.GetRowValues(e.VisibleIndex, "IDCONTRATO");
                int idTipoExp = (int)gridContExp.GetRowValues(e.VisibleIndex, "IDTIPOEXP");
                int idDoc = (int)gridContExp.GetRowValues(e.VisibleIndex, "IDDOC");
                string strDoc = (string)gridContExp.GetRowValues(e.VisibleIndex, "DOCUMENTO");
                string strCheck = (string)gridContExp.GetRowValues(e.VisibleIndex, "CHECKLIST");
                string strNomArch = (string)gridContExp.GetRowValues(e.VisibleIndex, "NOMARCH");
                string strRuta = (string)gridContExp.GetRowValues(e.VisibleIndex, "RUTA");
                //btn2.ClientSideEvents.Click = string.Format("function(s,e) { ShowWindow({0},{1});}", 20,10);

                //;
                //return false;
                if (strVal == "N")
                {
                    if (strCheck == "S")
                        btn2.ClientSideEvents.Click = String.Format("function(s,e) {{ ShowWindowList({0},{1},{2},'{3}','{4}','{5}');}}", idcontrato, idTipoExp, idDoc, strDoc, strCheck, strNomArch);
                    else
                        btn2.ClientSideEvents.Click = String.Format("function(s,e) {{ ShowWindow({0},{1},{2},'{3}','{4}','{5}');}}", idcontrato, idTipoExp, idDoc, strDoc, strCheck, strNomArch);

                    btn2.Visible = true;
                    btnYes.Visible = false;
                }
                else
                {
                    //if (strRuta != null && strRuta != "")
                    //{
                        string virtualFilePath = strRuta.Replace(MapPath(UploadDirectory), "../Exportaciones/");
                        virtualFilePath = virtualFilePath.Replace("\\", "/");
                        if (strCheck == "N")
                            btnYes.ClientSideEvents.Click = String.Format("function(s,e) {{ window.open(\"{0}\", \"_blank\", \"scrollbars=1, width=800,height=600\");}}", virtualFilePath);
                        else
                            btnYes.Enabled = false;
                    //}
                    btn2.Visible = false;
                    btnYes.Visible = true;
                }
            }
        }

        protected void uploadControl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            e.CallbackData = SavePostedFile(e.UploadedFile);
        }



        protected void btnOK2_Click(object sender, EventArgs e)
        {
            double idcont = (double)hfCargaArch["idcont"];
            double idtipo = (double)hfCargaArch["idtipo"];
            double iddoc = (double)hfCargaArch["iddoc"];
            ExportDS export = new ExportDS();
            if (chkListo.Checked)
               export.ActualizaContratoExport((int)idcont, (int)idtipo, (int)iddoc, "S");
            else
               export.ActualizaContratoExport((int)idcont, (int)idtipo, (int)iddoc, "N");
            gridContExp.DataBind();
            pcCheck.ShowOnPageLoad = false;
            chkListo.Checked = false;
        }

        protected void gridContratosExp_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)cmbContratoExp.FindControl("gridContratosExp");

            if (grid != null)
            {
                object[] Contratos = new object[grid.VisibleRowCount];
                object[] keyValues = new object[grid.VisibleRowCount];
                for (int i = 0; i < grid.VisibleRowCount; i++)
                {
                    Contratos[i] = grid.GetRowValues(i, "NUMCONTRATO");
                    keyValues[i] = grid.GetRowValues(i, "IDCONTRATO");
                }
                e.Properties["cpContratos"] = Contratos;
                e.Properties["cpKeyValues"] = keyValues;
            }
        }

        protected void cmbContratoExp_ValueChanged(object sender, EventArgs e)
        {

            /*try
            {
                if (cmbContratoExp.KeyValue.ToString() != "undefined")
                {
                    //hfCargaArch["cmbValue"]
                    cmbContratoExp.Text = hfCargaArch["cmbText"].ToString();
                    cmbContratoExp.KeyValue = hfCargaArch["cmbValue"];*/
                    Session["ContExp"] = cmbContratoExp.KeyValue;
                    Session["fechaOrden"] = edtFechaOS.Date.ToString();
                    gridContExp.DataBind();
                    /*if (int.Parse((string)cmbContratoExp.KeyValue) > 0)
                    {
                        pagecontrolExpCont.TabPages[1].Enabled = true;
                        pagecontrolExpCont.TabPages[2].Enabled = true;
                        pagecontrolExpCont.DataBind();
                    }*/

                /*}
            }
            catch
            {
            }*/

        }

        protected void btnGrabaBK_Click(object sender, EventArgs e)
        {
            ExportDS export = new ExportDS();
            int idBooking = (int)Session["IdBooking"];
            if (idBooking == 0)
                export.InsertaBooking(int.Parse((string)cmbContratoExp.KeyValue), edtNoBK.Text, edtFrom.Text, edtTo.Text, 30, edtSalida.Date, edtLlegada.Date);
            else
                export.ActualizaBooking(idBooking, edtNoBK.Text, edtFrom.Text, edtTo.Text, 30, edtSalida.Date, edtLlegada.Date);
        
        }

        protected void pagecontrolExpCont_ActiveTabChanging(object source, TabControlCancelEventArgs e)
        {
            
            //e.Cancel = true;

        }

        protected void dsPlanTransport_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            ExportDS export = new ExportDS();
            DataTable bookingDT = export.obtenBookigByIdContrato((string)cmbContratoExp.KeyValue);
            if (bookingDT.Rows.Count > 0)
                e.InputParameters[0] = bookingDT.Rows[0][0];
        }

        protected void btnGrabaOS_Click(object sender, EventArgs e)
        {
            ExportDS export = new ExportDS();
            int idOrdSalida = (int)Session["idOrdSalida"];
            if (idOrdSalida == 0)
            {
                idOrdSalida = export.InsertaOrdenSalida(int.Parse((string)cmbContratoExp.KeyValue), edtDestinoOS.Text, edtOrigenOS.Text, (DateTime)edtFechaOS.Value, edtLoteOS.Text, edtTipoOS.Text, edtContenedorOS.Text,
                                      edtSelloOS.Text, edtContratoOS.Text, int.Parse(edtTamboresOS.Text), float.Parse(edtPesoOS.Text), edtFleteraOS.Text, edtOperador.Text, edtPlacas.Text);
                Session["idOrdSalida"] = idOrdSalida;
            }
            else
                export.ActualizaOrdenSalida(idOrdSalida, edtDestinoOS.Text, edtOrigenOS.Text, (DateTime)edtFechaOS.Value, edtLoteOS.Text, edtTipoOS.Text, edtContenedorOS.Text,
                                      edtSelloOS.Text, edtContratoOS.Text, int.Parse(edtTamboresOS.Text), float.Parse(edtPesoOS.Text), edtFleteraOS.Text, edtOperador.Text, edtPlacas.Text);


        }

        


        protected void callbackPanel_Callback(object sender, CallbackEventArgsBase e)
        {
            //Cuando se cambie el contrato tambien se cambia el booking si es que se tiene
            ExportDS export = new ExportDS();
            DataTable bookingDT = export.obtenBookigByIdContrato(e.Parameter);
            if (bookingDT.Rows.Count > 0)
            {
                //Se actualiza la pestaña del booking
                Session["IdBooking"] = (int)bookingDT.Rows[0][0];
                edtNoBK.Text = (string)bookingDT.Rows[0][3];
                edtFrom.Text = (string)bookingDT.Rows[0][4];
                edtTo.Text = (string)bookingDT.Rows[0][5];
                edtSalida.Date = (DateTime)bookingDT.Rows[0][7];
                edtLlegada.Date = (DateTime)bookingDT.Rows[0][8];
                gridPlan.Enabled = true;
                gridIntinerario.Enabled = true;
                gridPlan.DataBind();
                gridIntinerario.DataBind();
            }
            else
            {
                Session["IdBooking"] = 0;
                edtNoBK.Text = "";
                edtFrom.Text = "";
                edtTo.Text = "";
                edtSalida.Text = "";
                edtLlegada.Text = "";
                gridPlan.CancelEdit();
                gridIntinerario.CancelEdit();
                gridPlan.Enabled = false;
                gridIntinerario.Enabled = false;
            }

            if (e.Parameter == null || e.Parameter == "")
                btnGrabaBK.Enabled = false;
            else
                btnGrabaBK.Enabled = true;

        }

        protected void callbackPanelOS_Callback(object sender, CallbackEventArgsBase e)
        {
            ExportDS export = new ExportDS();
            //Cuando cambie el contrato tambien cambia el panel de la orden de salida
            DataTable OrdenSalidaDT = export.ObtenOrdenSalidabyContrato(e.Parameter);
            if (OrdenSalidaDT.Rows.Count > 0)
            {
                Session["IdOrdSalida"] = (int)OrdenSalidaDT.Rows[0][0];
                edtDestinoOS.Text = (string)OrdenSalidaDT.Rows[0][2];
                edtOrigenOS.Text = (string)OrdenSalidaDT.Rows[0][3];
                edtFechaOS.Value = (DateTime)OrdenSalidaDT.Rows[0][4];
                edtLoteOS.Value = (string)OrdenSalidaDT.Rows[0][5];
                edtTipoOS.Text = (string)OrdenSalidaDT.Rows[0][6];
                edtContenedorOS.Text = (string)OrdenSalidaDT.Rows[0][7];
                edtSelloOS.Text = (string)OrdenSalidaDT.Rows[0][8];
                edtContenedorOS.Text = (string)OrdenSalidaDT.Rows[0][9];
                edtTamboresOS.Text = OrdenSalidaDT.Rows[0][10].ToString();
                edtPesoOS.Text = OrdenSalidaDT.Rows[0][11].ToString();
                edtFleteraOS.Text = (string)OrdenSalidaDT.Rows[0][12];
                edtOperador.Text = (string)OrdenSalidaDT.Rows[0][13];
                edtPlacas.Text = (string)OrdenSalidaDT.Rows[0][14];
            }
            else
            {
                Session["IdOrdSalida"] = 0;
                edtDestinoOS.Text = "";
                edtOrigenOS.Text = "";
                edtFechaOS.Value = "";
                edtLoteOS.Value = "";
                edtTipoOS.Text = "";
                edtContenedorOS.Text = "";
                edtSelloOS.Text = "";
                edtContenedorOS.Text = "";
                edtTamboresOS.Text = "";
                edtPesoOS.Text = "";
                edtFleteraOS.Text = "";
                edtOperador.Text = "";
                edtPlacas.Text = "";
            }

            if (e.Parameter == "")
                btnGrabaOS.Enabled = false;
            else
                btnGrabaOS.Enabled = true;
        }

        protected void ASPxComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            edtPlacas.Text = edtOperador.Value.ToString();
        }

        protected void gridIntinerario_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            if (grid.IsEditing)
            {
                object initialValue = null;
                switch (e.Column.FieldName)
                {
                    case "HORAINICIO":
                        if (e.Value != null)
                        {
                            initialValue = (TimeSpan)e.Value;
                            DateTime f = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, ((TimeSpan)e.Value).Hours, ((TimeSpan)e.Value).Minutes, ((TimeSpan)e.Value).Seconds);
                            e.Editor.Value = f;
                        }
                        break;
                    case "HORAFIN":
                        if (e.Value != null)
                        {
                            initialValue = (TimeSpan)e.Value;
                            DateTime f = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, ((TimeSpan)e.Value).Hours, ((TimeSpan)e.Value).Minutes, ((TimeSpan)e.Value).Seconds);
                            e.Editor.Value = f;
                        }
                        break;
                    default:
                        break;
                }

                
            }
        }


        /* Helper methods */

        private TimeSpan DateTimeToTimeSpan(Object value)
        {
            DateTime f = Convert.ToDateTime(value);
            TimeSpan t = new TimeSpan(f.Hour, f.Minute, f.Second);
            return t;
        }

        protected void gridIntinerario_ParseValue(object sender, DevExpress.Web.Data.ASPxParseValueEventArgs e)
        {
            
            if ((gridIntinerario.IsNewRowEditing || gridIntinerario.IsEditing) && e.FieldName == "HORAFIN")
                e.Value = DateTimeToTimeSpan(e.Value);
            if ((gridIntinerario.IsNewRowEditing || gridIntinerario.IsEditing) && e.FieldName == "HORAINICIO")
                e.Value = DateTimeToTimeSpan(e.Value);
        }
        
    }
}
