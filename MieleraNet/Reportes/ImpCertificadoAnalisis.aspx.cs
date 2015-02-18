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
    public partial class ImpCertificadoAnalisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Request.QueryString["idProd"] != null)
            rpviewerFQ.Report = CreateReport();
        }

        XtraReport CreateReport()
        {
            repCertificado report = new repCertificado();
            report.paramNumProd.Value = Request.QueryString["idProd"].ToString();
            report.CreateDocument();
            return report;
        }
    }
}
