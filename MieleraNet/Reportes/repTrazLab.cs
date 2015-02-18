using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet.Reportes
{
    public partial class repTrazLab : DevExpress.XtraReports.UI.XtraReport
    {
        public repTrazLab()
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
            ExportDS export = new ExportDS();
            DataTable dtAnalysisRep = export.ObtenReporteAnalisisByNumProd(this.paramIDProd.Value.ToString());
            int numPart;
            if (dtDetalle.Rows.Count > dtAnalysisRep.Rows.Count)
                numPart = dtDetalle.Rows.Count;
            else
                numPart = dtAnalysisRep.Rows.Count;

            dt.BeginInit();
            Double TotalKg = 0;
            for (int i = 0; i < numPart; i++)
            {
                DataRow rAnalysis = null;
                DataRow r = null; ;
                if (i < dtAnalysisRep.Rows.Count)
                    rAnalysis = dtAnalysisRep.Rows[i];
                if (i < dtDetalle.Rows.Count)
                    r = dtDetalle.Rows[i];
                rowTS = (TrazaSalidaSagarpaDS.TrazSalidaRow)dt.NewRow();

                if (i == 0)
                {
                    //Solo en la primera fila
                    if (r != null)
                    {
                        rowTS.Fecha = (DateTime)r[1];
                        rowTS.Lote = r[2].ToString();
                    }
                    if (rAnalysis != null)
                    rowTS.Destino = "INTERTEK FOOD SERVICE";
                }

                if (r != null)
                {
                    rowTS.VolumenKg = (double)r[0]; //KgsLote;
                    TotalKg = (double)r[0] + TotalKg;
                    
                    if ((bool)this.paramEsDetallado.Value)
                    {
                        rowTS.idApicultor = r[3].ToString();
                        rowTS.IDENFI = r[3].ToString();
                        //dt.Rows.Add(rowTS);
                    }
                }

                if (rAnalysis != null)
                {
                    rowTS.Fecha = (DateTime)rAnalysis[2];
                    rowTS.FechaSalida = (DateTime)rAnalysis["Fecha"];
                    rowTS.Homogenizado = rAnalysis["Folio"].ToString();
                }
                dt.Rows.Add(rowTS);
            }

            gridTrazSal.DataSource = dt;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if ((bool)this.paramEsDetallado.Value)
            {
                if (e.Column.FieldName == "colIdApic" && e.IsGetData)
                {
                    CentralDS central = new CentralDS();
                    string val = gridView1.GetRowCellValue(e.ListSourceRowIndex, "IDENFI").ToString();
                    if (val != "")
                    {
                        DataTable apicDT = central.ObtenIdApicultor(val);
                        if (apicDT.Rows.Count > 0)
                        {
                            e.Value = apicDT.Rows[0][0].ToString();
                        }
                    }
                }
            }else
                e.Value = "31-15733-E";
        }

        private void repTrazaSalSagarpa_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if ((bool)this.paramEsDetallado.Value)
            {
                //imgLogo.ImageUrl = "/Mielera/Images/gabriela.jpg";
                lbRazonSocial.Text = "MIEL GABRIELA S.A. DE C.V.";
                lbDirecFis.Text = "ANILLO PERIFERICO KM 7.8 ENTRE CALLE 60 Y 50 KANASIN, YUC.";
                lbresp.Text = "QBB ELENA BEATRIZ QUINTAL SALAZAR";
                tableDetalle.Visible = true;
                tableConcentrado.Visible = false;
            }
            else
            {
                //imgLogo.ImageUrl = "/Mielera/Images/integradora.jpg";
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
