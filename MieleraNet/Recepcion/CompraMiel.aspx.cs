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
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxPopupControl;
using DevExpress.Web.ASPxTabControl;
using DevExpress.Web.ASPxRoundPanel;
using MieleraNet.DAL;

namespace MieleraNet.Recepcion
{
    public partial class CompraMiel : System.Web.UI.Page
    {
        public string strerror = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //ASPxWebControl.RegisterBaseScript(Page);
            CompraMielDS compraDS = new CompraMielDS();
            int transaccion = compraDS.HayTransaccionMielActiva((int)Session["idusr"]);
            if (transaccion == 0)
                lbNumTran.Text = "[Ninguna]";
            else
            {
                lbNumTran.Text = transaccion.ToString();
                lbNumTran.ForeColor = System.Drawing.Color.Green;

                lbNoTran.Text = transaccion.ToString();
                lbNoTran.ForeColor = System.Drawing.Color.Green;
                
            }
            lbDelegado.Text = compraDS.ObtenDelegado((int)Session["idusr"]);
            lbArea.Text = compraDS.ObtenArea((int)Session["idarea"]);

            if (!Page.IsPostBack)
            {
                if (Page.Request["Pagina"] != null)
                {
                    if (Page.Request["Pagina"] == "1")
                    {
                        pagecontrolCompraMiel.ActiveTabIndex = 1;
                        pagecontrolCompraMiel.DataBind();
                    }
                    if (Page.Request["Pagina"] == "2")
                    {
                        pagecontrolCompraMiel.ActiveTabIndex = 2;
                        pagecontrolCompraMiel.DataBind();
                    }
                }
                //Removemos del cache la tabla de apicultores relacionado con el delegado
                HttpContext.Current.Cache.Remove("Cache_ApicultoresKey");
                ASPxGridView grid = (ASPxGridView)DropDownEdit.FindControl("gridApicultor");
                grid.DataBind();
                ASPxGridView gridTambores = (ASPxGridView)edtTamboraLlenar.FindControl("gridTamDisp");
                gridTambores.DataBind();
            }
            
        }

        protected void gridApicultor_CustomJSProperties(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)DropDownEdit.FindControl("gridApicultor");
            
