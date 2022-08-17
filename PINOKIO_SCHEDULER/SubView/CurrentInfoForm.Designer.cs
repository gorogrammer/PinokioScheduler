
namespace PINOKIO_SCHEDULER
{
    partial class CurrentInfoForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gcMachineInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorking = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSetTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperRatio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemainJobInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainCount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcMachineInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRemainJobInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "설비 정보";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "남은 Job 정보";
            // 
            // gcMachineInfo
            // 
            this.gcMachineInfo.Location = new System.Drawing.Point(12, 50);
            this.gcMachineInfo.MainView = this.gridView1;
            this.gcMachineInfo.Name = "gcMachineInfo";
            this.gcMachineInfo.Size = new System.Drawing.Size(526, 421);
            this.gcMachineInfo.TabIndex = 4;
            this.gcMachineInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMachine,
            this.colJobCount,
            this.colLastTime,
            this.colWorking,
            this.colSetTime,
            this.colOperRatio});
            this.gridView1.GridControl = this.gcMachineInfo;
            this.gridView1.Name = "gridView1";
            // 
            // colMachine
            // 
            this.colMachine.Caption = "Machine";
            this.colMachine.FieldName = "Name";
            this.colMachine.Name = "colMachine";
            this.colMachine.Visible = true;
            this.colMachine.VisibleIndex = 0;
            // 
            // colJobCount
            // 
            this.colJobCount.Caption = "JOB COUNT";
            this.colJobCount.FieldName = "JobCount";
            this.colJobCount.Name = "colJobCount";
            this.colJobCount.Visible = true;
            this.colJobCount.VisibleIndex = 1;
            // 
            // colLastTime
            // 
            this.colLastTime.Caption = "LAST";
            this.colLastTime.FieldName = "LastTime";
            this.colLastTime.Name = "colLastTime";
            this.colLastTime.Visible = true;
            this.colLastTime.VisibleIndex = 2;
            // 
            // colWorking
            // 
            this.colWorking.Caption = "WORK";
            this.colWorking.FieldName = "WorkingTime";
            this.colWorking.Name = "colWorking";
            this.colWorking.Visible = true;
            this.colWorking.VisibleIndex = 3;
            // 
            // colSetTime
            // 
            this.colSetTime.Caption = "SET UP";
            this.colSetTime.FieldName = "SetUpTime";
            this.colSetTime.Name = "colSetTime";
            this.colSetTime.Visible = true;
            this.colSetTime.VisibleIndex = 4;
            // 
            // colOperRatio
            // 
            this.colOperRatio.Caption = "OPER RATIO";
            this.colOperRatio.FieldName = "Operatingratio";
            this.colOperRatio.Name = "colOperRatio";
            this.colOperRatio.Visible = true;
            this.colOperRatio.VisibleIndex = 5;
            // 
            // gcRemainJobInfo
            // 
            this.gcRemainJobInfo.Location = new System.Drawing.Point(602, 50);
            this.gcRemainJobInfo.MainView = this.gridView2;
            this.gcRemainJobInfo.Name = "gcRemainJobInfo";
            this.gcRemainJobInfo.Size = new System.Drawing.Size(176, 421);
            this.gcRemainJobInfo.TabIndex = 4;
            this.gcRemainJobInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colJob,
            this.colRemainCount});
            this.gridView2.GridControl = this.gcRemainJobInfo;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView2.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            // 
            // colJob
            // 
            this.colJob.Caption = "JOB";
            this.colJob.FieldName = "Job";
            this.colJob.Name = "colJob";
            this.colJob.Visible = true;
            this.colJob.VisibleIndex = 0;
            // 
            // colRemainCount
            // 
            this.colRemainCount.Caption = "Count";
            this.colRemainCount.FieldName = "RemainCount";
            this.colRemainCount.Name = "colRemainCount";
            this.colRemainCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RemainCount", "SUM={0}"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max, "RemainCount", "MAX={0}"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Min, "RemainCount", "MIN={0}")});
            this.colRemainCount.Visible = true;
            this.colRemainCount.VisibleIndex = 1;
            // 
            // CurrentInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 516);
            this.Controls.Add(this.gcRemainJobInfo);
            this.Controls.Add(this.gcMachineInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CurrentInfoForm";
            this.Text = "현재 정보";
            ((System.ComponentModel.ISupportInitialize)(this.gcMachineInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRemainJobInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl gcMachineInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gcRemainJobInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colJobCount;
        private DevExpress.XtraGrid.Columns.GridColumn colSetTime;
        private DevExpress.XtraGrid.Columns.GridColumn colMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colLastTime;
        private DevExpress.XtraGrid.Columns.GridColumn colWorking;
        private DevExpress.XtraGrid.Columns.GridColumn colOperRatio;
        private DevExpress.XtraGrid.Columns.GridColumn colJob;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainCount;
    }
}