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
using MieleraNet.App_Data;

namespace MieleraNet.DAL
{
    public class MuestreoDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;

        public MuestreoDS()
        {
            applicationConfig objAppConfig = new applicationConfig();
            objAppConfig.configConnPeriferica(cs);

            this.fbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            fbConnection1.ConnectionString = cs.ToString();
        }

        /// <summary>
        /// Esta función ejecuta el query pasado y devuelve el resultado en un datatable
        /// </summary>
        /// <param name="query">Este parametro contiene el query que se ejecutara</param>
        /// <returns>Retorna el resultado en un DataTable</returns>
        private DataTable LlenaTabla(string query)
        {
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenTamboresNoMuestreados(int idUsuario, int idtrans)
        {
            string query = "SELECT a.idbarril as idtambor, max(nombre) as apicultor FROM im_mietam AS a " +
                           "INNER JOIN im_web_trans AS b ON b.idtrans=a.idmieltran AND a.idbarril=b.idtambor " +
                           "INNER JOIN LOCENFIS as c on c.idenfi = b.idapicultor " +
                           "WHERE b.idpersona=" + idUsuario.ToString() + "  AND b.activo='p' AND b.e_t='t' AND b.enviado IN('t','T') and a.idmieltran = " + idtrans.ToString() +
                           " AND a.idbarril NOT IN (SELECT a1.idbarril FROM im_muestra AS a1 WHERE a1.idmieltran=a.idmieltran) group by a.idbarril";
            return LlenaTabla(query);
        }

        public DataTable ObtenMuestrasActivas(int idUsuario)
        {
            string query = "SELECT a.IDMUESTRA ,a.IDMIELTRAN,a.IDBARRIL,a.IDENFI,a.STATUS,a.IMPRESO,a.ACTIVA " +
                           "FROM im_web_muestra AS a    WHERE a.activa='t' AND status='f' AND a.idenfi=" + idUsuario.ToString();
            return LlenaTabla(query);
        }

        //Para el muestreo del delegado
        public DataTable ObtenTamboresAMuestrearDelegado(int idUsuario)
        {
            string query = "SELECT DISTINCT a.idbarril,a.idmieltran FROM im_mietam AS a INNER JOIN im_web_trans AS b ON b.idtrans=a.idmieltran " +
                           "AND a.idbarril=b.idtambor WHERE b.idpersona=" + idUsuario.ToString() + " AND b.activo='p' AND b.e_t='t' AND b.enviado IN('t','T') " +
                           "AND a.idbarril NOT IN(SELECT a1.idbarril FROM im_muestra AS a1 WHERE a1.idmieltran=a.idmieltran)";
            return LlenaTabla(query);
        }

        //Para el muestreo del que recepciona
        public DataTable ObtenTransferenciasARecepcionar(int idarea)
        {
            string query = "SELECT a.idtrans FROM im_web_mieltrans AS a " +
                           "WHERE a.areatrans="+ idarea.ToString() +" AND a.activa='p' AND status='f' AND a.enviado='f' ORDER BY a.idtrans";
            return LlenaTabla(query);
        }
    
        //Para el muestreo del que recepciona
        public DataTable ObtenTransferenciasAReimprimir(int idUsuario)
        {
            string query = "SELECT idmieltran as idtrans FROM im_web_muestra " +
                           "WHERE idenfi="+ idUsuario.ToString() +" AND status='f' AND activa IN('t','f') GROUP BY idmieltran ORDER BY idmieltran";
            return LlenaTabla(query);
        }

         public DataTable ObtenTamboresPorTransferencia(int idtrans)
        {
            string query = "select a.idtambor,c.contenido,sum(preciounit)/count(*) as PrecioUnitario, " +
                           "sum(a.kilogramos)as kg,sum(a.subtotal)as tot,a.idtrans, " +
                           "(case b.status when 'f' then 'SI' else 'NO' end) as status " +
                           "from IM_WEB_TRANS as a left join im_web_muestra b on a.idtrans = b.idmieltran and a.idtambor = b.idbarril " +
                           "inner join IM_CAT_CONTENIDOS c on a.idcontenidos = c.idcontenido " +
                           "where a.idtrans=" + idtrans.ToString() + " and a.enviado= 'f' and a.activo = 'p' " +
                           "group by a.idtambor,c.contenido,a.idtrans, b.status";
            return LlenaTabla(query);
        }

        public bool HayTamboresPorMuestrear(int idtrans)
        {
            bool bHayTamb = false;
            
            string query = String.Format("SELECT muestra FROM im_web_trans WHERE idtrans={0} AND e_t='t' AND enviado='f' and muestra = 't'", idtrans);
            //string query = String.Format("select status from im_web_muestra WHERE idmieltran={0} and status <> 'f'", idtrans);
            DataTable dt = LlenaTabla(query);
            if (dt.Rows.Count > 0)
                bHayTamb = true;
            return bHayTamb;
        }

        public ReportesDS.MuestrasDTDataTable MuestrasAImprimir(string idtrans)
        {
            string query = "select idmuestra,idmieltran,idbarril, min(c.nombre) as apicultor, min(d.nombre) as delegado, min(e.area) as area " +
                           "from im_web_muestra a " +
                           "inner join im_web_trans b on a.idmieltran = b.idtrans and a.idbarril = b.idtambor " +
                           "inner join LOCENFIS c on c.idenfi = b.idapicultor " +
                           "inner join LOCENFIS d on d.idenfi = a.idenfi " +
                           "inner join areas e on e.idarea = a.idarea " +
                           "where idmieltran= " + idtrans + 
                           " group by idmuestra,idmieltran,idbarril";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            ReportesDS.MuestrasDTDataTable fdt = new ReportesDS.MuestrasDTDataTable();
            da.Fill(fdt);
            return fdt;
        }

        public ReportesDS.MuestrasDTDataTable MuestraAImprimir(string idtrans, string idtambor)
        {
            string query = "select idmuestra,idmieltran,idbarril, min(c.nombre) as apicultor, min(d.nombre) as delegado, min(e.area) as area " +
                           "from im_web_muestra a " +
                           "inner join im_web_trans b on a.idmieltran = b.idtrans and a.idbarril = b.idtambor " +
                           "inner join LOCENFIS c on c.idenfi = b.idapicultor " +
                           "inner join LOCENFIS d on d.idenfi = a.idenfi " +
                           "inner join areas e on e.idarea = a.idarea " +
                           "where idmieltran= " + idtrans +
                           " and idbarril = " + idtambor +
                           " group by idmuestra,idmieltran,idbarril";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            ReportesDS.MuestrasDTDataTable fdt = new ReportesDS.MuestrasDTDataTable();
            da.Fill(fdt);
            return fdt;
        }

        public void GeneraMuestreo(int idtrans, System.Collections.Generic.List<object> tambores, DateTime fecha, DateTime hora, int idusuario, int idarea)
        {
            string query = "";
            this.fbConnection1.Open();
            FbTransaction transaction = fbConnection1.BeginTransaction();
            try
            {
                 //Recorre los tambores a muestrear
                for (int i = 0; i < tambores.Count; i++)
                {
                    int idtambor = (int)tambores[i];
                    
                    //el generador im_muestra_gen para la tabla im_web_muestra
                    query = "SELECT GEN_ID(IM_MUESTRA_GEN_ID, 1 ) FROM RDB$DATABASE;";
                    FbCommand cmdMues = new FbCommand(query, this.fbConnection1);
                    cmdMues.Transaction = transaction;
                    FbDataReader readerMuestreo = cmdMues.ExecuteReader();

                    if (readerMuestreo.Read())
                    {
                        long idmuestra = (long)readerMuestreo.GetValue(0);
                        query = "INSERT  into im_web_muestra(idmuestra,idmieltran,idbarril,idenfi,idarea,fecha,hora,status,impreso,activa) " +
                                "VALUES(@idmuestra,@idtran,@idtambor,@idusr,@idarea,@fecha,@Hora,'f','t','t')";

                        FbCommand cmdim_web_muestra = new FbCommand(query, this.fbConnection1);
                        cmdim_web_muestra.Parameters.Add("@idmuestra", FbDbType.Integer).Value = idmuestra;
                        cmdim_web_muestra.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                        cmdim_web_muestra.Parameters.Add("@idtambor", FbDbType.Date).Value = idtambor;
                        cmdim_web_muestra.Parameters.Add("@idusr", FbDbType.Integer).Value = idusuario;
                        cmdim_web_muestra.Parameters.Add("@idarea", FbDbType.Integer).Value = idarea;
                        cmdim_web_muestra.Parameters.Add("@fecha", FbDbType.Time).Value = fecha;
                        cmdim_web_muestra.Parameters.Add("@Hora", FbDbType.Time).Value = hora;
                        cmdim_web_muestra.Transaction = transaction;
                        cmdim_web_muestra.ExecuteNonQuery();

                        //Para no hacer el query por cada tambor se realiza el update siguiente al fin del ciclo
                        //UPDATE im_web_trans SET muestra='f' WHERE idtrans='$idtransf' AND e_t='t' AND enviado='f' AND idtambor='$del_id'
                    }
                    else
                    {
                        throw new Exception("Error en el secuenciador IM_MUESTRA_GEN_ID");
                    }

                    //Este hace un update del campo muestra en la transferencia, para indicar el que tambor fue muestreado de esta transferencia.
                    //query = "UPDATE im_web_trans SET muestra='f' WHERE idtrans=@idtrans AND idpersona=@idusuario  " +
                    //         "AND idtambor	IN(SELECT idbarril FROM im_web_muestra WHERE idbarril=@idtambor)";
                    query = "UPDATE im_web_trans SET muestra='f' WHERE idtrans=@idtrans  " +
                             "AND idtambor	IN(SELECT idbarril FROM im_web_muestra WHERE idbarril=@idtambor)";
                    FbCommand cmdUpdatedetalle = new FbCommand(query, this.fbConnection1);
                    cmdUpdatedetalle.Parameters.Add("@idtrans", FbDbType.Integer).Value = idtrans;
                    //cmdUpdatedetalle.Parameters.Add("@idusuario", FbDbType.Integer).Value = idusuario;
                    cmdUpdatedetalle.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                    cmdUpdatedetalle.Transaction = transaction;
                    cmdUpdatedetalle.ExecuteNonQuery();

                    //Inserta en la table im_muestra
                    query = "INSERT INTO im_muestra (IDMUESTRA,IDMIELTRAN,IDBARRIL,IDENFI,IDAREA,FECHA,HORA )  " +
                             "SELECT IDMUESTRA, IDMIELTRAN,IDBARRIL,IDENFI,IDAREA,FECHA,HORA FROM im_web_muestra " +
                             "WHERE idbarril=@idtambor AND status='f' AND activa='t'";
                    FbCommand cmdim_muestra= new FbCommand(query, this.fbConnection1);
                    cmdim_muestra.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                    cmdim_muestra.Transaction = transaction;
                    cmdim_muestra.ExecuteNonQuery();
                }

                transaction.Commit();
                this.fbConnection1.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }
    }
}