            if (grid != null)
            {
                object[] NombreApicultor = new object[grid.VisibleRowCount];
                object[] keyValues = new object[grid.VisibleRowCount];
                for (int i = 0; i < grid.VisibleRowCount; i++)
                {
                    NombreApicultor[i] = grid.GetRowValues(i, "NOMBRE");
                    keyValues[i] = grid.GetRowValues(i, "IDENFI2");
                }
                e.Properties["cpNombreApicultor"] = NombreApicultor;
                e.Properties["cpKeyValues"] = keyValues;
                e.Properties["cpError"] = "";//strerror;
            }
        }

        protected void GridView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)DropDownEdit.FindControl("gridApicultor");
            //ASPxTextBox edtPrimerNom = (ASPxTextBox)grid.FindEditFormTemplateControl("PrimerNomEditor");
            ASPxPageControl pagectrlApic = (ASPxPageControl)grid.FindEditFormTemplateControl("pagectrlApic");
            EntidadesDS entidades = new EntidadesDS();
            try
            {
                if (pagectrlApic.ActiveTabIndex == 1)
                {
                    //entidades.ObtenApicultorPorId(
                    ASPxRoundPanel GeneralesGroup = (ASPxRoundPanel)pagectrlApic.FindControl("GeneralesGroup");
                    ASPxComboBox edtPrimerNom = (ASPxComboBox)GeneralesGroup.FindControl("edtPrimerNom");
                    ASPxComboBox edtSegundoNom = (ASPxComboBox)GeneralesGroup.FindControl("edtSegundoNom");
                    ASPxComboBox edtPrimerAp = (ASPxComboBox)GeneralesGroup.FindControl("edtPrimerAp");
                    ASPxComboBox edtSegundoAp = (ASPxComboBox)GeneralesGroup.FindControl("edtSegundoAp");
                    ASPxComboBox edtGenero = (ASPxComboBox)GeneralesGroup.FindControl("edtGenero");
                    ASPxTextBox edtIDApic = (ASPxTextBox)GeneralesGroup.FindControl("edtIDApic");
                    
                    ASPxRoundPanel FechaNacimiento = (ASPxRoundPanel)pagectrlApic.FindControl("FechaNacimiento");
                    ASPxDateEdit edtFechaNac = (ASPxDateEdit)FechaNacimiento.FindControl("edtFechaNac");
                    ASPxComboBox edtPaisPF = (ASPxComboBox)FechaNacimiento.FindControl("edtPaisPF");
                    ASPxComboBox edtEstadoPF = (ASPxComboBox)FechaNacimiento.FindControl("edtEstadoPF");
                    ASPxComboBox edtCiudadPF = (ASPxComboBox)FechaNacimiento.FindControl("edtCiudadPF");
                    
                    DataTable apicDT = entidades.ObtenApicultorPorId(edtIDApic.Text);
                    if (apicDT.Rows.Count > 0)
                    {
                        int idenfimo = (int)apicDT.Rows[0][0];
                        throw new Exception("El ID (" + edtIDApic.Text + ") pertence al apicultor " + idenfimo);
                    }
                    else
                    {
                        int idenfimo = entidades.AltaPersonaFisica(edtPaisPF.Text, edtEstadoPF.Text, edtCiudadPF.Text, (char)edtGenero.Value, edtFechaNac.Date,
                                          edtPrimerAp.Text, edtSegundoAp.Text, edtPrimerNom.Text, edtSegundoNom.Text, "",
                                          (int)Session["idusr"], 30/*30 significa Delegado*/, "", "", "", "");
                    }
                }
                else
                {
                    ASPxComboBox edtEntidad = (ASPxComboBox)pagectrlApic.FindControl("edtEntidad");
                    //ASPxComboBox edtPrimerNom = (ASPxComboBox)GeneralesGroup.FindControl("edtPrimerNom");
                    entidades.CreaRelacionDelegadoApicultor((int)Session["idusr"], (int)edtEntidad.Value);
                }
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                throw ex;
            }
           
              
            grid.CancelEdit();
            grid.DataBind();
        }

        protected void gridTamDisp_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                double stock = (double)e.GetValue("STK");
                if (stock > 0)
                    e.Row.BackColor = System.Drawing.Color.FromArgb(211, 235, 183);
            }
            catch{}
        }

        protected void gridTamDisp_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)edtTamboraLlenar.FindControl("gridTamDisp");

            if (grid != null)
            {
                object[] Tambores = new object[grid.VisibleRowCount];
                object[] Stock = new object[grid.VisibleRowCount];
                object[] Capacidad = new object[grid.VisibleRowCount];
                for (int i = 0; i < grid.VisibleRowCount; i++)
                {
                    Tambores[i] = grid.GetRowValues(i, "NUM_TAMBOR");
                    Stock[i] = grid.GetRowValues(i, "STK");
                    Capacidad[i] = grid.GetRowValues(i, "CAPACIDAD");
                    
                }
                e.Properties["cpNumTambor"] = Tambores;
                e.Properties["cpStock"] = Stock;
                e.Properties["cpCapacidad"] = Capacidad;
            }
        }

        protected void btnAddComp_Click(object sender, EventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)edtTamboraLlenar.FindControl("gridTamDisp");

            float capacidad = (float)grid.GetRowValuesByKeyValue(int.Parse(edtTamboraLlenar.Text), "CAPACIDAD");
            double stock = (double)grid.GetRowValuesByKeyValue(int.Parse(edtTamboraLlenar.Text), "STK");
            lbCap.Text = capacidad.ToString();
            lbStk.Text = stock.ToString();
            //double stock = double.Parse(lbStk.Text);
            CompraMielDS compraDS = new CompraMielDS();
            //Recuperamos el apicultor que tiene una compra pendiente de aceptar
            int apicultor = compraDS.ObtenApiculorCompraPendiente(Session["idusr"].ToString());
            int ApicSelec = int.Parse(DropDownEdit.KeyValue.ToString());
            float kilos = float.Parse(edtKilogramos.Text);
            double precioUni = double.Parse(edtPrecio.Text);
            double ImporteCompra = precioUni * kilos;
            int tipomiel = int.Parse(edtTipoMiel.Value.ToString());
            //Si no existe compra pendiente por aceptar o es el mismo apicultor
            //DropDownEdit.KeyValue = apicultor;
            if (apicultor == -1 || ApicSelec == apicultor)
            {
                double montoAnual = compraDS.ObtenMontoAnual();
                double montoAnualApico = compraDS.ObtenMontoAnualDelApiculor(ApicSelec.ToString());
                if (montoAnualApico + ImporteCompra <= montoAnual)
                {
                    if (stock + kilos <= capacidad)
                    {
                        if (!compraDS.EstaEnUso(edtTamboraLlenar.Text))
                        {
                            try
                            {
                                compraDS.AgregaCompra((int)Session["idusr"], (int)Session["idarea"], DateTime.Now.Date, DateTime.Now.ToLocalTime(),
                                                                           int.Parse(edtTamboraLlenar.Text), ApicSelec, tipomiel, kilos, precioUni, stock);
                                gridCompPend.DataBind();

                                //Se actualiza el grid de los tambores disponibles
                                //ASPxGridView gridTambores = (ASPxGridView)edtTamboraLlenar.FindControl("gridTamDisp");
                                //gridTambores.DataBind();

                                //Limpiamos algunas variables
                                lbCap.Text = "";
                                lbStk.Text = "";
                                edtTamboraLlenar.Text = "";
                                edtKilogramos.Text = "";
                                edtPrecio.Text = "";

                            }
                            catch (Exception ex)
                            {
                                lbError.Text = "Error al agregar la compra: " + ex.Message;
                                popMB.ShowOnPageLoad = true;
                                throw;
                            }
                        }
                        else
                        {
                            lbError.Text = "No se puede agreagar el mismo tambor, porque se esta utilizando";
                            popMB.ShowOnPageLoad = true;
                        }
                    }
                    else
                    {
                        float kilostotales = (float)(stock + kilos);
                        lbError.Text = "EL TAMBOR " + edtTamboraLlenar.Text + " NO PUEDE CONTENER " + kilostotales.ToString() + " KILOGRAMOS DE MIEL";
                        popMB.ShowOnPageLoad = true;
                    }
                }
                else
                {
                    lbError.Text = "ADVERTENCIA \n\n NO SE PUEDE REALIZAR LA COMPRA, PORQUE EL APICULTOR \n HA SUPERADO EL MONTO";
                    popMB.ShowOnPageLoad = true;
                }

            }
            else
            {
                lbError.Text = "NO SE PUEDE REALIZAR LA COMPRA\nPORQUE NO ES EL MISMO APICULTOR,\nEN UNA COMPRA SOLO SE PUEDE SELECCIONAR UN APICULTOR";
                popMB.ShowOnPageLoad = true;
            }
        }

        protected void btnAceptaCompra_Click(object sender, EventArgs e)
        {
            try
            {
                CompraMielDS compraDS = new CompraMielDS();
                compraDS.AceptaCompra((int)Session["idusr"], (int)Session["idarea"], DateTime.Now.Date, DateTime.Now.ToLocalTime(), int.Parse(lbNumTran.Text));

                ASPxGridView grid = (ASPxGridView)DropDownEdit.FindControl("gridApicultor");
                grid.DataBind();
                ASPxGridView gridTamb = (ASPxGridView)edtTamboraLlenar.FindControl("gridTamDisp");
                gridTamb.DataBind();
                gridCompPend.DataBind();
                gridTambEnv.DataBind();
                gridPendTrans.DataBind();
            }
            catch (Exception ex)
            {
                lbError.Text = "No se pudo Aceptar la compra, Disculpe las molestias\n Detalle del Error:\n" + ex.Message; ;
                popMB.ShowOnPageLoad = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CompraMielDS compraDS = new CompraMielDS();
            if (compraDS.HayTamboresPendAceptar())
            {
                compraDS.CancelaCompra(int.Parse(lbNumTran.Text), (int)Session["idusr"], (int)Session["idarea"]);
                gridCompPend.DataBind();
                lbError.Text = "COMPRA CANCELADA";
                popMB.ShowOnPageLoad = true;
            }
            else
            {
                lbError.Text = "NO EXISTE COMPRAS A CANCELAR";
                popMB.ShowOnPageLoad = true;
                
            }
            ASPxGridView grid = (ASPxGridView)DropDownEdit.FindControl("gridApicultor");
            grid.DataBind();
            ASPxGridView gridTamb = (ASPxGridView)edtTamboraLlenar.FindControl("gridTamDisp");
            gridTamb.DataBind();
            //Limpiamos algunas variables
            lbCap.Text = "";
            lbStk.Text = "";
            edtTamboraLlenar.Text = "";
        }

        protected void btnEnvTran_Click(object sender, EventArgs e)
        {
            //select * from im_web_trans where enviado='t' and e_t='f' and activo='p' and idcompra is null and idtrans='$trans'"
            
            CompraMielDS compraDS = new CompraMielDS();
            DataTable tambpendDT = compraDS.ObtenTamboresCompraPendienteAceptar((int)Session["idusr"]);
            if (comboPlantas.Text.Length > 0)
            {
                if (lbNoTran.Text.Length > 0)
                {

                    if (tambpendDT.Rows.Count == 0)
                    {
                        System.Collections.Generic.List<object> tambores = gridTambEnv.GetSelectedFieldValues("IDTAMBOR");
                        if (tambores.Count > 0)
                        {
                            compraDS.EnviaTransferencia(tambores, int.Parse(lbNoTran.Text), (int)Session["idusr"], int.Parse(comboPlantas.Value.ToString()));
                            gridTambEnv.DataBind();
                            gridHistorialRec.DataBind();
                            lbError.Text = "LA TRANSFERENCIA " + lbNoTran.Text + " HA SIDO ENVIADA EN " + Session["idarea"].ToString() + " DE MANERA SATISFACTORIA";
                            popMB.ShowOnPageLoad = true;
                        }
                        else
                        {
                            lbError.Text = "ADVERTENCIA\n\nSELECCIONE UN TAMBOR AL MENOS PARA ENVIAR LA TRANSFERENCIA";
                            popMB.ShowOnPageLoad = true;
                        }
                    }
                    else
                    {
                        lbError.Text = "ADVERTENCIA :\n\n NO SE PUEDE ENVIAR LA TRANSFERENCIA " + lbNoTran.Text + " \n PORQUE HAY COMPRAS AGREGADOS SIN ACEPTAR \n SI DESEA ENVIAR LA TRANSFERENCIA,\n FAVOR DE CANCELAR O ACEPTAR LAS COMPRAS AGREGADOS";
                        popMB.ShowOnPageLoad = true;
                    }
                }
                else
                {
                    lbError.Text = "ADVERTENCIA\n\nNO SE PUEDE REALIZAR LA TRANSFERENCIA PORQUE\nNO HAY TRANSFERENCIA ACTIVA NECESITA ACTIVAR UNA TRANSFERENCIA REALIZANDO UNA COMPRA LUEGO PODRA REALIZAR LA TRANSFERENCIA";
                    popMB.ShowOnPageLoad = true;
                }
            }
            else
            {
                lbError.Text = "ADVERTENCIA\n\nNO HA SELECCIONADO EL AREA DESTINO";
                popMB.ShowOnPageLoad = true;
            }

        }

        protected void gridTambEnv_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            /*if (e.ButtonType == DevExpress.Web.ASPxGridView.ColumnCommandButtonType.SelectCheckbox)
            {
                string strMuestreado = (string)gridTambEnv.GetRowValues(e.VisibleIndex, "STATUS");
                if (strMuestreado == "SI")
                    e.Enabled = false;
            }*/
        }

        protected void gridTambEnv_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IDTAMBOR")
            {
                string strMuestreado = (string)gridTambEnv.GetRowValues(e.VisibleRowIndex, "STATUS");
                int idTambor = (int)gridTambEnv.GetRowValues(e.VisibleRowIndex, "IDTAMBOR");
                int idTrans = (int)gridTambEnv.GetRowValues(e.VisibleRowIndex, "IDTRANS");
                int valor = (int)e.Value;
                if (strMuestreado == "SI")
                {
                    e.DisplayText = "<a Target=\"_blank\" href=\"../Reportes/ImpMuestras.aspx?idtrans=" + idTrans.ToString() + "&idtambor=" + idTambor.ToString() + "\">" + valor.ToString() + "</a>";
                    btnReimprimir.Visible = true;
                }
            }
        }

        protected void btnMuestrear_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<object> tambores = gridTambEnv.GetSelectedFieldValues("IDTAMBOR");
            System.Collections.Generic.List<object> status = gridTambEnv.GetSelectedFieldValues("STATUS");
            for (int i=0; i < status.Count; i++)
            {
                if (((string)status[i]) == "SI")
                {
                    lbError.Text = "SELECCIONA SOLO TAMBORES NO MUESTREADOS";
                    popMB.ShowOnPageLoad = true;
                    return;
                }
            }
            
                if (lbNoTran.Text.Length > 0)
                {
                    if (tambores.Count > 0)
                    {
                        MuestreoDS muestrear = new MuestreoDS();
                        muestrear.GeneraMuestreo(int.Parse(lbNoTran.Text), tambores, DateTime.Now.Date, DateTime.Now.ToLocalTime(), (int)Session["idusr"], (int)Session["idarea"]);
                        gridTambEnv.DataBind();
                        lbError.Text = "LOS TAMBORES SELECCIONADOS HAN SIDO MUESTREADOS";
                        popMB.ShowOnPageLoad = true;
                    }
                    else
                    {
                        lbError.Text = "SELECCIONA LOS TAMBORES PARA MUESTREAR";
                        popMB.ShowOnPageLoad = true;
                    }
                }
                else
                {
                    lbError.Text = "Necesita activar una transferencia realizando una compra";
                    popMB.ShowOnPageLoad = true;
                }
        }

        protected void gridHistorialRec_BeforePerformDataSelect(object sender, EventArgs e)
        {
           
        }

        protected void gridTambores_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["idHistTranMiel"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void pagectrlApic_ActiveTabChanged(object source, TabControlEventArgs e)
        {

        }

        protected void edtPrimerNom_ButtonClick(object source, ButtonEditClickEventArgs e)
        {

        }

        protected void gridPendTrans_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IDCOMPRA")
            {
                /*string strMuestreado = (string)gridTamb.GetRowValues(e.VisibleRowIndex, "STATUS");
                int idTambor = (int)gridTamb.GetRowValues(e.VisibleRowIndex, "IDTAMBOR");
                int idTrans = (int)gridTamb.GetRowValues(e.VisibleRowIndex, "IDTRANS");
                
                if (strMuestreado == "SI")
                {*/
                int valor = (int)e.Value;
               // int idTrans = 300;
                e.DisplayText = "<a Target=\"_blank\" href=\"../Reportes/ImpCompraMiel.aspx?idcompra=" + valor.ToString() + "\">" + valor.ToString() + "</a>";
                
            }
        }


    }
}
