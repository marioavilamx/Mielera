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
    public class EntidadesDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;

        public EntidadesDS()
        {
            applicationConfig objAppConfig = new applicationConfig();
            if (objAppConfig.esDemo())

                objAppConfig.configConnDemo(cs);
            else
                objAppConfig.configConnCentral(cs);
             this.fbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            fbConnection1.ConnectionString = cs.ToString();


        }

        public void CreaRelacionDelegadoApicultor(int delegado, int apicultor)
        {
            ///Relaciones
            FbCommand cmdRelaciones = new FbCommand("CREARELENTS", fbConnection1);
            cmdRelaciones.CommandType = CommandType.StoredProcedure;
            cmdRelaciones.Parameters.Add("IDENFIMO1", delegado);
            cmdRelaciones.Parameters.Add("IDENFIMO2", apicultor);
            cmdRelaciones.Parameters.Add("IDRELAC", 26); //13/Febrero/2012 Se cambio de 30 a 26 
            fbConnection1.Open();
            try
            {
                cmdRelaciones.ExecuteNonQuery();
            }
            catch
            {
                fbConnection1.Close();
                throw;
            }
        }

        public int AltaPersonaFisica(string pais, string edopro, string ciudad, char sexo, DateTime fechini, 
                                      string ape1, string ape2, string nom1, string nom2, string prefi,
                                      int idenfimo1, int idrelac, string telefono, string mail, string ocup, string obs)
        {
            int idenfimo2 = -1;
            FbTransaction transaction;
            FbCommand command = new FbCommand("CREA_PEFI", fbConnection1);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("pais", pais);
            command.Parameters.Add("edopro", edopro);
            command.Parameters.Add("ciudad", ciudad);
            command.Parameters.Add("sexo", sexo);
            command.Parameters.Add("fechini", fechini);
            command.Parameters.Add("ape1", ape1);
            command.Parameters.Add("ape2", ape2);
            command.Parameters.Add("nom1", nom1);
            command.Parameters.Add("nom2", nom2);
            command.Parameters.Add("prefi", prefi);
            /*FbCommand command = new FbCommand("PAIS_CREA", fbConnection1);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("pais", "Mario");*/
            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                idenfimo2 = (int)command.ExecuteScalar();
                
                ///Relaciones
                FbCommand cmdRelaciones = new FbCommand("CREARELENTS", fbConnection1);
                //transaction = fbConnection1.BeginTransaction();
                cmdRelaciones.Transaction = transaction;
                cmdRelaciones.CommandType = CommandType.StoredProcedure;
                cmdRelaciones.Parameters.Add("IDENFIMO1", idenfimo1);
                cmdRelaciones.Parameters.Add("IDENFIMO2", idenfimo2);
                cmdRelaciones.Parameters.Add("IDRELAC", idrelac);
                cmdRelaciones.ExecuteScalar();

                //Alta de telefono
                if (telefono.Length > 2)
                {
                    FbCommand cmdTel = new FbCommand("ALTA_TELENT", fbConnection1);
                    cmdTel.Transaction = transaction;
                    cmdTel.CommandType = CommandType.StoredProcedure;
                    cmdTel.Parameters.Add("telnue", telefono);
                    cmdTel.Parameters.Add("idenfi", idenfimo2);
                    cmdTel.ExecuteNonQuery();
                }

                //Alta del correo electronico
                if (mail.Length > 2)
                {
                    int posarroba = mail.IndexOf('@');
                    string emailnom = mail.Substring(0, posarroba);
                    string dominio = mail.Substring(posarroba + 1, mail.Length - posarroba - 1);
                    FbCommand cmdEmail = new FbCommand("CREA_EMAIL", fbConnection1);
                    cmdEmail.Transaction = transaction;
                    cmdEmail.CommandType = CommandType.StoredProcedure;
                    cmdEmail.Parameters.Add("emailnom", emailnom);
                    cmdEmail.Parameters.Add("dominio", dominio);
                    cmdEmail.Parameters.Add("idenfi", idenfimo2);
                    cmdEmail.ExecuteNonQuery();
                }

                //Alta de la ocupacion
                if (ocup.Length > 2)
                {
                    FbCommand cmdOcup = new FbCommand("AGRE_OCUP", fbConnection1);
                    cmdOcup.Transaction = transaction;
                    cmdOcup.CommandType = CommandType.StoredProcedure;
                    cmdOcup.Parameters.Add("idenfi", idenfimo2);
                    cmdOcup.Parameters.Add("ocup", ocup);
                    cmdOcup.ExecuteNonQuery();
                }

                //Alta de las observaciones
                if (obs.Length > 2)
                {
                    FbCommand cmdobs = new FbCommand("Update enfimos set obsers=@obsers where idenfimo=@idenfimo", fbConnection1);
                    cmdobs.Transaction = transaction;
                    cmdobs.Parameters.Add("@obsers", FbDbType.Text).Value = System.Text.Encoding.UTF8.GetBytes(obs);
                    cmdobs.Parameters.Add("@idenfimo", FbDbType.Integer).Value = idenfimo2;
                    cmdobs.ExecuteNonQuery();
                }
                transaction.Commit();
                //Sincronizamos la entidad con la bd periferica, grabamos en locenfis
                string nombre = ape1 + " " + ape2 + " " + nom1 + " " + nom2;
                PerifericaDS periferica = new PerifericaDS();
                periferica.SincornizaEntidad(idenfimo2, nombre);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();
            return idenfimo2;
        }


        public int AltaPersonaMoral(string pais, string edopro, string ciudad, DateTime fechini,
                                      string corp, string sufi, string rfc, string giro, string obs)
        {
            int idenfimo = -1;
            FbTransaction transaction;
            FbCommand command = new FbCommand("CREA_CORPR", fbConnection1);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("pais", pais);
            command.Parameters.Add("edopro", edopro);
            command.Parameters.Add("ciudad", ciudad);
            command.Parameters.Add("fechini", fechini);
            command.Parameters.Add("corp", corp);
            command.Parameters.Add("sufi", sufi);
            command.Parameters.Add("rfc", rfc);
            
            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                idenfimo = (int)command.ExecuteScalar();

                //Relacionar el giro con la entidad
                FbCommand cmdGiro = new FbCommand("AGRE_GIRO", fbConnection1);
                cmdGiro.Transaction = transaction;
                cmdGiro.CommandType = CommandType.StoredProcedure;
                cmdGiro.Parameters.Add("idenfi", idenfimo);
                cmdGiro.Parameters.Add("giro", giro);
                cmdGiro.ExecuteNonQuery();

                //Alta de las observaciones
                if (obs.Length > 2)
                {
                    FbCommand cmdobs = new FbCommand("Update enfimos set obsers=@obsers where idenfimo=@idenfimo", fbConnection1);
                    cmdobs.Transaction = transaction;
                    cmdobs.Parameters.Add("@obsers", FbDbType.Text).Value = System.Text.Encoding.UTF8.GetBytes(obs);
                    cmdobs.Parameters.Add("@idenfimo", FbDbType.Integer).Value = idenfimo;
                    cmdobs.ExecuteNonQuery();
                }
               transaction.Commit();
               //Sincronizamos la entidad con la bd periferica, grabamos en locenfis
               PerifericaDS periferica = new PerifericaDS();
               periferica.SincornizaEntidad(idenfimo, corp);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();
            return idenfimo;
        }

    

        public void AltaDireccion(string pais, string edopro, string munip, string ciudad, string codpo, string colonia,
                                              string callef, string callei, string called, string numex, string numin, int iddirclase, string tipdir, int idenfimo)
        {
            FbTransaction transaction;
            FbCommand command = new FbCommand("CREA_DIR", fbConnection1);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("pais", pais);
            command.Parameters.Add("edopro", edopro);
            command.Parameters.Add("munip", munip);
            command.Parameters.Add("ciudad", ciudad);
            command.Parameters.Add("codpo", codpo);
            command.Parameters.Add("colonia", colonia);
            command.Parameters.Add("callef", callef);
            command.Parameters.Add("callei", callei);
            command.Parameters.Add("called", called);
            command.Parameters.Add("numex", numex);
            command.Parameters.Add("numin", numin);
            command.Parameters.Add("iddirclase", iddirclase);

            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                int iddir1 = (int)command.ExecuteScalar();

                //Relacionar el tipo de direccion con la entidad
                FbCommand cmdRelaciones = new FbCommand("CREARELPERSODIR2", fbConnection1);
                cmdRelaciones.Transaction = transaction;
                cmdRelaciones.CommandType = CommandType.StoredProcedure;
                cmdRelaciones.Parameters.Add("idenfi", idenfimo);
                cmdRelaciones.Parameters.Add("iddir1", iddir1);
                cmdRelaciones.Parameters.Add("tipdir", tipdir);
                cmdRelaciones.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();
        }

        public int AltaApicultor(string PrimerNom)
        {
            int idenfimo2 = -1;
            /*FbTransaction transaction;
            FbCommand command = new FbCommand("CREA_PEFI", fbConnection1);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("pais", pais);
            command.Parameters.Add("edopro", edopro);
            command.Parameters.Add("ciudad", ciudad);
            command.Parameters.Add("sexo", sexo);
            command.Parameters.Add("fechini", fechini);
            command.Parameters.Add("ape1", ape1);
            command.Parameters.Add("ape2", ape2);
            command.Parameters.Add("nom1", nom1);
            command.Parameters.Add("nom2", nom2);
            command.Parameters.Add("prefi", prefi);
            fbConnection1.Open();
            transaction = fbConnection1.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                idenfimo2 = (int)command.ExecuteScalar();

                ///Relaciones
                FbCommand cmdRelaciones = new FbCommand("CREARELENTS", fbConnection1);
                //transaction = fbConnection1.BeginTransaction();
                cmdRelaciones.Transaction = transaction;
                cmdRelaciones.CommandType = CommandType.StoredProcedure;
                cmdRelaciones.Parameters.Add("IDENFIMO1", idenfimo1);
                cmdRelaciones.Parameters.Add("IDENFIMO2", idenfimo2);
                cmdRelaciones.Parameters.Add("IDRELAC", idrelac);
                cmdRelaciones.ExecuteScalar();

                
                transaction.Commit();
                string nombre = ape1 + " " + ape2 + " " + nom1 + " " + nom2;
                PerifericaDS periferica = new PerifericaDS();
                periferica.SincornizaEntidad(idenfimo2, nombre);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            fbConnection1.Close();*/
            return idenfimo2;
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
        
        public DataTable ObtenLocenfis()
        {
            string query = "SELECT * FROM LOCENFIS";
            return LlenaTabla(query);
        }

        public DataTable ObtenApicultorPorId(string IdApic)
        {
            string query = "select * from reldocs where doc = '" + IdApic + "'";
            return LlenaTabla(query);
        }
        
    }
}
