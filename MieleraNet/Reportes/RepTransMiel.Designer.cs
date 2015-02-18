namespace MieleraNet.Reportes
{
    partial class RepTransMiel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepTransMiel));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.gridTambores = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTamb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubTot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.paramIDEmpresa = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramIDTrans = new DevExpress.XtraReports.Parameters.Parameter();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lbHora = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDelegado = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotTran = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNumTran = new DevExpress.XtraReports.UI.XRLabel();
            this.lbHoraTran = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFechaTran = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEmpresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridTambores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer1});
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(617.2083F, 89.99999F);
            this.winControlContainer1.WinControl = this.gridTambores;
            // 
            // gridTambores
            // 
            this.gridTambores.Location = new System.Drawing.Point(0, 0);
            this.gridTambores.MainView = this.gridView1;
            this.gridTambores.Name = "gridTambores";
            this.gridTambores.Size = new System.Drawing.Size(593, 86);
            this.gridTambores.TabIndex = 0;
            this.gridTambores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Gainsboro;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSlateGray;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.Gainsboro;
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTamb,
            this.colKg,
            this.colSubTot,
            this.colPUnit});
            this.gridView1.GridControl = this.gridTambores;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            // 
            // colTamb
            // 
            this.colTamb.Caption = "Num. Tambor";
            this.colTamb.FieldName = "IDTAMBOR";
            this.colTamb.Name = "colTamb";
            this.colTamb.Visible = true;
            this.colTamb.VisibleIndex = 0;
            // 
            // colKg
            // 
            this.colKg.Caption = "Peso Neto por Tambor";
            this.colKg.FieldName = "K";
            this.colKg.Name = "colKg";
            this.colKg.Visible = true;
            this.colKg.VisibleIndex = 1;
            // 
            // colSubTot
            // 
            this.colSubTot.Caption = "SubTotal por Tambor";
            this.colSubTot.DisplayFormat.FormatString = "c";
            this.colSubTot.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSubTot.FieldName = "S";
            this.colSubTot.Name = "colSubTot";
            this.colSubTot.Visible = true;
            this.colSubTot.VisibleIndex = 2;
            // 
            // colPUnit
            // 
            this.colPUnit.Caption = "Precio Unitario";
            this.colPUnit.DisplayFormat.FormatString = "c";
            this.colPUnit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPUnit.FieldName = "PRECIOUNIT";
            this.colPUnit.Name = "colPUnit";
            this.colPUnit.Visible = true;
            this.colPUnit.VisibleIndex = 3;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 49F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // paramIDEmpresa
            // 
            this.paramIDEmpresa.Name = "paramIDEmpresa";
            this.paramIDEmpresa.ParameterType = DevExpress.XtraReports.Parameters.ParameterType.Int32;
            this.paramIDEmpresa.Value = 0;
            // 
            // paramIDTrans
            // 
            this.paramIDTrans.Name = "paramIDTrans";
            this.paramIDTrans.ParameterType = DevExpress.XtraReports.Parameters.ParameterType.Int32;
            this.paramIDTrans.Value = 0;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbHora,
            this.lbFecha,
            this.lbDelegado,
            this.lbTotTran,
            this.lbNumTran,
            this.lbHoraTran,
            this.lbFechaTran,
            this.xrPictureBox1,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.lbEmpresa});
            this.PageHeader.HeightF = 189F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.PageHeader_BeforePrint);
            // 
            // lbHora
            // 
            this.lbHora.LocationFloat = new DevExpress.Utils.PointFloat(520.2918F, 113.875F);
            this.lbHora.Name = "lbHora";
            this.lbHora.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbHora.SizeF = new System.Drawing.SizeF(119.7082F, 14.99999F);
            this.lbHora.StylePriority.UseTextAlignment = false;
            this.lbHora.Text = "lbHora";
            this.lbHora.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbFecha
            // 
            this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(520.2917F, 98.87502F);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFecha.SizeF = new System.Drawing.SizeF(119.7082F, 14.99999F);
            this.lbFecha.StylePriority.UseTextAlignment = false;
            this.lbFecha.Text = "lbFecha";
            this.lbFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbDelegado
            // 
            this.lbDelegado.LocationFloat = new DevExpress.Utils.PointFloat(194.875F, 161.125F);
            this.lbDelegado.Name = "lbDelegado";
            this.lbDelegado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDelegado.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbDelegado.StylePriority.UseTextAlignment = false;
            this.lbDelegado.Text = "lbDelegado";
            this.lbDelegado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbTotTran
            // 
            this.lbTotTran.LocationFloat = new DevExpress.Utils.PointFloat(150F, 146.125F);
            this.lbTotTran.Name = "lbTotTran";
            this.lbTotTran.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotTran.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbTotTran.StylePriority.UseTextAlignment = false;
            this.lbTotTran.Text = "lbTotTran";
            this.lbTotTran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbNumTran
            // 
            this.lbNumTran.LocationFloat = new DevExpress.Utils.PointFloat(150F, 129.625F);
            this.lbNumTran.Name = "lbNumTran";
            this.lbNumTran.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNumTran.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbNumTran.StylePriority.UseTextAlignment = false;
            this.lbNumTran.Text = "lbNumTran";
            this.lbNumTran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbHoraTran
            // 
            this.lbHoraTran.LocationFloat = new DevExpress.Utils.PointFloat(150F, 113.875F);
            this.lbHoraTran.Name = "lbHoraTran";
            this.lbHoraTran.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbHoraTran.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbHoraTran.StylePriority.UseTextAlignment = false;
            this.lbHoraTran.Text = "lbHoraTran";
            this.lbHoraTran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbFechaTran
            // 
            this.lbFechaTran.LocationFloat = new DevExpress.Utils.PointFloat(150F, 98.12502F);
            this.lbFechaTran.Name = "lbFechaTran";
            this.lbFechaTran.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFechaTran.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbFechaTran.StylePriority.UseTextAlignment = false;
            this.lbFechaTran.Text = "lbFechaTran";
            this.lbFechaTran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(89.58334F, 85.125F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabel8
            // 
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(48.00001F, 145.375F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Total Trans:";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(474.4584F, 98.12502F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(45.8334F, 15F);
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Fecha:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(477.5835F, 113.875F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(42.70834F, 15F);
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Hora:";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(48.00002F, 161.125F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(146.875F, 15F);
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Transferencia Hecho por:";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(48.00001F, 129.625F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "N Trans:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(48.00001F, 113.875F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Hora Trans:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(48.00001F, 98.125F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Fecha Trans:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(200.0002F, 79F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(251.0417F, 19.125F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "TRANSFERENCIA DE MIEL";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbEmpresa
            // 
            this.lbEmpresa.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbEmpresa.LocationFloat = new DevExpress.Utils.PointFloat(101.0417F, 0F);
            this.lbEmpresa.Name = "lbEmpresa";
            this.lbEmpresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEmpresa.SizeF = new System.Drawing.SizeF(448.9583F, 23F);
            this.lbEmpresa.StylePriority.UseFont = false;
            this.lbEmpresa.StylePriority.UseTextAlignment = false;
            this.lbEmpresa.Text = "lbEmpresa";
            this.lbEmpresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // RepTransMiel
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 50, 49);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.paramIDEmpresa,
            this.paramIDTrans});
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.gridTambores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        public DevExpress.XtraReports.Parameters.Parameter paramIDEmpresa;
        public DevExpress.XtraReports.Parameters.Parameter paramIDTrans;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lbEmpresa;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraGrid.GridControl gridTambores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTamb;
        private DevExpress.XtraGrid.Columns.GridColumn colKg;
        private DevExpress.XtraGrid.Columns.GridColumn colSubTot;
        private DevExpress.XtraGrid.Columns.GridColumn colPUnit;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel lbHora;
        private DevExpress.XtraReports.UI.XRLabel lbFecha;
        private DevExpress.XtraReports.UI.XRLabel lbDelegado;
        private DevExpress.XtraReports.UI.XRLabel lbTotTran;
        private DevExpress.XtraReports.UI.XRLabel lbNumTran;
        private DevExpress.XtraReports.UI.XRLabel lbHoraTran;
        private DevExpress.XtraReports.UI.XRLabel lbFechaTran;
    }
}
