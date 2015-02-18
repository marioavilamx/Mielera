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
using DevExpress.XtraReports.UI;

namespace MieleraNet.Reportes
{
    public partial class SagarpaEnt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //XtraReport CreateReport()
        //{
        //    repTrazaEntSagarpa report = new repTrazaEntSagarpa();
            
        //    //report.paramIDEmpresa.Value = Session["idEmpresa"];
        //    if (chkNombre.Checked)
        //        report.paramConNombre.Value = true;
        //    else
        //        report.paramConNombre.Value = false;
        //    report.paramIDProd.Value = cmbLotes.Value;
        //    report.CreateDocument();

        //    return report;
        //}

        protected void cmbLotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLotes.Text.Length > 0)
            {
                btnGenEntrada.Enabled = true;
                btnGenEntradaIntegradora.Enabled = true;
            }
            else
            {
                btnGenEntrada.Enabled = false;
                btnGenEntradaIntegradora.Enabled = false;
            }
            //tbTrazSalida.ReportViewer = rvTrazEnt;
        }

        protected void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLotes.Text = "";
            btnGenEntrada.Enabled = false;
            btnGenEntradaIntegradora.Enabled = false;
        }

        protected void cmbAnioSal_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLotesSal.Text = "";
            btnGenSalida.Enabled = false;
            btnSalidaConcentrado.Enabled = false;
        }

        protected void cmbLotesSal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLotesSal.Text.Length > 0)
            {
                btnGenSalida.Enabled = true;
                btnSalidaConcentrado.Enabled = true;
            }
            else
            {
                btnGenSalida.Enabled = false;
                btnSalidaConcentrado.Enabled = false;
            }
        }


    }
}
