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
    public partial class ImpTamboresExp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rvTamboresExp.Report = CreateReport();
        }

        XtraReport CreateReport()
        {
            repTambExp report = new repTambExp();

            //report.paramIDEmpresa.Value = Session["idEmpresa"];
            //report.paramIDTrans.Value = Request.QueryString["idtran"].ToString();
            report.CreateDocument();

            return report;
        }
    }
}
