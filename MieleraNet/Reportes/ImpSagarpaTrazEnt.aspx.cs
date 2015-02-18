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
    public partial class ImpSagarpaTrazEnt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           if (Request.QueryString["idProd"] != null)
            repTrazEnt.Report = CreateReport();
        }

        XtraReport CreateReport()
        {
            repTrazaEntSagarpa report = new repTrazaEntSagarpa();


            if (Request.QueryString["bSalida"] == "true")
                report.paramEsDetallado.Value = true;
            else
                report.paramEsDetallado.Value = false;

            //report.paramIDEmpresa.Value = Session["idEmpresa"];
            if (Request.QueryString["bNom"] != null)
            {
                if (Request.QueryString["bNom"].ToString().ToUpper() == "TRUE")
                    report.paramConNombre.Value = true;
                else
                    report.paramConNombre.Value = false;
            }

            report.paramIDProd.Value = int.Parse(Request.QueryString["idProd"].ToString());
            report.CreateDocument();

            return report;
        }
    }
}
