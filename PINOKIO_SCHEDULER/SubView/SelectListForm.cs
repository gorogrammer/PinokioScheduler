using DevExpress.XtraCharts;
using PINOKIO_SCHEDULER.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PINOKIO_SCHEDULER.Model;
using PINOKIO_SCHEDULER.GeneralFunctions;

namespace PINOKIO_SCHEDULER.SubView
{
    public partial class SelectListForm : Form
    {

        public MainForm_Ribbon Main;
        public DataTable _seltDT;

        public void load_SelectChart(string listName)
        {
            if (listName == "SCHEDULE")
            {
                _seltDT = GeneralFunc.GetNewScheduleListDT();

                SelectGrid.DataSource = Main.Grid_WF_SCHEDULELIST.DataSource;
            }
            else if(listName == "JOB")
            {
                SelectGrid.DataSource = Main.Grid_WF_JOB.DataSource;
            }



        }
        public SelectListForm()
        {
            InitializeComponent();
        }
    }
}
