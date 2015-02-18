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
    public class RecepTranMielDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;

        public RecepTranMielDS()
        {
            //TODO: arturo inicia
            using (applicationConfig objAppConfig = new applicationConfig())
            {
                objAppConfig.configConnPeriferica(cs);
            }
           
            //ARturo fin


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

        /// <summary>
        /// Funcion que devuelve el historial de las recepciones de miel (Plantas)
        /// </summary>
        /// <param name="idarea">el historial es en base al area del usuario</param>
        /// <returns>Retorna el historial de las recepciones de las transferencias de miel</returns>
        public DataTable ObtenHistRecepTransfMiel(int idarea)
        {
            string query = "select IDTRANS, IDDELEGADO, IDAREAB, FECHA, HORA, IDENFI, IDAREA, ACTIVA, AREATRANS, TOTALTRANS, STATUS  " +
                           "from im_web_mieltrans where activa='t' and areatrans=" + idarea.ToString() +
                           " order by idtrans ";
            return LlenaTabla(query);
        }


        /// <summary>
        /// Funcion que devuelve el historial de las recepciones de miel (Plantas)
        /// </summary>
        /// <param name="idarea">el historial es en base al area del usuario</param>
        /// <returns>Retorna el historial de las recepciones de las transferencias de miel</returns>
        public DataTable ObtenHistTamboresRecepcionTransferenciaMiel(string idtransferencia)
        {
            string query = "select b.idtambor,sum(b.kilogramos) as kilogramos,sum(b.subtotal)as subtotal,b.PRECIOUNIT, a.totaltrans,b.idtrans " +
                           "from im_web_mieltrans as a inner join im_web_trans as b on a.idtrans=b.idtrans " +
                           "where b.enviado='f' and a.status='f' and a.enviado='f' and a.idtrans= " + idtransferencia + //and b.idpersona='$idusuario'
                           " group by b.idtambor, b.PRECIOUNIT, a.totaltrans,b.idtrans";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Funicion para el encabezado del reporte de transferencias de miel
        /// </summary>
        /// <param name="idtransferencia">ID de la transferencia</param>
        /// <returns>Devuelve los datos de la transferencia</returns>
        public DataTable ObtenTransferenciaMielRep(string idtransferencia/*, string idarea*/)
        {
            string query = "select A.IDTRANS, A.IDDELEGADO, B.nombre AS NombreDelegado, A.IDAREAB, C.area as AREA_ORIGEN, A.FECHA, " +
                           "A.HORA, A.IDENFI, A.IDAREA, A.ACTIVA, A.AREATRANS, D.area AS AREA_DESTINO, A.TOTALTRANS, A.STATUS " +
                           "from im_web_mieltrans A LEFT OUTER join LOCENFIS B ON B.IDENFI = A.IDDELEGADO " +
                           "JOIN AREAS C ON C.idarea = A.idareab " +
                           "JOIN AREAS D ON D.idarea = A.areatrans " +
                           "where activa='t' and A.idtrans=" + idtransferencia;// + 
                           //"areatrans=" + idarea;
            return LlenaTabla(query);
        }

        /// <summary>
        /// Funcion para el detalle del reporte de transferencias de miel
        /// </summary>
        /// <param name="idtransferencia">ID de la transferencia</param>
        /// <returns></returns>
        public DataTable ObtenTambTransfMielRep(string idtransferencia)
        {
            string query = "select b.idtambor,sum(b.kilogramos) as k,sum(b.subtotal)as s,b.PRECIOUNIT, " +
                           "a.totaltrans,b.idtrans from im_web_mieltrans as a " +
                           "inner join im_web_trans as b on a.idtrans=b.idtrans where " +
                           "b.enviado='f' and a.status='f' and a.enviado='f' and a.idtrans= " + idtransferencia +
                           " group by b.idtambor, b.PRECIOUNIT, a.totaltrans,b.idtrans";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Funcion que devuelve el Total pagado de la transferencia
        /// </summary>
        /// <param name="idtransferencia">ID de la transferencia</param>
        /// <returns>Total Pagado</returns>
        public double ObtenTotalPagadoRep(string idtransferencia)
        {
            double tot = 0;
            string query = "select sum(pagado) as paga from im_tratam  where idtrans=" + idtransferencia.ToString();
            DataTable tbTemp = LlenaTabla(query);
            if (tbTemp.Rows.Count > 0)
                tot = (double)tbTemp.Rows[0][0];
            return tot;
        }
        

       /// <summary>
        /// Funcion para el detalle del reporte de transferencias de miel
        /// </summary>
        /// <param name="idtransferencia">ID de la transferencia</param>
        /// <returns></returns>
        public DataTable ObtenTransTrazabilidad(string idusuario)
        {
            string query = "SELECT a.idtrans FROM im_web_mieltrans AS a " +
                           "WHERE a.idenfi= " + idusuario + " AND a.status='f' AND a.enviado='f' " +
                           "ORDER BY a.idtrans ";
            return LlenaTabla(query);
        }

        public DataTable ObtenTrazabilidadEntrada(string idtran)
        {
            string query = "select  a.idbarril,a.fecha,a.idapicultor,c.nombre,b.pbruto,e.tara,b.pneto,a.preuni,b.pagado,g.idmuestra " +
                           "from im_mietam as a " +
                           "inner join im_tratam as b on a.idmieltran=b.idtrans  and a.idbarril=b.idbarril " +
                           "inner join locenfis as c on a.idapicultor=c.idenfi " +
                           "inner join im_barrils as d on a.idbarril=d.idbarril " +
                           "inner join im_cat_barriltipos as e  on d.idtipo=e.idtipo " +
                           "inner join im_web_mieltrans as f on f.idtrans=a.idmieltran " + 
                           "left outer join im_web_muestra g on a.idbarril=g.idbarril and g.idmieltran=a.idmieltran " +
                           "where a.activo in('t','p') and a.idmieltran = " + idtran +
                           "order by a.idbarril";
            return LlenaTabla(query);
        }

        public DataTable ObtenTamboresPorTransferencia(int idtrans)
        {
            string query = "select a.idtambor, " +
                           "sum(a.kilogramos)as kg,sum(a.subtotal)as tot,a.idtrans, " +
                           "(case b.status when 'f' then 'SI' else 'NO' end) as status " +
                           "from IM_WEB_TRANS as a left join im_web_muestra b on a.idtrans = b.idmieltran and a.idtambor = b.idbarril " +
                           "inner join IM_CAT_CONTENIDOS c on a.idcontenidos = c.idcontenido " +
                           "where a.idtrans=" + idtrans.ToString() + 
                           " group by a.idtambor,c.contenido,a.idtrans, b.status";
            return LlenaTabla(query);
        }

        public DataTable ObtenComprasMiel(DateTime FechaIni, DateTime FechaFin)
        {
            FechaFin = DateTime.Now;
            string query = "select a.idtrans,a.idtambor,c.nombre,d.contenido, a.kilogramos, a.preciounit,a.subtotal,a.fecha,a.hora,Extract(Year From fecha) as anio,Extract(Month From fecha) as Mes " +
                           "from IM_WEB_TRANS as a inner join locenfis as c inner join im_cat_contenidos as d " +
                           "on c.idenfi=a.idapicultor " +
                           "on a.idcontenidos=d.idcontenido " +
                           "where a.fecha between '2010-01-01' and '" + FechaFin.ToString("yy-MM-dd") +"' ";//and a.idpersona=83";
            return LlenaTabla(query);
        }



        /*public int ObtenIdPersonaTransferencia(int idtrans)
        {
            int idPersona = 0;
            string query = "select IDPERSONA " +
                           "from im_web_trans where enviado='f' and e_t='t' and idtrans=" + idtrans.ToString();
            DataTable tbPersona = LlenaTabla(query);
            if (tbPersona.Rows.Count > 0)
            {
                idPersona = (int)tbPersona.Rows[0][0];
            }
            return idPersona;
        }*/

        
        

        public void AceptarTransferenciaMiel(System.Collections.Generic.List<object> tambores,int idTransferencia, int idarea, int idusuario)
        {
            FbTransaction transaction;
            string query = "";
            //Obtenemos los tambores de la transferencia
            //DataTable dtTambores = ObtenTamboresPorTransferencia(idTransferencia);
            
            //Buscamos el id de la persona que realizo la transferencia
            //int idPersona = ObtenIdPersonaTransferencia(idTransferencia);

            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                
                //Recorremos los tambores de las transferencias.
                for (int i = 0; i < tambores.Count; i++)
                {
                    //int idtambor = (int)dtTambores.Rows[i][0];
                    int idtambor = ((int)tambores[i]);
                    //Actualiza detalle transferencia Web
                    FbCommand commandTranWeb = new FbCommand("update im_web_trans set activo='t' where activo='p' and idtambor=@idTambor and idtrans=@idtran", fbConnection1);
                    commandTranWeb.Transaction = transaction;
                    commandTranWeb.Parameters.Add("@idTambor", idtambor);
                    commandTranWeb.Parameters.Add("@idtran", idTransferencia);
                    commandTranWeb.Transaction = transaction;
                    commandTranWeb.ExecuteNonQuery();

                    //Actualiza el area del barril
                    FbCommand commandBarril = new FbCommand("update IM_BARRILS set idarea=@idarea, ocupado='t' where idbarril=@idTambor", fbConnection1);
                    commandBarril.Transaction = transaction;
                    commandBarril.Parameters.Add("@idarea", idarea);
                    commandBarril.Parameters.Add("@idTambor", idtambor);
                    commandBarril.Transaction = transaction;
                    commandBarril.ExecuteNonQuery();

                    //
                    //ActualizaEncabezadoTransWeb(idTransferencia, transaction);

                    //Actualiza la tabla IM_MIETAM 
                    FbCommand commandIM_MIETAM = new FbCommand("update IM_MIETAM set activo='t' where activo='p' and idbarril=@idTambor and idmieltran=@idtran", fbConnection1);
                    commandIM_MIETAM.Transaction = transaction;
                    commandIM_MIETAM.Parameters.Add("@idTambor", idtambor);
                    commandIM_MIETAM.Parameters.Add("@idtran", idTransferencia);
                    //commandIM_MIETAM.Parameters.Add("@idusuario", idusuario);
                    commandIM_MIETAM.Transaction = transaction;
                    commandIM_MIETAM.ExecuteNonQuery();

                    //Cuando se recepciona la transferencia se coloca en false el campo activo para liberar el barril
                    query = "update im_web_muestra set activa='f' where activa='t' and idmieltran=@idtrans and idbarril=@idTambor";
                    FbCommand cmdim_web_muestra = new FbCommand(query, this.fbConnection1);
                    cmdim_web_muestra.Transaction = transaction;
                    cmdim_web_muestra.Parameters.Add("@idtrans", FbDbType.Integer).Value = idTransferencia;
                    cmdim_web_muestra.Parameters.Add("@idTambor", FbDbType.Integer).Value = idusuario;
                    cmdim_web_muestra.ExecuteNonQuery();
                }

               transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();
        }

        public void ActualizaEncabezadoTransWeb(int idTransferencia)
        {
            FbTransaction transaction;
            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                //Actualiza el encabezado de la transferencia web
                FbCommand commandMielTrans = new FbCommand("update IM_WEB_MIELTRANS set activa='t' where activa='p' and idtrans=@idtran", fbConnection1);
                commandMielTrans.Transaction = transaction;
                commandMielTrans.Parameters.Add("@idtran", idTransferencia);
                commandMielTrans.Transaction = transaction;
                commandMielTrans.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();
        }
   }
}