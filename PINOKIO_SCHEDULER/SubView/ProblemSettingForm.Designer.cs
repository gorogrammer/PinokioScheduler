
namespace PINOKIO_SCHEDULER.SubView
{
    partial class ProblemSettingForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.bb_SettingProblem = new DevExpress.XtraEditors.SimpleButton();
            this.bb_Export_Problem = new DevExpress.XtraEditors.SimpleButton();
            this.bb_Import_Problem = new DevExpress.XtraEditors.SimpleButton();
            this.bbSettingValueClear = new DevExpress.XtraEditors.SimpleButton();
            this.bbSettingValueSAVE = new DevExpress.XtraEditors.SimpleButton();
            this.gc_JobGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tb_JobNo = new DevExpress.XtraEditors.TextEdit();
            this.tb_MachineNo = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Machine = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_JobGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_JobNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MachineNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Machine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.bb_SettingProblem);
            this.layoutControl1.Controls.Add(this.bb_Export_Problem);
            this.layoutControl1.Controls.Add(this.bb_Import_Problem);
            this.layoutControl1.Controls.Add(this.bbSettingValueClear);
            this.layoutControl1.Controls.Add(this.bbSettingValueSAVE);
            this.layoutControl1.Controls.Add(this.gc_JobGrid);
            this.layoutControl1.Controls.Add(this.tb_JobNo);
            this.layoutControl1.Controls.Add(this.tb_MachineNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2975, 280, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1011, 541);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // bb_SettingProblem
            // 
            this.bb_SettingProblem.Location = new System.Drawing.Point(312, 12);
            this.bb_SettingProblem.Name = "bb_SettingProblem";
            this.bb_SettingProblem.Size = new System.Drawing.Size(85, 22);
            this.bb_SettingProblem.StyleController = this.layoutControl1;
            this.bb_SettingProblem.TabIndex = 14;
            this.bb_SettingProblem.Text = "Confirm";
            this.bb_SettingProblem.Click += new System.EventHandler(this.bb_SettingProblem_Click);
            // 
            // bb_Export_Problem
            // 
            this.bb_Export_Problem.Location = new System.Drawing.Point(756, 12);
            this.bb_Export_Problem.Name = "bb_Export_Problem";
            this.bb_Export_Problem.Size = new System.Drawing.Size(60, 22);
            this.bb_Export_Problem.StyleController = this.layoutControl1;
            this.bb_Export_Problem.TabIndex = 13;
            this.bb_Export_Problem.Text = "Export";
            this.bb_Export_Problem.Click += new System.EventHandler(this.bb_Export_Problem_Click);
            // 
            // bb_Import_Problem
            // 
            this.bb_Import_Problem.Location = new System.Drawing.Point(641, 12);
            this.bb_Import_Problem.Name = "bb_Import_Problem";
            this.bb_Import_Problem.Size = new System.Drawing.Size(60, 22);
            this.bb_Import_Problem.StyleController = this.layoutControl1;
            this.bb_Import_Problem.TabIndex = 12;
            this.bb_Import_Problem.Text = "Import";
            this.bb_Import_Problem.Click += new System.EventHandler(this.bb_Import_Problem_Click);
            // 
            // bbSettingValueClear
            // 
            this.bbSettingValueClear.Location = new System.Drawing.Point(12, 507);
            this.bbSettingValueClear.Name = "bbSettingValueClear";
            this.bbSettingValueClear.Size = new System.Drawing.Size(243, 22);
            this.bbSettingValueClear.StyleController = this.layoutControl1;
            this.bbSettingValueClear.TabIndex = 10;
            this.bbSettingValueClear.Text = "Reset";
            this.bbSettingValueClear.Click += new System.EventHandler(this.bbSettingValueClear_Click);
            // 
            // bbSettingValueSAVE
            // 
            this.bbSettingValueSAVE.Location = new System.Drawing.Point(750, 507);
            this.bbSettingValueSAVE.Name = "bbSettingValueSAVE";
            this.bbSettingValueSAVE.Size = new System.Drawing.Size(249, 22);
            this.bbSettingValueSAVE.StyleController = this.layoutControl1;
            this.bbSettingValueSAVE.TabIndex = 9;
            this.bbSettingValueSAVE.Text = "Save";
            this.bbSettingValueSAVE.Click += new System.EventHandler(this.bbSettingValueSAVE_Click);
            // 
            // gc_JobGrid
            // 
            this.gc_JobGrid.Location = new System.Drawing.Point(12, 62);
            this.gc_JobGrid.MainView = this.gridView1;
            this.gc_JobGrid.Name = "gc_JobGrid";
            this.gc_JobGrid.Size = new System.Drawing.Size(987, 441);
            this.gc_JobGrid.TabIndex = 8;
            this.gc_JobGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gc_JobGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // tb_JobNo
            // 
            this.tb_JobNo.Location = new System.Drawing.Point(133, 38);
            this.tb_JobNo.Name = "tb_JobNo";
            this.tb_JobNo.Size = new System.Drawing.Size(102, 20);
            this.tb_JobNo.StyleController = this.layoutControl1;
            this.tb_JobNo.TabIndex = 5;
            this.tb_JobNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_JobNo_KeyPress);
            // 
            // tb_MachineNo
            // 
            this.tb_MachineNo.Location = new System.Drawing.Point(133, 12);
            this.tb_MachineNo.Name = "tb_MachineNo";
            this.tb_MachineNo.Size = new System.Drawing.Size(102, 20);
            this.tb_MachineNo.StyleController = this.layoutControl1;
            this.tb_MachineNo.TabIndex = 4;
            this.tb_MachineNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_MachineNo_KeyPress);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.Machine,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem2,
            this.emptySpaceItem5,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem6});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1011, 541);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gc_JobGrid;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(991, 445);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.bbSettingValueSAVE;
            this.layoutControlItem5.Location = new System.Drawing.Point(738, 495);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(253, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.bbSettingValueClear;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 495);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(247, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(247, 495);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(491, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Machine
            // 
            this.Machine.Control = this.tb_MachineNo;
            this.Machine.Location = new System.Drawing.Point(0, 0);
            this.Machine.Name = "Machine";
            this.Machine.Size = new System.Drawing.Size(227, 26);
            this.Machine.Text = "Number of Machines";
            this.Machine.TextLocation = DevExpress.Utils.Locations.Left;
            this.Machine.TextSize = new System.Drawing.Size(118, 14);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(808, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(183, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(693, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(51, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(389, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(240, 26);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.tb_JobNo;
            this.layoutControlItem2.CustomizationFormText = "Job Type";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(227, 24);
            this.layoutControlItem2.Text = "Number of Job Types";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(118, 14);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(227, 26);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(764, 24);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.bb_Import_Problem;
            this.layoutControlItem4.Location = new System.Drawing.Point(629, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(64, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.bb_Export_Problem;
            this.layoutControlItem7.Location = new System.Drawing.Point(744, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(64, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.bb_SettingProblem;
            this.layoutControlItem8.Location = new System.Drawing.Point(300, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(227, 0);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(73, 26);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ProblemSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 541);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ProblemSettingForm";
            this.Text = "Problem Setting";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_JobGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_JobNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MachineNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Machine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit tb_MachineNo;
        private DevExpress.XtraLayout.LayoutControlItem Machine;
        private DevExpress.XtraEditors.TextEdit tb_JobNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gc_JobGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton bbSettingValueClear;
        private DevExpress.XtraEditors.SimpleButton bbSettingValueSAVE;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraEditors.SimpleButton bb_Export_Problem;
        private DevExpress.XtraEditors.SimpleButton bb_Import_Problem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton bb_SettingProblem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
    }
}