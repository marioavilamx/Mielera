using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Xml.Serialization;

//using AspNet.StarterKits.Classifieds.Web;


namespace MieleraNet.BLL
{
    /// <summary>
    /// Contains the implementation for the site settings.
    /// </summary>
    public class SiteSettings
    {
        private const string XmlConfigFile = "~/App_Data/site-config.xml";
        //private AdminNotificationSetting _adminNotification;

        private string _siteName;
        private string _siteEmail;
        private string _DataSourceCentral;
        private string _DatabaseCentral;
        private string _UserIDCentral;
        private string _imageCentral;
        private string _DialectCentral;
        private string _DataSourceDemo;
        private string _DatabaseDemo;
        private string _UserIDDemo;
        private string _imageDemo;
        private string _DialectDemo;
        private string _DataSourcePeriferica;
        private string _DatabasePeriferica;
        private string _UserIDPeriferica;
        private string _imagePeriferica;
        private string _DialectPeriferica;
        /*[System.ComponentModel.TypeConverter(typeof(System.ComponentModel.EnumConverter))]*/
        public bool bEsDemo = false;

        public string SiteName
        {
            get
            {
                return _siteName;
            }
            set
            {
                lock (this)
                {
                    _siteName = value;
                }
            }
        }

        public string SiteEmailAddress
        {
            get
            {
                return _siteEmail;
            }
            set
            {
                lock (this)
                {
                    _siteEmail = value;
                }
            }
        }

        public string SiteEmailFromField
        {
            get
            {
                return String.Format("{0} <{1}>", _siteName, _siteEmail);
            }
        }


        #region Datos de conexion para la base de datos central
        public string DataSourceCentral
        {
            get
            {
                return _DataSourceCentral;
            }
            set
            {
                lock (this)
                {
                    _DataSourceCentral = value;
                }
            }
        }

        public string DatabaseCentral
        {
            get
            {
                return _DatabaseCentral;
            }
            set
            {
                lock (this)
                {
                    _DatabaseCentral = value;
                }
            }
        }

        public string UserIDCentral
        {
            get
            {
                return _UserIDCentral;
            }
            set
            {
                lock (this)
                {
                    _UserIDCentral = value;
                }
            }
        }

        public string imageCentral
        {
            get
            {
                return _imageCentral;
            }
            set
            {
                lock (this)
                {
                    _imageCentral = value;
                }
            }
        }

        public string DialectCentral
        {
            get
            {
                return _DialectCentral;
            }
            set
            {
                lock (this)
                {
                    _DialectCentral = value;
                }
            }
        }

        #endregion

        #region Datos de conexion para la base de datos Demo
        public string DataSourceDemo
        {
            get
            {
                return _DataSourceDemo;
            }
            set
            {
                lock (this)
                {
                    _DataSourceDemo = value;
                }
            }
        }

        public string DatabaseDemo
        {
            get
            {
                return _DatabaseDemo;
            }
            set
            {
                lock (this)
                {
                    _DatabaseDemo = value;
                }
            }
        }

        public string UserIDDemo
        {
            get
            {
                return _UserIDDemo;
            }
            set
            {
                lock (this)
                {
                    _UserIDDemo = value;
                }
            }
        }

        public string imageDemo
        {
            get
            {
                return _imageDemo;
            }
            set
            {
                lock (this)
                {
                    _imageDemo = value;
                }
            }
        }

        public string DialectDemo
        {
            get
            {
                return _DialectDemo;
            }
            set
            {
                lock (this)
                {
                    _DialectDemo = value;
                }
            }
        }

        #endregion

        #region Datos de conexion para la base de datos periferica
        public string DataSourcePeriferica
        {
            get
            {
                return _DataSourcePeriferica;
            }
            set
            {
                lock (this)
                {
                    _DataSourcePeriferica = value;
                }
            }
        }

        public string DatabasePeriferica
        {
            get
            {
                return _DatabasePeriferica;
            }
            set
            {
                lock (this)
                {
                    _DatabasePeriferica = value;
                }
            }
        }

        public string UserIDPeriferica
        {
            get
            {
                return _UserIDPeriferica;
            }
            set
            {
                lock (this)
                {
                    _UserIDPeriferica = value;
                }
            }
        }

        public string imagePeriferica
        {
            get
            {
                return _imagePeriferica;
            }
            set
            {
                lock (this)
                {
                    _imagePeriferica = value;
                }
            }
        }

        public string DialectPeriferica
        {
            get
            {
                return _DialectPeriferica;
            }
            set
            {
                lock (this)
                {
                    _DialectPeriferica = value;
                }
            }
        }

        #endregion

