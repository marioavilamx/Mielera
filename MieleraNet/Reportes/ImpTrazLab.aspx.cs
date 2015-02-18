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
    public partial class ImpTrazLab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           if (Request.QueryString["idProd"] != null)
               repTrazSal.Report = CreateReport();
            
            
        }

        XtraReport CreateReport()
        {
            repTrazLab report = new repTrazLab();

            //report.paramIDEmpresa.Value = Session["idEmpresa"];
            //if (Request.QueryString["bNom"].ToString().ToUpper() == "TRUE")
            //    report.paramConNombre.Value = true;
            //else
            //    report.paramConNombre.Value = false;
            
            report.paramEsDetallado.Value = true;
            report.paramIDProd.Value = int.Parse(Request.QueryString["idProd"].ToString());
            //report.paramFechaSalida.Value = DateTime.Parse(Request.QueryString["fSalida"].ToString());
            //report.paramExportKg.Value = double.Parse(Request.QueryString["kg"].ToString());
            report.CreateDocument();

            return report;
        }
    }
}
