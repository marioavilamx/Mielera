using System;
using System.Collections.Generic;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using MieleraNet;
using System.Data;
using MieleraNet.Web;

namespace MieleraNet.DAL
{
    class PerifericaDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;
        private applicationConfig objAppConfig;//TODO: arturo

        public PerifericaDS()
        {
            
            objAppConfig = new applicationConfig();
            objAppConfig.configConnPeriferica(cs);

            this.fbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            fbConnection1.ConnectionString = cs.ToString();
        }

        public string ObtenRoles(string Usuario, string pass, ref int usridarea, ref int idusr, ref int nivel)
        {
            string roles = "";
            string query = "SELECT ROLES, IDAREA, ID, NIVEL FROM IM_WEB_USUARIOS WHERE (USUARIO = '{0}') AND (PASS = '{1}')";
            query = string.Format(query, Usuario, pass);

            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            //da.Fill(EncabezadoDT);
            if (fdt.Rows.Count > 0) {
                roles = fdt.Rows[0][0].ToString();
                usridarea = (int)fdt.Rows[0][1];
                idusr = (int)fdt.Rows[0][2];
                nivel = (int)fdt.Rows[0][3];
            }
            return roles;
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

        public DataTable ObtenUsuarioWeb()
        {
            string query = "SELECT * FROM IM_WEB_USUARIOS order by usuario";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenDelegados()
        {
            string query = "SELECT a.id,b.nombre FROM IM_WEB_USUARIOS a inner join locenfis b on b.idenfi = a.id where roles = 'Delegado'";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }
        
        public DataTable ObtenAreas()
        {
            string query = "SELECT * FROM AREAS where idarea in (select idarea from im_web_usuarios)";
            return LlenaTabla(query);
        }

        public DataTable ObtenLocenfis()
        {
            string query = "SELECT * FROM LOCENFIS";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion actualiza los usuario registrados en web
        /// </summary>
        /// <param name="pass">password del usuario</param>
        /// <param name="roles">Rol que tiene configurado el usuario</param>
        /// <param name="id">idenfimo del usuario</param>
        public void ActualizaUsrWeb(string pass, string roles, int id)
        {
            FbTransaction transaction;
            FbCommand command;
            int idrol = 0;
            if (roles != null){
                
                switch (roles)
                {
                    case "Administrador" : idrol=1; break;
                    case "Delegado": idrol = 2; break;
                    case "Apicultor" : idrol = 3; break;
                }
                command = new FbCommand("update IM_WEB_USUARIOS set roles=@rol, nivel=@nivel, pass = @pass where id = @id", fbConnection1);
                command.Parameters.Add("@rol", FbDbType.VarChar, 50).Value = roles;
                command.Parameters.Add("@nivel", FbDbType.Integer).Value = idrol;
            }
            else
                command = new FbCommand("update IM_WEB_USUARIOS set pass = @pass where id = @id", fbConnection1);

            
            command.Parameters.Add("@pass", FbDbType.VarChar, 15).Value = pass;
            command.Parameters.Add("@id", FbDbType.Integer).Value = id;
            
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
        /// Se retira la cuenta del usuario para el acceso al sitio web
        /// </summary>
        /// <param name="id">idenfimo del cliente</param>
        public void EliminaUsrWeb(int id)
        {
            FbTransaction transaction;
            FbCommand command = new FbCommand("delete from IM_WEB_USUARIOS where id = @id", fbConnection1);
            command.Parameters.Add("@id", FbDbType.Integer).Value = id;
            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                transaction.Commit();
            }

            catch (FbException fbex)
            {
                transaction.Rollback();
                if (fbex.ErrorCode == 335544466)
                {
                   throw new Exception("No puede elminar un usario si ya ha enviado tambores");
                }

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();
        }

        /// <summary>
        /// Funcion que da de alta al usuario al sitio web
        /// </summary>
        /// <param name="idenfimo">idenfimo del usuario</param>
        /// <param name="usuario">Nick que se le pone al cliente para su acceso</param>
        /// <param name="pass">Password del usuario</param>
        /// <param name="idrol">idRol al que pertenece el usuario</param>
        /// <param name="rol">Rol al que pertenece el usuario</param>
        /// <param name="idarea">Area al que pertence el usuario</param>
        public void AltaUsuarioWeb(int idenfimo, string usuario, string pass, int idrol,
                                      string rol, int idarea)
        {
            FbTransaction transaction;
            FbCommand command = new FbCommand("insert into IM_WEB_USUARIOS values (@id,@usuario,@pass,@nivel,@idarea,@roles)", fbConnection1);

            command.Parameters.Add("@id", FbDbType.Integer).Value = idenfimo;
            command.Parameters.Add("@usuario", FbDbType.VarChar,25).Value = usuario;
            command.Parameters.Add("@pass", FbDbType.VarChar, 15).Value = pass;
            command.Parameters.Add("@nivel", FbDbType.Integer).Value = idrol;
            command.Parameters.Add("@idarea", FbDbType.Integer).Value = idarea;
            command.Parameters.Add("@roles", FbDbType.VarChar,50).Value = rol;

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

        public int SincornizaEntidad(int idenfimo, string nombre)
        {
            int result = 1;
            FbTransaction transaction;
            FbCommand command = new FbCommand("LOCENFI_SINCRO", fbConnection1);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("idenfimo", idenfimo);
            command.Parameters.Add("nombre", nombre);

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

        public DataTable ObtenAniosHist()
        {
            string query = "SELECT DISTINCT EXTRACT(YEAR FROM FECHA) AS mifecha FROM im_mietam";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenLoteHist(short mifecha)
        {
            string query = "select distinct numprod, idprod from im_prods " +
                           "where numprod <> '0' and extract(year from fecha) = " + mifecha.ToString();
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenLoteDetalleHist(string idprod)
        {
            string query = "select  b.fecha,k.numprod,g.idenfi,g.nombre,d.area, a.kilogramos, l.idmuestra " +
                           "from im_mietam a " + 
                           "left outer join im_mieltrans b on b.idmieltran=a.idmieltran " +
                           "left outer join locenfis c on c.idenfi=b.iddelegado " +
                           "left outer join areasb d on d.idtipdir=b.idareab and d.idenfi=b.iddelegado " +
                           "left outer join locenfis g on g.idenfi=a.idapicultor " +
                           "left outer join im_prods k on k.idprod=a.idprod " +
                           "left outer join im_muestra l on l.idmieltran=a.idmieltran and l.idbarril=a.idbarril " +
                           "where b.idareab <> 1 and a.idbarril > 45 and a.idprod=" + idprod + 
                           "  order by b.fecha,d.area";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenLoteDetalleHistIntegradora(string idprod)
        {
            string query = "select  b.fecha,k.numprod,g.idenfi,g.nombre,'Planta Merida' as area, sum(a.kilogramos) as kilogramos,l.idmuestra " +
                           "from im_mietam a left outer join im_mieltrans b on b.idmieltran=a.idmieltran " +
                           "left outer join locenfis c on c.idenfi=b.iddelegado left outer join areasb d on d.idtipdir=b.idareab and d.idenfi=b.iddelegado " +
                           "left outer join locenfis g on g.idenfi=a.idapicultor left outer join im_prods k on k.idprod=a.idprod " +
                           "left outer join im_muestra l on l.idmieltran=a.idmieltran and l.idbarril=a.idbarril " +
                           "where b.idareab  <> 1 and a.idbarril > 45 and a.idprod=" + idprod +
                           "  group by b.fecha,k.numprod,g.idenfi,g.nombre,d.area, l.idmuestra " +
                           "order by b.fecha,d.area;";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

       

        public DataTable ObtenLoteDetalleHistSalida(string idprod)
        {
            string query = "select sum(a.kilogramos) as KgsLote,max(b.fecha) as fecha ,max(b.numprod) as numprod, a.idapicultor, c.nombre " +
                           "from im_mietam as a " +
                           "inner join im_prods as b " +
                           "inner join locenfis as c on c.idenfi=a.idapicultor on a.idprod=b.idprod " +
                           "where b.idprod=" + idprod + " and a.idapicultor > 0 and a.idbarril > 45 " +
                           " group by a.idapicultor,c.nombre; ";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }
    
    }
}
