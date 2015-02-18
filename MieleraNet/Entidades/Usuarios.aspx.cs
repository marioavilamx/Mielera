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
using MieleraNet.DAL;

namespace MieleraNet.Entidades
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            PerifericaDS periferica = new PerifericaDS();

            try
            {
                periferica.AltaUsuarioWeb((int)edtEnfimo.Value, edtUsuario.Text, edtPass.Text, (int)edtRol.Value, edtRol.Text, (int)edtArea.Value);
                popMB.HeaderText = "MieleraNet";
                lbError.Text = "El usuario se dio de alta de manera satisfactoria";
                popMB.ShowOnPageLoad = true;
                edtOk.Visible = true;
                DlgBtnCerrar.Visible = false;
            }
            catch (Exception ex)
            {
                
                  lbError.Text = "Error al dar de alta al usuario, Disculpe las molestias\n Detalle del Error:\n" + ex.Message; ;
                  popMB.ShowOnPageLoad = true;
                  edtOk.Visible = false;
                  DlgBtnCerrar.Visible = true;
            }
        }

        protected void edtOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }
    }
}
