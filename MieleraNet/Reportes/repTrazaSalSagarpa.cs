using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet.Reportes
{
    public partial class repTrazaSalSagarpa : DevExpress.XtraReports.UI.XtraReport
    {
        public repTrazaSalSagarpa()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            TrazaSalidaSagarpaDS.TrazSalidaDataTable dt = new TrazaSalidaSagarpaDS.TrazSalidaDataTable();
            TrazaSalidaSagarpaDS.TrazSalidaRow rowTS = (TrazaSalidaSagarpaDS.TrazSalidaRow)dt.NewRow();
            
            /*rowTS.Fecha = DateTime.Now.AddDays(4);
            rowTS.Homogenizado = "n";
            rowTS.Kg = 300;
            dt.Rows.Add(rowTS);*/

            

             //KgsLote,fecha,numprod, idapicultor, nombre 
            PerifericaDS periferica = new PerifericaDS();
            DataTable dtDetalle = periferica.ObtenLoteDetalleHistSalida(this.paramIDProd.Value.ToString());
            dt.BeginInit();
            Double TotalKg = 0;
            for (int i = 0; i < dtDetalle.Rows.Count; i++)
            {
                DataRow r = dtDetalle.Rows[i];
                rowTS = (TrazaSalidaSagarpaDS.TrazSalidaRow)dt.NewRow();

                if (i == 0)
                {
                    //Solo en la primera fila
                    rowTS.Fecha = (DateTime)r[1];
                    rowTS.Homogenizado = "SI";
                    rowTS.Lote = r[2].ToString();
                    rowTS.FechaSalida = DateTime.Now;
                    rowTS.Destino = "MIEL INTEGRADORA";
                    rowTS.FechaSalida = (DateTime)this.paramFechaSalida.Value;
                    rowTS.ExportKg = (double)this.paramExportKg.Value;
                }

                rowTS.VolumenKg = (double)r[0]; //KgsLote;
                TotalKg = (double)r[0] + TotalKg;
                
                if ((bool)this.paramEsDetallado.Value)
                {
                    rowTS.idApicultor = r[3].ToString();
                    rowTS.IDENFI = r[3].ToString();
                    dt.Rows.Add(rowTS);
                }
                else
                {
                    if (i == 0)
                    {
                        rowTS.idApicultor = r[3].ToString();
                        rowTS.IDENFI = r[3].ToString();
                        dt.Rows.Add(rowTS);
                    }
                }
            }

            if (dtDetalle.Rows.Count > 0)
            {
                //Solo en la primera fila
                dt.Rows[0][3] = TotalKg;
                if ((bool)this.paramEsDetallado.Value)
                {
                    if (dtDetalle.Rows.Count > 1)
                        dt.Rows[1][7] = "MEXICO";
                }
                else
                {
                    dt.Rows[0][7] = this.paramDestino.Value;
                    dt.Rows[0][5] = TotalKg;
                }
                dt.EndInit();

                dt.AcceptChanges();
            }

            gridTrazSal.DataSource = dt;
            //gridTrazSal.Refresh();
            //if ((bool)this.paramConNombre.Value)
            //    colVolumen.Visible = true;
            //else
            //    colVolumen.Visible = false;
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
            }else
                e.Value = "31-15733-E";
        }

        private void repTrazaSalSagarpa_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if ((bool)this.paramEsDetallado.Value)
            {
                imgLogo.ImageUrl = "/Mielera/Images/gabriela.jpg";
                lbRazonSocial.Text = "MIEL GABRIELA S.A. DE C.V.";
                lbDirecFis.Text = "ANILLO PERIFERICO KM 7.8 ENTRE CALLE 60 Y 50 KANASIN, YUC.";
                lbresp.Text = "Javier Jesús Cordova Y Can";
                tableDetalle.Visible = true;
                tableConcentrado.Visible = false;
            }
            else
            {
                imgLogo.ImageUrl = "/Mielera/Images/integradora.jpg";
                lbRazonSocial.Text = "MIEL INTEGRADORA S.A. DE C.V.";
                lbDirecFis.Text = "ANILLO PERIFERICO KM 7.8 TABLAJE 15740 ENTRE CALLE 50 Y 60.";
                lbresp.Text = "Javier Jesús Cordova Y Can";
                tableDetalle.SendToBack();
                tableConcentrado.Visible = true;
                tableDetalle.Visible = false;

            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Lote")
            {
                string strLote = e.DisplayText;
                if (strLote.StartsWith("PL"))
                {
                    e.DisplayText = strLote.Substring(2);
                }
            }
        }

        /*private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
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
        }*/

        

    }
}
