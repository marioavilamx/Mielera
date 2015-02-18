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
using DevExpress.Utils;

namespace MieleraNet.Reportes
{
    public partial class ComprasMiel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveAs_Click(object sender, EventArgs e)
        {
            Export(true);
        }
        void Export(bool saveAs)
        {
            ASPxPivotGridExporter1.OptionsPrint.PrintHeadersOnEveryPage = true;
            ASPxPivotGridExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.False;
            ASPxPivotGridExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
            ASPxPivotGridExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
            ASPxPivotGridExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;

            string fileName = "ComprasMiel" + DateTime.Now.ToString("dd-mm-yy");
            switch (listExportFormat.SelectedIndex)
            {
                case 0:
                    ASPxPivotGridExporter1.ExportPdfToResponse(fileName, saveAs);
                    break;
                case 1:
                    ASPxPivotGridExporter1.ExportXlsToResponse(fileName, saveAs);
                    break;
                case 2:
                    ASPxPivotGridExporter1.ExportMhtToResponse(fileName, "utf-8", "ASPxPivotGrid Printing Sample", true, saveAs);
                    break;
                case 3:
                    ASPxPivotGridExporter1.ExportRtfToResponse(fileName, saveAs);
                    break;
                case 4:
                    ASPxPivotGridExporter1.ExportTextToResponse(fileName, saveAs);
                    break;
                case 5:	// TODO
                    ASPxPivotGridExporter1.ExportHtmlToResponse(fileName, "utf-8", "ASPxPivotGrid Printing Sample", true, saveAs);
                    break;
            }
        }

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            Export(false);
        }


    }
}
