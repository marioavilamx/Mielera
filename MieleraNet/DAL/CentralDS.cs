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
    public class CentralDS
    {
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        private FbConnection fbConnection1;
        private applicationConfig objAppConfig;
        internal const string ApicultoresKey = "Cache_ApicultoresKey";
        internal const string NombresKey = "Cache_NombresKey";
        internal const string ApellidosKey = "Cache_ApellidosKey";
        internal const string ClientesKey = "Cache_ClientesKey";
        public CentralDS()
        {
            objAppConfig = new applicationConfig();
            if (objAppConfig.esDemo())
                objAppConfig.configConnDemo(cs);
            else
                objAppConfig.configConnCentral(cs);
            this.fbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            fbConnection1.ConnectionString = cs.ToString();
        }

        public DataTable ObtenNombres()
        {
            string query = "SELECT * FROM NOMBRES";
            FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
            DataTable fdt = new DataTable();
            da.Fill(fdt);
            return fdt;
        }

        public DataTable ObtenNombresCache()
        {
            string query = "SELECT * FROM NOMBRES";

            DateTime expiration = DateTime.Now.AddMinutes(10);
            DataTable Nombres = HttpContext.Current.Cache[NombresKey] as DataTable;
            if (Nombres == null)
            {
                FbDataAdapter da = new FbDataAdapter(query, fbConnection1);
                Nombres = new DataTable();
                da.Fill(Nombres);

                HttpContext.Current.Cache.Add(NombresKey, Nombres, null, expiration, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            }

            return Nombres;
        }

        /// <summary>
        /// Esta funcion nos devuelve las empreas en las cuales se puede accesar desde la web
        /// </summary>
        /// <returns>Retorna la lista de las empresas web</returns>
        public DataTable ObtenEmpresas()
        {
            string query = "SELECT * FROM IM_WEB_EMPRESAS";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion nos devuelve la información de la empresa en base al idempresa enviado
        /// </summary>
        /// <returns>Retorna la información de la empresa deseada</returns>
        public DataTable ObtenEmpresasPorID(string idEmpresa)
        {
            string query = "SELECT * FROM IM_WEB_EMPRESAS WHERE IDEMPRESA=" + idEmpresa;
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion nos devuelve las empreas en las cuales se puede accesar desde la web
        /// </summary>
        /// <returns>Retorna la lista de las empresas web</returns>
        public void ObtenEmpresa(int idenfimo)
        {
            this.fbConnection1.Open();
            FbCommand cmdemp = new FbCommand("SELECT * FROM IM_WEB_EMPRESAS WHERE IDEMPRESA=@IDEMP", this.fbConnection1);
            cmdemp.Parameters.Add("@IDEMP", FbDbType.Integer).Value = idenfimo;
            FbDataReader reader = cmdemp.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    //TODO:arturo
                    objAppConfig.setPeriferica((string)reader.GetValue(2), (string)reader.GetValue(3), (string)reader.GetValue(4), (string)reader.GetValue(5), reader.GetValue(6).ToString());
                    
                }
            }
            finally
            {
                // always call Close when done reading.
                reader.Close();
                this.fbConnection1.Close();
            }
        }

        public DataTable ObtenApellidos()
        {
            string query = "SELECT * FROM APELLIDOS";
            return LlenaTabla(query);
        }

        public DataTable ObtenApellidosCache()
        {
            string query = "SELECT * FROM APELLIDOS";
            
            DateTime expiration = DateTime.Now.AddMinutes(10);
            DataTable Apellidos = HttpContext.Current.Cache[ApellidosKey] as DataTable;
            if (Apellidos == null)
            {
                Apellidos = LlenaTabla(query);
                HttpContext.Current.Cache.Add(ApellidosKey, Apellidos, null, expiration, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            }

            return Apellidos;
        }

        public DataTable ObtenPais()
        {
            string query = "SELECT * FROM paises";
            return LlenaTabla(query);
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
        /// Esta funcion devuleve los centros de acopio
        /// </summary>
        /// <returns>Retorna los centros de acopio</returns>
        public DataTable ObtenCentroAcopio()
        {
            string query = "SELECT * FROM locenfis";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve los centros de acopio
        /// </summary>
        /// <returns>Retorna los centros de acopio</returns>
        public DataTable ObtenApicultoresPorDelegado(string delegado)
        {
            string query = "SELECT l.idenfi,r.idenfimo2 idenfi2,a.nombre FROM LOCENFIS l " +
                            "inner join relents r on r.idenfimo = l.idenfi " +
                            "inner join locenfis a on r.idenfimo2 = a.idenfi " +
                            "where l.idenfi = " + delegado + " and r.idrelac = 26 " +
                            "order by 3 ";

            DateTime expiration = DateTime.Now.AddMinutes(1);
            DataTable Apicultores = null;// = HttpContext.Current.Cache[ApicultoresKey] as DataTable;
            if (Apicultores == null)
            {
                Apicultores = LlenaTabla(query);
                HttpContext.Current.Cache.Add(ApicultoresKey, Apicultores, null, expiration, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            }

            return Apicultores;
        }
        

        /// <summary>
        /// Esta funcion devuleve los estados
        /// </summary>
        /// <returns>Retorna los estados</returns>
        public DataTable ObtenEstados()
        {
            string query = "SELECT * FROM edopros";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve las Ciudades
        /// </summary>
        /// <returns>Retorna las ciudades</returns>
        public DataTable ObtenCiudades()
        {
            string query = "SELECT * FROM ciuds";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve las relaciones
        /// </summary>
        /// <returns>Retorna el nombre de la relación que se tiene con el centro de acopio </returns>
        public DataTable ObtenRelaciones()
        {
            string query = "select idrelac,relac from relacs";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve las ocupaciones
        /// </summary>
        /// <returns>Retorna las ocupaciones de las entidades </returns>
        public DataTable ObtenOcupaciones()
        {
            string query = "select * from ocups";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve las termanaciones legales de las empresas (Ej. SA de CV)
        /// </summary>
        /// <returns>Retorna las termanaciones legales </returns>
        public DataTable ObtenTermLegales()
        {
            string query = "select * from sufis";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve los giros de las empresas
        /// </summary>
        /// <returns>Retorna los giros </returns>
        public DataTable ObtenGiros()
        {
            string query = "select * from giros";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve los Municipios
        /// </summary>
        /// <returns>Retorna los giros </returns>
        public DataTable ObtenMunicipios()
        {
            string query = "select * from munips";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve los Codigos Postales
        /// </summary>
        /// <returns>Retorna los giros </returns>
        public DataTable ObtenCodPos()
        {
            string query = "select * from codpos";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve las colonias
        /// </summary>
        /// <returns>Retorna las colonias </returns>
        public DataTable ObtenColonias()
        {
            string query = "select * from colonias";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve los tipos de direcciones
        /// </summary>
        /// <returns>Retorna los tipos de direcciones</returns>
        public DataTable ObtenTipoDir()
        {
            string query = "select * from tipdirs";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve las corporaciones
        /// </summary>
        /// <returns>Retorna las corporaciones</returns>
        public DataTable ObtenCorps()
        {
            string query = "select * from corps order by corp";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve las calles registradas en el sistema
        /// </summary>
        /// <returns>Retorna las calles</returns>
        public DataTable ObtenCalles()
        {
            string query = "select * from calles order by calle";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve las Numeros Interiores de las direcciones
        /// </summary>
        /// <returns>Retorna las numeros interiores</returns>
        public DataTable ObtenNumInt()
        {
            string query = "select * from numins order by numin";
            return LlenaTabla(query);
        }

        /// <summary>
        /// Esta funcion devuleve las Numeros Exteriores de las direcciones
        /// </summary>
        /// <returns>Retorna las numeros exteriores</returns>
        public DataTable ObtenNumExt()
        {
            string query = "select * from numexs order by numex";
            return LlenaTabla(query);
        }

        public DataTable ObtenIdApicultor(string idApic)
        {
            string query = "select a.doc from reldocs as a inner join enfimos as b on a.idenfimo=b.idenfimo " +
                            "where a.idtipdoc=9 and b.idenfimo=" + idApic;
            return LlenaTabla(query);
        }

        public DataTable ObtenDatosCliente()
        {
            /*string query = "select a.idenfimo,f.iddir," +
                            "       a.nombre," +
                            "       case f.iddirclase" +
                            "       when 1 then 'Calle '||fa.calle||' Núm '||fi.numex||case when fj.idnumin>0 then ' ' else '' end||fj.numin||case when fb.idcalle>0 and fc.idcalle>0 then ' entre '||fb.calle||' y '||fc.calle else case when fb.idcalle>0 then ' por '||fb.calle else '' end end" +
                            "       when 2 then fa.calle||' '||fi.numex||' '||fj.numin||' '||fb.calle||' '||fc.calle" +
                            "       when 3 then fa.calle||' Núm '||fi.numex||case when fj.idnumin>0 then ' ' else '' end||fj.numin||case when fb.idcalle>0 and fc.idcalle>0 then ' entre '||fb.calle||' y '||fc.calle else case when fb.idcalle>0 then ' por '||fb.calle else '' end end" +
                            "       end as dir1," +
                            "       fe.ciudad||' '||fg.edopro||' '||fd.pais as dir3," +
                            "       (select stelefs from teldedir(f.iddir))," +
                            "       (select stelefs from teldeper(a.idenfimo))," +
                            "       ff.colonia||' CP '||fh.codpo as dir2," +
                            "       f.idedopro," +
                            "       b.tipdir " +
                            "from venfimos a " +
                            "left outer join relendis d on d.idenfimo=a.idenfimo " +
                            "left outer join tipdirs b on b.idtipdir=d.idtipdir " +
                            "left outer join dirs f on f.iddir=d.iddir " +
                            "left outer join calles fa on fa.idcalle=f.idcallef " +
                            "left outer join calles fb on fb.idcalle=f.idcallei " +
                            "left outer join calles fc on fc.idcalle=f.idcalled " +
                            "left outer join paises fd on fd.idpais=f.idpais " +
                            "left outer join ciuds fe on fe.idciud=f.idciud " +
                            "left outer join colonias ff on ff.idcolonia=f.idcolonia " +
                            "left outer join edopros fg on fg.idedopro=f.idedopro " +
                            "left outer join codpos fh on fh.idcodpo=f.idcodpo " +
                            "left outer join numexs fi on fi.idnumex=f.idnumex " +
                            "left outer join numins fj on fj.idnumin=f.idnumin " +
                            "where b.tipdir = 'fiscal'";*/
            string query = "select a.idenfimo, a.nombre from enfimos a " +
                            "left outer join relendis d on d.idenfimo=a.idenfimo " +
                            "left outer join tipdirs b on b.idtipdir=d.idtipdir " +
                            "where b.tipdir = 'fiscal' ";

            DateTime expiration = DateTime.Now.AddMinutes(10);
            DataTable Clientes = HttpContext.Current.Cache[ClientesKey] as DataTable;
            if (Clientes == null)
            {
                Clientes = LlenaTabla(query);
                HttpContext.Current.Cache.Add(ClientesKey, Clientes, null, expiration, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            }

            return Clientes;
            //return LlenaTabla(query);
        }

        public DataTable ObtenDatosCliente(int idcliente)
        {
            string query = "select a.idenfimo,f.iddir," +
                            "       a.nombre," +
                            "       case f.iddirclase" +
                            "       when 1 then 'Calle '||fa.calle||' Núm '||fi.numex||case when fj.idnumin>0 then ' ' else '' end||fj.numin||case when fb.idcalle>0 and fc.idcalle>0 then ' entre '||fb.calle||' y '||fc.calle else case when fb.idcalle>0 then ' por '||fb.calle else '' end end" +
                            "       when 2 then fa.calle||' '||fi.numex||' '||fj.numin||' '||fb.calle||' '||fc.calle" +
                            "       when 3 then fa.calle||' Núm '||fi.numex||case when fj.idnumin>0 then ' ' else '' end||fj.numin||case when fb.idcalle>0 and fc.idcalle>0 then ' entre '||fb.calle||' y '||fc.calle else case when fb.idcalle>0 then ' por '||fb.calle else '' end end" +
                            "       end as dir1," +
                            "       fe.ciudad||' '||fg.edopro||' '||fd.pais as dir3," +
                            "       (select stelefs from teldedir(f.iddir)) as Tel1," +
                            "       (select stelefs from teldeper(a.idenfimo)) as Tel2," +
                            "       ff.colonia||' CP '||fh.codpo as dir2," +
                            "       f.idedopro," +
                            "       b.tipdir " +
                            "from venfimos a " +
                            "left outer join relendis d on d.idenfimo=a.idenfimo " +
                            "left outer join tipdirs b on b.idtipdir=d.idtipdir " +
                            "left outer join dirs f on f.iddir=d.iddir " +
                            "left outer join calles fa on fa.idcalle=f.idcallef " +
                            "left outer join calles fb on fb.idcalle=f.idcallei " +
                            "left outer join calles fc on fc.idcalle=f.idcalled " +
                            "left outer join paises fd on fd.idpais=f.idpais " +
                            "left outer join ciuds fe on fe.idciud=f.idciud " +
                            "left outer join colonias ff on ff.idcolonia=f.idcolonia " +
                            "left outer join edopros fg on fg.idedopro=f.idedopro " +
                            "left outer join codpos fh on fh.idcodpo=f.idcodpo " +
                            "left outer join numexs fi on fi.idnumex=f.idnumex " +
                            "left outer join numins fj on fj.idnumin=f.idnumin " +
                            "where b.tipdir = 'fiscal' and a.idenfimo = " + idcliente;
            return LlenaTabla(query);
        }

        
    }
}
