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
using DevExpress.Web.ASPxGridView;

namespace MieleraNet.Transferencias
{
    public partial class RecepcioMiel : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CompraMielDS compraDS = new CompraMielDS();
            lbDelegado.Text = compraDS.ObtenDelegado((int)Session["idusr"]);
            lbArea.Text = compraDS.ObtenArea((int)Session["idarea"]);

            if (!Page.IsPostBack)
            {
                if (Page.Request["Pagina"] != null)
                {
                    if (Page.Request["Pagina"] == "1")
                    {
                        pagecontrolRecepMiel.ActiveTabIndex = 1;
                        pagecontrolRecepMiel.DataBind();
                    }
                }
            }


        }

        protected void chkReimp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReimp.Checked)
            {
                cmbTranferencias.DataSourceID = "dsReimprimir";
                btnAceptaTran.Visible = false;
            }
            else
            {
                cmbTranferencias.DataSourceID = "dsTransfARecep";
                btnAceptaTran.Visible = true;
            }
            cmbTranferencias.Text = "";
            cmbTranferencias.DataBind();
            btnReimprimir.Visible = false;
            btnMuestrear.Visible = false;
        }

        protected void cmbTranferencias_ValueChanged(object sender, EventArgs e)
        {
            MuestreoDS muestreo = new MuestreoDS();
            if (muestreo.HayTamboresPorMuestrear(int.Parse(cmbTranferencias.Text)))
            {
                //btnAceptaTran.Visible = false;
                btnMuestrear.Visible = true;
            }
            else
            {
                //if (!chkReimp.Checked)
                //   btnAceptaTran.Visible = true;
                btnMuestrear.Visible = false;
            }

            if (cmbTranferencias.Text.Length > 0)
                btnReimprimir.Visible = true;
            else
                btnReimprimir.Visible = false;
        }

        protected void gridTamb_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IDTAMBOR")
            {
                string strMuestreado = (string)gridTamb.GetRowValues(e.VisibleRowIndex, "STATUS");
                int idTambor = (int)gridTamb.GetRowValues(e.VisibleRowIndex, "IDTAMBOR");
                int idTrans = (int)gridTamb.GetRowValues(e.VisibleRowIndex, "IDTRANS");
                int valor = (int)e.Value;
                if (strMuestreado == "SI")
                {
                    e.DisplayText = "<a Target=\"_blank\" href=\"../Reportes/ImpMuestras.aspx?idtrans=" + idTrans.ToString() + "&idtambor=" + idTambor.ToString() + "\">" + valor.ToString() + "</a>";
                    btnReimprimir.Visible = true;
                }
                else
                {
                    btnMuestrear.Visible = true;
                }
            }
        }

        protected void gridTamb_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCommandButtonEventArgs e)
        {
            if (e.ButtonType == DevExpress.Web.ASPxGridView.ColumnCommandButtonType.SelectCheckbox)
            {
                //string strMuestreado = (string)gridTamb.GetRowValues(e.VisibleIndex, "STATUS");
                //if (strMuestreado == "SI")
                //    e.Enabled = false;
            }
        }

        protected void btnMuestrear_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<object> status = gridTamb.GetSelectedFieldValues("STATUS");
            for (int i = 0; i < status.Count; i++)
            {
                if (((string)status[i]) == "SI")
                {
                    lbError.Text = "SELECCIONA SOLO TAMBORES NO MUESTREADOS";
                    popMB.ShowOnPageLoad = true;
                    return;
                }
            }

            System.Collections.Generic.List<object> tambores = gridTamb.GetSelectedFieldValues("IDTAMBOR");
            if (tambores.Count > 0)
            {
                MuestreoDS muestrear = new MuestreoDS();

                try
                {
                    int numTransferencia = int.Parse(cmbTranferencias.Text);
                    int nUser = (int)Session["idusr"];
                    int nArea = (int)Session["idarea"];

                    muestrear.GeneraMuestreo(numTransferencia, tambores, DateTime.Now.Date, DateTime.Now.ToLocalTime(), nUser, nArea);
                    cmbTranferencias_ValueChanged(null, null);
                    gridTamb.DataBind();
                    gridTamb.Selection.UnselectAll();
                    lbError.Text = "LOS TAMBORES SELECCIONADOS HAN SIDO MUESTREADOS";
                    popMB.ShowOnPageLoad = true;
                }
                catch
                {
                    lbError.Text = "SELECCIONE UNA TRANSFERENCIA O SU SESION A TERMINADO";
                    popMB.ShowOnPageLoad = true;
                }
            }
            else
            {
                lbError.Text = "SELECCIONA LOS TAMBORES PARA MUESTREAR";
                popMB.ShowOnPageLoad = true;
            }
           
        }

        protected void gridTambores_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["idHistRecepTranMiel"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void btnAceptaTran_Click(object sender, EventArgs e)
        {
            int transf = int.Parse(cmbTranferencias.Value.ToString());
            int idarea = (int)Session["idarea"];
            int idusr = (int)Session["idusr"];    
            System.Collections.Generic.List<object> status = gridTamb.GetSelectedFieldValues("STATUS");

            if (status.Count < 1)
            {
                lbError.Text = "DEBE SELECCIONAR CUANDO MENOS UN TAMBOR DE LA TRANSFERENCIA";
                popMB.ShowOnPageLoad = true;
                return;
            }

            for (int i = 0; i < status.Count; i++)
            {
                if (((string)status[i]) == "NO")
                {
                    lbError.Text = "LOS TAMBORES DEBEN ESTAR MUESTREADOS PARA SU RECEPCIÓN";
                    popMB.ShowOnPageLoad = true;
                    return;
                }
            }

            

            System.Collections.Generic.List<object> tambores = gridTamb.GetSelectedFieldValues("IDTAMBOR");
            RecepTranMielDS recpmiel = new RecepTranMielDS();
            recpmiel.AceptarTransferenciaMiel(tambores, transf, idarea, idusr);

            MuestreoDS muestreos = new MuestreoDS();
            DataTable tambpendientes = muestreos.ObtenTamboresPorTransferencia(transf);
            if (tambpendientes.Rows.Count > 0)
            {
                gridTamb.DataBind();
            }
            else
            {
                recpmiel.ActualizaEncabezadoTransWeb(transf); 
                gridHistorialRec.DataBind();
                cmbTranferencias.DataBind();
                cmbTranferencias.Value = "";
                gridTamb.DataBind();
            }
            
        }
    }
}
