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
    public class CompraMielDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;
        public int idtranpendiente = 0;

        public CompraMielDS()
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

        /// <summary>
        /// Esta función ejecuta el query pasado y devuelve el resultado en un datatable
        /// </summary>
        /// <param name="query">Este parametro contiene el query que se ejecutara</param>
        /// <returns>Retorna el resultado en un DataTable</returns>
        private DataTable LlenaTablaTran(string query, FbTransaction transaction)
        {
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            da.SelectCommand.Transaction = transaction;
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenTamboresDisponiblesLlenados(int iddelegado, int idarea)
        {
            DateTime expiration = DateTime.Now.AddMinutes(1);
            DataTable Tambores = HttpContext.Current.Cache["Cache_TamboresDisponiblesKey"] as DataTable;
            if (Tambores == null)
            {
                string query = "select a.num_tambor,0 as stk,d.capacidad from im_web_tambor as a " +
                "inner join im_web_envio_tambores as b on a.idenvio=b.id " +
                "inner join im_barrils as c on c.idbarril=a.num_tambor " +
                "inner join im_cat_barriltipos as d on d.idtipo=c.idtipo " +
                "where b.destino=a.area " +
                "and b.iddelegado=" + iddelegado + " and a.area=" + idarea + " and a.status='R' " +
                "and a.compra='t' " +
                "union all " +
                "select a.idtambor as num_tambor,sum(a.kilogramos)as stk,c.capacidad " +
                "from im_web_trans as a " +
                "inner join im_barrils as b inner " +
                "join im_cat_barriltipos as c on c.idtipo=b.idtipo on b.idbarril=a.idtambor " +
                "where a.idpersona=" + iddelegado.ToString() + " and a.activo='p' and a.enviado in('t','T') AND  a.e_t='t' " +
                "group by a.idtambor,c.capacidad " +
                "order by 2 desc;";

                Tambores = LlenaTabla(query);
                HttpContext.Current.Cache.Add("Cache_TamboresDisponiblesKey", Tambores, null, expiration, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            }
            
            return Tambores;
            //return LlenaTabla(query);
        }

        public DataTable ObtenTiposMiel()
        {
            string query = "select * from IM_CAT_CONTENIDOS where idcontenido in (7,9)";
            return LlenaTabla(query);
        }

        public int ObtenApiculorCompraPendiente(string iddelegado)
        {
            int idapicultor = -1;
            string query = "select idapicultor from im_web_trans " +
                            "where e_t='f' and activo='p' and enviado='t' and idcompra is null and idpersona= " + iddelegado + " group by idapicultor";
            DataTable idapicDT = LlenaTabla(query);
            if (idapicDT.Rows.Count > 0)
            {
                idapicultor = (int)idapicDT.Rows[0][0];
            }
            return idapicultor;
        }

        public double ObtenMontoAnualDelApiculor(string idapicultor)
        {
            ///TODO: La fecha en el query esta estatica a 2010 - Cambiarla
            double monto = 0;
            string query = "select sum(a.kilogramos*a.preuni) as monto " +
                            "from im_mietam as a " +
                            "where a.idapicultor=" + idapicultor + " and extract(year from fecha)=extract (year from current_date) ";
            DataTable idapicDT = LlenaTabla(query);
            if (idapicDT.Rows.Count > 0)
            {
                try
                {
                    monto = (double)idapicDT.Rows[0][0];
                }
                catch{
                    monto = 0;
                }
            }
            return monto;
        }

        public double ObtenMontoAnual()
        {
            ///TODO: La fecha en el query esta estatica a 2010 - Cambiarla
            double monto = 0;
            string query = "select monto from im_web_anuales where anio=extract (year from current_date)";
            DataTable idapicDT = LlenaTabla(query);
            if (idapicDT.Rows.Count > 0)
            {
                monto = (double)idapicDT.Rows[0][0];
            }
            return monto;
        }
        
        public bool EstaEnUso(string idtambor)
        {
            bool benuso = false;
            string query = "select idtambor from im_web_trans where e_t='f' and enviado in('t','f') and idtambor=" + idtambor;
            DataTable idapicDT = LlenaTabla(query);
            if (idapicDT.Rows.Count > 0)
            {
                benuso = true;
            }
            return benuso;
        }
        
        
        public int HayTransaccionMielActiva(int idusuario)
        {
            int tranactiva = 0;
            string query = "SELECT idtrans FROM im_web_mieltrans WHERE activa='p' and enviado='t' AND idenfi=" + idusuario.ToString();
            DataTable idapicDT = LlenaTabla(query);
            if (idapicDT.Rows.Count > 0)
            {
                tranactiva = (int)idapicDT.Rows[0][0];
            }
            return tranactiva;
        }


        public void AgregaCompra(int idusuario, int idarea, DateTime fecha, DateTime hora, int idtambor, int idapicultor, int idcontenidos, float kilogramos, double precio, double stock)
        {
            string query = "";
            FbTransaction transaction;
            
            long idtrans = HayTransaccionMielActiva(idusuario);
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                if (idtrans == 0)
                {
                    //Si no existe una transaccion de miel pendiente la creamos
                    //el generador im_mieltrans_gen para la tabla im_web_mieltrans?
                    query = "SELECT GEN_ID(IM_MIELTRANS_GEN_ID, 1 ) FROM RDB$DATABASE;";
                    FbCommand cmdMIELTRANS = new FbCommand(query, this.fbConnection1);
                    cmdMIELTRANS.Transaction = transaction;
                    FbDataReader readerMIELTRANS = cmdMIELTRANS.ExecuteReader();

                    if (readerMIELTRANS.Read())
                    {
                        idtrans = (long)readerMIELTRANS.GetValue(0);
                        query = "INSERT INTO IM_WEB_MIELTRANS(IDTRANS,IDDELEGADO,IDAREAB,FECHA,HORA,IDENFI,IDAREA,ACTIVA,STATUS,ENVIADO) " +
                                "values(@idtran,@idusr,@idarea,@Fecha,@Hora,@idusr,@idarea,'p','t','t')";

                        FbCommand cmdMIELTRANS2 = new FbCommand(query, this.fbConnection1);
                        cmdMIELTRANS2.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                        cmdMIELTRANS2.Parameters.Add("@idusr", FbDbType.Integer).Value = idusuario;
                        cmdMIELTRANS2.Parameters.Add("@idarea", FbDbType.Integer).Value = idarea;
                        cmdMIELTRANS2.Parameters.Add("@Fecha", FbDbType.Date).Value = fecha;
                        cmdMIELTRANS2.Parameters.Add("@Hora", FbDbType.Time).Value = hora;
                        cmdMIELTRANS2.Transaction = transaction;
                        cmdMIELTRANS2.ExecuteNonQuery();
                    }
                }


                //Insertamos el detalle de la compra (El tambor con los kilos comprados - Falta por Aceptar la compra )
                query = "INSERT INTO IM_WEB_TRANS (IDTRANS,IDTAMBOR,IDAPICULTOR,IDCONTENIDOS,KILOGRAMOS,FECHA,HORA,IDPERSONA,ACTIVO,IDPRO,PRECIOUNIT,SUBTOTAL,E_T,ENVIADO,MUESTRA) " +
                                "values(@idtran,@idtambor,@idapicultor,@tipo,@kg,@Fecha,@Hora,@idusr,'p',0,@precio,@totalcompra,'f','t','t')";

                FbCommand cmdIM_WEB_TRANS = new FbCommand(query, this.fbConnection1);
                cmdIM_WEB_TRANS.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                cmdIM_WEB_TRANS.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                cmdIM_WEB_TRANS.Parameters.Add("@idapicultor", FbDbType.Integer).Value = idapicultor;
                cmdIM_WEB_TRANS.Parameters.Add("@tipo", FbDbType.Integer).Value = idcontenidos;
                cmdIM_WEB_TRANS.Parameters.Add("@kg", FbDbType.Float).Value = kilogramos;
                cmdIM_WEB_TRANS.Parameters.Add("@Fecha", FbDbType.Date).Value = fecha;
                cmdIM_WEB_TRANS.Parameters.Add("@Hora", FbDbType.Time).Value = hora;
                cmdIM_WEB_TRANS.Parameters.Add("@idusr", FbDbType.Integer).Value = idusuario;
                cmdIM_WEB_TRANS.Parameters.Add("@precio", FbDbType.Double).Value = precio;
                cmdIM_WEB_TRANS.Parameters.Add("@totalcompra", FbDbType.Double).Value = precio * kilogramos;

                cmdIM_WEB_TRANS.Transaction = transaction;
                cmdIM_WEB_TRANS.ExecuteNonQuery();

                //Porque se hace el select si lo acabamos de insertar ¿se puede tener el mismo tambor en la compra pendiente de aceptar? o ¿por que el subtotal?
                //Ya vimos que no es necesario el update, en el insert hay que colocar el subtotal 
                //"select (kilogramos*preciounit) as kp2 from im_web_trans  where idapicultor='$apicultor2' and idtambor='$tambor' and e_t='f'"
                //"update im_web_trans set subtotal='$tot' where idapicultor='$apicultor2' and idtambor='$tambor' and e_t='f'"

                if (stock == 0)
                { // Si es un tambor vacío actualizo el tambor en la tabla im_web_tambor
                    query = "update im_web_tambor set compra='f' where num_tambor=@idtabor and area=@idarea";
                    FbCommand cmdUpdateTambor = new FbCommand(query, this.fbConnection1);
                    cmdUpdateTambor.Parameters.Add("@idtabor", FbDbType.Integer).Value = idtambor;
                    cmdUpdateTambor.Parameters.Add("@idarea", FbDbType.Integer).Value = idarea;
                    cmdUpdateTambor.Transaction = transaction;
                    cmdUpdateTambor.ExecuteNonQuery();
                }
                transaction.Commit();
                //Removemos del cache la tabla de disponibles para que se actualice el grid
                HttpContext.Current.Cache.Remove("Cache_TamboresDisponiblesKey");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// Fu
        /// </summary>
        public int HayCompraAceptadaNoTransferida(int idusuario)
        {
            int idtran = 0;
            string query = "select idtrans FROM im_web_mieltrans WHERE activa='p' and status='t' and enviado='t' AND idenfi=" + idusuario.ToString();
            DataTable idapicDT = LlenaTabla(query);
            if (idapicDT.Rows.Count > 0)
            {
                idtran = (int)idapicDT.Rows[0][0];
            }
            return idtran;
        }
       

        public void AceptaCompra(int idusuario, int idarea, DateTime fecha, DateTime hora, int idtrans)
        {
            string query="";
            FbTransaction transaction;
            //Verifico si hay una compra aceptada - lo cual me diria que ya tengo una transacción de miel dada de alta
            int idtrans2 = HayCompraAceptadaNoTransferida(idusuario);
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                if (idtrans2 > 0)
                {// Si no la hay la creo la transaccion de miel
                    //Inserta Transaccion de Miel
                    /*query = "SELECT GEN_ID(IM_MIELTRANS_GEN_ID, 1 ) FROM RDB$DATABASE;";
                    FbCommand cmdMIELTRANS = new FbCommand(query, this.fbConnection1);
                    cmdMIELTRANS.Transaction = transaction;
                    FbDataReader readerMIELTRANS = cmdMIELTRANS.ExecuteReader();*/

                    /*if (readerMIELTRANS.Read())
                    {*/
                        //idtrans = (int)readerMIELTRANS.GetValue(0);
                        query = "insert into IM_MIELTRANS(IDMIELTRAN,IDDELEGADO,IDAREAB,FECHA,HORA,IDENFI,IDAREA,ACTIVA) " +
                                "values(@idtran,@idusr,@idarea,@Fecha,@Hora,@idusr,@idarea,'p')";
                        FbCommand cmdMIELTRANS2 = new FbCommand(query, this.fbConnection1);
                        cmdMIELTRANS2.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                        cmdMIELTRANS2.Parameters.Add("@idusr", FbDbType.Integer).Value = idusuario;
                        cmdMIELTRANS2.Parameters.Add("@idarea", FbDbType.Integer).Value = idarea;
                        cmdMIELTRANS2.Parameters.Add("@Fecha", FbDbType.Date).Value = fecha;
                        cmdMIELTRANS2.Parameters.Add("@Hora", FbDbType.Time).Value = hora;
                        cmdMIELTRANS2.Transaction = transaction;
                        cmdMIELTRANS2.ExecuteNonQuery();
                    //}

                }

                //Marco la compra pendiente por aceptar a Aceptada
                query = "update im_web_mieltrans set status='f' where status='t' and idtrans=@idtran and activa='p'";
                FbCommand cmdUpdateMietam = new FbCommand(query, this.fbConnection1);
                cmdUpdateMietam.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                cmdUpdateMietam.Transaction = transaction;
                cmdUpdateMietam.ExecuteNonQuery();

                #region Ciclo que revisa si quedaron tambores de compras aceptadas de un envio anterior
                query = "select IDTRANS,IDTAMBOR,IDAPICULTOR,IDCONTENIDOS,PRECIOUNIT " +
                               "from im_web_trans where e_t='t' and enviado='T' and idpersona=" + idusuario;
                DataTable dtTamboresNoTransferidos = LlenaTablaTran(query, transaction);
                for (int i = 0; i < dtTamboresNoTransferidos.Rows.Count; i++)
                {
                    int idtran = (int)dtTamboresNoTransferidos.Rows[i][0];
                    int idtambor = (int)dtTamboresNoTransferidos.Rows[i][1];
                    int idapic = (int)dtTamboresNoTransferidos.Rows[i][2];
                    int idcontenidos = (int)dtTamboresNoTransferidos.Rows[i][3];
                    double pUnitario = (double)dtTamboresNoTransferidos.Rows[i][4];
                    
                    //Actualiza la tabla im_mietam con la nueva transferencia
                    query = "update im_mietam set idmieltran=@idtran where idultper=@idusr " +
                            "and idbarril=@idtambor and idapicultor=@idapic and preuni=@pUnitario and idcontenido=@idcontenidos  " +
                            "and idmieltran=@idtranOrig";
                    FbCommand cmdim_mietam = new FbCommand(query, this.fbConnection1);
                    cmdim_mietam.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                    cmdim_mietam.Parameters.Add("@idusr", FbDbType.Integer).Value = idusuario;
                    cmdim_mietam.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                    cmdim_mietam.Parameters.Add("@idapic", FbDbType.Integer).Value = idapic;
                    cmdim_mietam.Parameters.Add("@pUnitario", FbDbType.Double).Value = pUnitario;
                    cmdim_mietam.Parameters.Add("@idcontenidos", FbDbType.Integer).Value = idcontenidos;
                    cmdim_mietam.Parameters.Add("@idtranOrig", FbDbType.Integer).Value = idtran;
                    cmdim_mietam.Transaction = transaction;
                    cmdim_mietam.ExecuteNonQuery();

                    //Actualizamos la tabla im_tratam con la nueva transferencia
                    query = "update im_tratam set idtrans=@idtran where idtrans=@idtranOrig and idbarril=@idtambor";
                    FbCommand cmdim_tratam = new FbCommand(query, this.fbConnection1);
                    cmdim_tratam.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                    cmdim_tratam.Parameters.Add("@idtranOrig", FbDbType.Integer).Value = idtran;
                    cmdim_tratam.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                    cmdim_tratam.Transaction = transaction;
                    cmdim_tratam.ExecuteNonQuery();

                    //Actualiza la tabla im_web_muestra con la nueva transferencia
                    query = "update im_web_muestra set idmieltran=@idtran,activa='t' where idmieltran=@idtranOrig and status='f' " +
                            "and activa='f' and idbarril in (select a.idtambor from im_web_trans as a where a.idtambor=@idtambor)";
                    FbCommand cmdim_web_muestra = new FbCommand(query, this.fbConnection1);
                    cmdim_web_muestra.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                    cmdim_web_muestra.Parameters.Add("@idtranOrig", FbDbType.Integer).Value = idtran;
                    cmdim_web_muestra.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                    cmdim_web_muestra.Transaction = transaction;
                    cmdim_web_muestra.ExecuteNonQuery();

                    //Actualiza la tabla im_muestra con la nueva transferencia
                    query = "update im_muestra set idmieltran=@idtran where  idmieltran=@idtranOrig " +
                            "and idbarril in (select a.idtambor from im_web_trans as a where  a.idtambor=@idtambor)";
                    FbCommand cmdim_muestra = new FbCommand(query, this.fbConnection1);
                    cmdim_muestra.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                    cmdim_muestra.Parameters.Add("@idtranOrig", FbDbType.Integer).Value = idtran;
                    cmdim_muestra.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                    cmdim_muestra.Transaction = transaction;
                    cmdim_muestra.ExecuteNonQuery();

                    //Actualiza la tabla im_web_trans con la nueva transferencia
                    query = "update im_web_trans set idtrans=@idtran,enviado='t' where idpersona=@idusr and " +
                            "enviado='T' and e_t='t' and idtambor=@idtambor and idapicultor=@idapic and idtrans=@idtranOrig";
                    FbCommand cmdim_web_trans = new FbCommand(query, this.fbConnection1);
                    cmdim_web_trans.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                    cmdim_web_trans.Parameters.Add("@idusr", FbDbType.Integer).Value = idusuario;
                    cmdim_web_trans.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                    cmdim_web_trans.Parameters.Add("@idapic", FbDbType.Integer).Value = idapic;
                    cmdim_web_trans.Parameters.Add("@idtranOrig", FbDbType.Integer).Value = idtran;
                    
                    cmdim_web_trans.Transaction = transaction;
                    cmdim_web_trans.ExecuteNonQuery();

                }
                #endregion

                #region Ciclo para colocar el detalle como compra aceptada
                query = "select b.idtambor,b.idapicultor,b.idcontenidos,b.kilogramos,b.fecha,b.hora,b.preciounit,b.idtrans " +
                               "from im_web_trans as b  where b.e_t='f' and b.enviado='t' and b.idtrans=" + idtrans + " and b.idpersona=" + idusuario;
                DataTable im_web_transDT = LlenaTablaTran(query,transaction);

                //int idtrans = 0;
                int idapicultor = 0;
                for (int i = 0; i < im_web_transDT.Rows.Count; i++)
                {
                    int idtambor = (int)im_web_transDT.Rows[i][0];
                    idapicultor = (int)im_web_transDT.Rows[i][1];
                    int idcontenidos = (int)im_web_transDT.Rows[i][2];
                    float Kilogramos = (float)im_web_transDT.Rows[i][3];
                    fecha = (DateTime)im_web_transDT.Rows[i][4];

                    DateTime thora = (DateTime)im_web_transDT.Rows[i][5];
                    /*TimeSpan thora = DateTime.Now.TimeOfDay;
                    if ((im_web_transDT.Rows[i][5]).GetType().ToString() == "System.DateTime")
                    {
                        thora = ((DateTime)im_web_transDT.Rows[i][5]).TimeOfDay;
                    }
                    if ((im_web_transDT.Rows[i][5]).GetType().ToString() == "System.TimeSpan")
                        thora = (TimeSpan)im_web_transDT.Rows[i][5];    */

                    
                    double pUnitario = (double)im_web_transDT.Rows[i][6];
                    //idtrans = (int)im_web_transDT.Rows[i][7];

                    //Verifican si el tambor se encuentra en la tabla im_mietam
                    query = "select kilogramos " +
                            "from im_mietam where IDMIELTRAN=@idtran and IDBARRIL=@idtambor and IDAPICULTOR=@idapic and IDCONTENIDO=@idcont and " +
                            "PREUNI=@pUnitario and activo='p' and idultper=@idusr";
                    FbCommand cmdemp = new FbCommand(query, this.fbConnection1);
                    cmdemp.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                    cmdemp.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                    cmdemp.Parameters.Add("@idapic", FbDbType.Integer).Value = idapicultor;
                    cmdemp.Parameters.Add("@idcont", FbDbType.Integer).Value = idcontenidos;
                    cmdemp.Parameters.Add("@pUnitario", FbDbType.Double).Value = pUnitario;
                    cmdemp.Parameters.Add("@idusr", FbDbType.Integer).Value = idusuario;
                    cmdemp.Transaction = transaction;
                    FbDataReader readerMieTam = cmdemp.ExecuteReader();

                    if (readerMieTam.Read())
                    {//Si el tambor se encuentra en la tabla im_mietam
                        float kil = (float)readerMieTam.GetValue(0);
                        float KilosTotales = kil + Kilogramos;
                        query = "update im_mietam set kilogramos=@KilosT where IDAPICULTOR=@idapic and IDCONTENIDO=@idcont " +
                         "and PREUNI=@pUnitario and idmieltran=@idtran and idbarril=@idtambor and activo='p'";
                        FbCommand cmdmetam = new FbCommand(query, this.fbConnection1);
                        cmdmetam.Parameters.Add("@KilosT", FbDbType.Float).Value = KilosTotales;
                        cmdmetam.Parameters.Add("@idapic", FbDbType.Integer).Value = idapicultor;
                        cmdmetam.Parameters.Add("@idcont", FbDbType.Integer).Value = idcontenidos;
                        cmdmetam.Parameters.Add("@pUnitario", FbDbType.Double).Value = pUnitario;
                        cmdmetam.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                        cmdmetam.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                        cmdmetam.Transaction = transaction;
                        cmdmetam.ExecuteNonQuery();
                    }
                    else
                    {
                        query = "insert into IM_MIETAM(IDMIELTRAN,IDBARRIL,IDAPICULTOR,IDCONTENIDO,KILOGRAMOS,FECHA,HORA,IDULTPER,ACTIVO,IDPROD,PREUNI) " +
                                "values(@idtran,@idtambor,@idapic,@idcont,@KilosT,@Fecha,@Hora,@idusr,'p',0,@pUnitario)";
                        FbCommand cmdmetam = new FbCommand(query, this.fbConnection1);
                        cmdmetam.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                        cmdmetam.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                        cmdmetam.Parameters.Add("@idapic", FbDbType.Integer).Value = idapicultor;
                        cmdmetam.Parameters.Add("@idcont", FbDbType.Integer).Value = idcontenidos;
                        cmdmetam.Parameters.Add("@KilosT", FbDbType.Float).Value = Kilogramos;
                        cmdmetam.Parameters.Add("@Fecha", FbDbType.Date).Value = fecha;
                        cmdmetam.Parameters.Add("@Hora", FbDbType.Time).Value = thora;
                        cmdmetam.Parameters.Add("@idusr", FbDbType.Integer).Value = idusuario;
                        cmdmetam.Parameters.Add("@pUnitario", FbDbType.Double).Value = pUnitario;
                        cmdmetam.Transaction = transaction;
                        cmdmetam.ExecuteNonQuery();
                    }

                    //Seleccionamos la tara
                    float tara = 0;
                    query = "select b.tara from im_barrils a join im_cat_barriltipos b on b.idtipo=a.idtipo where idbarril=" + idtambor;
                    DataTable im_barrilsDT = LlenaTablaTran(query,transaction);
                    if (im_barrilsDT.Rows.Count > 0)
                    {
                        tara = (float)im_barrilsDT.Rows[0][0];
                    }

                    //Checamos el peso bruto de la tabla im_tratam
                    double PesoBruto = 0;
                    query = "select a.pbruto from im_tratam as a  where a.idbarril=" + idtambor + " and a.idtrans=" + idtrans;
                    DataTable im_tratamDT = LlenaTablaTran(query,transaction);
                    if (im_tratamDT.Rows.Count > 0)
                    {
                        PesoBruto = (double)im_tratamDT.Rows[0][0];
                        //Si existe el peso en bruto con los kilos del tambor que estamos recorriendo, Actualizamos  la tabla im_tratam
                        query = "update im_tratam set pbruto=@pBruto where idbarril=@idtambor and idtrans=@idtran";
                        FbCommand cmdtratam = new FbCommand(query, this.fbConnection1);
                        cmdtratam.Parameters.Add("@pBruto", FbDbType.Double).Value = PesoBruto + Kilogramos;
                        cmdtratam.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                        cmdtratam.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                        cmdtratam.Transaction = transaction;
                        cmdtratam.ExecuteNonQuery();
                    }
                    else
                    {
                        //Si no existe se da de alta y se le suma la tara ($sumatara=$kil+$tara1;)
                        query = "insert into im_tratam(idbarril,idtrans,pbruto)values(@idtambor,@idtran,@pBruto)";
                        FbCommand cmdtratam = new FbCommand(query, this.fbConnection1);
                        cmdtratam.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
                        cmdtratam.Parameters.Add("@pBruto", FbDbType.Double).Value = Kilogramos + tara;
                        cmdtratam.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                        cmdtratam.Transaction = transaction;
                        cmdtratam.ExecuteNonQuery();
                    }

                }//Fin del ciclo
                #endregion

                //Generamos el siguiente del im_web_trans_id
                query = "SELECT GEN_ID( GEN_IM_WEB_TRANS_ID, 1 ) FROM RDB$DATABASE;";
                FbCommand cmdgenid = new FbCommand(query, this.fbConnection1);
                cmdgenid.Transaction = transaction;
                FbDataReader reader_im_web_tran = cmdgenid.ExecuteReader();

                if (reader_im_web_tran.Read())
                {
                    long idcompra = (long)reader_im_web_tran.GetValue(0);
                    //Y lo actualizamos en la tabla im_web_trans      
                    query = "update im_web_trans set idcompra=@idcompra, e_t='t' where idpersona=@idusr and idtrans=@idtran and activo='p' and enviado='t' and idapicultor=@idapic and e_t='f'";
                    FbCommand cmdim_web_trans = new FbCommand(query, this.fbConnection1);
                    cmdim_web_trans.Parameters.Add("@idcompra", FbDbType.Integer).Value = idcompra;
                    cmdim_web_trans.Parameters.Add("@idusr", FbDbType.Integer).Value = idusuario;
                    cmdim_web_trans.Parameters.Add("@idtran", FbDbType.Integer).Value = idtrans;
                    cmdim_web_trans.Parameters.Add("@idapic", FbDbType.Integer).Value = idapicultor;
                    cmdim_web_trans.Transaction = transaction;
                    cmdim_web_trans.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }

            fbConnection1.Close();
        }

        public DataTable ObtenHistTransferenciaMiel(string idusuario)
        {
            string query = "select IDTRANS, IDDELEGADO, IDAREAB, FECHA, HORA, IDENFI, IDAREA, ACTIVA, AREATRANS, TOTALTRANS, STATUS " +
                           "from im_web_mieltrans where enviado='f' and idenfi=" + idusuario +
                           " order by idtrans";
            return LlenaTabla(query);
        }


        public DataTable ObtenHistTamboresTransferenciaMiel(string idtransferencia)
        {
            string query = "select b.idtambor,sum(b.kilogramos) as Kilogramos,sum(b.subtotal)as Subtotal,b.PRECIOUNIT, a.totaltrans,b.idtrans " +
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
        public DataTable ObtenTransferenciaMielRep(string idtransferencia)
        {
            string query = "select A.IDTRANS, A.IDDELEGADO, B.nombre AS NombreDelegado, A.IDAREAB, C.area as AREA_ORIGEN, A.FECHA, " +
                           "A.HORA, A.IDENFI, A.IDAREA, A.ACTIVA, A.AREATRANS, D.area AS AREA_DESTINO, A.TOTALTRANS, A.STATUS " +
                           "from im_web_mieltrans A LEFT OUTER join LOCENFIS B ON B.IDENFI = A.IDDELEGADO " + 
                           "LEFT OUTER JOIN AREAS C ON C.idarea = A.idareab " + 
                           "LEFT OUTER JOIN AREAS D ON D.idarea = A.areatrans " +
                           "where A.idtrans=" + idtransferencia;
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
        

        public DataTable ObtenTamboresCompraPendienteAceptar(int idusuario)
        {
            string query = "select a.idtambor as Tambor,b.nombre as Apicultor,c.contenido as TipoMiel,a.kilogramos,a.preciounit,a.subtotal " +
                           "from IM_WEB_TRANS as a inner join locenfis as b on a.idapicultor = b.idenfi " +
                           "inner join im_cat_contenidos c on a.idcontenidos = c.idcontenido " +
                           "where a.idpersona=" + idusuario.ToString() + " and activo='p' and e_t='f' and idcompra is null " +
                           "order by a.idtambor asc";
            return LlenaTabla(query);
        }


        public DataTable ObtenComprasRealizadas(int idusuario)
        {
            string query = "select c.nombre,b.contenido , sum(kilogramos) as kg,sum(kilogramos*preciounit)as st ,idcompra " +
                        "from im_web_trans as a inner join IM_CAT_CONTENIDOS b on a.idcontenidos = b.idcontenido " +
                        "inner join LOCENFIS c on c.idenfi = a.idapicultor " +
                        "where a.idpersona=" + idusuario + " and activo='p' and e_t='t' and enviado='t' " +
                        "group by c.nombre,b.contenido,idcompra " +
                        "order by idcompra";
            return LlenaTabla(query);
        }


        /// <summary>
        /// Verifica si existen tambores pendientes de aceptar
        /// </summary>
        public bool HayTamboresPendAceptar()
        {
            bool bHayTambores = false;
            string query = "select * from im_web_trans where e_t='f' and enviado='t'";
            DataTable idapicDT = LlenaTabla(query);
            if (idapicDT.Rows.Count > 0)
            {
                bHayTambores = true;
            }
            return bHayTambores;
        }

        public void CancelaCompra(int idtrans, int idusuario, int idarea)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();

            try
            {
                //Actualizamos los tambores de im_web_tambor para indicar que estan disponibles
                //Se le coloca compra = 't' a todos los tambores que pertenecen a un tambor que esta pendiente de aceptar
                //Nota: Cuando se agrega un tambor por primera vez la muestra se graba como t y si ya existe en una compra aceptada se graba como f
                query = "update im_web_tambor set compra='t' where compra='f' and num_tambor in(select idtambor from im_web_trans " +
                         "where idpersona=@idusuario and e_t='f' and enviado='t' and muestra='t') and area=@idarea";
                FbCommand cmdim_web_trans = new FbCommand(query, this.fbConnection1);
                cmdim_web_trans.Parameters.Add("@idusuario", FbDbType.Integer).Value = idusuario;
                cmdim_web_trans.Parameters.Add("@idarea", FbDbType.Integer).Value = idarea;
                cmdim_web_trans.Transaction = transaction;
                cmdim_web_trans.ExecuteNonQuery();

                //Borra el detalle de los tambores de la compra pendiente de aceptacion
                // donde e_t='f' y enviado = 't', quite el idtambor del where
                query = "delete from im_web_trans where idtrans=@idtrans and idpersona=@idusuario " +
                "and e_t='f' and enviado='t' and muestra in('t','f')";
                FbCommand cmdUpdateIM_web_trans = new FbCommand(query, this.fbConnection1);
                cmdUpdateIM_web_trans.Parameters.Add("@idtrans", FbDbType.Integer).Value = idtrans;
                cmdUpdateIM_web_trans.Parameters.Add("@idusuario", FbDbType.Integer).Value = idusuario;
                cmdUpdateIM_web_trans.Transaction = transaction;
                cmdUpdateIM_web_trans.ExecuteNonQuery();

                //No tenemos que checar que sea el ultimo tambor ya que se han eliminado todos los e_t='f' en el paso anterior
                //Y solo la eliminara si el estatus = 't' (cuando ya hay una compra aceptada el estatus es 'f')
                query = "delete from im_web_mieltrans where activa='p' and idenfi=@idusuario and status='t' and enviado='t'";
                FbCommand cmdDeleteEnc = new FbCommand(query, this.fbConnection1);
                cmdDeleteEnc.Parameters.Add("@idusuario", FbDbType.Integer).Value = idusuario;
                cmdDeleteEnc.Transaction = transaction;
                cmdDeleteEnc.ExecuteNonQuery();
                transaction.Commit();
                this.fbConnection1.Close();
                //Checamos si es el ultimo tambor

                /*query = "select * from im_web_trans where idtrans=" + idtrans.ToString() + " and e_t='f' and enviado='t' and muestra in('t','f')";	
                FbCommand cmdDetalleTran = new FbCommand(query, this.fbConnection1);
            
                FbDataReader reader_im_web_tran = cmdDetalleTran.ExecuteReader();
                if (!reader_im_web_tran.HasRows)
                {
                    //Si lo es borramos el encabezado
                   //delete from im_web_mieltrans where activa='p' and idenfi='$idusuario' and status='t' and enviado='t'
                }*/
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                fbConnection1.Close();
                throw ex;
            }
        }

        public DataTable ObtenPlantas()
        {
            string query = "SELECT DISTINCT idtipdir,area FROM areasb WHERE idtipdir=51 OR idtipdir=56 OR idtipdir=58 OR idtipdir=61 ORDER BY AREA ASC";
            return LlenaTabla(query);
        }

        public DataTable ObtenPlantasFiltrado(int idArea)
        {
            string query = "SELECT DISTINCT idtipdir,area FROM areasb WHERE (idtipdir=51 OR idtipdir=56 OR idtipdir=58 OR idtipdir=61) and idtipdir <> "+ idArea + " ORDER BY AREA ASC";
            return LlenaTabla(query);
        }

        public DataTable ComprasRealizadasAgrupadasPorTamborPorTransferir(int idusuario)
        {
            string query = "select a.idtambor,c.contenido,sum(preciounit)/count(*) as PrecioUnitario,sum(a.kilogramos)as kg,sum(a.subtotal)as tot,a.idtrans, (case b.status when 'f' then 'SI' else 'NO' end) as status " +
                            "from IM_WEB_TRANS as a left join im_web_muestra b on a.idtrans = b.idmieltran and a.idtambor = b.idbarril " +
                            "inner join IM_CAT_CONTENIDOS c on a.idcontenidos = c.idcontenido " +
                            "where a.idpersona=" + idusuario.ToString() + "  and activo='p' and enviado in('t','T')and e_t='t' " +
                            "group by a.idtambor,c.contenido,a.idtrans, b.status";
            return LlenaTabla(query);
        }
        //

        public DataTable ObtenCompraMielPorIdCompra(int idcompra)
        {
            string query = "select a.idapicultor,rtrim(nombre),rtrim(h.area),a.fecha,idtambor,e.tara,f.pbruto,f.pneto,preciounit,f.pagado from im_web_trans a " +
                            "inner join locenfis b on b.idenfi = a.idapicultor " +
                            "inner join im_tratam f on a.idtrans = f.idtrans and f.idbarril = a.idtambor " +
                            "inner join im_barrils as d on a.idtambor=d.idbarril " +
                            "inner join im_cat_barriltipos as e  on d.idtipo=e.idtipo " +
                            "inner join im_web_usuarios g on a.idpersona = g.id " +
                            "inner join areas h on h.idarea = g.idarea " +
                            "where idcompra = " + idcompra;
            return LlenaTabla(query);
        }


        public DataTable ObtenCompraPorIdDelegado()
        {
            /*Determina la compra en un rango de fecha por delegado*/
            string query = "select idpersona,idcompra,sum(kilogramos*preciounit)as st from im_web_trans " +
                            "where idcompra is not null and enviado = 'f' and fecha between '01/03/2012' and '11/03/2012' and " +
                            "idpersona = 83 " +
                            "group by idpersona,idcompra ";
            return LlenaTabla(query);
        }

        public DataTable ObtenAnticipoPorFechas()
        {
            /*Determina los anticipos autorizados a un delegado en un rango de fechas (Montos)*/
            string query = "select idpersona,idcompra,sum(kilogramos*preciounit)as st from im_web_trans " +
                            "where idcompra is not null and enviado = 'f' and fecha between '01/03/2012' and '11/03/2012' and " +
                            "idpersona = 83 " +
                            "group by idpersona,idcompra ";
            return LlenaTabla(query);
        }

        public DataTable ObtenCortesPorDelegado(DateTime FechaIni, DateTime FechaFin, int iddelegado)
        {
            FbDataAdapter da = new FbDataAdapter();
            DataTable fdt = new DataTable();
            this.fbConnection1.Open();
            try
            {
                string query = "select c.nombre delegado, rtrim(h.area)as  area, fecha_corte,hora_corte, saldo_corte+abono-cargo as anterior,cargo,abono,saldo_corte actual, b.nombre elaboro " +
                                "from IM_CORTE_DELEGADO a " +
                                "inner join locenfis b on b.idenfi = a.idelaboro " +
                                "inner join locenfis c on c.idenfi = a.iddelegado " +
                                "inner join im_web_usuarios g on a.iddelegado = g.id " +
                                "inner join areas h on h.idarea = g.idarea " +
                                "where (IDDELEGADO = @iddelegado or @iddelegado = 0) and fecha_corte between @fechaIni and @fechafin ";
                FbCommand cmd = new FbCommand(query, this.fbConnection1);
                cmd.Parameters.Add("@iddelegado", FbDbType.Integer).Value = iddelegado;
                cmd.Parameters.Add("@fechaIni", FbDbType.Date).Value = FechaIni;
                cmd.Parameters.Add("@fechafin", FbDbType.Date).Value = FechaFin;
                da.SelectCommand = cmd;
                da.Fill(fdt);
                this.fbConnection1.Close();
                return fdt;
            }
            catch (Exception ex)
            {
                fbConnection1.Close();
                throw ex;
            }
        }

        public DataTable ObtenCortesPorFecha(DateTime FechaIni, DateTime FechaFin, int iddelegado)
        {
            FbDataAdapter da = new FbDataAdapter();
            DataTable fdt = new DataTable();
            this.fbConnection1.Open();
            try
            {
               string query = "select c.nombre delegado, rtrim(h.area)as  area, fecha_corte,hora_corte, saldo_corte+abono-cargo as anterior,cargo,abono,saldo_corte actual, b.nombre elaboro " +
                                "from IM_CORTE_DELEGADO a " +
                                "inner join locenfis b on b.idenfi = a.idelaboro " +
                                "inner join locenfis c on c.idenfi = a.iddelegado " +
                                "inner join im_web_usuarios g on a.iddelegado = g.id " +
                                "inner join areas h on h.idarea = g.idarea " +
                                "where (IDDELEGADO = @iddelegado or @iddelegado = 0) and fecha_corte between @fechaIni and @fechafin ";
                FbCommand cmd = new FbCommand(query, this.fbConnection1);
                cmd.Parameters.Add("@iddelegado", FbDbType.Integer).Value = iddelegado;
                cmd.Parameters.Add("@fechaIni", FbDbType.Date).Value = FechaIni;
                cmd.Parameters.Add("@fechafin", FbDbType.Date).Value = FechaFin;
                da.SelectCommand = cmd;
                da.Fill(fdt);
                this.fbConnection1.Close();
                return fdt;
            }
            catch (Exception ex)
            {
                fbConnection1.Close();
                throw ex;
            }
        }

        public DataTable ObtenAnticiposDelegadoPorFecha(DateTime FechaIni, DateTime FechaFin, int iddelegado)
        {
            FbDataAdapter da = new FbDataAdapter();
            DataTable fdt = new DataTable();
            this.fbConnection1.Open();
            try
            {
                string query = "SELECT b.nombre,g.idarea , rtrim(h.area)as  area,iddelegado,canti,a.fecha,a.hora, a.docum,c.nombre elaboro,a.sit FROM IM_ANTICIPOS a " +
                                 "inner join locenfis b on b.idenfi = a.iddelegado " +
                                 "inner join locenfis c on c.idenfi = a.idautor " +
                                 "inner join im_web_usuarios g on a.iddelegado = g.id " +
                                 "inner join areas h on h.idarea = g.idarea " +
                                 "where (iddelegado = @iddelegado or @iddelegado = 0) and fecha between @fechaIni and @fechafin " +
                                 " order by b.nombre, a.fecha,a.hora";
                FbCommand cmd = new FbCommand(query, this.fbConnection1);
                cmd.Parameters.Add("@iddelegado", FbDbType.Integer).Value = iddelegado;
                cmd.Parameters.Add("@fechaIni", FbDbType.Date).Value = FechaIni;
                cmd.Parameters.Add("@fechafin", FbDbType.Date).Value = FechaFin;
                da.SelectCommand = cmd;
                da.Fill(fdt);
                this.fbConnection1.Close();
                return fdt;
            }
            catch (Exception ex)
            {
                fbConnection1.Close();
                throw ex;
            }
        }
        /*

 * 
 * 
SELECT g.idarea , rtrim(h.area)as  area,iddelegado,sum(canti) FROM IM_ANTICIPOS a
inner join im_web_usuarios g on a.iddelegado = g.id
inner join areas h on h.idarea = g.idarea
where iddelegado = 83 and fecha between '01/03/2010' and '11/03/2010'
group by g.idarea,h.area,iddelegado

//Determina los anticipos autorizados a un delegado en un rango de fechas (Detalle)
SELECT b.nombre,g.idarea , rtrim(h.area)as  area,iddelegado,canti,a.fecha,a.hora, a.docum,c.nombre elaboro,a.sit FROM IM_ANTICIPOS a
inner join locenfis b on b.idenfi = a.iddelegado
inner join locenfis c on c.idenfi = a.idautor
inner join im_web_usuarios g on a.iddelegado = g.id
inner join areas h on h.idarea = g.idarea
where iddelegado = 83 and fecha between '01/03/2010' and '11/03/2010'*/

        public string ObtenDelegado(int delegado)
        {
            string nombre = "";
            string query = "select nombre from locenfis where idenfi=" + delegado.ToString(); 
            DataTable idapicDT = LlenaTabla(query);
            if (idapicDT.Rows.Count > 0)
            {
                nombre = (string)idapicDT.Rows[0][0];
            }
            return nombre;
        }

        public string ObtenArea(int idarea)
        {
            string area = "";
            string query = "select area from areas where idarea=" + idarea.ToString(); 
            DataTable idapicDT = LlenaTabla(query);
            if (idapicDT.Rows.Count > 0)
            {
                area = (string)idapicDT.Rows[0][0];
            }
            return area;
        }

        public void EnviaTransferencia(System.Collections.Generic.List<object> tambores, int idtrans, int idusuario, int idarea)
        {
            string query = "";
            FbTransaction transaction;
            this.fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                //Recorre los tambores de la transferencia
                for (int i = 0; i < tambores.Count; i++)
                {
                    int idtam = (int)tambores[i];
                    //Cambia de estado el tambor como enviado (detall transferencia web).
                    //update im_web_trans set enviado='f' where enviado='t' and idtambor='$del' and idtrans='idtransf' 
                    //  and idpersona='$idusuario (es el delegado)
                    query = "update im_web_trans set enviado='f' where enviado='t' and idtambor=@idtambor and idtrans=@idtrans " +
                             " and idpersona=@idusuario";
                    FbCommand cmdim_web_trans = new FbCommand(query, this.fbConnection1);
                    cmdim_web_trans.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtam;
                    cmdim_web_trans.Parameters.Add("@idtrans", FbDbType.Integer).Value = idtrans;
                    cmdim_web_trans.Parameters.Add("@idusuario", FbDbType.Integer).Value = idusuario;
                    cmdim_web_trans.Transaction = transaction;
                    cmdim_web_trans.ExecuteNonQuery();
                }

                //Suma el total de la transferencia
                //select sum(subtotal) as st from im_web_trans where activo='p' and idtrans='$t' and enviado in('f','T')

                //Actualiza el total de la transferencia web encabezado.
                query = "update im_web_mieltrans set AREATRANS=@idarea,enviado='f', " +
                        "TOTALTRANS=(select sum(subtotal) from im_web_trans  where activo='p' and enviado in('f','T') and idtrans=@idtrans) " +
                        "where idtrans=@idtrans and idenfi=@idusuario and activa='p' and status='f'";
                FbCommand cmdim_web_mieltrans = new FbCommand(query, this.fbConnection1);
                cmdim_web_mieltrans.Parameters.Add("@idarea", FbDbType.Integer).Value = idarea;
                cmdim_web_mieltrans.Parameters.Add("@idtrans", FbDbType.Integer).Value = idtrans;
                cmdim_web_mieltrans.Parameters.Add("@idusuario", FbDbType.Integer).Value = idusuario;
                cmdim_web_mieltrans.Transaction = transaction;
                cmdim_web_mieltrans.ExecuteNonQuery();

                //Si el tambor fue muestreado entonces graba su estado.
                query = "update im_web_muestra set activa='f' where activa='t' and idmieltran=@idtrans and idenfi=@idusuario";
                FbCommand cmdim_web_muestra = new FbCommand(query, this.fbConnection1);
                cmdim_web_muestra.Parameters.Add("@idtrans", FbDbType.Integer).Value = idtrans;
                cmdim_web_muestra.Parameters.Add("@idusuario", FbDbType.Integer).Value = idusuario;
                cmdim_web_muestra.Transaction = transaction;
                cmdim_web_muestra.ExecuteNonQuery();

                //Marcamos los tambores que no se transfirieron colocandoles una T
                query = "update im_web_trans set enviado='T' where enviado='t' and e_t='t' and idtrans=@idtrans and idpersona=@idusuario";
                FbCommand cmdUpdateT = new FbCommand(query, this.fbConnection1);
                cmdUpdateT.Parameters.Add("@idtrans", FbDbType.Integer).Value = idtrans;
                cmdUpdateT.Parameters.Add("@idusuario", FbDbType.Integer).Value = idusuario;
                cmdUpdateT.Transaction = transaction;
                cmdUpdateT.ExecuteNonQuery();
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
