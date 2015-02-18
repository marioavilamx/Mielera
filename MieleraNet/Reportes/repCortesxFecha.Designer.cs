namespace MieleraNet.Reportes
{
    partial class repCortesxFecha
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
            this.gridCortexFecha = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grodFechaCorte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridHoraCorte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridAnterior = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridAbonos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSaldoFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridElaboro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.lbFechas = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDelegado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.paramFechaIni = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramFechaFin = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramDelegado = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramNombre = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.gridCortexFecha)).BeginInit();
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
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(650F, 90.00001F);
            this.winControlContainer1.WinControl = this.gridCortexFecha;
            // 
            // gridCortexFecha
            // 
            this.gridCortexFecha.Location = new System.Drawing.Point(0, 0);
            this.gridCortexFecha.MainView = this.gridView1;
            this.gridCortexFecha.Name = "gridCortexFecha";
            this.gridCortexFecha.Size = new System.Drawing.Size(624, 86);
            this.gridCortexFecha.TabIndex = 0;
            this.gridCortexFecha.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grodFechaCorte,
            this.gridHoraCorte,
            this.gridAnterior,
            this.gridCargo,
            this.gridAbonos,
            this.gridSaldoFinal,
            this.gridElaboro});
            this.gridView1.GridControl = this.gridCortexFecha;
            this.gridView1.Name = "gridView1";
            // 
            // grodFechaCorte
            // 
            this.grodFechaCorte.Caption = "Fecha Corte";
            this.grodFechaCorte.FieldName = "FECHA_CORTE";
            this.grodFechaCorte.Name = "grodFechaCorte";
            this.grodFechaCorte.Visible = true;
            this.grodFechaCorte.VisibleIndex = 0;
            // 
            // gridHoraCorte
            // 
            this.gridHoraCorte.Caption = "Hora Corte";
            this.gridHoraCorte.DisplayFormat.FormatString = "t";
            this.gridHoraCorte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridHoraCorte.FieldName = "HORA_CORTE";
            this.gridHoraCorte.Name = "gridHoraCorte";
            this.gridHoraCorte.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.gridHoraCorte.Visible = true;
            this.gridHoraCorte.VisibleIndex = 1;
            // 
            // gridAnterior
            // 
            this.gridAnterior.Caption = "Saldo Anterior";
            this.gridAnterior.DisplayFormat.FormatString = "c";
            this.gridAnterior.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridAnterior.FieldName = "ANTERIOR";
            this.gridAnterior.Name = "gridAnterior";
            this.gridAnterior.Visible = true;
            this.gridAnterior.VisibleIndex = 2;
            // 
            // gridCargo
            // 
            this.gridCargo.Caption = "Cargos";
            this.gridCargo.DisplayFormat.FormatString = "c";
            this.gridCargo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridCargo.FieldName = "CARGO";
            this.gridCargo.Name = "gridCargo";
            this.gridCargo.Visible = true;
            this.gridCargo.VisibleIndex = 3;
            // 
            // gridAbonos
            // 
            this.gridAbonos.Caption = "Abonos";
            this.gridAbonos.DisplayFormat.FormatString = "c";
            this.gridAbonos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridAbonos.FieldName = "ABONO";
            this.gridAbonos.Name = "gridAbonos";
            this.gridAbonos.Visible = true;
            this.gridAbonos.VisibleIndex = 4;
            // 
            // gridSaldoFinal
            // 
            this.gridSaldoFinal.Caption = "Saldo Final";
            this.gridSaldoFinal.DisplayFormat.FormatString = "c";
            this.gridSaldoFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridSaldoFinal.FieldName = "ACTUAL";
            this.gridSaldoFinal.Name = "gridSaldoFinal";
            this.gridSaldoFinal.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gridSaldoFinal.Visible = true;
            this.gridSaldoFinal.VisibleIndex = 5;
            // 
            // gridElaboro
            // 
            this.gridElaboro.Caption = "Elaboró";
            this.gridElaboro.FieldName = "ELABORO";
            this.gridElaboro.Name = "gridElaboro";
            this.gridElaboro.Visible = true;
            this.gridElaboro.VisibleIndex = 6;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbFechas,
            this.lbDelegado,
            this.xrLabel1});
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbFechas
            // 
            this.lbFechas.LocationFloat = new DevExpress.Utils.PointFloat(51.04168F, 77.20834F);
            this.lbFechas.Multiline = true;
            this.lbFechas.Name = "lbFechas";
            this.lbFechas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFechas.SizeF = new System.Drawing.SizeF(548.9583F, 17.79167F);
            this.lbFechas.StylePriority.UseTextAlignment = false;
            this.lbFechas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbDelegado
            // 
            this.lbDelegado.LocationFloat = new DevExpress.Utils.PointFloat(52F, 57.5F);
            this.lbDelegado.Multiline = true;
            this.lbDelegado.Name = "lbDelegado";
            this.lbDelegado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDelegado.SizeF = new System.Drawing.SizeF(548.9583F, 17.79167F);
            this.lbDelegado.StylePriority.UseTextAlignment = false;
            this.lbDelegado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(51.0417F, 39.54167F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(548.9583F, 17.79167F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "REPORTE DE CORTES ELABORADOS DEL DELEGADO";
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
            // paramNombre
            // 
            this.paramNombre.Name = "paramNombre";
            this.paramNombre.Value = "";
            // 
            // repCortesxFecha
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.paramFechaIni,
            this.paramFechaFin,
            this.paramDelegado,
            this.paramNombre});
            this.Version = "10.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.repCortesxFecha_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.gridCortexFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel lbDelegado;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraGrid.GridControl gridCortexFecha;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DevExpress.XtraReports.Parameters.Parameter paramFechaIni;
        public DevExpress.XtraReports.Parameters.Parameter paramFechaFin;
        public DevExpress.XtraReports.Parameters.Parameter paramDelegado;
        private DevExpress.XtraGrid.Columns.GridColumn grodFechaCorte;
        private DevExpress.XtraGrid.Columns.GridColumn gridHoraCorte;
        private DevExpress.XtraGrid.Columns.GridColumn gridAnterior;
        private DevExpress.XtraGrid.Columns.GridColumn gridCargo;
        private DevExpress.XtraGrid.Columns.GridColumn gridAbonos;
        private DevExpress.XtraGrid.Columns.GridColumn gridSaldoFinal;
        private DevExpress.XtraReports.UI.XRLabel lbFechas;
        public DevExpress.XtraReports.Parameters.Parameter paramNombre;
        private DevExpress.XtraGrid.Columns.GridColumn gridElaboro;
    }
}
