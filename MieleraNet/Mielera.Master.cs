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
using MieleraNet.Web;

namespace MieleraNet
{

    public partial class Mielera : System.Web.UI.MasterPage
    {
        public class MySiteMapProvider : UnboundSiteMapProvider
        {
            public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
            {
                return IsRolesAccessibleToCurrentUser(node.Roles);
            }
        }

        
        public static bool IsRolesAccessibleToCurrentUser(IList roles)
        {
            // TODO: Your custom logic here
            //string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            
            //this.Page.User
            bool bEstaenrol = false;
            if (HttpContext.Current.User.IsInRole("Administrador"))
                return true;
            foreach (string rol in roles)
            {
                if (HttpContext.Current.User.IsInRole(rol))
                    bEstaenrol = true;
            }
            return bEstaenrol;
            //HttpContext.Current.User.IsInRole("Administraodr");
            
            //if (roles.Contains("Administrador") && IsAdmin())
            //    return true;
            //return false;
        }

        protected static bool IsAdmin()
        {
            // TODO: Your custom logic here
            //return HttpContext.Current.Request.Cookies["admin_key"] != null;
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string Theme = ConfigurationManager.AppSettings["styleSheetTheme"];
            //ASPxSiteMapDataSource1.DataBind();
            MySiteMapProvider provider = new MySiteMapProvider();
            provider.SiteMapFileName = "~/web.sitemap";
            provider.EnableRoles = true;
            ASPxSiteMapDataSource1.Provider = provider;

            //string ImageUrl = "~/App_Themes/SoftOrange" + Theme + "/main_logo.jpg";
            //imgLogo.ImageUrl = ImageUrl;
            
            //lbEmpresa.Text = MieleraNet.Web.MieleraHttpApplication.NomEmpresa;
            
        }

        protected void navbarMain_PreRender(object sender, EventArgs e)
        {
            //((ASPxNavBar)sender).Groups[0].Name =
            //((ASPxNavBar)sender).Groups[1].Visible = false;
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            //MieleraNet.Web.MieleraHttpApplication.NomEmpresa = "";
            //TODO:arturo
            applicationConfig objAppConfig = new applicationConfig();
            objAppConfig.setEmpresa("");
        }
    }
}