        public static SiteSettings LoadFromConfiguration()
        {
            SiteSettings s = LoadFromXml();

            if (s == null)
            {
                s = new SiteSettings();
                //s.AdminNotification = AdminNotificationSetting.None;
                //SaveToXml(s);
            }
            return s;
        }

        /*public static SiteSettings GetSharedSettings()
        {
            //return ClassifiedsHttpApplication.ClassifiedsApplicationSettings;
        }*/

        /*public static bool UpdateSettings(SiteSettings newSettings)
        {
            // write settings to code or db

            // update Application-wide settings, only over-writing settings that users should edit
            lock (ClassifiedsHttpApplication.ClassifiedsApplicationSettings)
            {
                // Ads must be activated before appearing on the site
                ClassifiedsHttpApplication.ClassifiedsApplicationSettings.AdActivationRequired = newSettings.AdActivationRequired;

                // Store Photos in Database
                ClassifiedsHttpApplication.ClassifiedsApplicationSettings.StorePhotosInDatabase = newSettings.StorePhotosInDatabase;
                // ... else: use the following directory to save uploaded Photos:
                ClassifiedsHttpApplication.ClassifiedsApplicationSettings.ServerPhotoUploadDirectory = newSettings.ServerPhotoUploadDirectory;


                // Maximum Number of Photos to Upload
                ClassifiedsHttpApplication.ClassifiedsApplicationSettings.MaxPhotosPerAd = newSettings.MaxPhotosPerAd;
                
                // Maximum Number of Days for which an Ad is active
                ClassifiedsHttpApplication.ClassifiedsApplicationSettings.MaxAdRunningDays = newSettings.MaxAdRunningDays;

                // Allow Users to edit their own Ads
                ClassifiedsHttpApplication.ClassifiedsApplicationSettings.AllowUsersToEditAds = newSettings.AllowUsersToEditAds;

                // Users to delete ads direclty in the database
                ClassifiedsHttpApplication.ClassifiedsApplicationSettings.AllowUsersToDeleteAdsInDB = newSettings.AllowUsersToDeleteAdsInDB;

                // Notifications to Administrators
                ClassifiedsHttpApplication.ClassifiedsApplicationSettings.AdminNotification = newSettings.AdminNotification;

                // Site Name
                ClassifiedsHttpApplication.ClassifiedsApplicationSettings.SiteName = newSettings.SiteName;

                // Contact Email Address for Site
                ClassifiedsHttpApplication.ClassifiedsApplicationSettings.SiteEmailAddress = newSettings.SiteEmailAddress;

                // Serialize to Xml Config File
                return SaveToXml(ClassifiedsHttpApplication.ClassifiedsApplicationSettings);
            }
        }*/

        private static SiteSettings LoadFromXml()
        {
            SiteSettings settings = null;

            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                string configPath = context.Server.MapPath(XmlConfigFile);

                XmlSerializer xml = null;
                FileStream fs = null;

                bool success = false;
                int numAttempts = 0;

                while (!success && numAttempts < 2)
                {
                    try
                    {
                        numAttempts++;
                        xml = new XmlSerializer(typeof(SiteSettings));
                        fs = new FileStream(configPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        settings = xml.Deserialize(fs) as SiteSettings;
                        success = true;
                    }
                    catch (Exception x)
                    {
                        // if an exception is thrown, there might have been a sharing violation;
                        // we wait and try again (max: two attempts)
                        success = false;
                        System.Threading.Thread.Sleep(1000);
                        if (numAttempts == 2)
                            throw new Exception("The Site Configuration could not be loaded.", x);
                    }
                }

                if (fs != null)
                    fs.Close();
            }

            return settings;

        }

        public string GetXml()
        {
            StringBuilder result = new StringBuilder();
            StringWriter s = new StringWriter(result);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(SiteSettings));
                xml.Serialize(s, this);
            }
            finally
            {
                s.Close();
            }
            
            return result.ToString();

        }

        private static bool SaveToXml(SiteSettings settings)
        {
            if (settings == null)
                return false;

            HttpContext context = HttpContext.Current;
            if (context == null)
                return false;

            string configPath = context.Server.MapPath(XmlConfigFile);

            XmlSerializer xml = null;
            System.IO.FileStream fs = null;

            bool success = false;
            int numAttempts = 0;

            while (!success && numAttempts < 2)
            {
                try
                {
                    numAttempts++;
                    xml = new XmlSerializer(typeof(SiteSettings));
                    fs = new FileStream(configPath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                    xml.Serialize(fs, settings);
                    success = true;
                }
                catch
                {
                    // if an exception is thrown, there might have been a sharing violation;
                    // we wait and try again (max: two attempts)
                    success = false;
                    System.Threading.Thread.Sleep(1000);
                }
            }

            if (fs != null)
                fs.Close();

            return success;

        }
    }
}

