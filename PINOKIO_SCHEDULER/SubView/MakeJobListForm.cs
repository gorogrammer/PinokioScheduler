using DevExpress.XtraGrid.Columns;
using PINOKIO_SCHEDULER.JOB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PINOKIO_SCHEDULER.GeneralFunctions;

namespace PINOKIO_SCHEDULER.SubView
{
    public partial class MakeJobListForm : Form
    {
        public DataTable JobListTable
        { get; set; }
        public Problem Problem_Value
        {
            get; set;
        }
        public Dictionary<string, double> DicJobTypeWeight
        {
            get; set;
        }
        List<string> sdsd = new List<string>();
        public MakeJobListForm()
        {
            InitializeComponent();
            Problem_Value = new Problem();
            DicJobTypeWeight = new Dictionary<string, double>();
            JobListTable = new DataTable();


        }
        public void SettingJobTypeWeight(Problem sd)
        {
            double JobtypeCount = Convert.ToDouble(sd.Job_Type_Count);
            int counts = sd.Job_Type_Count;
            foreach (KeyValuePair<string, Job_Setting_Value> pair in sd.Dic_JobType_Setting)
            {
                double pp = ((double)1 / (double)JobtypeCount);
                double ss = Math.Round(pp, 3);
                DicJobTypeWeight.Add(pair.Key, ss);

            }

            DataTable dt = new DataTable();

            dt.Columns.Add("Job Type");
            dt.Columns.Add("Generation \n Probability");

            DataTable DT_MakeJob_Wegiht = dt;

            foreach (KeyValuePair<string, double> piar_1 in DicJobTypeWeight)
            {
                DT_MakeJob_Wegiht.Rows.Add(piar_1.Key, piar_1.Value);
            }

            gc_Weight.DataSource = DT_MakeJob_Wegiht;

            if (JobListTable.Rows.Count > 0)
            {
                gc_MakeJobList.DataSource = JobListTable;
            }

        }
        private void RefreshWegih()
        {
            DicJobTypeWeight.Clear();

            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                string job = string.Empty;
                double weight = 0;
                foreach (GridColumn column in gridView1.VisibleColumns)
                {
                    if (column.FieldName == "Job Type")
                        job = gridView1.GetRowCellValue(i, column).ToString();
                    else if (column.FieldName == "Generation \n Probability")
                        weight = Convert.ToDouble(gridView1.GetRowCellValue(i, column));
                }
                DicJobTypeWeight.Add(job, weight);
            }
        }

        private void bb_JobListMake_Click(object sender, EventArgs e)
        {
            if (tb_JobCount.Text == "")
                MessageBox.Show("Job Count 입력 부탁드립니다.");
            else
            {

                int counts = Convert.ToInt32(tb_JobCount.Text);
                int ID = 0;
                List<double> duedatelist = new List<double>();
                List<string> jobtypeList = new List<string>();
                int qunt_Avg = Convert.ToInt32(tb_Quantity_Avg.Text);
                int qunt_Var = Convert.ToInt32(tb_Quantity_Var.Text);

                double tightness = Convert.ToDouble(tb_DueDate_thigt.Text);


                DataTable dt = new DataTable();
                dt.Columns.Add("Job ID");
                dt.Columns.Add("Job Type");
                dt.Columns.Add("Quantity", typeof(Int32));
                dt.Columns.Add("Due Date", typeof(Int32));

                DataTable DT_MakeJob_Wegiht = dt;

                RefreshWegih();
                WeightedRandom randomjop = new WeightedRandom(DicJobTypeWeight);
                for (int i = 0; i < counts; i++)
                {
                    string typeName = randomjop.getRandom(i);
                    jobtypeList.Add(typeName);
                }

                int dueRand_Max = MaxA(Problem_Value.Dic_JobType_Setting, jobtypeList);
                for (int i = 0; i < counts; i++)
                {
                    string typeName = jobtypeList[i];
                    sdsd.Add(typeName);

                    int Quantity_Mix = Maths.MinQuant(Problem_Value.Dic_JobType_Setting[typeName].ProcessTime_Machine);
                    int qunt = Maths.Normal_Random(i, qunt_Avg, qunt_Var);
                    int RandomDueMin = qunt * Quantity_Mix;

                    int MaxJobProsTime = Maths.MaxQuant(Problem_Value.Dic_JobType_Setting[typeName].ProcessTime_Machine);
                    int duedateA = dueRand_Max / RandomDueMin;
                    int RanDue = Convert.ToInt32(Maths.RandomDue(i, dueRand_Max, tightness, RandomDueMin, MaxJobProsTime, duedateA));
                    DT_MakeJob_Wegiht.Rows.Add(i, typeName, qunt, RanDue);
                    duedatelist.Add(RanDue);
                }


                gc_MakeJobList.DataSource = DT_MakeJob_Wegiht;
                JobListTable = DT_MakeJob_Wegiht;
                tb_DueDate_Max.Text = duedatelist.Max().ToString();
                tb_DueDate_Min.Text = duedatelist.Min().ToString();
            }

        }
        
        private int MaxA(Dictionary<string, Job_Setting_Value> dic, List<string> listjobtype)
        {
            int max = 0;
            for (int i = 0; i < listjobtype.Count; i++)
            {
                max += Maths.MaxQuant(Problem_Value.Dic_JobType_Setting[listjobtype[i]].ProcessTime_Machine);
            }


            return max;
        }        
        private string GetRandom(Dictionary<string, double> dic, int i)
        {
            Random sd = new Random();
            sd.Next(1, 3000);
            Random random = new Random((Guid.NewGuid().GetHashCode() * sd.Next() * (int)DateTime.Now.Millisecond + i) % (i + sd.Next()));
            double pivot = random.NextDouble();
            //double pivot = rd.NextDouble();

            double acc = 0;


            foreach (KeyValuePair<string, double> pair in dic)
            {
                acc += pair.Value;
                if (pivot <= acc)
                {
                    return pair.Key.ToString();
                }
                else
                {
                    //pivot -= pair.Value;
                }
            }
            return null;

        }

        private void bb_JobListSave_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tb_JobCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;

            }
        }
    }
    class WeightedRandom
    {

        private Dictionary<string, double> dicJobRand;


        public WeightedRandom(Dictionary<string, double> target)
        {

            dicJobRand = target;
            double totalWeight = 0;

            foreach (KeyValuePair<string, double> pair in dicJobRand)
            {
                totalWeight += pair.Value;
            }

            Dictionary<string, double> dicJobRand_sorted = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> pair in dicJobRand)
            {
                dicJobRand_sorted.Add(pair.Key, pair.Value / totalWeight);

            }

            // dicJobRand_sorted = dicJobRand_sorted.OrderBy(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            this.dicJobRand = dicJobRand_sorted;
        }

        public String getRandom(int i)
        {

            Random sd = new Random();

            Random random = new Random((Guid.NewGuid().GetHashCode() * sd.Next() * (int)DateTime.Now.Millisecond + i) % (i + sd.Next()));
            double pivot = random.NextDouble();
            double acc = 0;


            foreach (KeyValuePair<string, double> pair in dicJobRand)
            {
                acc += pair.Value;

                if (pivot <= acc)
                {
                    return pair.Key;
                }
                else if (pivot > acc)
                {

                }

            }

            return null;
        }
    }
}
