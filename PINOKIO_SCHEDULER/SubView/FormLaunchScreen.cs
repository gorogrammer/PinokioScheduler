using DevExpress.Utils.Drawing;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PINOKIO_SCHEDULER.SubView
{
    public partial class FormLaunchScreen : SplashScreen
    {
        public FormLaunchScreen()
        {
            InitializeComponent();
        }

        #region Overrides

        protected override void DrawBackground(PaintEventArgs e)
        {
            if (!UseCustomBackColor)
            {
                base.DrawBackground(e);
                return;
            }
            using (GraphicsCache cache = new GraphicsCache(e))
            {
                DrawCustomBackground(cache);
            }
        }
        protected void DrawCustomBackground(GraphicsCache graphicsCache)
        {
            graphicsCache.FillRectangle(ForeColor, ClientRectangle);
        }
        protected virtual bool UseCustomBackColor { get { return true; } }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);

            switch (cmd)
            {
                case SplashScreenCommand.RECEIVE_VERSION:
                    this.LB_TITLE.Text += " " + arg.ToString();
                    break;
                case SplashScreenCommand.SETMAXPGBVALUE:
                    this.progressBarControl1.Properties.Maximum = Convert.ToInt32(arg);
                    break;
                case SplashScreenCommand.SETCURRENTVALUE:
                    this.progressBarControl1.Position = Convert.ToInt32(arg);
                    break;
            }
        }

        #endregion

        public enum SplashScreenCommand
        {
            RECEIVE_VERSION,
            SETCURRENTVALUE,
            SETMAXPGBVALUE,
            ADDPGBVALUE
        }
    }
}