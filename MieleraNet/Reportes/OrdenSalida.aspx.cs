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
    public partial class OrdenSalida1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               ReportViewer1.Report = CreateReport();
        }
        
        XtraReport CreateReport()
        {
            OrdenSalida report = new OrdenSalida();
            report.Parameters["paramOrigen"].Value   = Request.QueryString["origen"].ToString();
            report.Parameters["paramFecha"].Value    = (string)Session["fechaOrden"];//Request.QueryString["fecha"].ToString();
            report.Parameters["paramOperador"].Value = Request.QueryString["operador"].ToString();
            report.Parameters["paramDestino"].Value  = Request.QueryString["destino"].ToString();
            report.Parameters["paramFletera"].Value  = Request.QueryString["fletera"].ToString();
            report.Parameters["paramContrato"].Value = (string)Session["ContExp"]; //Request.QueryString["contrato"].ToString();
            report.CreateDocument();
            
            return report;
        }
    }
}
