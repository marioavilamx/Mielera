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
    public class ExportDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;

        public ExportDS()
        {

            using (applicationConfig objAppConfig = new applicationConfig())
            {
                objAppConfig.configConnPeriferica(cs);
            }

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

        public DataTable ObtenTamboresExportadosPorContrato(string idcontrato)
        {
            string query =  "select c.idbarril,c.kilogramos,e.tara from MI_ORDENSALIDA a " + 
                            "inner join im_prods b on a.lote = b.numprod " +
                            "inner join im_mietam c on c.idprod = b.idprod " +
                            "inner join im_barrils d on d.idbarril = c.idbarril " +
                            "inner join im_cat_barriltipos e on e.idtipo = d.idtipo " +
                            "where a.IDCONTRATO = " + idcontrato;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenFacturas()
        {
            string query = "SELECT a.Fecha,a.NumFac,b.nombre FROM facturas a " +
                            "left join locenfis b on a.idvendedor = b.idenfi " +
                            "where idfacedo in (3,4,5,7) and (obsers is null or obsers = '') " +
                            "order by a.fecha desc";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ContratosSinTipo()
        {
            string query = "select a.idcontrato,a.numcontrato,a.fechalta, a.horalta,b.nombre from im_contratos a " +
                            "left join locenfis b on a.idautor = b.idenfi " +
                            "where idtipoexp is null";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ContratosConTipo()
        {
            string query = "select a.idcontrato,a.numcontrato,a.fechalta, a.horalta,b.nombre from im_contratos a " +
                            "left join locenfis b on a.idautor = b.idenfi " +
                            "where idtipoexp is not null";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }
        
        public DataTable ObtenMesAnioContrato(string idcontrato)
        {
            string query = "select EXTRACT(MONTH  FROM fechalta) mes, EXTRACT(YEAR  FROM fechalta) from im_contratos " +
                            "where idcontrato = " + idcontrato;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }


        public DataTable ObtenTipoExp()
        {
            string query = "select * from tipoexp";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenPlanTransporte()
        {
            string query = "select * from MI_PLANTRANSPORTE";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        

        public DataTable ObtenChoferes()
        {
            string query = "select * from im_cat_choferes";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }
        
        public DataTable obtenDocumentosPorTipoExp(string idtipoexp)
        {
            string query = "select * from CHECKLISTEXP " +
                            "where activo='S' and idtipoexp=1 or idtipoexp=" + idtipoexp +
                            "  order by orden ";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable obtenContratoExport(string idcontrato)
        {
            if (idcontrato == null)
                idcontrato = "-1";
            string query = "select * from export_contrato " +
                            "where idcontrato = " + idcontrato.ToString();
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable obtenBookigByIdContrato(string idcontrato)
        {
            if (idcontrato == null)
                idcontrato = "0";

            string query = "select * from mi_booking "  +
                            "where idcontrato = " + idcontrato;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenIntinerarioByBooking(int idBooking)
        {
            string query = "select * from MI_INTINERARIO where IDBOOKING = " + idBooking.ToString();
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenPlanByBooking(int idBooking)
        {
            string query = "select * from MI_PLANTRANSPORTE where IDBOOKING = " + idBooking.ToString();
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public void InsertaIntinerario(int idbooking, string tipo, string ubicacion, DateTime fecha, TimeSpan horainicio, TimeSpan horafin)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(MI_INTINERARIO_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenIntinerario = new FbCommand(query, this.fbConnection1);
                cmdGenIntinerario.Transaction = transaction;
                FbDataReader readerIntinerario = cmdGenIntinerario.ExecuteReader();
                if (readerIntinerario.Read())
                {
                    long idIntinerario = (long)readerIntinerario.GetValue(0);
                    query = "insert into MI_INTINERARIO (IDINTINERARIO,IDBOOKING,TIPO,UBICACION,FECHA,HORAINICIO,HORAFIN) " +
                            "values(@idintinerario,@idbooking,@tipo,@ubicacion,@fecha,@horainicio,@horafin)";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    cmdInsertInt.Parameters.Add("@idintinerario", FbDbType.Integer).Value = idIntinerario;
                    cmdInsertInt.Parameters.Add("@idbooking", FbDbType.Integer).Value = idbooking;
                    cmdInsertInt.Parameters.Add("@tipo", FbDbType.VarChar).Value = tipo;
                    cmdInsertInt.Parameters.Add("@ubicacion", FbDbType.VarChar).Value = ubicacion;
                    cmdInsertInt.Parameters.Add("@fecha", FbDbType.Date).Value = fecha;
                    cmdInsertInt.Parameters.Add("@horainicio", FbDbType.Date).Value = horainicio;
                    cmdInsertInt.Parameters.Add("@horafin", FbDbType.Date).Value = horafin;
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

        public void EliminaIntinerario(int idintinerario)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "delete from MI_INTINERARIO " +
                        "where idintinerario = @idintinerario";

                FbCommand cmdUpdatePlan = new FbCommand(query, this.fbConnection1);
                cmdUpdatePlan.Parameters.Add("@idintinerario", FbDbType.Integer).Value = idintinerario;
                cmdUpdatePlan.Transaction = transaction;
                cmdUpdatePlan.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void ActualizaIntinerario(int idintinerario, string tipo, string ubicacion, DateTime fecha, TimeSpan horainicio, TimeSpan horafin)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "update MI_INTINERARIO set TIPO=@tipo,UBICACION=@ubicacion,FECHA=@fecha,HORAINICIO=@horainicio,HORAFIN=@horafin   " +
                        "where idintinerario = @idintinerario";

                FbCommand cmdUpdateInt = new FbCommand(query, this.fbConnection1);
                cmdUpdateInt.Parameters.Add("@tipo", FbDbType.VarChar).Value = tipo;
                cmdUpdateInt.Parameters.Add("@ubicacion", FbDbType.VarChar).Value = ubicacion;
                cmdUpdateInt.Parameters.Add("@fecha", FbDbType.Date).Value = fecha;
                cmdUpdateInt.Parameters.Add("@horainicio", FbDbType.Date).Value = horainicio;
                cmdUpdateInt.Parameters.Add("@horafin", FbDbType.Date).Value = horafin;
                cmdUpdateInt.Parameters.Add("@idintinerario", FbDbType.Integer).Value = idintinerario;
                cmdUpdateInt.Transaction = transaction;
                cmdUpdateInt.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }


        public void InsertaPlanTransporte(int idbooking, string from, string to, string transporte,int numerotransporte, DateTime fechasalida, DateTime fechallegada)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            if (transporte == null)
                transporte = "";
            try
            {
                //Si no existe una transaccion de miel pendiente la creamos
                //el generador im_mieltrans_gen para la tabla im_web_mieltrans?
                query = "SELECT GEN_ID(MI_PLANTRANSPORTE_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenPlan = new FbCommand(query, this.fbConnection1);
                cmdGenPlan.Transaction = transaction;
                FbDataReader readerGenPlan = cmdGenPlan.ExecuteReader();

                if (readerGenPlan.Read())
                {
                    long idPlan = (long)readerGenPlan.GetValue(0);
                    query = "insert into mi_plantransporte (IDPLANTRANSP,IDBOOKING,\"FROM\",\"TO\",TRANSPORTE,NUMEROTRANSPORTE,FECHASALIDA, FECHALLEGADA) " +
                            "values(@idplantransp,@idbooking,@from,@to,@transp,@numerotransp,@fechasalida,@fechallegada)";

                    FbCommand cmdInsertPlan = new FbCommand(query, this.fbConnection1);
                    cmdInsertPlan.Parameters.Add("@idplantransp", FbDbType.Integer).Value = idPlan;
                    cmdInsertPlan.Parameters.Add("@idbooking", FbDbType.Integer).Value = idbooking;
                    cmdInsertPlan.Parameters.Add("@from", FbDbType.VarChar).Value = from;
                    cmdInsertPlan.Parameters.Add("@to", FbDbType.VarChar).Value = to;
                    cmdInsertPlan.Parameters.Add("@transp", FbDbType.VarChar).Value = transporte;
                    cmdInsertPlan.Parameters.Add("@numerotransp", FbDbType.Integer).Value = numerotransporte;
                    cmdInsertPlan.Parameters.Add("@fechasalida", FbDbType.Date).Value = fechasalida;
                    cmdInsertPlan.Parameters.Add("@fechallegada", FbDbType.Date).Value = fechallegada;
                    cmdInsertPlan.Transaction = transaction;
                    cmdInsertPlan.ExecuteNonQuery();
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

        public void EliminaPlanTransporte(int idplantransp)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "delete from mi_plantransporte " +
                        "where idplantransp = @idplantransp";

                FbCommand cmdUpdatePlan = new FbCommand(query, this.fbConnection1);
                cmdUpdatePlan.Parameters.Add("@idplantransp", FbDbType.Integer).Value = idplantransp;
                cmdUpdatePlan.Transaction = transaction;
                cmdUpdatePlan.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void ActualizaPlanTransporte(int idplantransp, string from, string to, string transporte, int numerotransporte, DateTime fechasalida, DateTime fechallegada)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            if (transporte == null)
                transporte = "";
            try
            {
                query = "update mi_plantransporte set \"FROM\" = @from,\"TO\"= @to,TRANSPORTE = @transp,NUMEROTRANSPORTE = @numerotransp,FECHASALIDA = @fechasalida, FECHALLEGADA= @fechallegada " +
                        "where idplantransp = @idplantransp";

                    FbCommand cmdUpdatePlan = new FbCommand(query, this.fbConnection1);
                    cmdUpdatePlan.Parameters.Add("@from", FbDbType.VarChar).Value = from;
                    cmdUpdatePlan.Parameters.Add("@to", FbDbType.VarChar).Value = to;
                    cmdUpdatePlan.Parameters.Add("@transp", FbDbType.VarChar).Value = transporte;
                    cmdUpdatePlan.Parameters.Add("@numerotransp", FbDbType.Integer).Value = numerotransporte;
                    cmdUpdatePlan.Parameters.Add("@fechasalida", FbDbType.Date).Value = fechasalida;
                    cmdUpdatePlan.Parameters.Add("@fechallegada", FbDbType.Date).Value = fechallegada;
                    cmdUpdatePlan.Parameters.Add("@idplantransp", FbDbType.Integer).Value = idplantransp;
                    cmdUpdatePlan.Transaction = transaction;
                    cmdUpdatePlan.ExecuteNonQuery();
                    transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public DataTable ObtenBookingRecordatorio()
        {
            string query = "select * from mi_booking " +
                            "where fechallegada-diasrecordatorio <= (select current_date from rdb$database)";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        

        public void InsertaBooking(int idcontrato,string foliobooking, string from, string to, int numerotransporte, DateTime fechasalida, DateTime fechallegada)
        {
            string query = "";
            //Obtenemos los dias recordatorio
            ConfiguracionDS config = new ConfiguracionDS();
            string diasrecordatorio = config.ObtenValor("EXPORT", "DIASBOOKIN");
            if (diasrecordatorio == "")
                diasrecordatorio = "3";

            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(MI_BOOKING_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenBooking = new FbCommand(query, this.fbConnection1);
                cmdGenBooking.Transaction = transaction;
                FbDataReader readerBooking = cmdGenBooking.ExecuteReader();

                if (readerBooking.Read())
                {
                    long idBooking = (long)readerBooking.GetValue(0);
                    query = "INSERT INTO MI_BOOKING(IDBOOKING,IDCONTRATO,FECHA,FOLIOBOOKING,\"FROM\",\"TO\",TIPOTRANSPORTE,FECHASALIDA,FECHALLEGADA,DIASRECORDATORIO) " +
                            "values(@idbooking,@idcontrato,@fecha,@foliobooking,@from,@to,@tipotransp,@fechasalida,@fechallegada,@diasrecordatorio)";

                    FbCommand cmdInsertBooking = new FbCommand(query, this.fbConnection1);
                    cmdInsertBooking.Parameters.Add("@idbooking", FbDbType.Integer).Value = idBooking;
                    cmdInsertBooking.Parameters.Add("@idcontrato", FbDbType.Integer).Value = idcontrato;
                    cmdInsertBooking.Parameters.Add("@fecha", FbDbType.Date).Value = DateTime.Now;
                    cmdInsertBooking.Parameters.Add("@foliobooking", FbDbType.VarChar).Value = foliobooking;
                    cmdInsertBooking.Parameters.Add("@from", FbDbType.VarChar).Value = from;
                    cmdInsertBooking.Parameters.Add("@to", FbDbType.VarChar).Value = to;
                    cmdInsertBooking.Parameters.Add("@tipotransp", FbDbType.Integer).Value = numerotransporte;
                    cmdInsertBooking.Parameters.Add("@fechasalida", FbDbType.Date).Value = fechasalida;
                    cmdInsertBooking.Parameters.Add("@fechallegada", FbDbType.Date).Value = fechallegada;
                    cmdInsertBooking.Parameters.Add("@diasrecordatorio", FbDbType.Integer).Value = int.Parse(diasrecordatorio); //Hay que leer los días de la tabla de configuración
                    cmdInsertBooking.Transaction = transaction;
                    cmdInsertBooking.ExecuteNonQuery();

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

        public void ActualizaBooking(int idbooking, string foliobooking, string from, string to, int numerotransporte, DateTime fechasalida, DateTime fechallegada)
        {
            string query = "";
            
            //Obtenemos los dias recordatorio
            ConfiguracionDS config = new ConfiguracionDS();
            string diasrecordatorio = config.ObtenValor("EXPORT", "DIASBOOKING");
            if (diasrecordatorio == "")
                diasrecordatorio = "3";

            this.fbConnection1.Open();
            FbTransaction transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "UPDATE MI_BOOKING SET FECHA=@fecha,FOLIOBOOKING=@foliobooking,\"FROM\"=@from,\"TO\"=@to,TIPOTRANSPORTE=@tipotransp,FECHASALIDA=@fechasalida,FECHALLEGADA=@fechallegada,DIASRECORDATORIO=@diasrecordatorio " +
                        "WHERE IDBOOKING=@idbooking";
                    FbCommand cmdInsertBooking = new FbCommand(query, this.fbConnection1);
                    cmdInsertBooking.Parameters.Add("@fecha", FbDbType.Date).Value = DateTime.Now;
                    cmdInsertBooking.Parameters.Add("@foliobooking", FbDbType.VarChar).Value = foliobooking;
                    cmdInsertBooking.Parameters.Add("@from", FbDbType.VarChar).Value = from;
                    cmdInsertBooking.Parameters.Add("@to", FbDbType.VarChar).Value = to;
                    cmdInsertBooking.Parameters.Add("@tipotransp", FbDbType.Integer).Value = numerotransporte;
                    cmdInsertBooking.Parameters.Add("@fechasalida", FbDbType.Date).Value = fechasalida;
                    cmdInsertBooking.Parameters.Add("@fechallegada", FbDbType.Date).Value = fechallegada;
                    cmdInsertBooking.Parameters.Add("@diasrecordatorio", FbDbType.Integer).Value = int.Parse(diasrecordatorio); 
                    cmdInsertBooking.Parameters.Add("@idbooking", FbDbType.Integer).Value = idbooking;
                    cmdInsertBooking.Transaction = transaction;
                    cmdInsertBooking.ExecuteNonQuery();

                    transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }
        public void ActualizaContratoExport(int idcontrato,int idtipoexport, int iddoc, string Listo)
        {
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            string query = "update export_contrato set Listo = @LISTO " +
                            "where idcontrato = @IDCONTRATO and idtipoexp=@IDTIPOEXP and iddoc=@IDDOC";
            try
            {
                FbCommand cmdInsertExpCont = new FbCommand(query, this.fbConnection1);
                cmdInsertExpCont.Parameters.Add("@LISTO", FbDbType.Char).Value = Listo;
                cmdInsertExpCont.Parameters.Add("@IDCONTRATO", FbDbType.Integer).Value = idcontrato;
                cmdInsertExpCont.Parameters.Add("@IDTIPOEXP", FbDbType.Integer).Value = idtipoexport;
                cmdInsertExpCont.Parameters.Add("@IDDOC", FbDbType.Integer).Value = iddoc;
                cmdInsertExpCont.Transaction = transaction;
                cmdInsertExpCont.ExecuteNonQuery();
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

        public void ActualizaContratoExportArch(int idcontrato, int idtipoexport, int iddoc, string Ruta)
        {
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            string query = "update export_contrato set Listo = 'S',ruta = @RUTA " +
                            "where idcontrato = @IDCONTRATO and idtipoexp=@IDTIPOEXP and iddoc=@IDDOC";
            try
            {
                FbCommand cmdInsertExpCont = new FbCommand(query, this.fbConnection1);
                cmdInsertExpCont.Parameters.Add("@RUTA", FbDbType.Char).Value = Ruta;
                cmdInsertExpCont.Parameters.Add("@IDCONTRATO", FbDbType.Integer).Value = idcontrato;
                cmdInsertExpCont.Parameters.Add("@IDTIPOEXP", FbDbType.Integer).Value = idtipoexport;
                cmdInsertExpCont.Parameters.Add("@IDDOC", FbDbType.Integer).Value = iddoc;
                cmdInsertExpCont.Transaction = transaction;
                cmdInsertExpCont.ExecuteNonQuery();
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

        public void ExportaContrato(string idcontrato, string idtipoexp)
        {
            string query = "";
            FbTransaction transaction;
            DataTable documentosDT = obtenDocumentosPorTipoExp(idtipoexp);
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            int idtipoexport=0;
            int iddoc = 0;
            int orden;
            string documento;
            string check;
            string nomarch="";

            
            try
            {
                //En el cotrato se marca el tipo de exportación (lo que indica que éste contrato entrara al ciclo de la documentación)
                query = "update im_contratos set idtipoexp =  @idtipoexp  " +
                         "where idcontrato = @idcontrato";
                FbCommand cmdUpdateContrato = new FbCommand(query, this.fbConnection1);
                cmdUpdateContrato.Parameters.Add("@idtipoexp", FbDbType.Integer).Value = idtipoexp;
                cmdUpdateContrato.Parameters.Add("@idcontrato", FbDbType.Integer).Value = idcontrato;
                cmdUpdateContrato.Transaction = transaction;
                cmdUpdateContrato.ExecuteNonQuery();

                for (int i=0; i<documentosDT.Rows.Count; i++)
                {
                    idtipoexport = (int)documentosDT.Rows[i][0];
                    iddoc = (int)documentosDT.Rows[i][1];
                    orden = (int)documentosDT.Rows[i][2];
                    documento = (string)documentosDT.Rows[i][3];
                    check = (string)documentosDT.Rows[i][4];
                    nomarch = (string)documentosDT.Rows[i][5];

                    query = "insert into EXPORT_CONTRATO(IDCONTRATO,IDTIPOEXP,IDDOC,ORDEN,DOCUMENTO,CHECKLIST,NOMARCH,RUTA,LISTO) " +
                            "values(@IDCONTRATO,@IDTIPOEXP,@IDDOC,@ORDEN,@DOCUMENTO,@CHECKLIST,@NOMARCH,@RUTA,@LISTO)";
                    FbCommand cmdInsertExpCont = new FbCommand(query, this.fbConnection1);
                    cmdInsertExpCont.Parameters.Add("@IDCONTRATO", FbDbType.Integer).Value = idcontrato;
                    cmdInsertExpCont.Parameters.Add("@IDTIPOEXP", FbDbType.Integer).Value = idtipoexport;
                    cmdInsertExpCont.Parameters.Add("@IDDOC", FbDbType.Integer).Value = iddoc;
                    cmdInsertExpCont.Parameters.Add("@ORDEN", FbDbType.Integer).Value = orden;
                    cmdInsertExpCont.Parameters.Add("@DOCUMENTO", FbDbType.VarChar).Value = documento;
                    cmdInsertExpCont.Parameters.Add("@CHECKLIST", FbDbType.Char).Value = check;
                    cmdInsertExpCont.Parameters.Add("@NOMARCH", FbDbType.VarChar).Value = nomarch;
                    cmdInsertExpCont.Parameters.Add("@RUTA", FbDbType.VarChar).Value = "";
                    cmdInsertExpCont.Parameters.Add("@LISTO", FbDbType.Char).Value = "N";
                    cmdInsertExpCont.Transaction = transaction;
                    cmdInsertExpCont.ExecuteNonQuery();

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
        
        #region "Sección para la administración de las ordenes de salida"

        public DataTable ObtenProduccionLibres()
        {
            string query = "select idprod, numprod from im_prods " +
                           "where  idcontrato is null and numprod <> '0' " +
                           "order by fecha desc";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenOrdenSalidabyContrato(string idcontrato)
        {
            string query = "select * from MI_ORDENSALIDA " +
                           "where IDCONTRATO =  " + idcontrato;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }
        


        public int InsertaOrdenSalida(int idcontrato,string destino, string origen, DateTime fecha, string lote, string tipo, string contenedor, string sello, string factura, int tambores, float pesoneto, string fletera,string operador, string placas)
        {
            long idordsalida = 0;
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(MI_ORDENSALIDA_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenOS = new FbCommand(query, this.fbConnection1);
                cmdGenOS.Transaction = transaction;
                FbDataReader readerOS = cmdGenOS.ExecuteReader();

                if (readerOS.Read())
                {
                    idordsalida = (long)readerOS.GetValue(0);
                    query = "INSERT INTO MI_ORDENSALIDA(IDORDSALIDA,IDCONTRATO,DESTINO,ORIGEN,FECHA,LOTE,TIPO,CONTENEDOR,SELLO,FACTURA,TAMBORES,PESONETO,FLETERA,OPERADOR,PLACAS) " +
                            "values(@idordsalida,@idcontrato,@destino,@origen,@fecha,@lote,@tipo,@contenedor,@sello,@factura,@tambores,@pesoneto,@fletera,@operador,@placas)";

                    FbCommand cmdInsertOS = new FbCommand(query, this.fbConnection1);
                    cmdInsertOS.Parameters.Add("@idordsalida", FbDbType.Integer).Value = idordsalida;
                    cmdInsertOS.Parameters.Add("@idcontrato", FbDbType.Integer).Value = idcontrato;
                    cmdInsertOS.Parameters.Add("@destino", FbDbType.VarChar).Value = destino;
                    cmdInsertOS.Parameters.Add("@origen", FbDbType.VarChar).Value = origen;
                    cmdInsertOS.Parameters.Add("@fecha", FbDbType.Date).Value = fecha;
                    cmdInsertOS.Parameters.Add("@lote", FbDbType.VarChar).Value = lote;
                    cmdInsertOS.Parameters.Add("@tipo", FbDbType.VarChar).Value = tipo;
                    cmdInsertOS.Parameters.Add("@contenedor", FbDbType.VarChar).Value = contenedor;
                    cmdInsertOS.Parameters.Add("@sello", FbDbType.VarChar).Value = sello;
                    cmdInsertOS.Parameters.Add("@factura", FbDbType.VarChar).Value = factura;
                    cmdInsertOS.Parameters.Add("@tambores", FbDbType.Integer).Value = tambores;
                    cmdInsertOS.Parameters.Add("@pesoneto", FbDbType.Float).Value = pesoneto;
                    cmdInsertOS.Parameters.Add("@fletera", FbDbType.VarChar).Value = fletera;
                    cmdInsertOS.Parameters.Add("@operador", FbDbType.VarChar).Value = operador;
                    cmdInsertOS.Parameters.Add("@placas", FbDbType.VarChar).Value = placas;
                    cmdInsertOS.Transaction = transaction;
                    cmdInsertOS.ExecuteNonQuery();

                    query = "update im_prods set idcontrato =@idcontrato, contenedor=@contenedor, sellocamion = @sello " +
                            "where NUMPROD = @lote";
                    FbCommand cmdupdateProd = new FbCommand(query, this.fbConnection1);
                    cmdupdateProd.Parameters.Add("@idcontrato", FbDbType.Integer).Value = idcontrato;
                    cmdupdateProd.Parameters.Add("@contenedor", FbDbType.VarChar).Value = contenedor;
                    cmdupdateProd.Parameters.Add("@sello", FbDbType.VarChar).Value = sello;
                    cmdupdateProd.Parameters.Add("@lote", FbDbType.VarChar).Value = lote;
                    cmdupdateProd.Transaction = transaction;
                    cmdupdateProd.ExecuteNonQuery();
                    

                    transaction.Commit();
                }
                return (int)idordsalida;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
                
            }
        }

        public void ActualizaOrdenSalida(int idordensalida, string destino, string origen, DateTime fecha, string lote, string tipo, string contenedor, string sello, string factura, int tambores, float pesoneto, string fletera, string operador, string placas)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "UPDATE MI_ORDENSALIDA SET DESTINO=@destino,ORIGEN=@origen,FECHA=@fecha,LOTE=@lote,TIPO=@tipo,CONTENEDOR=@contenedor,SELLO=@sello," +
                                                   "FACTURA=@factura,TAMBORES=@tambores,PESONETO=@pesoneto,FLETERA=@fletera,OPERADOR=@operador,PLACAS=@placas " +
                         "WHERE IDORDSALIDA= @idordsalida";
                    FbCommand cmdInsertOS = new FbCommand(query, this.fbConnection1);
                    cmdInsertOS.Parameters.Add("@destino", FbDbType.VarChar).Value = destino;
                    cmdInsertOS.Parameters.Add("@origen", FbDbType.VarChar).Value = origen;
                    cmdInsertOS.Parameters.Add("@fecha", FbDbType.Date).Value = fecha;
                    cmdInsertOS.Parameters.Add("@lote", FbDbType.VarChar).Value = lote;
                    cmdInsertOS.Parameters.Add("@tipo", FbDbType.VarChar).Value = tipo;
                    cmdInsertOS.Parameters.Add("@contenedor", FbDbType.VarChar).Value = contenedor;
                    cmdInsertOS.Parameters.Add("@sello", FbDbType.VarChar).Value = sello;
                    cmdInsertOS.Parameters.Add("@factura", FbDbType.VarChar).Value = factura;
                    cmdInsertOS.Parameters.Add("@tambores", FbDbType.Integer).Value = tambores;
                    cmdInsertOS.Parameters.Add("@pesoneto", FbDbType.Float).Value = pesoneto;
                    cmdInsertOS.Parameters.Add("@fletera", FbDbType.VarChar).Value = fletera;
                    cmdInsertOS.Parameters.Add("@operador", FbDbType.VarChar).Value = operador;
                    cmdInsertOS.Parameters.Add("@placas", FbDbType.VarChar).Value = placas;
                    cmdInsertOS.Parameters.Add("@idordsalida", FbDbType.Integer).Value = idordensalida;
                    cmdInsertOS.Transaction = transaction;
                    cmdInsertOS.ExecuteNonQuery();

                    transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }
        #endregion

        #region "Sección para la captura de datos del laboratorio"
        public DataTable ObtenFisicoQuimicoDet()
        {
            string query = "select * from IM_LAB_FISICOQUICODET";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenFisicoQuimicoDet2()
        {
            string query = "select * from IM_LAB_FISICOQUICODET";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenLaboratorios(string tipo)
        {
            string query = "select IDLABORATORIO, LABORATORIO from IM_CAT_LABORATORIOS where TIPO='" + tipo +"'";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenFisicoQuimicoByIdLote(string lote)
        {
            string query = "select * from IM_LAB_FISICOQUIMICO where NUMPROD = '" + lote + "'";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenFisicoQuimicoByIdNumProd(string numprod)
        {
            string query = "select * from IM_LAB_FISICOQUIMICO where NUMPROD = " + numprod;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public int ObtenNumeroSiguienteReporteFisico()
        {
            int numrep = 0;
            string query = "select count(*) from IM_LAB_FISICOQUIMICO where fecha = current_date";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);

            if (fdt.Rows.Count > 0)
            {
                numrep = (int)fdt.Rows[0][0];
            }

            return numrep;
        }

        public int ObtenIdReporteByNumProd(string numprod)
        {
            int idReporte = 0;
            string query = "select idreporte from IM_LAB_FISICOQUIMICO where NUMPROD = " + numprod;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            if (fdt.Rows.Count > 0)
            {
                idReporte = (int)fdt.Rows[0][0];
            }
            return idReporte;
        }

        public DataTable ObtenFisicoQuimicoByIdReporte(int idReporte)
        {
            string query = "select * from IM_LAB_FISICOQUICODET where IDREPORTE = " + idReporte;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);

            return fdt;
        }

        public DataTable ObtenFisicoQuimicoParaReporte(int numprod)
        {
            string query = "select * from im_lab_fisicoquimico a " +
                           "inner join im_cat_laboratorios b on b.IDLABORATORIO = a.idempresa " +
                           "where numprod = " + numprod;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);

            return fdt;
        }
        
        public DataTable ObtenDetalleFisicoQuimicoByNumProd(string numprod)
        {
            string query = "select analisis,resultado from im_lab_fisicoquimico a " +
                           "inner join im_lab_fisicoquicodet b on a.idreporte = b.idreporte and a.numprod =  " + numprod;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);

            return fdt;
        }
        


       public void InsertaFisicoQuimico(string lote, string numreporte, DateTime fecha, string factura, string producto, string descripcion, string temperatura, string empaquetado, DateTime fechaini, DateTime fechafin, int idempresa, int delegado)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(IM_LAB_FISICOQUIMICO_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenFQ = new FbCommand(query, this.fbConnection1);
                cmdGenFQ.Transaction = transaction;
                FbDataReader readerFQ = cmdGenFQ.ExecuteReader();
                if (readerFQ.Read())
                {
                    long idFQ = (long)readerFQ.GetValue(0);
                    query = "insert into IM_LAB_FISICOQUIMICO (IDREPORTE,NUMPROD,NUMREPORTE,FECHA,FACTURA,PRODUCTO,DESCRIMUESTRA,TEMPERATURA,EMPAQUETADO,FECHAINIREP,FECHAFINREP,IDEMPRESA,ELABORO,FECHAELAB,HORAELAB) " +
                            "values(@IDREPORTE,@NUMPROD,@NUMREPORTE,@FECHA,@FACTURA,@PRODUCTO,@DESCRIMUESTRA,@TEMPERATURA,@EMPAQUETADO,@FECHAINIREP,@FECHAFINREP,@IDEMPRESA,@ELABORO,@FECHAELAB,@HORAELAB)";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    cmdInsertInt.Parameters.Add("@IDREPORTE", FbDbType.Integer).Value = idFQ;
                    cmdInsertInt.Parameters.Add("@NUMPROD", FbDbType.VarChar).Value = lote;
                    cmdInsertInt.Parameters.Add("@NUMREPORTE", FbDbType.VarChar).Value = numreporte;
                    cmdInsertInt.Parameters.Add("@FECHA", FbDbType.Date).Value = fecha;
                    cmdInsertInt.Parameters.Add("@FACTURA", FbDbType.VarChar).Value = factura;
                    cmdInsertInt.Parameters.Add("@PRODUCTO", FbDbType.VarChar).Value = producto;
                    cmdInsertInt.Parameters.Add("@DESCRIMUESTRA", FbDbType.VarChar).Value = descripcion;
                    cmdInsertInt.Parameters.Add("@TEMPERATURA", FbDbType.VarChar).Value = temperatura;

                    cmdInsertInt.Parameters.Add("@EMPAQUETADO", FbDbType.VarChar).Value = empaquetado;
                    cmdInsertInt.Parameters.Add("@FECHAINIREP", FbDbType.Date).Value = fechaini;
                    cmdInsertInt.Parameters.Add("@FECHAFINREP", FbDbType.Date).Value = fechafin;
                    cmdInsertInt.Parameters.Add("@IDEMPRESA", FbDbType.Integer).Value = idempresa;
                    cmdInsertInt.Parameters.Add("@ELABORO", FbDbType.Integer).Value = delegado;
                    cmdInsertInt.Parameters.Add("@FECHAELAB", FbDbType.Date).Value = DateTime.Now;
                    cmdInsertInt.Parameters.Add("@HORAELAB", FbDbType.Time).Value = DateTime.Now;

                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();

                    transaction.Commit();
                    fbConnection1.Close();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void AcutalizaFisicoQuimico(int idreporte, string numreporte, DateTime fecha, string factura, string producto, string descripcion, string temperatura, string empaquetado, DateTime fechaini, DateTime fechafin, int idempresa, int delegado)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
               
                   query = "update IM_LAB_FISICOQUIMICO set NUMREPORTE=@NUMREPORTE,FECHA=@FECHA,FACTURA=@FACTURA,PRODUCTO=@PRODUCTO,DESCRIMUESTRA=@DESCRIMUESTRA,TEMPERATURA=@TEMPERATURA,EMPAQUETADO=@EMPAQUETADO,FECHAINIREP=@FECHAINI,FECHAFINREP=@FECHAFIN,IDEMPRESA=@IDEMPRESA " +
                           "where IDREPORTE = @IDREPORTE ";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    //cmdInsertInt.Parameters.Add("@NUMPROD", FbDbType.VarChar).Value = lote;
                    cmdInsertInt.Parameters.Add("@NUMREPORTE", FbDbType.VarChar).Value = numreporte;
                    cmdInsertInt.Parameters.Add("@FECHA", FbDbType.Date).Value = fecha;
                    cmdInsertInt.Parameters.Add("@FACTURA", FbDbType.VarChar).Value = factura;
                    cmdInsertInt.Parameters.Add("@PRODUCTO", FbDbType.VarChar).Value = producto;
                    cmdInsertInt.Parameters.Add("@DESCRIMUESTRA", FbDbType.VarChar).Value = descripcion;
                    cmdInsertInt.Parameters.Add("@TEMPERATURA", FbDbType.VarChar).Value = temperatura;

                    cmdInsertInt.Parameters.Add("@EMPAQUETADO", FbDbType.VarChar).Value = empaquetado;
                    cmdInsertInt.Parameters.Add("@FECHAINI", FbDbType.Date).Value = fechaini;
                    cmdInsertInt.Parameters.Add("@FECHAFIN", FbDbType.Date).Value = fechafin;
                    cmdInsertInt.Parameters.Add("@IDEMPRESA", FbDbType.Integer).Value = idempresa;
                    //cmdInsertInt.Parameters.Add("@ELABORO", FbDbType.Integer).Value = delegado;
                    //cmdInsertInt.Parameters.Add("@FECHAELAB", FbDbType.Date).Value = DateTime.Now;
                    //cmdInsertInt.Parameters.Add("@HORAELAB", FbDbType.Time).Value = DateTime.Now;
                    cmdInsertInt.Parameters.Add("@IDREPORTE", FbDbType.Integer).Value = idreporte;
                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();
                    transaction.Commit();
                    fbConnection1.Close();
                
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void InsertaFisicoQuimicoDet(int idReporte, string tipoanalisis, string analisis, string resultado, string unidad, string limite, string metodo)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(IM_LAB_FISICOQUICODET_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenFQ = new FbCommand(query, this.fbConnection1);
                cmdGenFQ.Transaction = transaction;
                FbDataReader readerFQ = cmdGenFQ.ExecuteReader();
                if (readerFQ.Read())
                {
                    long idFQ = (long)readerFQ.GetValue(0);
                    query = "insert into IM_LAB_FISICOQUICODET (IDMOVREPORTE,IDREPORTE,TIPOANALISIS,ANALISIS,RESULTADO,UNIDAD,LIMTIEDETECCION,METODO) " +
                            "values(@IDMOVREPORTE,@IDREPORTE,@TIPOANALISIS,@ANALISIS,@RESULTADO,@UNIDAD,@LIMTIEDETECCION,@METODO)";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    cmdInsertInt.Parameters.Add("@IDMOVREPORTE", FbDbType.Integer).Value = idFQ;
                    cmdInsertInt.Parameters.Add("@IDREPORTE", FbDbType.Integer).Value = idReporte;
                    cmdInsertInt.Parameters.Add("@TIPOANALISIS", FbDbType.VarChar).Value = tipoanalisis;
                    cmdInsertInt.Parameters.Add("@ANALISIS", FbDbType.VarChar).Value = analisis;
                    cmdInsertInt.Parameters.Add("@RESULTADO", FbDbType.VarChar).Value = resultado;
                    cmdInsertInt.Parameters.Add("@UNIDAD", FbDbType.VarChar).Value = unidad;
                    cmdInsertInt.Parameters.Add("@LIMTIEDETECCION", FbDbType.VarChar).Value = limite;
                    cmdInsertInt.Parameters.Add("@METODO", FbDbType.VarChar).Value = metodo;
                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();

                    transaction.Commit();
                    fbConnection1.Close();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void AcutalizaFisicoQuimicoDet(int IDMOVREPORTE, int IDREPORTE, string TIPOANALISIS, string ANALISIS, string RESULTADO, string UNIDAD, string LIMTIEDETECCION, string METODO)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                    query = "update IM_LAB_FISICOQUICODET set TIPOANALISIS=@TIPOANALISIS,ANALISIS=@ANALISIS,RESULTADO=@RESULTADO,UNIDAD=@UNIDAD,LIMTIEDETECCION=@LIMTIEDETECCION,METODO=@METODO " +
                            "where IDMOVREPORTE=@IDMOVREPORTE and IDREPORTE=@IDREPORTE";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    cmdInsertInt.Parameters.Add("@TIPOANALISIS", FbDbType.VarChar).Value = TIPOANALISIS;
                    cmdInsertInt.Parameters.Add("@ANALISIS", FbDbType.VarChar).Value = ANALISIS;
                    cmdInsertInt.Parameters.Add("@RESULTADO", FbDbType.VarChar).Value = RESULTADO;
                    cmdInsertInt.Parameters.Add("@UNIDAD", FbDbType.VarChar).Value = UNIDAD;
                    cmdInsertInt.Parameters.Add("@LIMTIEDETECCION", FbDbType.VarChar).Value = LIMTIEDETECCION;
                    cmdInsertInt.Parameters.Add("@METODO", FbDbType.VarChar).Value = METODO;
                    cmdInsertInt.Parameters.Add("@IDMOVREPORTE", FbDbType.Integer).Value = IDMOVREPORTE;
                    cmdInsertInt.Parameters.Add("@IDREPORTE", FbDbType.Integer).Value = IDREPORTE;
                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();

                    transaction.Commit();
                    fbConnection1.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        //Analisis Report
        public DataTable ObtenReporteAnalisisByIdReporte(int idReporte)
        {
            string query = "select * from IM_LAB_ANALYSISREPORT where IDREPORTE = " + idReporte;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenReporteAnalisisByNumProd(string numprod)
        {
            if (numprod == null || numprod.Length < 1)
                numprod = "0";

            string query = "select * from IM_LAB_ANALYSISREPORT where NUMPROD = " + numprod;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);

            return fdt;
        }

        public void InsertaAnalisisReport( string FOLIO, DateTime FECHA, int IDLABORATORIO, string NUMPROD)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(IM_LAB_ANALYSISREPORT_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenFQ = new FbCommand(query, this.fbConnection1);
                cmdGenFQ.Transaction = transaction;
                FbDataReader readerFQ = cmdGenFQ.ExecuteReader();
                if (readerFQ.Read())
                {
                    long idReporte = (long)readerFQ.GetValue(0);
                    query = "insert into IM_LAB_ANALYSISREPORT (IDREPORTE,FOLIO,FECHA,IDLABORATORIO,NUMPROD) " +
                            "values(@IDREPORTE,@FOLIO,@FECHA,@IDLABORATORIO,@NUMPROD)";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    cmdInsertInt.Parameters.Add("@IDREPORTE", FbDbType.Integer).Value = idReporte;
                    cmdInsertInt.Parameters.Add("@FOLIO", FbDbType.VarChar).Value = FOLIO;
                    cmdInsertInt.Parameters.Add("@FECHA", FbDbType.Date).Value = FECHA;
                    cmdInsertInt.Parameters.Add("@IDLABORATORIO", FbDbType.Integer).Value = IDLABORATORIO;
                    cmdInsertInt.Parameters.Add("@NUMPROD", FbDbType.VarChar).Value = NUMPROD;
                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();

                    transaction.Commit();
                    fbConnection1.Close();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void ActualizaAnalisisReport(int IDREPORTE, string FOLIO, string FECHA, int IDLABORATORIO, string NUMPROD)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "update IM_LAB_ANALYSISREPORT set FOLIO=@FOLIO,FECHA=@FECHA,IDLABORATORIO=@IDLABORATORIO " +
                        "where IDREPORTE=@IDREPORTE";

                FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                cmdInsertInt.Parameters.Add("@FOLIO", FbDbType.VarChar).Value = FOLIO;
                cmdInsertInt.Parameters.Add("@FECHA", FbDbType.Date).Value = FECHA;
                cmdInsertInt.Parameters.Add("@IDLABORATORIO", FbDbType.Integer).Value = IDLABORATORIO;
                cmdInsertInt.Parameters.Add("@IDREPORTE", FbDbType.Integer).Value = IDREPORTE;
                cmdInsertInt.Transaction = transaction;
                cmdInsertInt.ExecuteNonQuery();

                transaction.Commit();
                fbConnection1.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void EliminaAnalisisReport(int IDREPORTE)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "delete from IM_LAB_ANALYSISREPORT " +
                        "where IDREPORTE=@IDREPORTE";

                FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                cmdInsertInt.Parameters.Add("@IDREPORTE", FbDbType.Integer).Value = IDREPORTE;
                cmdInsertInt.Transaction = transaction;
                cmdInsertInt.ExecuteNonQuery();

                transaction.Commit();
                fbConnection1.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        //**********************************Certificado de analisis**************************************************************

        public int ObtenNumeroSiguienteCertificado()
        {
            int numrep = 0;
            string query = "select count(*) from IM_LAB_CERTIFICADO_ANALISIS where fecha = current_date";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);

            if (fdt.Rows.Count > 0)
            {
                numrep = (int)fdt.Rows[0][0];
            }

            return numrep;
        }

        public DataTable ObtenCertificadoIdNumProd(string numprod)
        {
            string query = "select * from IM_LAB_CERTIFICADO_ANALISIS where NUMPROD = " + numprod;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenCertificadoByIdCertificado(int IDCERTIFICADO)
        {
            string query = "select * from IM_LAB_CERTIFICADO_DETALLE where IDCERTIFICADO = " + IDCERTIFICADO;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);

            return fdt;
        }

        public int ObtenIdCertificadoByNumProd(string numprod)
        {
            int IDCERTIFICADO = 0;
            string query = "select IDCERTIFICADO from IM_LAB_CERTIFICADO_ANALISIS where NUMPROD = " + numprod;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            if (fdt.Rows.Count > 0)
            {
                IDCERTIFICADO = (int)fdt.Rows[0][0];
            }
            return IDCERTIFICADO;
        }

        public void InsertaCertificado(string FOLIO, DateTime FECHA, string NUMPROD, string INVOICE, string CONTRAC, string CONTAINER, string PRODUCT, string DESCRIPTION, string TEMPERATURA, string PACKING, DateTime FECHAINI, DateTime FECHAFIN, int IDDELEGADO, string OURREFERENCE, int IDCLIENTE)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(IM_LAB_CERT_ANALISIS_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenFQ = new FbCommand(query, this.fbConnection1);
                cmdGenFQ.Transaction = transaction;
                FbDataReader readerFQ = cmdGenFQ.ExecuteReader();
                if (readerFQ.Read())
                {
                    long IDCERTIFICADO = (long)readerFQ.GetValue(0);
                    query = "insert into IM_LAB_CERTIFICADO_ANALISIS (IDCERTIFICADO ,FOLIO,FECHA,NUMPROD,INVOICE ,CONTRAC,CONTAINER,PRODUCT ,DESCRIPTION,TEMPERATURA,PACKING,FECHAINICERTI,FECHAFINCERTI,FECHAELAB,HORAELAB,IDELABORO,OURREFERENCE,IDCLIENTE) " +
                            "values(@IDCERTIFICADO,@FOLIO,@FECHA,@NUMPROD,@INVOICE,@CONTRAC,@CONTAINER,@PRODUCT,@DESCRIPTION,@TEMPERATURA,@PACKING,@FECHAINI,@FECHAFIN,@FECHAELAB,@HORAELAB,@IDELABORO,@OURREFERENCE,@IDCLIENTE)";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    cmdInsertInt.Parameters.Add("@IDCERTIFICADO", FbDbType.Integer).Value = IDCERTIFICADO;
                    cmdInsertInt.Parameters.Add("@FOLIO", FbDbType.VarChar).Value = FOLIO;
                    cmdInsertInt.Parameters.Add("@FECHA", FbDbType.Date).Value = FECHA;
                    cmdInsertInt.Parameters.Add("@NUMPROD", FbDbType.VarChar).Value = NUMPROD;
                    cmdInsertInt.Parameters.Add("@INVOICE", FbDbType.VarChar).Value = INVOICE;
                    cmdInsertInt.Parameters.Add("@CONTRAC", FbDbType.VarChar).Value = CONTRAC;
                    cmdInsertInt.Parameters.Add("@CONTAINER", FbDbType.VarChar).Value = CONTAINER;
                    cmdInsertInt.Parameters.Add("@PRODUCT", FbDbType.VarChar).Value = PRODUCT;

                    cmdInsertInt.Parameters.Add("@DESCRIPTION", FbDbType.VarChar).Value = DESCRIPTION;
                    cmdInsertInt.Parameters.Add("@TEMPERATURA", FbDbType.VarChar).Value = TEMPERATURA;
                    cmdInsertInt.Parameters.Add("@PACKING", FbDbType.VarChar).Value = PACKING;
                    cmdInsertInt.Parameters.Add("@FECHAINI", FbDbType.Date).Value = FECHAINI;
                    cmdInsertInt.Parameters.Add("@FECHAFIN", FbDbType.Date).Value = FECHAFIN;
                    
                    
                    cmdInsertInt.Parameters.Add("@FECHAELAB", FbDbType.Date).Value = DateTime.Now;
                    cmdInsertInt.Parameters.Add("@HORAELAB", FbDbType.Time).Value = DateTime.Now;
                    cmdInsertInt.Parameters.Add("@IDELABORO", FbDbType.Integer).Value = IDDELEGADO;
                    cmdInsertInt.Parameters.Add("@OURREFERENCE", FbDbType.VarChar).Value = OURREFERENCE;
                    cmdInsertInt.Parameters.Add("@IDCLIENTE", FbDbType.Integer).Value = IDCLIENTE;
                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();

                    transaction.Commit();
                    fbConnection1.Close();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void ActualizaCertificado(int IDCERTIFICADO, string FOLIO, DateTime FECHA, string INVOICE, string CONTRAC, string CONTAINER, string PRODUCT, string DESCRIPTION, string TEMPERATURA, string PACKING, DateTime FECHAINI, DateTime FECHAFIN, int IDCLIENTE)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {

                query = "update IM_LAB_CERTIFICADO_ANALISIS set FECHA=@FECHA,INVOICE=@INVOICE,CONTRAC=@CONTRAC,CONTAINER=@CONTAINER,PRODUCT=@PRODUCT,DESCRIPTION=@DESCRIPTION,TEMPERATURA=@TEMPERATURA,PACKING=@PACKING,FECHAINICERTI=@FECHAINI,FECHAFINCERTI=@FECHAFIN, IDCLIENTE=@IDCLIENTE " +
                           "where IDCERTIFICADO = @IDCERTIFICADO ";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    
                    //cmdInsertInt.Parameters.Add("@FOLIO", FbDbType.VarChar).Value = FOLIO;
                    cmdInsertInt.Parameters.Add("@FECHA", FbDbType.Date).Value = FECHA;
                    //cmdInsertInt.Parameters.Add("@NUMPROD", FbDbType.Date).Value = NUMPROD;
                    cmdInsertInt.Parameters.Add("@INVOICE", FbDbType.VarChar).Value = INVOICE;
                    cmdInsertInt.Parameters.Add("@CONTRAC", FbDbType.VarChar).Value = CONTRAC;
                    cmdInsertInt.Parameters.Add("@CONTAINER", FbDbType.VarChar).Value = CONTAINER;
                    cmdInsertInt.Parameters.Add("@PRODUCT", FbDbType.VarChar).Value = PRODUCT;
                    cmdInsertInt.Parameters.Add("@DESCRIPTION", FbDbType.VarChar).Value = DESCRIPTION;
                    cmdInsertInt.Parameters.Add("@TEMPERATURA", FbDbType.VarChar).Value = TEMPERATURA;
                    cmdInsertInt.Parameters.Add("@PACKING", FbDbType.VarChar).Value = PACKING;
                    cmdInsertInt.Parameters.Add("@FECHAINI", FbDbType.Date).Value = FECHAINI;
                    cmdInsertInt.Parameters.Add("@FECHAFIN", FbDbType.Date).Value = FECHAFIN;
                    cmdInsertInt.Parameters.Add("@IDCLIENTE", FbDbType.Integer).Value = IDCLIENTE;
                    //cmdInsertInt.Parameters.Add("@FECHAELAB", FbDbType.Date).Value = DateTime.Now;
                    //cmdInsertInt.Parameters.Add("@HORAELAB", FbDbType.Time).Value = DateTime.Now;
                    //cmdInsertInt.Parameters.Add("@IDELABORO", FbDbType.Integer).Value = IDDELEGADO;
                    cmdInsertInt.Parameters.Add("@IDCERTIFICADO", FbDbType.Integer).Value = IDCERTIFICADO;
                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();

                    transaction.Commit();
                    fbConnection1.Close();
                
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }


        public void InsertaCertificadoDet(int IDCERTIFICADO, string ANALISIS, string RESULT, string UNIT, string LIMITOFDETECTION, string METHOD)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "SELECT GEN_ID(IM_LAB_CERT_DETALLE_GEN_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdGenFQ = new FbCommand(query, this.fbConnection1);
                cmdGenFQ.Transaction = transaction;
                FbDataReader readerFQ = cmdGenFQ.ExecuteReader();
                if (readerFQ.Read())
                {
                    long IDDETCERTIFICADO = (long)readerFQ.GetValue(0);
                    query = "insert into IM_LAB_CERTIFICADO_DETALLE (IDDETCERTIFICADO, IDCERTIFICADO ,ANALISIS,RESULT,UNIT ,LIMITOFDETECTION,METHOD,FECHAELAB,HORAELAB) " +
                            "values(@IDDETCERTIFICADO,@IDCERTIFICADO ,@ANALISIS,@RESULT,@UNIT,@LIMITOFDETECTION,@METHOD,@FECHAELAB,@HORAELAB)";

                    FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                    cmdInsertInt.Parameters.Add("@IDDETCERTIFICADO", FbDbType.Integer).Value = IDDETCERTIFICADO;
                    cmdInsertInt.Parameters.Add("@IDCERTIFICADO", FbDbType.Integer).Value = IDCERTIFICADO;
                    cmdInsertInt.Parameters.Add("@ANALISIS", FbDbType.VarChar).Value = ANALISIS;
                    cmdInsertInt.Parameters.Add("@RESULT", FbDbType.VarChar).Value = RESULT;
                    cmdInsertInt.Parameters.Add("@UNIT", FbDbType.VarChar).Value = UNIT;
                    cmdInsertInt.Parameters.Add("@LIMITOFDETECTION", FbDbType.VarChar).Value = LIMITOFDETECTION;
                    cmdInsertInt.Parameters.Add("@METHOD", FbDbType.VarChar).Value = METHOD;
                    cmdInsertInt.Parameters.Add("@FECHAELAB", FbDbType.Date).Value = DateTime.Now;
                    cmdInsertInt.Parameters.Add("@HORAELAB", FbDbType.Time).Value = DateTime.Now;
                    cmdInsertInt.Transaction = transaction;
                    cmdInsertInt.ExecuteNonQuery();

                    transaction.Commit();
                    fbConnection1.Close();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public void AcutalizaCertificadoDet(int IDDETCERTIFICADO, int IDCERTIFICADO, string ANALISIS, string RESULT, string UNIT, string LIMITOFDETECTION, string METHOD)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                query = "update IM_LAB_CERTIFICADO_DETALLE set ANALISIS=@ANALISIS,RESULT=@RESULT,UNIT=@UNIT,LIMITOFDETECTION=@LIMITOFDETECTION,METHOD=@METHOD " +
                        "where IDDETCERTIFICADO=@IDDETCERTIFICADO and IDCERTIFICADO=@IDCERTIFICADO"; 

                FbCommand cmdInsertInt = new FbCommand(query, this.fbConnection1);
                cmdInsertInt.Parameters.Add("@ANALISIS", FbDbType.VarChar).Value = ANALISIS;
                cmdInsertInt.Parameters.Add("@RESULT", FbDbType.VarChar).Value = RESULT;
                cmdInsertInt.Parameters.Add("@UNIT", FbDbType.VarChar).Value = UNIT;
                cmdInsertInt.Parameters.Add("@LIMITOFDETECTION", FbDbType.VarChar).Value = LIMITOFDETECTION;
                cmdInsertInt.Parameters.Add("@METHOD", FbDbType.VarChar).Value = METHOD;
                cmdInsertInt.Parameters.Add("@IDDETCERTIFICADO", FbDbType.Integer).Value = IDDETCERTIFICADO;
                cmdInsertInt.Parameters.Add("@IDCERTIFICADO", FbDbType.Integer).Value = IDCERTIFICADO;
                cmdInsertInt.Transaction = transaction;
                cmdInsertInt.ExecuteNonQuery();

                transaction.Commit();
                fbConnection1.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public DataTable ObtenCertificadoParaReporte(int numprod)
        {
            string query = "select * from IM_LAB_CERTIFICADO_ANALISIS a " +
                           //"inner join im_cat_laboratorios b on b.IDLABORATORIO = a.idempresa " +
                           "where numprod = " + numprod;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);

            return fdt;
        }

        public string ObtenNombreByIdenfi(int idenfi)
        {
            string nombre = "";
            string query = "select nombre from locenfis " +
                           "where idenfi = " + idenfi;
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            if (fdt.Rows.Count > 0)
            {
                nombre = fdt.Rows[0][0].ToString();
            }
            return nombre;
           
        }
        


        #endregion
    }
}
