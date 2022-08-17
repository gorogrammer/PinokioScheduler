using DevExpress.Export;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using PINOKIO_SCHEDULER.Definitions;
using PINOKIO_SCHEDULER.GeneralFunctions;
using PINOKIO_SCHEDULER.JOB;
using PINOKIO_SCHEDULER.Model;
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
    public partial class ReportForm : Form
    {
        public MainForm_Ribbon Main;

        public ReportForm()
        {
            InitializeComponent();
 

          
        }
        //public void InitCombo_Chart()
        //{
        //    List<string> cb_chartlist = new List<string>();
        //    cb_chartlist.Add("Tardy");
        //    cb_chartlist.Add("Set Up");
        //    cb_chartlist.Add("Utilities");

        //    cb_Chart.DataSource = cb_chartlist;
            
        //}

        //public void InitCombo_Grid()
        //{
        //    List<string> cb_gridlist = new List<string>();
        //    cb_gridlist.Add("Machine");
        //    cb_gridlist.Add("Job");
          
        

        //    cb_Grid.DataSource = cb_gridlist;

        //}

        private void bb_Search_Report_Click(object sender, EventArgs e)
        {
            MakeUtilChart();
            MakeTardyCountChart();
            MakeSetupChart();
            MakeTardySumChart();


            if (Main.Problem_Value.Dic_JobType_Setting.Count > 0)
                MakeProblemGrid();
              

            MakeJobGrid();
            MakeMachineGrid();

            Grid_Report_Machine.Refresh();
            Grid_Report_Job.Refresh();
        }

        private void MakeTardySumChart()
        {
            Series TardySeries = new Series(DEF.GRAPH_TARDY, ViewType.StackedLine);
            Series TardySumSeries = new Series("Tardiness Accum", ViewType.StackedLine);
            Chart_Report_TardySum.Series.Add(TardySeries);
            Chart_Report_TardySum.Series.Add(TardySumSeries);
            DataTable _seltDT_Sum = new DataTable();
            _seltDT_Sum.Columns.Add("Time", typeof(Int32));
            _seltDT_Sum.Columns.Add("Value", typeof(Int32));
            _seltDT_Sum.Columns.Add("Accum", typeof(Int32));
            XYDiagram diagram = Chart_Report_TardySum.Diagram as XYDiagram;
            ((XYDiagram)Chart_Report_TardySum.Diagram).SecondaryAxesY.Clear();
            SecondaryAxisY secondAxisY = new SecondaryAxisY();
            ((XYDiagram)Chart_Report_TardySum.Diagram).SecondaryAxesY.Add(secondAxisY);

            //TardySeries.ShowInLegend = false;

            diagram.AxisX.WholeRange.SideMarginsValue = 0;

            TardySeries.DataSource = _seltDT_Sum;
            TardySeries.ArgumentScaleType = ScaleType.Numerical;
            TardySeries.ArgumentDataMember = "Time";
            TardySeries.ValueScaleType = ScaleType.Numerical;

            TardySumSeries.DataSource = _seltDT_Sum;
            TardySumSeries.ArgumentScaleType = ScaleType.Numerical;
            TardySumSeries.ArgumentDataMember = "Time";
            TardySumSeries.ValueScaleType = ScaleType.Numerical;
            ((LineSeriesView)Chart_Report_TardySum.Series[1].View).AxisY = ((XYDiagram)Chart_Report_TardySum.Diagram).SecondaryAxesY[0];


            foreach (KeyValuePair<int, TimeGrapgh> pair in Main._dicGraphTime)
            {
                _seltDT_Sum.Rows.Add(pair.Key, pair.Value.TardySum, pair.Value.TardyAccum);
            }

            Chart_Report_TardySum.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });
            Chart_Report_TardySum.Series[1].ValueDataMembers.AddRange(new string[] { "Accum" });


            ((XYDiagram)Chart_Report_TardySum.Diagram).AxisX.Title.Text = "Time";
            ((XYDiagram)Chart_Report_TardySum.Diagram).AxisX.Title.Visibility = DefaultBoolean.True;

            ((XYDiagram)Chart_Report_TardySum.Diagram).AxisY.Title.Text = "Tardiness Sum";
            ((XYDiagram)Chart_Report_TardySum.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;

            Chart_Report_TardySum.Refresh();
        }

        private void MakeTardyCountChart()
        {
            Series TardySeries = new Series(DEF.GRAPH_TARDY, ViewType.StackedLine);
            Chart_Report_Tardy_Count.Series.Add(TardySeries);
            
            DataTable _seltDT_Count = new DataTable();
            _seltDT_Count.Columns.Add("Time", typeof(Int32));
            _seltDT_Count.Columns.Add("Value", typeof(Int32));

            XYDiagram diagram = Chart_Report_Tardy_Count.Diagram as XYDiagram;
            diagram.AxisX.WholeRange.SideMarginsValue = 0;

            TardySeries.ShowInLegend = false;
            TardySeries.DataSource = _seltDT_Count;
            TardySeries.ArgumentScaleType = ScaleType.Numerical;
            TardySeries.ArgumentDataMember = "Time";
            TardySeries.ValueScaleType = ScaleType.Numerical;

            foreach (KeyValuePair<int, TimeGrapgh> pair in Main._dicGraphTime)
            {
                _seltDT_Count.Rows.Add(pair.Key, pair.Value.TardyCount);
            }

            Chart_Report_Tardy_Count.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });


            ((XYDiagram)Chart_Report_Tardy_Count.Diagram).AxisX.Title.Text = "Time";
            ((XYDiagram)Chart_Report_Tardy_Count.Diagram).AxisX.Title.Visibility = DefaultBoolean.True;

            ((XYDiagram)Chart_Report_Tardy_Count.Diagram).AxisY.Title.Text = "Tardiness Count";
            ((XYDiagram)Chart_Report_Tardy_Count.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;

            Chart_Report_Tardy_Count.Refresh();
        }

        private void MakeSetupChart()
        {
            Series SetupSeries = new Series(DEF.GRAPH_SETUP, ViewType.StackedLine);
            chart_Report_SetUp.Series.Add(SetupSeries);
            DataTable _seltDT_Setup = new DataTable(DEF.GRAPH_SETUP);
            _seltDT_Setup.Columns.Add("Time", typeof(Int32));
            _seltDT_Setup.Columns.Add("Value", typeof(Int32));

            XYDiagram diagram = chart_Report_SetUp.Diagram as XYDiagram;
            diagram.AxisX.WholeRange.SideMarginsValue = 0;

            SetupSeries.ShowInLegend = false;
            SetupSeries.DataSource = _seltDT_Setup;
            SetupSeries.ArgumentScaleType = ScaleType.Numerical;
            SetupSeries.ArgumentDataMember = "Time";
            SetupSeries.ValueScaleType = ScaleType.Numerical;
            foreach (KeyValuePair<int, TimeGrapgh> pair in Main._dicGraphTime)
            {
                _seltDT_Setup.Rows.Add(pair.Key, pair.Value.SetUpSum);
            }
            chart_Report_SetUp.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });


            ((XYDiagram)chart_Report_SetUp.Diagram).AxisX.Title.Text = "Time";
            ((XYDiagram)chart_Report_SetUp.Diagram).AxisX.Title.Visibility = DefaultBoolean.True;

            ((XYDiagram)chart_Report_SetUp.Diagram).AxisY.Title.Text = "Setup Time Sum";
            ((XYDiagram)chart_Report_SetUp.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;

            chart_Report_SetUp.Refresh();
        }

        private void MakeUtilChart()
        {
                //리소스
                Series ResourceSeries = new Series(DEF.GRAPH_RESOURCE, ViewType.Bar);
                Chart_Report_Util.Series.Add(ResourceSeries);
                ResourceSeries.View.Colorizer = GeneralFunc.CreateColorizer(1);

                DataTable _seltDT_util = new DataTable(DEF.GRAPH_RESOURCE);
                _seltDT_util.Columns.Add(DEF.GRAPH_RESOURCE_X, typeof(Int32));
                _seltDT_util.Columns.Add(DEF.GRAPH_RESOURCE_Y, typeof(double));
            ResourceSeries.ShowInLegend = false;



            ResourceSeries.DataSource = _seltDT_util;
                ResourceSeries.ArgumentScaleType = ScaleType.Numerical;
                ResourceSeries.ArgumentDataMember = DEF.GRAPH_RESOURCE_X;
                ResourceSeries.ValueScaleType = ScaleType.Numerical;


                foreach (MachineUtilities util in Main._lstGraphicModel[Main._CurrentStep - 1].lstMachineUtilities)
                    _seltDT_util.Rows.Add(util.MachineIndex, Math.Round(util.Uitility_CurrenetRuned, 2));
                Chart_Report_Util.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });

            ((XYDiagram)Chart_Report_Util.Diagram).AxisX.Title.Text = "Machine";
            ((XYDiagram)Chart_Report_Util.Diagram).AxisX.Title.Visibility = DefaultBoolean.True;

            ((XYDiagram)Chart_Report_Util.Diagram).AxisY.Title.Text = "Util";
            ((XYDiagram)Chart_Report_Util.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
            Chart_Report_Util.Refresh();

        }


        private void MakeMachineGrid()
        {

            DataTable dt_Machine = new DataTable();

            dt_Machine.Columns.Add("Machine ID");
            dt_Machine.Columns.Add("Work Count", typeof(Int32));
            dt_Machine.Columns.Add("Processing Time", typeof(double));
            dt_Machine.Columns.Add("# Violations", typeof(Int32));
            dt_Machine.Columns.Add("MakeSpan", typeof(Int32));
            dt_Machine.Columns.Add("IDLE Time", typeof(Int32));
            dt_Machine.Columns.Add("SetUp Time", typeof(Int32));
            dt_Machine.Columns.Add("Util", typeof(Double));
            dt_Machine.Columns.Add("Total Violation Time", typeof(Int32));


            foreach (KeyValuePair<string, MachineNode> pair in Main.DicMachine)
            {
                dt_Machine.Rows.Add(pair.Key.Replace("M",""), pair.Value.WorkCount, pair.Value.TotalworkTime, pair.Value.DueDateJob.Values.Count(), pair.Value.MakeSpan, pair.Value.TotalIdleTime, pair.Value.TotalsetupTime, Math.Round(pair.Value.Util, 2) * 100,pair.Value.TotalViolation);

            }
            Grid_Report_Machine.DataSource = dt_Machine;
            gridView2.BestFitColumns();
        }

        private void MakeProblemGrid()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Job Type");
            dt.Columns.Add("Machine Arr");
            dt.Columns.Add("Processing Time");
            dt.Columns.Add("Setup Time");



            foreach (KeyValuePair<string, Job_Setting_Value> pair in Main.Problem_Value.Dic_JobType_Setting)
            {

                string Avail_Machine = string.Empty;
                string processTime = string.Empty;
                int availMachineCount = pair.Value.ProcessTime_Machine.Count();
                int index = 0;
                foreach (KeyValuePair<int, int> pair_2 in pair.Value.ProcessTime_Machine)
                {
                    string sss = pair_2.Key.ToString();
                    string ttt = pair_2.Value.ToString();
                    if (index == availMachineCount - 1)
                    {
                        Avail_Machine += sss;
                        processTime += ttt;

                    }
                    else
                    {
                        Avail_Machine += sss + "/";
                        processTime += ttt + "/";
                    }

                    index++;
                }
                dt.Rows.Add(pair.Key, Avail_Machine, processTime, pair.Value.SetUp_Time);
            }
            Grid_Problem.DataSource = dt;

            gridView3.BestFitColumns();
        }

        private void MakeJobGrid()
        {
            DataTable dt_Job = new DataTable();
            dt_Job.Columns.Add("ID_LOT");
            dt_Job.Columns.Add("Machine ID");
            dt_Job.Columns.Add("ProcessingTime", typeof(Int32));
            dt_Job.Columns.Add("StartTime", typeof(Int32));
            dt_Job.Columns.Add("EndTime", typeof(Int32));
            dt_Job.Columns.Add("DueTime", typeof(Int32));
            dt_Job.Columns.Add("SetUpTime", typeof(Int32));
            dt_Job.Columns.Add("Violation", typeof(Int32));



            foreach (KeyValuePair<string, ScheduleModel> pair in Main.DicJobInfo)
            {
                dt_Job.Rows.Add(pair.Key, pair.Value.ID_Machine, pair.Value.ProcessingTime, pair.Value.StartTime, pair.Value.EndTime, pair.Value.DueTime, pair.Value.SetUpTime, pair.Value.Violation);
            }
            Grid_Report_Job.DataSource = dt_Job;
            gridView2.BestFitColumns();
        }
        private void bb_Eport_Report_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog fileDlg = new SaveFileDialog();
                fileDlg.Filter = "csv File (*.csv)|*.CSV|All files (*.*)|*.*";
                Main.reportCell = true;
                Main.bt_Duedate_CheckedChanged(null, null);
                CompositeLink composLink = new CompositeLink(new PrintingSystem());

                CompositeLink composLink_All = new CompositeLink(new PrintingSystem());

                PrintableComponentLink pcLink_Daytime = new PrintableComponentLink();
                PrintableComponentLink pcLink_Problem = new PrintableComponentLink();
                PrintableComponentLink pcLink_Machine = new PrintableComponentLink();
                PrintableComponentLink pcLink_Job = new PrintableComponentLink();
                PrintableComponentLink pcLink_TardySum = new PrintableComponentLink();
                PrintableComponentLink pcLink_TardyCount = new PrintableComponentLink();

                PrintableComponentLink pcLink_Setup = new PrintableComponentLink();
                PrintableComponentLink pcLink_Util = new PrintableComponentLink();
                PrintableComponentLink pcLink_Schedule = new PrintableComponentLink();

                Link linkMainReport_DayTime = new Link();
                linkMainReport_DayTime.CreateDetailArea +=
                    new CreateAreaEventHandler(linkGrid1Report_Current);


                Link linkMainReport_Problem = new Link();
                linkMainReport_Problem.CreateDetailArea +=
                    new CreateAreaEventHandler(linkGrid1Report_Chart_Problem);


                Link linkMainReport_Machine = new Link();
                linkMainReport_Machine.CreateDetailArea +=
                    new CreateAreaEventHandler(linkMainReport_Create_Machine);

                Link linkMainReport_Job = new Link();
                linkMainReport_Job.CreateDetailArea +=
                    new CreateAreaEventHandler(linkGrid1Report_Create_Job);

                Link linkGrid1Report_TardySum = new Link();
                linkGrid1Report_TardySum.CreateDetailArea +=
                    new CreateAreaEventHandler(linkGrid1Report_Chart_TardySUM);

                Link linkGrid1Report_TardyCount = new Link();
                linkGrid1Report_TardyCount.CreateDetailArea +=
                    new CreateAreaEventHandler(linkGrid1Report_Chart_TardyCount);

                Link linkGrid1Report_Setup = new Link();
                linkGrid1Report_Setup.CreateDetailArea +=
                    new CreateAreaEventHandler(linkGrid1Report_Chart_SetUp);

                Link linkGrid1Report_Util = new Link();
                linkGrid1Report_Util.CreateDetailArea +=
                    new CreateAreaEventHandler(linkGrid1Report_Chart_Util);

                pcLink_Problem.Component = this.Grid_Problem;
                pcLink_Machine.Component = this.Grid_Report_Machine;
                pcLink_Job.Component = this.Grid_Report_Job;

                pcLink_TardySum.Component = this.Chart_Report_TardySum;
                pcLink_TardyCount.Component = this.Chart_Report_Tardy_Count;
                pcLink_Setup.Component = this.chart_Report_SetUp;
                pcLink_Util.Component = this.Chart_Report_Util;

                pcLink_Schedule.Component = Main.GC_WF_SCHEDULE;



                composLink.Links.Add(linkMainReport_DayTime);
                composLink.Links.Add(linkMainReport_Problem);
                composLink.Links.Add(pcLink_Problem);
                composLink.Links.Add(linkMainReport_Machine);
                composLink.Links.Add(pcLink_Machine);
                composLink.Links.Add(linkMainReport_Job);
                composLink.Links.Add(pcLink_Job);
                composLink.Links.Add(linkGrid1Report_TardySum);
                composLink.Links.Add(pcLink_TardySum);
                composLink.Links.Add(linkGrid1Report_TardyCount);
                composLink.Links.Add(pcLink_TardyCount);
                composLink.Links.Add(linkGrid1Report_Setup);
                composLink.Links.Add(pcLink_Setup);

                composLink.Links.Add(linkGrid1Report_Util);
                composLink.Links.Add(pcLink_Util);


                XlsExportOptions options = new XlsExportOptions();
                options.ExportMode = XlsExportMode.SingleFilePageByPage;
                XlsExportOptionsEx dsd = new XlsExportOptionsEx();
                dsd.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                dsd.FitToPrintedPageHeight = true;
                dsd.FitToPrintedPageWidth = true;
                dsd.ExportMode = XlsExportMode.SingleFilePageByPage;
                //dsd.CustomizeCell += opt_CustomizeCell;


                options.FitToPrintedPageHeight = true;
                options.FitToPrintedPageWidth = true;
                options.SheetName = "Test";
                //composLink.CreatePageForEachLink();
                //composLink.Links.Add(pcLink_Schedule);



                string debugFolderPath = @"C:\VAMS";
                DirectoryInfo di = new DirectoryInfo(debugFolderPath);

                if (di.Exists == false)
                    di.Create();

                string problemPath = @"C:\VAMS\Report" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "_" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".xls";

                //composLink.ExportToXls(fileDlg.FileName, options);
                composLink_All.Links.Add(composLink);
                composLink_All.Links.Add(pcLink_Schedule);
                composLink_All.CreatePageForEachLink();
                composLink_All.ExportToXls(problemPath, dsd);

                Main.reportCell = false;
                //if (fileDlg.ShowDialog() == DialogResult.OK)
                //{


                //}

                MessageBox.Show("Export 완료");
            }
            catch
            {
                MessageBox.Show("Export 실패");
            }
           
        }
 
        private void ColorizeCell(string fieldName, int rowHandle, object appearanceObject)
        {
            if (fieldName == "Text" && rowHandle >= 0 && rowHandle % 2 != 0)
            {
                AppearanceObject app = appearanceObject as AppearanceObject;
                if (app != null)
                    app.BackColor = Color.Indigo;
                else
                {

                    XlFormattingObject obj = appearanceObject as XlFormattingObject;
                    if (obj != null)
                        obj.BackColor = Color.Indigo;
                }
            }
        }

        void linkGrid1Report_Current(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            tb.Text = DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString();
            tb.Font = new Font("Arial", 15);
            tb.Rect = new RectangleF(0, 0, 300, 25);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);



        }
        void linkGrid1Report_Chart_Problem(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            tb.Text = "Problem Setting";
            tb.Font = new Font("Arial", 15);
            tb.Rect = new RectangleF(0, 0, 300, 25);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }

        void linkMainReport_Create_Machine(object sender, CreateAreaEventArgs e)
        {

            TextBrick tb = new TextBrick();
            tb.Text = "Machine";
            tb.Font = new Font("Arial", 15);
            tb.Rect = new RectangleF(0, 0, 300, 25);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }

        void linkGrid1Report_Create_Job(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            tb.Text = "Job";
            tb.Font = new Font("Arial", 15);
            tb.Rect = new RectangleF(0, 0, 300, 25);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }

        void linkGrid1Report_Chart_TardySUM(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            tb.Text = "Tardniess Sum";
            tb.Font = new Font("Arial", 15);
            tb.Rect = new RectangleF(0, 0, 300, 25);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }

        void linkGrid1Report_Chart_TardyCount(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            tb.Text = "Tardiness Count";
            tb.Font = new Font("Arial", 15);
            tb.Rect = new RectangleF(0, 0, 300, 25);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }
        void linkGrid1Report_Chart_SetUp(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            tb.Text = "Set Up Sum";
            tb.Font = new Font("Arial", 15);
            tb.Rect = new RectangleF(0, 0, 300, 25);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }

        void linkGrid1Report_Chart_Util(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            tb.Text = "Util";
            tb.Font = new Font("Arial", 15);
            tb.Rect = new RectangleF(0, 0, 300, 25);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }
    }
}
