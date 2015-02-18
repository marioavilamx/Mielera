namespace MieleraNet.Reportes
{
    partial class repAnticiposEnt
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
            this.gridAnticipos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridHora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDocum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridElaboro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.lbTitulo = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.paramFechaIni = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramFechaFin = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramDelegado = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnticipos)).BeginInit();
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
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(650F, 89.99999F);
            this.winControlContainer1.WinControl = this.gridAnticipos;
            // 
            // gridAnticipos
            // 
            this.gridAnticipos.Location = new System.Drawing.Point(0, 0);
            this.gridAnticipos.MainView = this.gridView1;
            this.gridAnticipos.Name = "gridAnticipos";
            this.gridAnticipos.Size = new System.Drawing.Size(624, 86);
            this.gridAnticipos.TabIndex = 0;
            this.gridAnticipos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridNombre,
            this.gridArea,
            this.gridCantidad,
            this.gridFecha,
            this.gridHora,
            this.gridDocum,
            this.gridElaboro});
            this.gridView1.GridControl = this.gridAnticipos;
            this.gridView1.Name = "gridView1";
            // 
            // gridNombre
            // 
            this.gridNombre.Caption = "Delegado";
            this.gridNombre.FieldName = "NOMBRE";
            this.gridNombre.Name = "gridNombre";
            this.gridNombre.Visible = true;
            this.gridNombre.VisibleIndex = 0;
            // 
            // gridArea
            // 
            this.gridArea.Caption = "Area";
            this.gridArea.FieldName = "AREA";
            this.gridArea.Name = "gridArea";
            this.gridArea.Visible = true;
            this.gridArea.VisibleIndex = 1;
            // 
            // gridCantidad
            // 
            this.gridCantidad.Caption = "Cantidad";
            this.gridCantidad.DisplayFormat.FormatString = "c";
            this.gridCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridCantidad.FieldName = "CANTI";
            this.gridCantidad.Name = "gridCantidad";
            this.gridCantidad.Visible = true;
            this.gridCantidad.VisibleIndex = 2;
            // 
            // gridFecha
            // 
            this.gridFecha.Caption = "Fecha";
            this.gridFecha.FieldName = "FECHA";
            this.gridFecha.Name = "gridFecha";
            this.gridFecha.Visible = true;
            this.gridFecha.VisibleIndex = 3;
            // 
            // gridHora
            // 
            this.gridHora.Caption = "Hora";
            this.gridHora.FieldName = "HORA";
            this.gridHora.Name = "gridHora";
            this.gridHora.Visible = true;
            this.gridHora.VisibleIndex = 4;
            // 
            // gridDocum
            // 
            this.gridDocum.Caption = "Documento";
            this.gridDocum.FieldName = "DOCUM";
            this.gridDocum.Name = "gridDocum";
            this.gridDocum.Visible = true;
            this.gridDocum.VisibleIndex = 5;
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
            this.lbTitulo});
            this.TopMargin.HeightF = 68F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbTitulo
            // 
            this.lbTitulo.LocationFloat = new DevExpress.Utils.PointFloat(0.8750191F, 30.16667F);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTitulo.SizeF = new System.Drawing.SizeF(648.1251F, 23F);
            this.lbTitulo.StylePriority.UseTextAlignment = false;
            this.lbTitulo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            // repAnticiposEnt
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 68, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.paramFechaIni,
            this.paramFechaFin,
            this.paramDelegado});
            this.Version = "10.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.repAnticiposEnt_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.gridAnticipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel lbTitulo;
        public DevExpress.XtraReports.Parameters.Parameter paramFechaIni;
        public DevExpress.XtraReports.Parameters.Parameter paramFechaFin;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraGrid.GridControl gridAnticipos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DevExpress.XtraReports.Parameters.Parameter paramDelegado;
        private DevExpress.XtraGrid.Columns.GridColumn gridNombre;
        private DevExpress.XtraGrid.Columns.GridColumn gridArea;
        private DevExpress.XtraGrid.Columns.GridColumn gridCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gridHora;
        private DevExpress.XtraGrid.Columns.GridColumn gridDocum;
        private DevExpress.XtraGrid.Columns.GridColumn gridElaboro;
    }
}
