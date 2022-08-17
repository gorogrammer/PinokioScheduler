
namespace PINOKIO_SCHEDULER.SubView
{
    partial class SelectChartForm
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
            this.SelectChart = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.SelectChart)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectChart
            // 
            this.SelectChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectChart.Legend.Name = "Default Legend";
            this.SelectChart.Location = new System.Drawing.Point(0, 0);
            this.SelectChart.Name = "SelectChart";
            this.SelectChart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.SelectChart.Size = new System.Drawing.Size(914, 566);
            this.SelectChart.TabIndex = 0;
            // 
            // SelectChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 566);
            this.Controls.Add(this.SelectChart);
            this.Name = "SelectChartForm";
            this.Text = "Chart";
            ((System.ComponentModel.ISupportInitialize)(this.SelectChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraCharts.ChartControl SelectChart;
    }
}