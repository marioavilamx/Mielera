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
    public class AnticipoDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;
        private applicationConfig objAppConfig;

        public AnticipoDS()
        {
            
            objAppConfig = new applicationConfig();
            objAppConfig.configConnPeriferica(cs);

            this.fbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            fbConnection1.ConnectionString = cs.ToString();
        }

        public DataTable ObtenAnticiposHistorialPorDelegado(string iddelegado)
        {
            string query = "select IDSOLREC,FEHOR1,NOMBRE,OBSERS,c.edo,TOPESOS,PAGADO,ENVIADO,MONTOSOL, " +
                           "case (select count(*) from im_solrecdets where IDSOLIC = a.idsolrec) when 0 then 'Anticipo' else 'Suministro' end  as EsSuministro " +
                           "from  IM_SOLRECS a " +
                           "inner join locenfis b on a.iddelegado = b.idenfi " +
                           "inner join IM_SOLRECEDOS c on a.idedo=c.idedo " +
                           "where a.idedo <> 1 and iddelegado=" + iddelegado +
                           " ORDER BY 2 DESC";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenAnticiposPorDelegado(string iddelegado)
        {
            string query = "select IDSOLREC,FEHOR1,NOMBRE,OBSERS,c.edo,TOPESOS,PAGADO,ENVIADO,MONTOSOL, " +
                           "case (select count(*) from im_solrecdets where IDSOLIC = a.idsolrec) when 0 then 'Anticipo' else 'Suministro' end  as EsSuministro " +
                           "from  IM_SOLRECS a " +
                           "inner join locenfis b on a.iddelegado = b.idenfi " +
                           "inner join IM_SOLRECEDOS c on a.idedo=c.idedo " +
                           "where a.idedo = 1 and iddelegado=" + iddelegado;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        //select * from IM_SOLRECDETS  where idsolic = 9
        public DataTable ObtenAnticiposDetallePorIdSolicitud(string idsolrec)
        {
            string query = "select rtrim(nombre) as Nombre,kilos,preu,tambores,femax,framues from IM_SOLRECDETS a inner join locenfis b on a.idapic = b.idenfi where idsolic =" + idsolrec;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }


        public void InsertaSolicitud(int iddelegado, string obser, double monto)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(IM_SOLRECS_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenSolicitud = new FbCommand(query, this.fbConnection1);
                cmdGenSolicitud.Transaction = transaction;
                FbDataReader readerSolicitud = cmdGenSolicitud.ExecuteReader();
                if (readerSolicitud.Read())
                {
                    long idSolicitud = (long)readerSolicitud.GetValue(0);
                    query = "insert into IM_SOLRECS (IDSOLREC,FEHOR1,IDDELEGADO,OBSERS,IDEDO,MONTOSOL) " +
                            "values(@idsol,@fecha,@delegado,@obser,@idedo,@monto)";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    cmdInsertInt.Parameters.Add("@idsol", FbDbType.Integer).Value = idSolicitud;
                    cmdInsertInt.Parameters.Add("@fecha", FbDbType.Date).Value = DateTime.Now;
                    cmdInsertInt.Parameters.Add("@delegado", FbDbType.Integer).Value = iddelegado;
                    cmdInsertInt.Parameters.Add("@obser", FbDbType.VarChar).Value = obser;
                    cmdInsertInt.Parameters.Add("@idedo", FbDbType.SmallInt).Value = 1; // 1 significa elaborado
                    cmdInsertInt.Parameters.Add("@monto", FbDbType.Double).Value = monto;
                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void InsertaSolicitudSuministro(int iddelegado, string obser, string apicultor, double kilos, double punitario, int tambores, int frascos, DateTime fmax)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(IM_SOLRECS_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenSolicitud = new FbCommand(query, this.fbConnection1);
                cmdGenSolicitud.Transaction = transaction;
                FbDataReader readerSolicitud = cmdGenSolicitud.ExecuteReader();
                if (readerSolicitud.Read())
                {
                    long idSolicitud = (long)readerSolicitud.GetValue(0);
                    query = "insert into IM_SOLRECS (IDSOLREC,FEHOR1,IDDELEGADO,OBSERS,IDEDO) " +
                            "values(@idsol,@fecha,@delegado,@obser,@idedo)";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    cmdInsertInt.Parameters.Add("@idsol", FbDbType.Integer).Value = idSolicitud;
                    cmdInsertInt.Parameters.Add("@fecha", FbDbType.Date).Value = DateTime.Now;
                    cmdInsertInt.Parameters.Add("@delegado", FbDbType.Integer).Value = iddelegado;
                    cmdInsertInt.Parameters.Add("@obser", FbDbType.VarChar).Value = obser;
                    cmdInsertInt.Parameters.Add("@idedo", FbDbType.SmallInt).Value = 1; // 1 significa elaborado

                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();


                    query = "SELECT GEN_ID(IM_SOLRECDETS_GEN_ID, 1 ) FROM RDB$DATABASE;";
                    FbCommand cmdGenSolicitudDet = new FbCommand(query, this.fbConnection1);
                    cmdGenSolicitudDet.Transaction = transaction;
                    FbDataReader readerSolicitudDet = cmdGenSolicitudDet.ExecuteReader();
                    if (readerSolicitudDet.Read())
                    {
                        long idSolicitudDet = (long)readerSolicitudDet.GetValue(0);
                        query = "insert into IM_SOLRECDETS (IDSOLIC,IDREN,IDAPIC,KILOS,PREU,TAMBORES,FEMAX,FRAMUES) " +
                                "values(@idsol,@idren,@idapic,@kilos,@punitario,@tambores,@fmax,@framues)";
                                //"values(@idsol,@idren,@idapic,@kilos,@punitario,@tambores,@fmax,@idenvio,@framues)";

                        FbCommand cmdInsertIntDet = new FbCommand(query, this.fbConnection1);
                        cmdInsertIntDet.Parameters.Add("@idsol", FbDbType.Integer).Value = idSolicitud;
                        cmdInsertIntDet.Parameters.Add("@idren", FbDbType.SmallInt).Value = idSolicitudDet;
                        cmdInsertIntDet.Parameters.Add("@idapic", FbDbType.Integer).Value = int.Parse(apicultor);
                        cmdInsertIntDet.Parameters.Add("@kilos", FbDbType.Double).Value = kilos;
                        cmdInsertIntDet.Parameters.Add("@punitario", FbDbType.Double).Value = punitario;
                        cmdInsertIntDet.Parameters.Add("@tambores", FbDbType.SmallInt).Value = tambores;
                        cmdInsertIntDet.Parameters.Add("@fmax", FbDbType.Date).Value = fmax;
                        //cmdInsertIntDet.Parameters.Add("@idenvio", FbDbType.Integer).Value = iddelegado;
                        cmdInsertIntDet.Parameters.Add("@framues", FbDbType.Integer).Value = frascos;


                        cmdInsertIntDet.Transaction = transaction;
                        cmdInsertIntDet.ExecuteNonQuery();
                    }   
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void InsertaEnvioSolicitud(int iddelegado, double cantidad, string docum, string destino, string idsolrec)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(IM_SOLENVS_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenSolicitud = new FbCommand(query, this.fbConnection1);
                cmdGenSolicitud.Transaction = transaction;
                FbDataReader readerSolicitud = cmdGenSolicitud.ExecuteReader();
                if (readerSolicitud.Read())
                {
                    long idenvio = (long)readerSolicitud.GetValue(0);
                    query = "insert into IM_SOLENVS (IDENVIO,IDDELEGADO,FECHA,HORA,CANTIDAD,DOCUM,DESTI) " +
                            "values(@idenvio,@iddelegado,@fecha,@hora,@cantidad,@docum,@destino)";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    cmdInsertInt.Parameters.Add("@idenvio", FbDbType.Integer).Value = idenvio;
                    cmdInsertInt.Parameters.Add("@iddelegado", FbDbType.Integer).Value = iddelegado;
                    cmdInsertInt.Parameters.Add("@fecha", FbDbType.Date).Value = DateTime.Now;
                    cmdInsertInt.Parameters.Add("@hora", FbDbType.Date).Value = DateTime.Now;
                    cmdInsertInt.Parameters.Add("@cantidad", FbDbType.Double).Value = cantidad;
                    cmdInsertInt.Parameters.Add("@docum", FbDbType.VarChar).Value = docum; 
                    cmdInsertInt.Parameters.Add("@destino", FbDbType.VarChar).Value = destino;
                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();

                    query = "update IM_SOLRECS set idedo = 2 where idsolrec = " + idsolrec;
                    FbCommand cmdUpdateSolRecs = new FbCommand(query, this.fbConnection1);
                    cmdUpdateSolRecs.Transaction = transaction;
                    cmdUpdateSolRecs.ExecuteNonQuery();

                    transaction.Commit();
                }
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


