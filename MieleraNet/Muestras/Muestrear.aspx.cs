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

namespace MieleraNet.Muestras
{
    public partial class Muestrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CompraMielDS compraDS = new CompraMielDS();
            lbDelegado.Text = compraDS.ObtenDelegado((int)Session["idusr"]);
            lbArea.Text = compraDS.ObtenArea((int)Session["idarea"]);
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
            }
            cmbTranferencias.Text = "";
            cmbTranferencias.DataBind();
        }

        protected void cmbTranferencias_ValueChanged(object sender, EventArgs e)
        {
            MuestreoDS muestreo = new MuestreoDS();
            if (muestreo.HayTamboresPorMuestrear(int.Parse(cmbTranferencias.Text)))
            {
                btnAceptaTran.Visible = true;
            }
            else
            {
                btnAceptaTran.Visible = false;
            }
        }

        protected void gridTamb_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IDTAMBOR")
            {
                string strMuestreado = (string)gridTamb.GetRowValues(e.VisibleRowIndex, "STATUS");
                int valor = (int)e.Value;
                if (strMuestreado == "SI")
                    e.DisplayText = "<a href=http://wwww.google.com.mx>" + valor.ToString() + "</a>";
            }
        }

        protected void gridTamb_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCommandButtonEventArgs e)
        {
            if (e.ButtonType == DevExpress.Web.ASPxGridView.ColumnCommandButtonType.SelectCheckbox)
            {
                string strMuestreado = (string)gridTamb.GetRowValues(e.VisibleIndex, "STATUS");
                if (strMuestreado == "SI")
                    e.Enabled = false;
            }
        }
    }
}
