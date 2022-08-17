
namespace PINOKIO_SCHEDULER.SubView
{
    partial class FormLaunchScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLaunchScreen));
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.LB_LoadingText = new DevExpress.XtraEditors.LabelControl();
            this.LB_TITLE = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarControl1.Location = new System.Drawing.Point(12, 213);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.ShowTitle = true;
            this.progressBarControl1.Properties.TextOrientation = DevExpress.Utils.Drawing.TextOrientation.Horizontal;
            this.progressBarControl1.ShowProgressInTaskBar = true;
            this.progressBarControl1.Size = new System.Drawing.Size(570, 73);
            this.progressBarControl1.TabIndex = 22;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEdit2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.Location = new System.Drawing.Point(124, 22);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.AllowFocused = false;
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowMenu = false;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit2.Size = new System.Drawing.Size(347, 213);
            this.pictureEdit2.TabIndex = 21;
            // 
            // LB_LoadingText
            // 
            this.LB_LoadingText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_LoadingText.Appearance.Options.UseTextOptions = true;
            this.LB_LoadingText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LB_LoadingText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LB_LoadingText.Location = new System.Drawing.Point(105, 263);
            this.LB_LoadingText.Name = "LB_LoadingText";
            this.LB_LoadingText.Size = new System.Drawing.Size(393, 14);
            this.LB_LoadingText.TabIndex = 19;
            this.LB_LoadingText.Text = "Loading...";
            // 
            // LB_TITLE
            // 
            this.LB_TITLE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.LB_TITLE.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.LB_TITLE.Appearance.Options.UseFont = true;
            this.LB_TITLE.Appearance.Options.UseTextOptions = true;
            this.LB_TITLE.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LB_TITLE.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LB_TITLE.Location = new System.Drawing.Point(96, 192);
            this.LB_TITLE.Name = "LB_TITLE";
            this.LB_TITLE.Size = new System.Drawing.Size(400, 74);
            this.LB_TITLE.TabIndex = 20;
            this.LB_TITLE.Text = "CARLO DLBOX";
            // 
            // FormLaunchScreen
            // 
            this.ActiveGlowColor = System.Drawing.Color.White;
            this.AutoFitImage = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(593, 328);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.pictureEdit2);
            this.Controls.Add(this.LB_LoadingText);
            this.Controls.Add(this.LB_TITLE);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.InactiveGlowColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLaunchScreen";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowMode = DevExpress.XtraSplashScreen.ShowMode.Image;
            this.SplashImageOptions.Image = global::PINOKIO_SCHEDULER.Properties.Resources.Splash_Inu_blue;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.LabelControl LB_LoadingText;
        private DevExpress.XtraEditors.LabelControl LB_TITLE;
    }
}
