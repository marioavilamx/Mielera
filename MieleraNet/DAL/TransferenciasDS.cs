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
    public class TransferenciasDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;
        public int idtranpendiente = 0;
        private applicationConfig objAppConConfig;

        public TransferenciasDS()
        {
            
            objAppConConfig = new applicationConfig();
            objAppConConfig.configConnPeriferica(cs);

            this.fbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            fbConnection1.ConnectionString = cs.ToString();
        }

        /// <summary>
        /// Esta funcion graba en la lista de tambores de una transferencia pendiente
        /// </summary>
        /// <param name="idenfimo">Usuario que esta loggeado</param>
        /// <param name="idtambor">Tambor a agregar a la lista</param>
        /// <param name="idarea">Area del usuario</param>
        /// <returns></returns>
        public int AgregaTamborPendiente( int idenfimo, int idtambor, int idarea)
        {
            int result = 1;
            FbTransaction transaction;
            FbCommand command = new FbCommand("AGRE_TAMBOR_PENDIENTE", fbConnection1);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("idenfimo", idenfimo);
            command.Parameters.Add("idtambor", idtambor);
            command.Parameters.Add("idarea", idarea);

            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                result = (int)command.ExecuteScalar();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();
            return result;
        }

        /// <summary>
        /// Esta funcion envia realiza la transferencia
        /// </summary>
        /// <param name="destino">Centro de Acopio que recibe</param>
        /// <param name="idarea">Centro de Acopio que envía</param>
        /// <param name="fenvio">La fecha en que se realizo</param>
        /// <param name="idenfimo">Usuario que realiza la operación</param>
        /// <returns>Esta funcio retorna algun codigo de error (0 Todo OK)</returns>
        public int EnviaTransferencia(int destino, int idarea, DateTime fenvio,int idenfimo)
        {
            int result = 0;
            FbTransaction transaction;
            FbCommand command = new FbCommand("ENVIA_TRANSFERENCIA", fbConnection1);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("destino", destino);
            command.Parameters.Add("idarea", idarea);
            command.Parameters.Add("fenvio", fenvio);
            command.Parameters.Add("idenfimo", idenfimo);

            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();
            return result;
        }

        /// <summary>
        /// Esta funcion nos devuelve las tambores que pertencen a una transferencia pendiente
        /// </summary>
        /// <returns>Retorna la lista de las empresas web</returns>
        public System.Collections.ArrayList ObtenTamboresPendientes(int idusr, int idarea)
        {
            this.fbConnection1.Open();
            System.Collections.ArrayList listaTambores = new System.Collections.ArrayList();

            FbCommand cmdemp = new FbCommand("select a.num_tambor,b.id from im_web_tambor as a  inner join im_web_envio_tambores as b on a.idenvio=b.id " +
                                              "where a.status='Activo' and b.idsuario=@idusr and b.origen=@idarea", this.fbConnection1);
            cmdemp.Parameters.Add("@idusr", FbDbType.Integer).Value = idusr;
            cmdemp.Parameters.Add("@idarea", FbDbType.Integer).Value = idarea;
            FbDataReader reader = cmdemp.ExecuteReader();
            try
            {
                 while (reader.Read())
                {
                    listaTambores.Add((string)reader.GetValue(0).ToString());
                    idtranpendiente = (int)reader.GetValue(1);
                }
            }
            finally
            {
                // always call Close when done reading.
                reader.Close();
                this.fbConnection1.Close();
            }
            return listaTambores;
        }

        /// <summary>
        /// Esta funcion nos devuelve las tambores que pertencen a una transferencia pendiente
        /// </summary>
        /// <returns>Retorna la lista de las empresas web</returns>
        public DataTable ObtenTamboresPendientes2(int idusr, int idarea)
        {
            this.fbConnection1.Open();
            System.Collections.ArrayList listaTambores = new System.Collections.ArrayList();

            FbCommand cmdemp = new FbCommand("select a.num_tambor,b.id from im_web_tambor as a  inner join im_web_envio_tambores as b on a.idenvio=b.id " +
                                              "where a.status='Activo' and b.idsuario=@idusr and b.origen=@idarea", this.fbConnection1);
            cmdemp.Parameters.Add("@idusr", FbDbType.Integer).Value = idusr;
            cmdemp.Parameters.Add("@idarea", FbDbType.Integer).Value = idarea;

            FbDataAdapter da = new FbDataAdapter(cmdemp);
            DataTable fdt = new DataTable();
            try
            {
                    da.Fill(fdt);
            }
            finally
            {
                this.fbConnection1.Close();
            }
            return fdt;
        }

        //
        public void RecepcionaTambores(int idtambor, int idTransferencia, int idarea)
        {
            FbTransaction transaction;
            FbCommand command;
            //El estatus R significa que ya esta recepcionado
            command = new FbCommand("UPDATE im_web_tambor SET status='R' WHERE num_tambor=@idtambor and status='Ocupado'", fbConnection1);
            command.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                //Actualiza Tambor en detalle de transferencia
                command.ExecuteNonQuery();

                //Actualiza transferencia
                FbCommand commandTran = new FbCommand("UPDATE im_web_envio_tambores SET status='A' WHERE status='ENVIADO' AND id=@idtran and destino=@idarea", fbConnection1);
                commandTran.Transaction = transaction;
                commandTran.Parameters.Add("@idtran", idTransferencia);
                commandTran.Parameters.Add("@idarea", idarea);
                commandTran.ExecuteNonQuery();

                //Actualiza Tambor
                FbCommand commandBarril = new FbCommand("update IM_BARRILS set idarea=@idarea where idbarril=@idtambor", fbConnection1);
                commandBarril.Transaction = transaction;
                commandBarril.Parameters.Add("@idarea", idarea);
                commandBarril.Parameters.Add("@idtambor", idtambor);
                commandBarril.ExecuteNonQuery();

                
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();
        }

        public void EliminaListaTambores(int idtambor, int idTransferencia)
        {
            FbTransaction transaction;
            FbCommand command;
            if (idtambor > 0)
            {
                command = new FbCommand("delete from im_web_tambor where status='Activo' and num_tambor=@idtambor and idenvio=@idtran and compra='t'", fbConnection1);
                command.Parameters.Add("@idtambor", FbDbType.Integer).Value = idtambor;
            }
            else
                command = new FbCommand("delete from im_web_tambor where idenvio=@idtran", fbConnection1);

            command.Parameters.Add("@idtran", FbDbType.Integer).Value = idTransferencia;
            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();
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

        public DataTable ObtenTamboresPorIdTransferencia(string idtransferencia)
        {
            string query = "select * from im_web_tambor where idenvio = " + idtransferencia;
            return LlenaTabla(query);
        }

        public DataTable ObtenHistorialTransferencias(string idusuario, string idarea)
        {
            string query = "SELECT a.id, a.fecha_envio,b.area as Origen, c.area as Destino, a.iddelegado,a.idsuario,a.status, " +
                           "(case a.status when 'ENVIADO' then 'Si' else 'No' end) as Activa " +
                           "FROM im_web_envio_tambores a " +
                           "inner join areas b on b.idarea = a.origen " +
                           "inner join areas c on c.idarea = a.destino " +
                           "WHERE a.idsuario=" + idusuario + " AND a.origen=" + idarea + " order by a.id";
            return LlenaTabla(query);
        }

        public DataTable ObtenHistorialTamboresRecepcionados(string idusuario, string idarea)
        {
            
            //string query = "SELECT a.*, b.area as Origen, c.area as Destino, " +
            string query = "SELECT a.ID, a.fecha_envio,b.area as Origen, c.area as Destino, a.iddelegado,a.idsuario,a.status, " +
                           "(case a.status when 'A' then 'NO' else '' end) as Activa " +
                           "FROM  im_web_envio_tambores a " +
                           "inner join areas b on b.idarea = a.origen " +
                           "inner join areas c on c.idarea = a.destino " +
                           "WHERE a.iddelegado=" + idusuario.ToString() + " AND a.status='A' " +
                           "order by a.id";
            return LlenaTabla(query);
        }


        public DataTable ObtenTamboresARecepcionar(string nivel, string area)
        {
            string query =  "select a.num_tambor,a.idenvio, d.area as Origen, " +
                            "e.area as Destino,b.destino as iddestino " +
                            "from im_web_tambor  a  " +
                            "inner join im_web_envio_tambores  b on a.idenvio=b.id  " +
                            "inner join im_web_usuarios c on  c.id=b.iddelegado " +
                            "inner join areas d on d.idarea = b.origen " +
                            "inner join areas e on e.idarea = b.destino " +
                            "where b.destino=a.area and c.nivel="+ nivel +" and b.destino = "+ area +" and a.status='Ocupado'";
            return LlenaTabla(query);
        }

        public DataTable ObtenTransferenciaPorIdTran(string idTran)
        {
            string query = "select tran.*, usr.nombre, ar.area, usr2.nombre as nombre2, ar2.area from IM_WEB_ENVIO_TAMBORES tran " +
                           "inner join locenfis usr on tran.iddelegado = usr.idenfi " +
                           "inner join locenfis usr2 on tran.idsuario = usr2.idenfi " +
                           "inner join areas ar on tran.destino = ar.idarea " +
                           "inner join areas ar2 on tran.origen = ar2.idarea " +
                           "where tran.id = " + idTran;
            return LlenaTabla(query);
        }

        #region Seccion de Transferencias
        public DataTable ObtenTamboresEnviados()
        {
            string query = "select et.id,a.area as origen,dest.area as destino,et.fecha_envio " +
                           "from IM_WEB_ENVIO_TAMBORES et " +
                           "inner join areas a on et.origen=a.idarea " +
                           "inner join areas dest on dest.idarea = et.destino " +
                           "where et.status='ENVIADO'";
            return LlenaTabla(query);
        }
        #endregion

        

    }

 
}
