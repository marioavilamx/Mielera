using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet.Reportes
{
    public partial class repCertificado : DevExpress.XtraReports.UI.XtraReport
    {
        public repCertificado()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            

            ExportDS ext = new ExportDS();
            DataTable dtFQ = ext.ObtenCertificadoParaReporte((int)this.paramNumProd.Value);
            if (dtFQ.Rows.Count > 0)
            {
                int IDCERTIFICADO = (int)dtFQ.Rows[0]["IDCERTIFICADO"];
                //lbTitulo.Text = dtFQ.Rows[0]["LABORATORIO"].ToString();
                //lbDirec.Text = dtFQ.Rows[0]["DIRECCION"].ToString();
                //lbTelefono.Text = dtFQ.Rows[0]["TELEFONO"].ToString();
                //lbRFC.Text = dtFQ.Rows[0]["RFC"].ToString();
                lbNoRep.Text = dtFQ.Rows[0]["FOLIO"].ToString();
                DateTime fecha = (DateTime)dtFQ.Rows[0]["FECHA"];
                lbFecha.Text = fecha.ToString("dd/MM/yyyy"); 
                //lbFax.Text = dtFQ.Rows[0]["FECHA"].ToString(); 

                lbContainer.Text = dtFQ.Rows[0]["CONTAINER"].ToString();
                lbInvoice.Text = dtFQ.Rows[0]["INVOICE"].ToString();
                lbContrac.Text = dtFQ.Rows[0]["CONTRAC"].ToString();
                lbProduct.Text = dtFQ.Rows[0]["PRODUCT"].ToString();
                lbLote.Text = dtFQ.Rows[0]["OURREFERENCE"].ToString();
                lbLoteCli.Text = dtFQ.Rows[0]["DESCRIPTION"].ToString();
                lbTemperatura.Text = dtFQ.Rows[0]["TEMPERATURA"].ToString();
                lbPacking.Text = dtFQ.Rows[0]["PACKING"].ToString();
                DateTime fIni = (DateTime)dtFQ.Rows[0]["FECHAINICERTI"];
                DateTime fFin = (DateTime)dtFQ.Rows[0]["FECHAFINCERTI"];
                lbFechas.Text = fIni.ToString("dd/MM/yy") + " // " + fFin.ToString("dd/MM/yy");
                lbElaboro.Text = ext.ObtenNombreByIdenfi((int)dtFQ.Rows[0]["IDELABORO"]);

                gridFQDet.DataSource = ext.ObtenCertificadoByIdCertificado(IDCERTIFICADO);

                //Datos del cliente
                CentralDS cent = new CentralDS();
                DataTable dtDatosCli = cent.ObtenDatosCliente((int)dtFQ.Rows[0]["IDCLIENTE"]);
                lbCliente.Text = dtDatosCli.Rows[0]["NOMBRE"].ToString();
                lbDireccion.Text = dtDatosCli.Rows[0]["DIR1"].ToString();
                lbLugar.Text = dtDatosCli.Rows[0]["DIR3"].ToString();
                lbTel.Text = dtDatosCli.Rows[0]["TEL1"].ToString();
            }
        }

        private void repCertificado_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //imgLogoIntegradora.ImageUrl = "/Images/Logo_Cert.jpg";
        }

    }
}
