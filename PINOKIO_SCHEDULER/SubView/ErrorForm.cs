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
    public partial class ErrorForm : Form
    {
        public ErrorForm(List<string> arr, List<string> setup, List<string> processing, List<string> jobtype, List<string> setupox, List<string> vio)
        {
            InitializeComponent();

            lb_MachinArr.DataSource = arr;
            lb_Processing.DataSource = processing;
            lb_SetupTime.DataSource = setup;
            lb_JobTpye.DataSource = jobtype;
            lb_SetupOX.DataSource = setupox;
            lb_violation.DataSource = vio;
            
        }

    }
}
