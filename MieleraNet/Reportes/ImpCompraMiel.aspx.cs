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
using MieleraNet.DAL;
using MieleraNet.App_Data;

namespace MieleraNet.Reportes
{
    public partial class ImpCompraMiel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idcompra"] != null)
                ReportViewer1.Report = CreateReport();
        }

        XtraReport CreateReport()
        {
            repCompraMiel report = new repCompraMiel();

            //report.paramIDTrans.Value 
            report.paramIdCompra.Value = Request.QueryString["idcompra"].ToString();
                report.CreateDocument();
            return report;
        }
    }
}
