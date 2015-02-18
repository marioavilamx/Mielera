using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using MieleraNet.Web;

namespace MieleraNet
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //MieleraHttpApplication cha = new MieleraHttpApplication();
            //cha.Application_Start(sender, e);
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            FormsAuthenticationUtil.AttachRolesToUser();
        }

    }
}