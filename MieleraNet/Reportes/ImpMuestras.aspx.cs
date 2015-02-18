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
    public partial class ImpMuestras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idtrans"] != null)
                ReportViewer1.Report = CreateReport();
        }

        XtraReport CreateReport()
        {
            repMuestras report = new repMuestras();
            if (Request.QueryString["idTambor"] == null)
            {
                report.paramEsTambor.Value = false;
                report.paramIDTrans.Value = Request.QueryString["idtrans"].ToString();
                report.CreateDocument();
            }else
            {
                report.paramEsTambor.Value = true;
                report.paramIDTrans.Value = Request.QueryString["idtrans"].ToString();
                report.paramIDTambor.Value = Request.QueryString["idTambor"].ToString();
                report.CreateDocument();
            }
            return report;
        }
    }
}
