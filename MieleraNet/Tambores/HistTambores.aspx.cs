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
using DevExpress.Web;

namespace MieleraNet.Tambores
{
    public partial class HistTambores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridTambores_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["idHistTamRec"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
    }
}
