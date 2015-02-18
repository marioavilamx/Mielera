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
    public partial class ImpCortesxFecha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                edtFechaIni.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                edtFechaFin.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            }
            ReportViewer1.Report = CreateReport();
        }

        XtraReport CreateReport()
        {
            repCortesxDelegado report = new repCortesxDelegado();
            //if (Request.QueryString["idTambor"] == null)
            //{
            //report.paramFechaIni.Value = edtFechaIni.Date;
            report.paramFechaIni.Value = edtFechaIni.Value;
            report.paramFechaFin.Value = edtFechaFin.Value;
            report.CreateDocument();
            //}

           return report;
        }

        protected void btnGenRep_Click(object sender, EventArgs e)
        {
            ReportViewer1.Report = CreateReport();
        }

    }
}
