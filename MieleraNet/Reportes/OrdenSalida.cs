using System;
using MieleraNet.DAL;
using DevExpress.XtraReports.Parameters;
using MieleraNet.Web;

namespace MieleraNet.Reportes
{
    public partial class OrdenSalida : DevExpress.XtraReports.UI.XtraReport
    {
        public OrdenSalida()
        {
            InitializeComponent();
            using (applicationConfig appConfig = new applicationConfig())
            {
                xrLabelEmpresa.Text = appConfig.getEmpresa();
            }


        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            OrdenSalidaDS dsOrdenSalda = new OrdenSalidaDS();
            gridOrdenSalida.DataSource = dsOrdenSalda.getOrdenSalida(Parameters["paramContrato"].Value.ToString());
            //Arturo inicia: aquí configuramos los  parámetros del reporte


            //Arturo fin


        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabelOrigen.Text  = (string)Parameters["paramOrigen"].Value;
            xrLabelFecha.Text   = Parameters["paramFecha"].Value.ToString();
            xrLabelDestino.Text = Parameters["paramDestino"].Value.ToString();
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabelOperador.Text = Parameters["paramOperador"].Value.ToString();
            xrLabelFletera.Text  = Parameters["paramFletera"].Value.ToString();
        }
    }
    
}
