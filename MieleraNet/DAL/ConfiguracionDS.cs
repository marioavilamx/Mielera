using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FirebirdSql.Data.FirebirdClient;
using MieleraNet.Web;

namespace MieleraNet.DAL
{
    public class ConfiguracionDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;

        public ConfiguracionDS()
        {
           
            using (applicationConfig objAppConfig = new applicationConfig())
            {
                objAppConfig.configConnPeriferica(cs);
            }

            this.fbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            fbConnection1.ConnectionString = cs.ToString();
        }

        public string ObtenValor(string modulo, string parametro)
        {
            string valor = "";
            this.fbConnection1.Open();

            string query = "SELECT VALOR FROM MI_CONFIGURACION_EMPRESA " +
                           "WHERE MODULO=@modulo and PARAMETRO='DIASMUESTRA'";
            FbCommand cmdGetValor = new FbCommand(query, this.fbConnection1);
            cmdGetValor.Parameters.Add("@modulo", FbDbType.VarChar).Value = modulo;
            cmdGetValor.Parameters.Add("@parametro", FbDbType.VarChar).Value = parametro;
            FbDataReader readerGetValor = cmdGetValor.ExecuteReader();
            if (readerGetValor.Read())
            {
                valor = (string)readerGetValor.GetValue(0);
            }
            return valor;
        }
    }
}
