using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet.Reportes
{
    public partial class repFisicoQuimico : DevExpress.XtraReports.UI.XtraReport
    {
        public repFisicoQuimico()
        {
            InitializeComponent();
        }

        public static string GetSiteRootUrl()
        {
            string protocol;

            if (System.Web.HttpContext.Current.Request.IsSecureConnection)
                protocol = "https";
            else
                protocol = "http";

            System.Text.StringBuilder uri = new System.Text.StringBuilder(protocol + "://");

            string hostname = System.Web.HttpContext.Current.Request.Url.Host;
            


            uri.Append(hostname);

            int port = System.Web.HttpContext.Current.Request.Url.Port;

            if (port != 80 && port != 443)
            {
                uri.Append(":");
                uri.Append(port.ToString());
            }

            return uri.ToString();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ExportDS ext = new ExportDS();
            DataTable dtFQ = ext.ObtenFisicoQuimicoParaReporte((int)this.paramNumProd.Value);
            if (dtFQ.Rows.Count > 0)
            {
                int idReporte = (int)dtFQ.Rows[0]["IDREPORTE"];
                lbEmpresa.Text = dtFQ.Rows[0]["LABORATORIO"].ToString();
                lbDirec.Text = dtFQ.Rows[0]["DIRECCION"].ToString();
                lbTelefono.Text = dtFQ.Rows[0]["TELEFONO"].ToString();
                lbRFC.Text = dtFQ.Rows[0]["RFC"].ToString();
                lbNoRep.Text = dtFQ.Rows[0]["NUMREPORTE"].ToString();
                DateTime fecha = (DateTime)dtFQ.Rows[0]["FECHA"];
                lbFecha.Text = fecha.ToString("dd/MM/yy"); 
                //lbFax.Text = dtFQ.Rows[0]["FECHA"].ToString(); 


                imgLogo.ImageUrl = GetSiteRootUrl() + dtFQ.Rows[0]["LOGO"].ToString();

                //lbFactura.Text = dtFQ.Rows[0]["FACTURA"].ToString();
                lbFactura.Text = System.Web.HttpContext.Current.Request.Url.Fragment;
                //lbProducto.Text = dtFQ.Rows[0]["PRODUCTO"].ToString();
                lbProducto.Text = dtFQ.Rows[0]["LOGO"].ToString();
                lbLote.Text = dtFQ.Rows[0]["DESCRIMUESTRA"].ToString();
                lbTemperatura.Text = dtFQ.Rows[0]["TEMPERATURA"].ToString();
                lbEmpaquetado.Text = dtFQ.Rows[0]["EMPAQUETADO"].ToString();
                DateTime fIni = (DateTime)dtFQ.Rows[0]["FECHAINIREP"];
                DateTime fFin = (DateTime)dtFQ.Rows[0]["FECHAFINREP"];
                lbFechas.Text = fIni.ToString("dd/MM/yy") + " // " + fFin.ToString("dd/MM/yy");
                lbElaboro.Text = "IBQ. " + ext.ObtenNombreByIdenfi((int)dtFQ.Rows[0]["ELABORO"]);
                
                gridFQDet.DataSource = ext.ObtenFisicoQuimicoByIdReporte(idReporte);
            }
        }

    }
}
