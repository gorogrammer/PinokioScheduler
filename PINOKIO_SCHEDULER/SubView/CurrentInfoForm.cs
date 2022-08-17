using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PINOKIO_SCHEDULER
{
    public partial class CurrentInfoForm : Form
    {
   
        public CurrentInfoForm()
        {
            InitializeComponent();
            GetGridColumn();


        }

        public void UpdateMachineGrid(Dictionary<string,ScheduleLog> dic)
        {
            
            this.gcMachineInfo.DataSource = dic.Values.ToList();
        }

        public void UpdateRemainGrid(Dictionary<string, RemainJob> remaindic)
        {

            remaindic = remaindic.OrderByDescending(x => x.Value.RemainCount).ToDictionary(p => p.Key, p => p.Value);
            this.gcRemainJobInfo.DataSource = remaindic.Values.ToList();
        }
        private void GetGridColumn()
        {
            this.gridView2.OptionsView.ShowFooter = true;
         
           

        }
    }
}
