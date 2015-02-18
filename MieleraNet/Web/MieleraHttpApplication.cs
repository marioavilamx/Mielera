using System;

using MieleraNet.BLL;
using FirebirdSql.Data.FirebirdClient;
using System.Web.SessionState;





namespace MieleraNet.Web
{
    
    /// <summary>
    /// Summary description for MieleraHttpApplication
    /// </summary>
    public class MieleraHttpApplication /*: HttpApplication*/
    {

        private  object _settingsLock = new object();
       

        private  SiteSettings _settings;
        private  string _siteUrl;
        private  string _nomempresa="";

        public SiteSettings MieleraApplicationSettings
        {
            get
            {
                if (_settings == null)
                    MieleraApplicationSettings = SiteSettings.LoadFromConfiguration();
                return _settings;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("MieleraApplicationSettings cannot be set to null");
                lock (_settingsLock)
                {
                    _settings = value;
                }
            }
        }

        public  string NomEmpresa
        {
            get
            {
                return _nomempresa;
            }
            set
            {
                    _nomempresa = value;
            }
        }

        public string SiteUrl
        {
            get
            {
                return _siteUrl;
            }
        }
        

        public void Application_Start(Object sender, EventArgs e)
        {
            //_siteUrl = GetSiteUrl();
            
            // set-up Settings
            //TODO: Arturo 
            //MieleraHttpApplication.MieleraApplicationSettings = SiteSettings.LoadFromConfiguration();

            /*// set-up maintenance timer
            _lastNotificationTime = DateTime.Now;
            TimerCallback callback = new TimerCallback(Maintenance.HourlyMaintenanceTimer);
            Timer _hourlyTimer = new Timer(callback, null, TimeSpan.Zero, TimeSpan.FromHours(1.0));*/
        }



        /*private string GetSiteUrl()
        {
            string baseUrl = "";

            return baseUrl;
        }*/

        void Application_End(Object sender, EventArgs e)
        {
            
        }

        void Application_Error(Object sender, EventArgs e)
        {

        }

        internal void setSession(System.Web.SessionState.HttpSessionState Session)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    //TODO: Arturo: clase para acceder a la variable Session["httpApplication"]

    /// <summary>
    ///arturo:
    ///Clase que enmascara el acceso a la variable de session Session["httpApplication"]
    ///
    /// </summary>
    public class applicationConfig : System.Web.UI.Page  
    {

        //private System.Web.SessionState.HttpSessionState Session;
        private MieleraHttpApplication mieleraHttp;
        public applicationConfig()
        {
         // Session= new System.Web.SessionState.HttpSessionState();
            MieleraHttpApplication httpApplication = (MieleraHttpApplication)Session["httpApplication"];
            if (httpApplication == null)
            {
                ///solo se instancia una vez la clase MieleraHttpApplication
                mieleraHttp = new MieleraHttpApplication();
                mieleraHttp.MieleraApplicationSettings = SiteSettings.LoadFromConfiguration();
                Session["httpApplication"] = mieleraHttp;
               
            }
            else
            {
                ///Configuramos la empresa
                if (httpApplication.NomEmpresa == "" || httpApplication.NomEmpresa == null)
                    httpApplication.NomEmpresa = (string)Session["Empresa"];
            }


       }
        //TODO: Arturo: método para configurar la conexión a periférica.
        public  void configConnPeriferica(FbConnectionStringBuilder connString)
        {
            MieleraHttpApplication  httpApplication = (MieleraHttpApplication)Session["httpApplication"];
            connString.DataSource = httpApplication.MieleraApplicationSettings.DataSourcePeriferica;
            connString.Database   = httpApplication.MieleraApplicationSettings.DatabasePeriferica;
            connString.UserID     = httpApplication.MieleraApplicationSettings.UserIDPeriferica;
            connString.Password   = httpApplication.MieleraApplicationSettings.imagePeriferica;
            connString.Dialect    = int.Parse(httpApplication.MieleraApplicationSettings.DialectPeriferica);

            

        }
        ///<summary>
        ///método para determinar si se trata de una aplicación demo
        /// </summary>
        
        public  bool esDemo()
        {
            MieleraHttpApplication httpApplication = (MieleraHttpApplication)Session["httpApplication"];
            return httpApplication.MieleraApplicationSettings.bEsDemo;
        }

        /// <summary>
        /// para configurar la conexión a central
        /// </summary>
        /// <param name="cs">FbConnectionStringBuilder</param>
        public  void configConnCentral(FbConnectionStringBuilder cs)
        {
            MieleraHttpApplication httpApplication = (MieleraHttpApplication)Session["httpApplication"];
            cs.DataSource = httpApplication.MieleraApplicationSettings.DataSourceCentral;
            cs.Database   = httpApplication.MieleraApplicationSettings.DatabaseCentral;
            cs.UserID     = httpApplication.MieleraApplicationSettings.UserIDCentral;
            cs.Password   = httpApplication.MieleraApplicationSettings.imageCentral;
            cs.Dialect    = int.Parse(httpApplication.MieleraApplicationSettings.DialectCentral);
        }
        /// <summary>
        /// Para configurar la conexión a demo
        /// </summary>
        /// <param name="cs">FbConnectionStringBuilder</param>
        public  void configConnDemo(FbConnectionStringBuilder cs)
        {
            MieleraHttpApplication httpApplication = (MieleraHttpApplication)Session["httpApplication"];
            cs.DataSource = httpApplication.MieleraApplicationSettings.DataSourceDemo;
            cs.Database   = httpApplication.MieleraApplicationSettings.DatabaseDemo;
            cs.UserID     = httpApplication.MieleraApplicationSettings.UserIDDemo;
            cs.Password   = httpApplication.MieleraApplicationSettings.imageDemo;
            cs.Dialect    = int.Parse(httpApplication.MieleraApplicationSettings.DialectDemo);
        }
        
        ///<summary>
        ///Asigna a Session["httpApplication"] los datos leidos de la base de datos
        ///</summary>
        public  void setPeriferica(string dsPeriferica,string dbPeriferica,string userIdPeriperica,string imgPeriferica,string dialectPeriferica)
        {
            MieleraHttpApplication httpApplication = (MieleraHttpApplication)Session["httpApplication"];
            httpApplication.MieleraApplicationSettings.DataSourcePeriferica = dsPeriferica;
            httpApplication.MieleraApplicationSettings.DatabasePeriferica   = dbPeriferica;
            httpApplication.MieleraApplicationSettings.UserIDPeriferica     = userIdPeriperica;
            httpApplication.MieleraApplicationSettings.imagePeriferica      = imgPeriferica;
            httpApplication.MieleraApplicationSettings.DialectPeriferica    = dialectPeriferica;
            Session["httpApplication"] = httpApplication;
        }
        /// <summary>
        /// Configura la empresa
        /// </summary>
        /// <param name="empresa">Razón social.</param>
        public void setEmpresa(string empresa)
        {
            MieleraHttpApplication httpApplication = (MieleraHttpApplication)Session["httpApplication"];
            httpApplication.NomEmpresa = empresa;
            Session["httpApplication"] = httpApplication;
        }

        public string getEmpresa()
        {
            string result = "";
            MieleraHttpApplication httpApplication = (MieleraHttpApplication)Session["httpApplication"];
            if (httpApplication!=null)
                result=httpApplication.NomEmpresa;
            return result;
        }

    }
    
}
