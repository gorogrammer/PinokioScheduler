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
    public partial class ProblemSettingForm : Form
    {
        List<string> jobTpye = new List<string>();

        DataTable DT_Problem = new DataTable();
        string _LoadCsvPath;
        public Dictionary<string, Job_Setting_Value> DicJobTypeValue
        {
            get; set;
        }
        public Problem ProblemValue
        {
            get; set;
        }
        public ProblemSettingForm()
        {
            InitializeComponent();
            MakeJobTpye();
            ProblemValue = new Problem();
            DicJobTypeValue = new Dictionary<string, Job_Setting_Value>();

        }
        public ProblemSettingForm(Problem sd)
        {
            InitializeComponent();
            MakeJobTpye();
            ProblemValue = new Problem();
            DicJobTypeValue = new Dictionary<string, Job_Setting_Value>();

            Setting_ProblemValue(sd);
        }

        public void Setting_ProblemValue(Problem sd)
        {
            tb_MachineNo.Text = sd.Machine_Count.ToString();
            tb_JobNo.Text = sd.Job_Type_Count.ToString();
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Job Type");
            dt.Columns.Add("Machine Arr");
            dt.Columns.Add("Processing Time");
            dt.Columns.Add("Setup Time");

            DataTable DT_MakeJob = dt;
           
            foreach(KeyValuePair<string,Job_Setting_Value> pair in sd.Dic_JobType_Setting)
            {

                string Avail_Machine = string.Empty;
                string processTime = string.Empty;
                int availMachineCount = pair.Value.ProcessTime_Machine.Count();
                int index = 0;
                foreach (KeyValuePair<int,int> pair_2 in pair.Value.ProcessTime_Machine)
                {
                    string sss = pair_2.Key.ToString();
                    string ttt = pair_2.Value.ToString();
                    if (index == availMachineCount-1)
                    {
                        Avail_Machine += sss;
                        processTime += ttt;

                    }
                    else
                    {
                        Avail_Machine += sss+"/";
                        processTime += ttt+"/";
                    }
            
                    index++;
                }
                DT_MakeJob.Rows.Add(pair.Key, Avail_Machine, processTime, pair.Value.SetUp_Time);
            }
            gc_JobGrid.DataSource = DT_MakeJob;

            gridView1.BestFitColumns();
        }
        private void bbSettingJob_Click(object sender, EventArgs e)
        {

        }

        private string InitMachineArr(int no)
        {
            string machinearr = string.Empty;

            for(int i =0; i < no; i++)
            {
                if(i == no-1)
                {
                    machinearr += i;
                }
                else
                {
                    machinearr += i+"/";
                }
               
            }

            return machinearr;
        }

        private string InitProcessing(int no)
        {
            string machinearr = string.Empty;

            for (int i = 0; i < no; i++)
            {
                if (i == no - 1)
                {
                    machinearr += 1;
                }
                else
                {
                    machinearr += 1 + "/";
                }

            }

            return machinearr;
        }

        private string InitSetuptime(int no)
        {
            string setuptime = string.Empty;

            for (int i = 0; i < no; i++)
            {
                if (i == no - 1)
                {
                    setuptime += 2;
                }
                else
                {
                    setuptime += 2 + ",";
                }

            }

            return setuptime;
        }

        private void MakeJobTpye()
        {
            jobTpye.Add("A");
            jobTpye.Add("B");
            jobTpye.Add("C");
            jobTpye.Add("D");
            jobTpye.Add("E");
            jobTpye.Add("F");
            jobTpye.Add("G");
            jobTpye.Add("H");
            jobTpye.Add("I");
            jobTpye.Add("J");
            jobTpye.Add("K");
            jobTpye.Add("L");
            jobTpye.Add("M");
            jobTpye.Add("N");
            jobTpye.Add("O");
            jobTpye.Add("P");
            jobTpye.Add("Q");
            jobTpye.Add("R");
            jobTpye.Add("S");
            jobTpye.Add("T");
            jobTpye.Add("U");
            jobTpye.Add("V");
            jobTpye.Add("W");
            jobTpye.Add("X");
            jobTpye.Add("Y");
            jobTpye.Add("Z");
        }

        private void bbSettingValueClear_Click(object sender, EventArgs e)
        {
            gc_JobGrid.DataSource = null;
            GridView view = new GridView(gc_JobGrid);
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ShowColumnHeaders = false;
            //gc_JobGrid.MainView = view;
        }

        private void bbSettingValueSAVE_Click(object sender, EventArgs e)
        {

            bool error = false;
            DicJobTypeValue.Clear();
            ProblemValue.Machine_Count = Convert.ToInt32(tb_MachineNo.Text);
            ProblemValue.Job_Type_Count = Convert.ToInt32(tb_JobNo.Text);

            for (int i=0; i < gridView1.RowCount; i++)
            {
                Job_Setting_Value jobvalue = new Job_Setting_Value();
                List<object> sd = gridView1.GetDataRow(i).ItemArray.ToList();
                jobvalue.TYPE = sd[0].ToString();
                jobvalue.SetUp_Time = Convert.ToInt32(sd[3]);
                if(jobvalue.SetUp_Time >=21)
                {
                    MessageBox.Show(jobvalue.TYPE+"의 "+"Setup Time은 20 이하로 설정 부탁드립니다.");
                    error = true; 
                    break;
                }
              
                if(sd[1].ToString() == "" && sd[2].ToString() == "")
                {
                    if (sd[1] == "")
                    {
                        if (MessageBox.Show(jobvalue.TYPE + "의 Machine 할당이 되어있지 않습니다.", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //jobvalue.ProcessTime_Machine.Add(Convert.ToInt32(""), Convert.ToInt32(""));
                        }
                        else
                        {
                            error = true;
                            continue;
                        }
                    }
                       
                }
                else if(!sd[1].ToString().Contains('/'))
                {
                    jobvalue.ProcessTime_Machine.Add(Convert.ToInt32(sd[1].ToString()), Convert.ToInt32(sd[2].ToString()));
                }
                else if(sd[1].ToString().Contains('/'))
                {
                    string[] machine_arr = sd[1].ToString().Split('/');
                    string[] processing = sd[2].ToString().Split('/');
                    if(machine_arr.Length != processing.Length)
                    {
                        MessageBox.Show(jobvalue.TYPE + "의 " + "Machine Arr과 Processing Time 설정이 잘 못되었습니다.");
                        error = true;
                        break;
                    }

                    for (int x = 0; x < machine_arr.Count(); x++)
                    {
                        jobvalue.ProcessTime_Machine.Add(Convert.ToInt32(machine_arr[x]), Convert.ToInt32(processing[x]));
                    }
                }

                DicJobTypeValue.Add(sd[0].ToString(), jobvalue);
            }
            if(!error)
            {
                ProblemValue.Dic_JobType_Setting = DicJobTypeValue;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
          
        }

        private void bb_Export_Problem_Click(object sender, EventArgs e)
        {

            try
            {
                DT_Problem = gc_JobGrid.DataSource as DataTable;
                SaveFileDialog fileDlg = new SaveFileDialog();
                fileDlg.Filter = "csv File (*.csv)|*.CSV|All files (*.*)|*.*";

                string debugFolderPath = @"C:\VAMS";
                DirectoryInfo di = new DirectoryInfo(debugFolderPath);

                string problemPath = @"C:\VAMS\ProblemSetting_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "_" + DateTime.Now.Hour + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".csv";

                if (di.Exists == false)
                    di.Create();

                //fileDlg.Filter = "xls File (*.xls)|*.XLS|All files (*.*)|*.*";
                FileStream fs = new FileStream(problemPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                StreamWriter csvExport = new StreamWriter(fs, System.Text.Encoding.UTF8);

                csvExport.Write("Number of Machines, " + tb_MachineNo.Text.ToString());
                csvExport.Write(csvExport.NewLine);

                csvExport.Write("Number of Jobs, " + tb_JobNo.Text.ToString());
                csvExport.Write(csvExport.NewLine);



                string line = string.Join(",", DT_Problem.Columns.Cast<object>());
                csvExport.WriteLine(line);

                foreach (DataRow item in DT_Problem.Rows)
                {
                    line = string.Join(",", item.ItemArray.Cast<object>());
                    csvExport.WriteLine(line);
                }


                csvExport.Close();
                fs.Close();

                MessageBox.Show("Export 완료");
            }
            catch
            {
                MessageBox.Show("Export 실패");
            }
     


            
        }
        void linkMainReport_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {

            string tb = tb_MachineNo.Text.ToString() ;
            e.Graph.DrawString(tb, new RectangleF(0 ,0, 1, 1));
      
        }

        void linkMainReport_CreateDetailArea_1(object sender, CreateAreaEventArgs e)
        {

            string tb = tb_JobNo.Text.ToString();
            e.Graph.DrawString(tb, new RectangleF(0, 1, 1, 1));
        }

        private void bb_Import_Problem_Click(object sender, EventArgs e)
        {
            if (ReadFiles())
            {
                

            }
            else
            {
                MessageBox.Show("형식에 맞지 않는 데이터입니다.");
            }
        }
        public bool ReadFiles()
        {
            _LoadCsvPath = GeneralFunc.OpenFiles();

            if (_LoadCsvPath == string.Empty)
                return false;

            List<string> lstReadCSV = GeneralFunc.ReadCsv(_LoadCsvPath);
            if (lstReadCSV == null)
                return false;
            else
            {
                char tt = ',';
                string[] machineNo = lstReadCSV[0].Split(',');
                string[] jobNo = lstReadCSV[1].Split(',');
                tb_MachineNo.Text = machineNo[1].Replace(" ","");
                tb_JobNo.Text = jobNo[1].Replace(" ", "");
                DataTable dt = new DataTable();
                dt.Columns.Add("Job Type");
                dt.Columns.Add("Machine Arr");
                dt.Columns.Add("Processing Time");
                dt.Columns.Add("Setup Time");

                for (int i =3; i < lstReadCSV.Count; i++)
                {
                

                    DataTable DT_MakeJob = dt;



                    string dsdsd = lstReadCSV[i].Replace("\"", string.Empty);
                    string[] splitString = dsdsd.Split(',');
                    //string[] splitString = lstReadCSV[i].Split(',');

                    DT_MakeJob.Rows.Add(splitString[0], splitString[1], splitString[2], splitString[3]);
                    
                    gc_JobGrid.DataSource = DT_MakeJob;

                    GridView gridView = this.gc_JobGrid.MainView as GridView;
                }
            }

            

            //리스트로 이루어진 스케쥴 초기 모델

            return true;
        }

      
        public bool ReadFilesXls()
        {
            _LoadCsvPath = GeneralFunc.OpenFilesXls();

            if (_LoadCsvPath == string.Empty)
                return false;

            List<string> lstReadCSV = GeneralFunc.ReadXls(_LoadCsvPath);
            if (lstReadCSV == null)
                return false;
            else
            {
                tb_MachineNo.Text = lstReadCSV[0].Replace(",", "");
                tb_JobNo.Text = lstReadCSV[1].Replace(",", "");
                DataTable dt = new DataTable();
                dt.Columns.Add("Job Type");
                dt.Columns.Add("Machine Arr");
                dt.Columns.Add("Processing Time");
                dt.Columns.Add("Setup Time");

                for (int i = 3; i < lstReadCSV.Count; i++)
                {


                    DataTable DT_MakeJob = dt;



                    string[] splitString = lstReadCSV[i].Split(',');


                    DT_MakeJob.Rows.Add(splitString[0], splitString[1], splitString[2], splitString[3]);

                    gc_JobGrid.DataSource = DT_MakeJob;

                    GridView gridView = this.gc_JobGrid.MainView as GridView;
                }
            }



            //리스트로 이루어진 스케쥴 초기 모델

            return true;
        }

        private void bb_SettingProblem_Click(object sender, EventArgs e)
        {
            if (tb_JobNo.Text == "")
            {
                MessageBox.Show("Job Type 수 입력이 부탁드립니다.");
                return;
            }

            if (tb_MachineNo.Text == "")
            {
                MessageBox.Show("Machine 수 입력이 부탁드립니다.");
                return;
            }
            if (Convert.ToInt32(tb_JobNo.Text) >= 27)
            {
                MessageBox.Show("Job Type 수는 26개 이하로 입력 부탁드립니다.");
                return;
            }
            if (Convert.ToInt32(tb_MachineNo.Text) >= 31)
            {
                MessageBox.Show("Machine 수는 30개 이하로 입력 부탁드립니다.");
                return;
            }



            DataTable dt = new DataTable();
            dt.Columns.Add("Job Type");
            dt.Columns.Add("Machine Arr");
            dt.Columns.Add("Processing Time");
            dt.Columns.Add("Setup Time");


            DataTable DT_MakeJob = dt;
            string Init_MachineArr = InitMachineArr(Convert.ToInt32(tb_MachineNo.Text));
            string Init_SetupTime = InitSetuptime(Convert.ToInt32(tb_JobNo.Text));
            string Init_Processing = InitProcessing(Convert.ToInt32(tb_MachineNo.Text));


            for (int i = 0; i < Convert.ToInt32(tb_JobNo.Text); i++)
            {
                DT_MakeJob.Rows.Add(jobTpye[i], Init_MachineArr, Init_Processing, 2);
            }
            gc_JobGrid.DataSource = DT_MakeJob;

            GridView gridView = this.gc_JobGrid.MainView as GridView;

            //gridView.BestFitColumns();
            gridView.Columns["Job Type"].Width = 80;
            gridView.Columns["Job Type"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["Job Type"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridView.Columns["Setup Time"].Width = 80;
            gridView.Columns["Setup Time"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["Setup Time"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;


            gridView1.BestFitColumns();
        }

        private void tb_MachineNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;

            }
        }

        private void tb_JobNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;

            }
        }
    }
}
