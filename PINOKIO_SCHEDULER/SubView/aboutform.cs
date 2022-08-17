using DevExpress.Export;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using PINOKIO_SCHEDULER.GeneralFunctions;
using PINOKIO_SCHEDULER.JOB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PINOKIO_SCHEDULER.SubView
{
    public partial class aboutform : Form
    {
        public aboutform()
        {
            InitializeComponent();

            Image img =  Properties.Resources.INU_워드마크;
            this.pb_about.Image = img;
            this.pb_about.SizeMode = PictureBoxSizeMode.StretchImage;

        }

       
    }
}
