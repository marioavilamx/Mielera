namespace MieleraNet.Reportes
{
    partial class repCompraMiel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.gridCompraTambores = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTambor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPBruto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTara = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubtotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrPanel3 = new DevExpress.XtraReports.UI.XRPanel();
            this.lbApicultor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lbArea = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNotaEntrada = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.barcodeNota = new DevExpress.XtraReports.UI.XRBarCode();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.paramIdCompra = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompraTambores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer1});
            this.Detail.HeightF = 93F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(640F, 58.99998F);
            this.winControlContainer1.WinControl = this.gridCompraTambores;
            // 
            // gridCompraTambores
            // 
            this.gridCompraTambores.Location = new System.Drawing.Point(0, 0);
            this.gridCompraTambores.MainView = this.gridView1;
            this.gridCompraTambores.Name = "gridCompraTambores";
            this.gridCompraTambores.Size = new System.Drawing.Size(614, 57);
            this.gridCompraTambores.TabIndex = 0;
            this.gridCompraTambores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTambor,
            this.gcPBruto,
            this.gcTara,
            this.gcPNeto,
            this.gcPUnit,
            this.gcSubtotal});
            this.gridView1.GridControl = this.gridCompraTambores;
            this.gridView1.Name = "gridView1";
            // 
            // gcTambor
            // 
            this.gcTambor.Caption = "No. Tambor";
            this.gcTambor.FieldName = "IDTAMBOR";
            this.gcTambor.Name = "gcTambor";
            this.gcTambor.SummaryItem.DisplayFormat = "{0} TAMBOR(ES)";
            this.gcTambor.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.gcTambor.Visible = true;
            this.gcTambor.VisibleIndex = 0;
            // 
            // gcPBruto
            // 
            this.gcPBruto.Caption = "P. BRUTO";
            this.gcPBruto.DisplayFormat.FormatString = "n2";
            this.gcPBruto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPBruto.FieldName = "PBRUTO";
            this.gcPBruto.Name = "gcPBruto";
            this.gcPBruto.Visible = true;
            this.gcPBruto.VisibleIndex = 1;
            // 
            // gcTara
            // 
            this.gcTara.Caption = "TARA";
            this.gcTara.FieldName = "TARA";
            this.gcTara.Name = "gcTara";
            this.gcTara.Visible = true;
            this.gcTara.VisibleIndex = 2;
            // 
            // gcPNeto
            // 
            this.gcPNeto.Caption = "P. NETO";
            this.gcPNeto.DisplayFormat.FormatString = "n2";
            this.gcPNeto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPNeto.FieldName = "PNETO";
            this.gcPNeto.Name = "gcPNeto";
            this.gcPNeto.SummaryItem.DisplayFormat = "Total Neto: {0:n2}";
            this.gcPNeto.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gcPNeto.Visible = true;
            this.gcPNeto.VisibleIndex = 3;
            // 
            // gcPUnit
            // 
            this.gcPUnit.Caption = "PRECIO";
            this.gcPUnit.DisplayFormat.FormatString = "c";
            this.gcPUnit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPUnit.FieldName = "PRECIOUNIT";
            this.gcPUnit.Name = "gcPUnit";
            this.gcPUnit.Visible = true;
            this.gcPUnit.VisibleIndex = 4;
            // 
            // gcSubtotal
            // 
            this.gcSubtotal.Caption = "SUBTOTAL";
            this.gcSubtotal.DisplayFormat.FormatString = "c";
            this.gcSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcSubtotal.FieldName = "PAGADO";
            this.gcSubtotal.Name = "gcSubtotal";
            this.gcSubtotal.SummaryItem.DisplayFormat = "TOTAL: {0:c}";
            this.gcSubtotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gcSubtotal.Visible = true;
            this.gcSubtotal.VisibleIndex = 5;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel3,
            this.xrPanel2,
            this.xrPanel1,
            this.xrLabel1,
            this.xrLabel2});
            this.TopMargin.HeightF = 195.8333F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPanel3
            // 
            this.xrPanel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbApicultor,
            this.xrLabel3});
            this.xrPanel3.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 115.9167F);
            this.xrPanel3.Name = "xrPanel3";
            this.xrPanel3.SizeF = new System.Drawing.SizeF(332.2917F, 51.04169F);
            this.xrPanel3.StylePriority.UseBorders = false;
            // 
            // lbApicultor
            // 
            this.lbApicultor.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbApicultor.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 21.16668F);
            this.lbApicultor.Name = "lbApicultor";
            this.lbApicultor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbApicultor.SizeF = new System.Drawing.SizeF(202.0833F, 22.99998F);
            this.lbApicultor.StylePriority.UseBorders = false;
            this.lbApicultor.Text = "Jose Luis Ceme Hau";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 5.458339F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 15.70834F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.Text = "RECIBO DE:";
            // 
            // xrPanel2
            // 
            this.xrPanel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbFecha,
            this.lbArea,
            this.xrLabel8});
            this.xrPanel2.LocationFloat = new DevExpress.Utils.PointFloat(450F, 111.875F);
            this.xrPanel2.Name = "xrPanel2";
            this.xrPanel2.SizeF = new System.Drawing.SizeF(190F, 51.04169F);
            this.xrPanel2.StylePriority.UseBorders = false;
            // 
            // lbFecha
            // 
            this.lbFecha.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(52.91666F, 23.45834F);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFecha.SizeF = new System.Drawing.SizeF(81.04166F, 23F);
            this.lbFecha.StylePriority.UseBorders = false;
            this.lbFecha.Text = "28/01/2012";
            // 
            // lbArea
            // 
            this.lbArea.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbArea.LocationFloat = new DevExpress.Utils.PointFloat(3.79175F, 4.041664F);
            this.lbArea.Name = "lbArea";
            this.lbArea.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbArea.SizeF = new System.Drawing.SizeF(144.1667F, 15.70835F);
            this.lbArea.StylePriority.UseBorders = false;
            this.lbArea.Text = "Tizimin CA";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(5.79175F, 23.45834F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(46.875F, 23F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.Text = "Fecha:";
            // 
            // xrPanel1
            // 
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.lbNotaEntrada});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(450F, 45.87498F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(190F, 61.45834F);
            this.xrPanel1.StylePriority.UseBorders = false;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(6F, 4.041672F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(179.5833F, 21.25002F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "NOTA DE ENTRADA";
            // 
            // lbNotaEntrada
            // 
            this.lbNotaEntrada.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbNotaEntrada.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotaEntrada.LocationFloat = new DevExpress.Utils.PointFloat(10.79178F, 29.29169F);
            this.lbNotaEntrada.Name = "lbNotaEntrada";
            this.lbNotaEntrada.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNotaEntrada.SizeF = new System.Drawing.SizeF(170.2083F, 22.99998F);
            this.lbNotaEntrada.StylePriority.UseBorders = false;
            this.lbNotaEntrada.StylePriority.UseFont = false;
            this.lbNotaEntrada.StylePriority.UseTextAlignment = false;
            this.lbNotaEntrada.Text = "1100-3828";
            this.lbNotaEntrada.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(73.95834F, 10.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(507.2917F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "SOCIEDAD DE CALIDAD EN MIEL DE ABEJA S.A. DE C.V.";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(180.2083F, 43.33334F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(269.7916F, 50.83332F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Periferico sur Km. 7.5 s/n x 50 y 60 Sur\r\nMérida, Yucatán. C.P. 97299\r\nTELS. (999" +
                ") 9263174, (999) 9427140";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 45F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(350F, 10.00001F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(300F, 16.66667F);
            this.xrTable1.StylePriority.UseBorders = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "RECIBIÓ:";
            this.xrTableCell1.Weight = 1;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "ENTREGÓ:";
            this.xrTableCell2.Weight = 1;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "AUTORIZÓ:";
            this.xrTableCell3.Weight = 1;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(350F, 26.6667F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(300F, 63.33335F);
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Weight = 1;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Weight = 1;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Weight = 1;
            // 
            // barcodeNota
            // 
            this.barcodeNota.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.barcodeNota.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.barcodeNota.Name = "barcodeNota";
            this.barcodeNota.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.barcodeNota.SizeF = new System.Drawing.SizeF(310.9167F, 129F);
            this.barcodeNota.StylePriority.UseFont = false;
            this.barcodeNota.StylePriority.UseTextAlignment = false;
            this.barcodeNota.Symbology = code128Generator1;
            this.barcodeNota.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.barcodeNota,
            this.xrTable1,
            this.xrTable2});
            this.ReportFooter.HeightF = 141F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // paramIdCompra
            // 
            this.paramIdCompra.Name = "paramIdCompra";
            this.paramIdCompra.Value = "";
            // 
            // repCompraMiel
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 196, 45);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.paramIdCompra});
            this.Version = "10.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.repCompraMiel_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.gridCompraTambores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel lbApicultor;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPanel xrPanel2;
        private DevExpress.XtraReports.UI.XRLabel lbArea;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel lbNotaEntrada;
        private DevExpress.XtraReports.UI.XRLabel lbFecha;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRBarCode barcodeNota;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraGrid.GridControl gridCompraTambores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcTambor;
        private DevExpress.XtraGrid.Columns.GridColumn gcPBruto;
        public DevExpress.XtraReports.Parameters.Parameter paramIdCompra;
        private DevExpress.XtraGrid.Columns.GridColumn gcTara;
        private DevExpress.XtraGrid.Columns.GridColumn gcPNeto;
        private DevExpress.XtraGrid.Columns.GridColumn gcPUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubtotal;
        private DevExpress.XtraReports.UI.XRPanel xrPanel3;
    }
}
