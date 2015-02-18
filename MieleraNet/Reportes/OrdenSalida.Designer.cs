namespace MieleraNet.Reportes
{
    partial class OrdenSalida
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.Parameters.Parameter paramOrigen;
            DevExpress.XtraReports.Parameters.Parameter paramFecha;
            DevExpress.XtraReports.Parameters.Parameter paramOperador;
            DevExpress.XtraReports.Parameters.Parameter paramDestino;
            DevExpress.XtraReports.Parameters.Parameter paramFletera;
            DevExpress.XtraReports.Parameters.Parameter paramContrato;
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.gridOrdenSalida = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLOTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTIPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONTENEDOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSELLO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFACTURA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAMBORES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPESONETO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordenSalida1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ordenSalida1 = new MieleraNet.App_Data.OrdenSalida();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabelDestino = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabelOrigen = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelEmpresa = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabelOperador = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelFletera = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            paramOrigen = new DevExpress.XtraReports.Parameters.Parameter();
            paramFecha = new DevExpress.XtraReports.Parameters.Parameter();
            paramOperador = new DevExpress.XtraReports.Parameters.Parameter();
            paramDestino = new DevExpress.XtraReports.Parameters.Parameter();
            paramFletera = new DevExpress.XtraReports.Parameters.Parameter();
            paramContrato = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrdenSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenSalida1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenSalida1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // paramOrigen
            // 
            paramOrigen.Name = "paramOrigen";
            paramOrigen.Value = "";
            // 
            // paramFecha
            // 
            paramFecha.Name = "paramFecha";
            paramFecha.ParameterType = DevExpress.XtraReports.Parameters.ParameterType.DateTime;
            paramFecha.Value = new System.DateTime(((long)(0)));
            // 
            // paramOperador
            // 
            paramOperador.Name = "paramOperador";
            paramOperador.Value = "";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer1});
            this.Detail.HeightF = 175F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 9.999974F);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(522.9167F, 121.9583F);
            this.winControlContainer1.WinControl = this.gridOrdenSalida;
            // 
            // gridOrdenSalida
            // 
            this.gridOrdenSalida.Location = new System.Drawing.Point(0, 0);
            this.gridOrdenSalida.MainView = this.gridView1;
            this.gridOrdenSalida.Name = "gridOrdenSalida";
            this.gridOrdenSalida.Size = new System.Drawing.Size(502, 117);
            this.gridOrdenSalida.TabIndex = 0;
            this.gridOrdenSalida.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLOTE,
            this.colTIPO,
            this.colCONTENEDOR,
            this.colSELLO,
            this.colFACTURA,
            this.colTAMBORES,
            this.colPESONETO});
            this.gridView1.GridControl = this.gridOrdenSalida;
            this.gridView1.Name = "gridView1";
            // 
            // colLOTE
            // 
            this.colLOTE.FieldName = "LOTE";
            this.colLOTE.Name = "colLOTE";
            this.colLOTE.Visible = true;
            this.colLOTE.VisibleIndex = 0;
            // 
            // colTIPO
            // 
            this.colTIPO.FieldName = "TIPO";
            this.colTIPO.Name = "colTIPO";
            this.colTIPO.Visible = true;
            this.colTIPO.VisibleIndex = 1;
            // 
            // colCONTENEDOR
            // 
            this.colCONTENEDOR.FieldName = "CONTENEDOR";
            this.colCONTENEDOR.Name = "colCONTENEDOR";
            this.colCONTENEDOR.Visible = true;
            this.colCONTENEDOR.VisibleIndex = 2;
            // 
            // colSELLO
            // 
            this.colSELLO.FieldName = "SELLO";
            this.colSELLO.Name = "colSELLO";
            this.colSELLO.Visible = true;
            this.colSELLO.VisibleIndex = 3;
            // 
            // colFACTURA
            // 
            this.colFACTURA.FieldName = "FACTURA";
            this.colFACTURA.Name = "colFACTURA";
            this.colFACTURA.Visible = true;
            this.colFACTURA.VisibleIndex = 4;
            // 
            // colTAMBORES
            // 
            this.colTAMBORES.FieldName = "TAMBORES";
            this.colTAMBORES.Name = "colTAMBORES";
            this.colTAMBORES.Visible = true;
            this.colTAMBORES.VisibleIndex = 5;
            // 
            // colPESONETO
            // 
            this.colPESONETO.FieldName = "PESONETO";
            this.colPESONETO.Name = "colPESONETO";
            this.colPESONETO.Visible = true;
            this.colPESONETO.VisibleIndex = 6;
            // 
            // ordenSalida1BindingSource
            // 
            this.ordenSalida1BindingSource.DataMember = "ordenSalida";
            this.ordenSalida1BindingSource.DataSource = this.ordenSalida1;
            // 
            // ordenSalida1
            // 
            this.ordenSalida1.DataSetName = "OrdenSalida";
            this.ordenSalida1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLabelDestino,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLine1,
            this.xrLabelOrigen,
            this.xrLabel5,
            this.xrLabelFecha,
            this.xrLabel3,
            this.xrLabelEmpresa});
            this.TopMargin.HeightF = 325F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.StylePriority.UseTextAlignment = false;
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.TopMargin.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.TopMargin_BeforePrint);
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(26.04167F, 291F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(623.9583F, 23F);
            // 
            // xrLabelDestino
            // 
            this.xrLabelDestino.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelDestino.LocationFloat = new DevExpress.Utils.PointFloat(26.0417F, 194.7501F);
            this.xrLabelDestino.Name = "xrLabelDestino";
            this.xrLabelDestino.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelDestino.SizeF = new System.Drawing.SizeF(214.5833F, 23F);
            this.xrLabelDestino.StylePriority.UseFont = false;
            this.xrLabelDestino.StylePriority.UseTextAlignment = false;
            this.xrLabelDestino.Text = "PUERTO PROGRESO";
            this.xrLabelDestino.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(26.04167F, 268F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(279.1667F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "ATTE: DALIA PENSABÉ";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(26.04173F, 222F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(540.6251F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "AGENCIA ADUANAL: GRUPO ADUANERO PENINSULAR";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(26.04167F, 245F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(279.1667F, 23.00002F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "TEL:019699344427";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(26.0417F, 161.5417F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(227.0833F, 33.20836F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "DESTINATARIO:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(26.04167F, 138.5417F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(623.9583F, 23F);
            // 
            // xrLabelOrigen
            // 
            this.xrLabelOrigen.LocationFloat = new DevExpress.Utils.PointFloat(126.0417F, 103.9167F);
            this.xrLabelOrigen.Name = "xrLabelOrigen";
            this.xrLabelOrigen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelOrigen.SizeF = new System.Drawing.SizeF(205.2083F, 23F);
            this.xrLabelOrigen.StylePriority.UseTextAlignment = false;
            this.xrLabelOrigen.Text = "PLANTA MERIDA";
            this.xrLabelOrigen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(26.04167F, 103.9167F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "ORIGEN:";
            // 
            // xrLabelFecha
            // 
            this.xrLabelFecha.AutoWidth = true;
            this.xrLabelFecha.LocationFloat = new DevExpress.Utils.PointFloat(126.0417F, 80.91669F);
            this.xrLabelFecha.Name = "xrLabelFecha";
            this.xrLabelFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelFecha.SizeF = new System.Drawing.SizeF(97.91666F, 23F);
            this.xrLabelFecha.StylePriority.UseTextAlignment = false;
            this.xrLabelFecha.Text = "03 DE MARZO 2011";
            this.xrLabelFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(26.04167F, 80.91669F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "FECHA:";
            // 
            // xrLabelEmpresa
            // 
            this.xrLabelEmpresa.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelEmpresa.LocationFloat = new DevExpress.Utils.PointFloat(26.04173F, 10.00001F);
            this.xrLabelEmpresa.Name = "xrLabelEmpresa";
            this.xrLabelEmpresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelEmpresa.SizeF = new System.Drawing.SizeF(623.9583F, 31.33334F);
            this.xrLabelEmpresa.StylePriority.UseFont = false;
            this.xrLabelEmpresa.Text = "MIEL";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabelOperador,
            this.xrLine3,
            this.xrLabel14,
            this.xrLabelFletera,
            this.xrLabel12});
            this.ReportFooter.HeightF = 150F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ReportFooter_BeforePrint);
            // 
            // xrLabelOperador
            // 
            this.xrLabelOperador.LocationFloat = new DevExpress.Utils.PointFloat(177.0833F, 107F);
            this.xrLabelOperador.Name = "xrLabelOperador";
            this.xrLabelOperador.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelOperador.SizeF = new System.Drawing.SizeF(368.75F, 22.99999F);
            this.xrLabelOperador.Text = "DANIEL GASPAR VILLANUEVA RAMOS";
            // 
            // xrLine3
            // 
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(177.0833F, 77.08334F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(389.5835F, 23.00002F);
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 77.08334F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(149.375F, 23.00002F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "OPERADOR:";
            // 
            // xrLabelFletera
            // 
            this.xrLabelFletera.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelFletera.LocationFloat = new DevExpress.Utils.PointFloat(177.0833F, 9.999974F);
            this.xrLabelFletera.Name = "xrLabelFletera";
            this.xrLabelFletera.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelFletera.SizeF = new System.Drawing.SizeF(389.5835F, 23.00002F);
            this.xrLabelFletera.StylePriority.UseFont = false;
            this.xrLabelFletera.Text = "TRANSPORTES UNIDOS PARA SERVIR";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 9.999974F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(149.375F, 23.00002F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "TRANSPORTE:";
            // 
            // paramDestino
            // 
            paramDestino.Name = "paramDestino";
            paramDestino.Value = "";
            // 
            // paramFletera
            // 
            paramFletera.Name = "paramFletera";
            paramFletera.Value = "";
            // 
            // paramContrato
            // 
            paramContrato.Name = "paramContrato";
            paramContrato.Value = "";
            // 
            // OrdenSalida
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 325, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            paramOrigen,
            paramFecha,
            paramOperador,
            paramDestino,
            paramFletera,
            paramContrato});
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.gridOrdenSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenSalida1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenSalida1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraGrid.GridControl gridOrdenSalida;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource ordenSalida1BindingSource;
        private MieleraNet.App_Data.OrdenSalida ordenSalida1;
        private DevExpress.XtraGrid.Columns.GridColumn colLOTE;
        private DevExpress.XtraGrid.Columns.GridColumn colTIPO;
        private DevExpress.XtraGrid.Columns.GridColumn colCONTENEDOR;
        private DevExpress.XtraGrid.Columns.GridColumn colSELLO;
        private DevExpress.XtraGrid.Columns.GridColumn colFACTURA;
        private DevExpress.XtraGrid.Columns.GridColumn colTAMBORES;
        private DevExpress.XtraGrid.Columns.GridColumn colPESONETO;
        private DevExpress.XtraReports.UI.XRLabel xrLabelOrigen;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabelFecha;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabelEmpresa;
        private DevExpress.XtraReports.UI.XRLabel xrLabelDestino;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabelFletera;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabelOperador;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
    }
}
