using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet.Reportes
{
    public partial class repTrazaEntSagarpa : DevExpress.XtraReports.UI.XtraReport
    {
        public repTrazaEntSagarpa()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PerifericaDS periferica = new PerifericaDS();
            //gridTrazEnt.DataSource = periferica.ObtenLoteDetalleHist(this.paramIDProd.Value.ToString());
            if ((bool)this.paramEsDetallado.Value)
                gridTrazEnt.DataSource = periferica.ObtenLoteDetalleHist(this.paramIDProd.Value.ToString());
            else
                gridTrazEnt.DataSource = periferica.ObtenLoteDetalleHistIntegradora(this.paramIDProd.Value.ToString());
            if ((bool)this.paramConNombre.Value)
                colNombre.Visible = true;
            else
                colNombre.Visible = false;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if ((bool)this.paramEsDetallado.Value)
            {
                if (e.Column.FieldName == "colIdApic" && e.IsGetData)
                {
                    CentralDS central = new CentralDS();
                    string val = gridView1.GetRowCellValue(e.ListSourceRowIndex, "IDENFI").ToString();
                    DataTable apicDT = central.ObtenIdApicultor(val);
                    if (apicDT.Rows.Count > 0)
                    {
                        e.Value = apicDT.Rows[0][0].ToString();
                    }
                }
                
            }
            else
            {
                e.Value = "31-15733-E";
            }
        }

        private void repTrazaEntSagarpa_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if ((bool)this.paramEsDetallado.Value)
            {
                imgLogo.ImageUrl = "/Mielera/Images/gabriela.jpg";
                lbRazonSocial.Text = "MIEL GABRIELA S.A. DE C.V.";
                lbDirecFis.Text = "ANILLO PERIFERICO KM 7.8 ENTRE CALLE 60 Y 50 KANASIN, YUC.";
                lbresp.Text = "David Eduardo Arceo Cardeña";
                tableDetalle.Visible = true;
                tableConcentrado.Visible = false;
            }
            else
            {
                imgLogo.ImageUrl = "/Mielera/Images/integradora.jpg";
                lbRazonSocial.Text = "MIEL INTEGRADORA S.A. DE C.V.";
                lbDirecFis.Text = "ANILLO PERIFERICO KM 7.8 TABLAJE 15740 ENTRE CALLE 50 Y 60.";
                lbresp.Text = "David Eduardo Arceo Cardeña";
                tableDetalle.SendToBack();
                tableConcentrado.Visible = true;
                tableDetalle.Visible = false;

            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "NUMPROD")
            {
                string strLote = e.DisplayText;
                if (strLote.StartsWith("PL"))
                {
                    e.DisplayText = strLote.Substring(2);
                }
            }

        }

    }
}
