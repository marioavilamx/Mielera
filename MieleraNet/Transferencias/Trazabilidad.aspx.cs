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
using MieleraNet.Reportes;

namespace MieleraNet.Transferencias
{
    public partial class Trazabilidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (cmbTrans.Text.Length > 0)
                rvTraza.Report = CreateReport();
        }

        XtraReport CreateReport()
        {
            repTrazabilidadEnt report = new repTrazabilidadEnt();

            report.paramIDEmpresa.Value = Session["idEmpresa"];
            report.paramIDTrans.Value = cmbTrans.Text;
            report.CreateDocument();

            return report;
        }

        protected void cmbTrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTrans.Text.Length > 0)
                rvTraza.Report = CreateReport();
        }
    }
}
