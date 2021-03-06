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
    public partial class VisorReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idtran"] != null)
                ReportViewer1.Report = CreateReport();
        }

        XtraReport CreateReport()
        {
            repTamRec report = new repTamRec();
            //report.idTransferencia.Value = "102";
            if (Request.QueryString["idtran"] != null)
            {
                report.idTransferencia.Value = Request.QueryString["idtran"];
                report.CreateDocument();
            }
            return report;
        }

    }
}
