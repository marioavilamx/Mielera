namespace MieleraNet.Reportes
{
    partial class repCortesxDelegado
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.gridCorteDelegado = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridDelegado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnterior = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridAbono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colElaboro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.lbFechas = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.paramFechaIni = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramFechaFin = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramDelegado = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.gridCorteDelegado)).BeginInit();
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
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(650F, 77.16667F);
            this.winControlContainer1.WinControl = this.gridCorteDelegado;
            // 
            // gridCorteDelegado
            // 
            this.gridCorteDelegado.Location = new System.Drawing.Point(0, 0);
            this.gridCorteDelegado.MainView = this.gridView1;
            this.gridCorteDelegado.Name = "gridCorteDelegado";
            this.gridCorteDelegado.Size = new System.Drawing.Size(624, 74);
            this.gridCorteDelegado.TabIndex = 0;
            this.gridCorteDelegado.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridDelegado,
            this.gridArea,
            this.colFecha,
            this.colHora,
            this.colAnterior,
            this.colCargo,
            this.gridAbono,
            this.colActual,
            this.colElaboro});
            this.gridView1.GridControl = this.gridCorteDelegado;
            this.gridView1.Name = "gridView1";
            // 
            // gridDelegado
            // 
            this.gridDelegado.Caption = "Delegado";
            this.gridDelegado.FieldName = "DELEGADO";
            this.gridDelegado.Name = "gridDelegado";
            this.gridDelegado.Visible = true;
            this.gridDelegado.VisibleIndex = 0;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha Corte";
            this.colFecha.FieldName = "FECHA_CORTE";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 2;
            // 
            // colHora
            // 
            this.colHora.Caption = "Hora Corte";
            this.colHora.DisplayFormat.FormatString = "hh:mm";
            this.colHora.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHora.FieldName = "HORA_CORTE";
            this.colHora.Name = "colHora";
            this.colHora.Visible = true;
            this.colHora.VisibleIndex = 3;
            // 
            // colAnterior
            // 
            this.colAnterior.Caption = "Saldo Inicial";
            this.colAnterior.DisplayFormat.FormatString = "c";
            this.colAnterior.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAnterior.FieldName = "ANTERIOR";
            this.colAnterior.Name = "colAnterior";
            this.colAnterior.Visible = true;
            this.colAnterior.VisibleIndex = 4;
            // 
            // colCargo
            // 
            this.colCargo.Caption = "Cargos";
            this.colCargo.DisplayFormat.FormatString = "c";
            this.colCargo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCargo.FieldName = "CARGO";
            this.colCargo.Name = "colCargo";
            this.colCargo.Visible = true;
            this.colCargo.VisibleIndex = 5;
            // 
            // gridAbono
            // 
            this.gridAbono.Caption = "Abonos";
            this.gridAbono.DisplayFormat.FormatString = "c";
            this.gridAbono.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridAbono.FieldName = "ABONO";
            this.gridAbono.Name = "gridAbono";
            this.gridAbono.Visible = true;
            this.gridAbono.VisibleIndex = 6;
            // 
            // colActual
            // 
            this.colActual.Caption = "Saldo Final";
            this.colActual.DisplayFormat.FormatString = "c";
            this.colActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colActual.FieldName = "ACTUAL";
            this.colActual.Name = "colActual";
            this.colActual.Visible = true;
            this.colActual.VisibleIndex = 7;
            // 
            // colElaboro
            // 
            this.colElaboro.Caption = "Elaboró";
            this.colElaboro.FieldName = "ELABORO";
            this.colElaboro.Name = "colElaboro";
            this.colElaboro.Visible = true;
            this.colElaboro.VisibleIndex = 8;
            // 
            // gridArea
            // 
            this.gridArea.Caption = "Area";
            this.gridArea.FieldName = "AREA";
            this.gridArea.Name = "gridArea";
            this.gridArea.Visible = true;
            this.gridArea.VisibleIndex = 1;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbFechas,
            this.xrLabel1});
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbFechas
            // 
            this.lbFechas.LocationFloat = new DevExpress.Utils.PointFloat(50F, 55.29168F);
            this.lbFechas.Multiline = true;
            this.lbFechas.Name = "lbFechas";
            this.lbFechas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFechas.SizeF = new System.Drawing.SizeF(548.9583F, 17.79167F);
            this.lbFechas.StylePriority.UseTextAlignment = false;
            this.lbFechas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(50F, 37.5F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(548.9583F, 17.79167F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "REPORTE DE DELEGADOS CON CORTES";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // paramFechaIni
            // 
            this.paramFechaIni.Name = "paramFechaIni";
            this.paramFechaIni.ParameterType = DevExpress.XtraReports.Parameters.ParameterType.DateTime;
            this.paramFechaIni.Value = new System.DateTime(((long)(0)));
            // 
            // paramFechaFin
            // 
            this.paramFechaFin.Name = "paramFechaFin";
            this.paramFechaFin.ParameterType = DevExpress.XtraReports.Parameters.ParameterType.DateTime;
            this.paramFechaFin.Value = new System.DateTime(((long)(0)));
            // 
            // paramDelegado
            // 
            this.paramDelegado.Name = "paramDelegado";
            this.paramDelegado.ParameterType = DevExpress.XtraReports.Parameters.ParameterType.Int32;
            this.paramDelegado.Value = 0;
            // 
            // repCortesxDelegado
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.paramFechaIni,
            this.paramFechaFin,
            this.paramDelegado});
            this.Version = "10.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.repCortesxDelegado_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.gridCorteDelegado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraGrid.GridControl gridCorteDelegado;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colHora;
        private DevExpress.XtraGrid.Columns.GridColumn colAnterior;
        private DevExpress.XtraGrid.Columns.GridColumn colCargo;
        private DevExpress.XtraGrid.Columns.GridColumn gridAbono;
        private DevExpress.XtraGrid.Columns.GridColumn colActual;
        private DevExpress.XtraGrid.Columns.GridColumn colElaboro;
        private DevExpress.XtraReports.UI.XRLabel lbFechas;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        public DevExpress.XtraReports.Parameters.Parameter paramFechaIni;
        public DevExpress.XtraReports.Parameters.Parameter paramFechaFin;
        public DevExpress.XtraReports.Parameters.Parameter paramDelegado;
        private DevExpress.XtraGrid.Columns.GridColumn gridDelegado;
        private DevExpress.XtraGrid.Columns.GridColumn gridArea;
    }
}
