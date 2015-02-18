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
using MieleraNet.Web;

namespace MieleraNet
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    MieleraHttpApplication.MieleraApplicationSettings.bEsDemo = false;
            //}
            /*MieleraHttpApplication cha = new MieleraHttpApplication();
            cha.Application_Start(sender, e);*/
            edtUsuario.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            CentralDS centDS = new CentralDS();
            if (edtEmpresas.SelectedIndex >= 0)
            {
                try
                {
                    centDS.ObtenEmpresa((int)edtEmpresas.Value);

                    PerifericaDS acceso = new PerifericaDS();

                    //string roles = acceso.ObtenRoles(edtUsuario.Text, edtPassword.Text);
                    int area = 0;
                    int idusr = 0;
                    int nivel = 0;
                    //string roles = acceso.ObtenRoles("miguel", "miguel8393", ref area, ref idusr, ref nivel);
                    string roles = acceso.ObtenRoles(edtUsuario.Text, edtPassword.Text, ref area, ref idusr, ref nivel);
                    //string roles = acceso.ObtenRoles(edtUsuario.Text, "admin051", ref area, ref idusr, ref nivel);
                    
                    if (roles.Length > 1)
                    {
                        Session["idarea"] = area;
                        Session["idusr"] = idusr;
                        Session["usrNivel"] = nivel;
                        Session["Empresa"] = edtEmpresas.Text;
                        Session["idEmpresa"] = edtEmpresas.Value;
                        //MieleraNet.Web.MieleraHttpApplication.NomEmpresa = edtEmpresas.Text;//arturo
                        FormsAuthentication.SetAuthCookie(edtUsuario.Text, false);
                        FormsAuthenticationUtil.RedirectFromLoginPage(edtUsuario.Text, roles, false);
                        
                    }

                    
                }
                catch (Exception ex)
                {
                    lbError.Text = "No se pudo conectar al servidor, Disculpe las molestias\n Detalle del Error:\n" + ex.Message; ;
                    popMB.ShowOnPageLoad = true;
                }
            }
        }

        protected void btnDemo_Click(object sender, ImageClickEventArgs e)
        {
            //TODO:arturo inicia
            MieleraHttpApplication httpApplication = (MieleraHttpApplication)Session["httpApplication"];
            httpApplication.MieleraApplicationSettings.bEsDemo = true;
            Session["httpApplication"] = httpApplication;
            //MieleraHttpApplication.MieleraApplicationSettings.bEsDemo = true;
            //ARturo fin
            edtEmpresas.DataBind();
            btnLogin.Text = "Ingresar a Demo";
        }

        protected void btnProd_Click(object sender, ImageClickEventArgs e)
        {
            //TODO: arturo inicia
            //MieleraHttpApplication.MieleraApplicationSettings.bEsDemo = false;
            MieleraHttpApplication httpApplication = (MieleraHttpApplication)Session["httpApplication"];
            httpApplication.MieleraApplicationSettings.bEsDemo = false;
            Session["httpApplication"] = httpApplication;
            //arturo fin
            edtEmpresas.DataBind();
            btnLogin.Text = "Ingresar";
        }

    }
}
