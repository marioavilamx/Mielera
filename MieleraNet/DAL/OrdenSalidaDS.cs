using System;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using MieleraNet.Web;

namespace MieleraNet.DAL
{
    public class OrdenSalidaDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;
        public OrdenSalidaDS()
        {

            using (applicationConfig objAppConfig = new applicationConfig())
            {
                objAppConfig.configConnPeriferica(cs);
            }

            this.fbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            fbConnection1.ConnectionString = cs.ToString();  
        }
        private DataTable LlenaTabla(string query)
        {
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        
        public DataTable getOrdenSalida(string contrato)
        {
            string query = "select * from MI_ORDENSALIDA where idcontrato="+contrato;
            return LlenaTabla(query);
        }

                                           
    }
}
