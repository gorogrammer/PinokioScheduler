using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using devDept.Geometry;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Graphics;
using devDept.Eyeshot.Labels;

using PINOKIO_SCHEDULER.Nodes;
using PINOKIO_SCHEDULER.GeneralFunctions;
using PINOKIO_SCHEDULER.Model;
using PINOKIO_SCHEDULER.Definitions;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing.Drawing2D;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Paint;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using System.Threading;
using DevExpress.XtraCharts;
using DevExpress.Utils.Menu;
using DevExpress.XtraSplashScreen;
using PINOKIO_SCHEDULER.SubView;
using DevExpress.Utils;

using System.Net.Sockets;
using System.Net;

namespace PINOKIO_SCHEDULER
{
    public partial class MainFrom : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables
        public int boxCount;
        public Dictionary<string, MachineNode> DicMachine = new Dictionary<string, MachineNode>();
        public Dictionary<int, MachineShape> DicBoxSahpe = new Dictionary<int, MachineShape>();
        public Dictionary<int, Block> DicStateSahpe = new Dictionary<int, Block>();
        public Dictionary<int, Entity> DicStateEntity = new Dictionary<int, Entity>();
        public Dictionary<string,JobBoxNode> DicJobBox = new Dictionary<string, JobBoxNode>();
        public Dictionary<string, int> DicJobCount_IN = new Dictionary<string, int>();
        public Dictionary<string, int> DicJobCount_PY = new Dictionary<string, int>();
        public Dictionary<string, int> DicJobCount_Out = new Dictionary<string, int>();
        public Dictionary<int, List<StatesModel>> DicJobState = new Dictionary<int, List<StatesModel>>();
        public Dictionary<string, List<Entity>> DicJobBoxEntity = new Dictionary<string, List<Entity>>();
        public Dictionary<string, int> DicJobCount_IN_Clone = new Dictionary<string, int>();
        public DevExpress.Utils.ToolTipController tooltipcontroller1 = new ToolTipController();
        public Dictionary<string, ScheduleModel> DicJobInfo = new Dictionary<string, ScheduleModel>();

        public Dictionary<string, ScheduleLog> DicSchedule = new Dictionary<string, ScheduleLog>();
        public Dictionary<string, RemainJob> DicRemainJob = new Dictionary<string, RemainJob>();

        bool objimport;
        ProcessShape sd = new ProcessShape();
        CurrentInfoForm infoForm = null;
        Thread thread = null;


        /// <summary>
        /// /////////////////
        /// </summary>
        Thread TimeLineAnimationThread;
        Thread ScheduleStackAnimationThread;

        List<ScheduleModel> _lstSchedule;
        List<string> _lstOriginalSchedule;
        List<GraphModel> _lstGraphicModel;

        DataTable _DT_Job;
        DataTable _DT_ScheduleTable;
        DataTable _DT_ScheduleList;
        DataTable _DT_ScheduleList_Assigned;
        DataTable _CHARTDT_Tardy;
        DataTable _CHARTDT_Setup;
        DataTable _CHARTDT_Resource;
        DataTable _RT_CHARTDT_Output;
        DataTable _RT_CHARTDT_Setup;
        DataTable _RT_CHARTDT_Resource;

        bool _isTimelineAnimating;
        bool _isScheduleAnimating;
        string _LoadCsvPath;

        public int _CurrentStep;
        public int _TotalMachineNum;
        public int _TotalJobNum;
        public int _TotalWorkingTime;
        public int _AnimationTic;
        public Entity[] Entity3DS;

        #endregion

        public MainFrom()
        {
            ShowLaunchScreen();
            InitializeComponent();
            this.model1.DisplayMode = displayType.Rendered;
            this.model1.OriginSymbol.Visible = false;            
            this.model1.Grid.Visible = false;
            this.model1.ForeColor = Color.DarkGray;
            this.model1.Camera.ProjectionMode = projectionType.Orthographic;
            this.model1.Dock = DockStyle.Fill;
            this.model1.Shaded.ShowEdges = false;
            this.model1.Shaded.ShowInternalWires = false;
            this.model1.Rendered.ShowEdges = false;
            this.model1.Entities.AsParallel();
            model1.Unlock("US2-RHM61-2NWXC-YS38-SA3F");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 17;
            comboBox3.SelectedIndex = 1;
            SplashScreenManager.CloseForm();

            //Python socket interface
            //thread = new Thread(() => { infoForm = new CurrentInfoForm(); Application.Run(infoForm); });
            infoForm = new CurrentInfoForm();
            // infoForm.Show();
          //  Thread thread = new Thread(new ThreadStart(PySockets));
            //thread.Start();

            //Task.Run(() => PySockets());
            
        }

        #region Python Socket interface

        public void PySockets()
        {
            using (var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                // ip는 로컬이고 포트는 9999로 listen 대기한다.

                server.Bind(new IPEndPoint(IPAddress.Any, 9999));
                server.Listen(20);
                Console.WriteLine("Server Start... Listen port 9999...");
                try
                {
                    while (true)
                    {
                        // 다중 접속을 허용하기 위한 Threadpool
                        ThreadPool.QueueUserWorkItem(c =>
                        {
                            Socket client = (Socket)c;
                            try
                            {
                                while (true)
                                {
                                    // 처음에 데이터 길이를 받기 위한 4byte
                                    var data = new byte[4];
                                    // python에서 little 엔디언으로 값이 온다. big엔디언과 little엔디언은 배열의 순서가 반대이므로 reverse
                                    client.Receive(data, 4, SocketFlags.None);
                                    Array.Reverse(data);
                                    data = new byte[BitConverter.ToInt32(data, 0)];
                                    client.Receive(data, data.Length, SocketFlags.None);
                                    var msg = Encoding.UTF8.GetString(data);
                                    Console.WriteLine(msg);
                                    msg = Python_Script(msg);
                                    data = Encoding.UTF8.GetBytes(msg);
                                    client.Send(BitConverter.GetBytes(data.Length));
                                    client.Send(data, data.Length, SocketFlags.None);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                                client.Close();
                            }
                        }, server.Accept());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public string Python_Script(string msg)
        {
            string returnString = string.Empty;

            if (msg.Contains("SETSCL"))
            {
                if (_lstOriginalSchedule != null)
                    ClearSchedules();

                List<string> lstPythonScheduleList = PySocket.FromPY_SetScheduleList(msg);
                InitializeWithPythonSchedules(lstPythonScheduleList);
            }
            else if (msg.Contains("SETJBL"))
            {
                if (_DT_Job != null)
                    ClearSchedules();

                DataTable JobDT = PySocket.FromPY_SetJobList(msg);
                _DT_Job = JobDT;
                Grid_WF_JOB.BeginInvoke(new Action(() => Grid_WF_JOB.DataSource = _DT_Job));
                _TotalJobNum = JobDT.Rows.Count;
                Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.Refresh()));
                Grid_WF_SCHEDULELIST.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST.Refresh()));
            }
            else if (msg.Equals("GETJBL"))
            {
                returnString = PySocket.ToPY_GetJobList(_DT_Job);
            }
            else if (msg.Equals("GETJBL_TYPE"))
            {
                returnString = PySocket.ToPY_GetJobList_byJobType(_DT_Job);
            }
            else if (msg.Contains("GETMACHINE_INFO"))
            {
                returnString = PySocket.ToPY_GetMachine_LastTime(msg, DicSchedule);
            }
            else if (msg.Equals("GETJBL_CURRENT"))
            {
                returnString = PySocket.ToPY_GetJobList_Current(DicRemainJob);
            }
            else if (msg.Contains("SET_JOB_SINGLE"))
            {
                ScheduleModel model;
                returnString = PySocket.FromPY_SetScheduleSingle(msg, _TotalMachineNum, _DT_Job, _lstSchedule, out model);
                if(DicJobCount_PY.Count ==0)
                {
                    DicJobCount_PY = PySocket.ToPY_GetJobCount(_DT_Job);
                }
                if (model == null)
                    return returnString;
                else
                {
                    _lstSchedule.Add(model);

                    if (_lstSchedule.Count == 1)
                    {
                        InitializeGrid_ByJOBLOADING();
                        InitializeGraph();
                        InitializeEyeShot();
                    }

                    AddSchedule(model);
                    Assign_Schedule(_CurrentStep, _lstSchedule);
                    Add_AssignedSchedule(model);
                    if (DicRemainJob.Count == 0)
                    {
                        foreach (KeyValuePair<string, int> pair in DicJobCount_PY)
                        {
                            RemainJob sd = new RemainJob();
                            sd.Job = pair.Key;
                            sd.RemainCount = pair.Value;
                            if (!DicRemainJob.ContainsKey(pair.Key))
                                DicRemainJob.Add(pair.Key, sd);
                        }
                    }
                    if (!DicSchedule.ContainsKey("M" + model.ID_Machine))
                    {
                        ScheduleLog sd = new ScheduleLog(model);
                        DicSchedule.Add("M" + model.ID_Machine, sd);
                        DicRemainJob[model.JobType].RemainCount--;
                    }
                    else
                    {
                        ScheduleLog sded = DicSchedule["M" + model.ID_Machine];
                        sded.UpdateLog(model);
                        DicRemainJob[model.JobType].RemainCount--;

                    }




                    if (Application.OpenForms.Count == 0)
                    {

                        // 해결 완료 
                        //CurrentInformForm 얘는 MainForm 에 속해있는 애라 MainForm을 실행 시키는 Thread에서 
                        // Show를 Call 해야하기 때문에 
                        // MainForm을 대상으로 대리자를 만들어 콜하면 해결
                        RunCurrentInformForm();
                        

                    }
                    infoForm.BeginInvoke(new Action(() => infoForm.UpdateMachineGrid(DicSchedule)));
                    infoForm.BeginInvoke(new Action(() => infoForm.UpdateRemainGrid(DicRemainJob)));




                    if (Grid_WF_SCHEDULELIST.InvokeRequired)
                        Grid_WF_SCHEDULELIST.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST.CurrentCell = Grid_WF_SCHEDULELIST.Rows[Grid_WF_SCHEDULELIST.Rows.Count - 1].Cells[0]));
                    else
                        Grid_WF_SCHEDULELIST.CurrentCell = Grid_WF_SCHEDULELIST.Rows[Grid_WF_SCHEDULELIST.Rows.Count - 1].Cells[0];

                    if (Grid_WF_SCHEDULELIST_ASSIGNED.InvokeRequired)
                        Grid_WF_SCHEDULELIST_ASSIGNED.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST_ASSIGNED.CurrentCell = Grid_WF_SCHEDULELIST_ASSIGNED.Rows[Grid_WF_SCHEDULELIST_ASSIGNED.Rows.Count - 1].Cells[0]));
                    else
                        Grid_WF_SCHEDULELIST_ASSIGNED.CurrentCell = Grid_WF_SCHEDULELIST_ASSIGNED.Rows[Grid_WF_SCHEDULELIST_ASSIGNED.Rows.Count - 1].Cells[0];


                    _lstGraphicModel = GeneralFunc.GetGraphicModels(_lstSchedule);
                    SetGraphByStep(_CurrentStep);

                    _CurrentStep++;
                }
            }

            return returnString;
        }
        private delegate void RunDelegate();

        public void RunCurrentInformForm()
        {
            if(this.InvokeRequired)
            {
                RunDelegate runDelegate = new RunDelegate(RunCurrentInformForm);
                this.Invoke(runDelegate);
            }
            else
            {
                this.infoForm.Show();
            }
        }
        public void PopupForm()
        {
            Application.Run(infoForm);
        }
        public void AddSchedule(ScheduleModel model)
        {
            _DT_ScheduleList.Rows.Add(model.ID_LOT, model.ID_Machine, model.JobType, model.ProcessingTime, model.StartTime, model.EndTime, model.DueTime, model.Setup, model.Violation);
        }

        public void Add_AssignedSchedule(ScheduleModel model)
        {
            _DT_ScheduleList_Assigned.Rows.Add(model.ID_LOT, model.ID_Machine, model.JobType, model.ProcessingTime, model.StartTime, model.EndTime, model.DueTime, model.Setup, model.Violation);
        }

        public void InitializeWithPythonSchedules(List<string> pythonStrLst)
        {
            InitializeSettings();
            _lstSchedule = GeneralFunc.GetScheduleModels(pythonStrLst, out _TotalMachineNum, out _TotalWorkingTime, out _DT_ScheduleList);
            _lstOriginalSchedule = new List<string>();
            foreach (string model in pythonStrLst)
                _lstOriginalSchedule.Add(model);

            InitializeGrid();
            InitializeGraph();
            InitializeEyeShot();
        }

        #endregion

        #region DevExpress Func
        private void SetResizeMainLogo()
        {
            Bitmap logo = global::PINOKIO_SCHEDULER.Properties.Resources.카를로_로고_컬러;

            int resizeWidth = this.Size.Width / 6;
            double rate = (double)resizeWidth / (double)logo.Width;
            int resizeHeight = (int)Math.Round(logo.Height * rate);

            Size resize = new Size(resizeWidth, resizeHeight);
            Bitmap resizeImage = new Bitmap(logo, resize);

            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Center;
            this.BackgroundImageStore = resizeImage;
        }
        public void ShowLaunchScreen()
        {
            string versionInfo = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            System.Drawing.Point centerPoint = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Height / 2));
            SplashScreenManager.ShowForm(this, typeof(FormLaunchScreen), true, true);
            SplashScreenManager.Default.SendCommand(FormLaunchScreen.SplashScreenCommand.RECEIVE_VERSION, versionInfo);
            Thread.Sleep(500);
        }
        private void ImportMachine3DS()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "/Machine3DS.3DS";
            
            Read3DS ro = new Read3DS(path);
            ro.DoWork();
            ro.AddToScene(this.model1);
            Entity[] es = ro.Entities;
           
            int index = 0;

            string blockname;
            blockname = "Machine3DS";
            Block block = new Block(blockname);

            foreach (Entity sd in model1.Entities.ToList())
            {
                this.model1.Entities.Remove(sd);
            }

            foreach (Entity ww in es)
            {
                if (index == 2 || index == 4 || index == 1)
                    ;
                else
                {
                    block.Entities.Add(ww);

                }

                index++;
            }

            Entity3DS = block.Entities.ToArray();
            //model1.Blocks.Add(block);

          

        }
        public bool ReadFiles()
        {
            _LoadCsvPath = GeneralFunc.OpenFiles();

            if (_LoadCsvPath == string.Empty)
                return false;

            List<string> lstReadCSV = GeneralFunc.ReadCsv(_LoadCsvPath);
            if (lstReadCSV == null)
                return false;

            //리스트로 이루어진 스케쥴 초기 모델
            _lstSchedule = GeneralFunc.GetScheduleModels(lstReadCSV, out _TotalMachineNum, out _TotalWorkingTime, out _DT_ScheduleList);
            UpdateJobInfoDic(_lstSchedule);

            _lstOriginalSchedule = new List<string>();
            foreach (string model in lstReadCSV)
                _lstOriginalSchedule.Add(model);

            return true;
        }
        public void UpdateJobInfoDic(List<ScheduleModel> sl)
        {
            foreach(ScheduleModel sd in sl)
            {
                string keyname = sd.JobType + sd.ID_LOT;
                if (!DicJobInfo.ContainsKey(keyname))
                {
                    
                    DicJobInfo.Add(keyname, sd);
                }
            }
        }

        public void InitializeSettings()
        {
            _isTimelineAnimating = false;
            _isScheduleAnimating = false;
            _CurrentStep = 0;
            _TotalWorkingTime = 0;
            _TotalMachineNum = Convert.ToInt32(comboBox2.SelectedItem);
            _TotalJobNum = 0;
        }

        public void InitializeGrid()
        {
            if (_lstSchedule == null)
                return;

            _lstGraphicModel = GeneralFunc.GetGraphicModels(_lstSchedule);

            //DT는 데이터 빠른 표기를 위한 컨테이너 //잡디티 생성
            _DT_Job = GeneralFunc.GetNewJobDT();
            foreach (ScheduleModel model in _lstSchedule)
                _DT_Job.Rows.Add(model.ID_LOT, model.JobType, model.ProcessingTime, model.DueTime);

            _TotalJobNum = _DT_Job.Rows.Count;

            //그룹박스 초기화
            GB_JOB.BeginInvoke(new Action(() => GB_JOB.Text = "Job List : " + _TotalJobNum));
            GB_SCHEDULELIST.BeginInvoke(new Action(() => GB_SCHEDULELIST.Text = "Schedule List : " + _TotalJobNum));
            GB_SCHEDULELIST_ASSIGNED.BeginInvoke(new Action(() => GB_SCHEDULELIST_ASSIGNED.Text = "Assigned Schedule List : "));

            // 잡 DT 생성	
            if (Grid_WF_JOB.InvokeRequired)
                Grid_WF_JOB.BeginInvoke(new Action(() => Grid_WF_JOB.DataSource = _DT_Job));
            else
                Grid_WF_JOB.DataSource = _DT_Job;

            Grid_WF_SCHEDULELIST.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST.DataSource = _DT_ScheduleList));

            // 스케줄 리스트 DT 생성	
            _DT_ScheduleList_Assigned = GeneralFunc.GetNewScheduleListDT();

            if (Grid_WF_SCHEDULELIST_ASSIGNED.InvokeRequired)
                Grid_WF_SCHEDULELIST_ASSIGNED.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST_ASSIGNED.DataSource = _DT_ScheduleList_Assigned));
            else
                Grid_WF_SCHEDULELIST_ASSIGNED.DataSource = _DT_ScheduleList_Assigned;

            // 스케줄 DT 생성	
            _DT_ScheduleTable = GeneralFunc.GetNewScheduleDT(_TotalWorkingTime, _TotalMachineNum);

            if (Grid_WF_SCHEDULE.InvokeRequired)
                Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.DataSource = _DT_ScheduleTable));
            else
                Grid_WF_SCHEDULE.DataSource = _DT_ScheduleTable;

            SetDatatableNotsorted();
        }

        public void InitializeGrid_ByJOBLOADING()
        {
            if (_lstSchedule == null)
                return;

            //_lstGraphicModel = GeneralFunc.GetGraphicModels(_lstSchedule);

            ////DT는 데이터 빠른 표기를 위한 컨테이너 //잡디티 생성
            //_DT_Job = GeneralFunc.GetNewJobDT();
            //foreach (ScheduleModel model in _lstSchedule)
            //    _DT_Job.Rows.Add(model.ID_LOT, model.JobType, model.ProcessingTime, model.DueTime);

            //_TotalJobNum = _DT_Job.Rows.Count;

            //그룹박스 초기화
            GB_JOB.BeginInvoke(new Action(() => GB_JOB.Text = "Job List : " + _TotalJobNum));
            GB_SCHEDULELIST.BeginInvoke(new Action(() => GB_SCHEDULELIST.Text = "Schedule List : " + _TotalJobNum));
            GB_SCHEDULELIST_ASSIGNED.BeginInvoke(new Action(() => GB_SCHEDULELIST_ASSIGNED.Text = "Assigned Schedule List : "));

            // 잡 DT 생성	
            //if (Grid_WF_JOB.InvokeRequired)
            //    Grid_WF_JOB.BeginInvoke(new Action(() => Grid_WF_JOB.DataSource = _DT_Job));
            //else
            //    Grid_WF_JOB.DataSource = _DT_Job;

            Grid_WF_SCHEDULELIST.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST.DataSource = _DT_ScheduleList));

            // 스케줄 리스트 DT 생성	
            _DT_ScheduleList_Assigned = GeneralFunc.GetNewScheduleListDT();

            if (Grid_WF_SCHEDULELIST_ASSIGNED.InvokeRequired)
                Grid_WF_SCHEDULELIST_ASSIGNED.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST_ASSIGNED.DataSource = _DT_ScheduleList_Assigned));
            else
                Grid_WF_SCHEDULELIST_ASSIGNED.DataSource = _DT_ScheduleList_Assigned;

            // 스케줄 DT 생성	
            _DT_ScheduleTable = GeneralFunc.GetNewScheduleDT(_TotalWorkingTime, _TotalMachineNum);

            if (Grid_WF_SCHEDULE.InvokeRequired)
                Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.DataSource = _DT_ScheduleTable));
            else
                Grid_WF_SCHEDULE.DataSource = _DT_ScheduleTable;

            SetDatatableNotsorted();
        }

        public void InitializeGraph()
        {
            //타디
            Series TardySeries = new Series(DEF.GRAPH_TARDY, ViewType.StackedLine);
            CHART_TARDY.Series.Add(TardySeries);
            _CHARTDT_Tardy = new DataTable(DEF.GRAPH_TARDY);
            _CHARTDT_Tardy.Columns.Add(DEF.GRAPH_TARDY_X, typeof(Int32));
            _CHARTDT_Tardy.Columns.Add(DEF.GRAPH_TARDY_Y, typeof(Int32));

            TardySeries.DataSource = _CHARTDT_Tardy;
            TardySeries.ArgumentScaleType = ScaleType.Numerical;
            TardySeries.ArgumentDataMember = DEF.GRAPH_TARDY_X;
            TardySeries.ValueScaleType = ScaleType.Numerical;

            //셋업
            Series SetupSeries = new Series(DEF.GRAPH_SETUP, ViewType.StackedLine);
            CHART_SETUP.Series.Add(SetupSeries);
            _CHARTDT_Setup = new DataTable(DEF.GRAPH_SETUP);
            _CHARTDT_Setup.Columns.Add(DEF.GRAPH_SETUP_X, typeof(Int32));
            _CHARTDT_Setup.Columns.Add(DEF.GRAPH_SETUP_Y, typeof(Int32));

            SetupSeries.DataSource = _CHARTDT_Setup;
            SetupSeries.ArgumentScaleType = ScaleType.Numerical;
            SetupSeries.ArgumentDataMember = DEF.GRAPH_SETUP_X;
            SetupSeries.ValueScaleType = ScaleType.Numerical;

            //리소스
            Series ResourceSeries = new Series(DEF.GRAPH_RESOURCE, ViewType.Bar);
            CHART_RESOURCE.Series.Add(ResourceSeries);
            ResourceSeries.View.Colorizer = GeneralFunc.CreateColorizer(1);

            _CHARTDT_Resource = new DataTable(DEF.GRAPH_RESOURCE);
            _CHARTDT_Resource.Columns.Add(DEF.GRAPH_RESOURCE_X, typeof(Int32));
            _CHARTDT_Resource.Columns.Add(DEF.GRAPH_RESOURCE_Y, typeof(double));

            ResourceSeries.DataSource = _CHARTDT_Resource;
            ResourceSeries.ArgumentScaleType = ScaleType.Numerical;
            ResourceSeries.ArgumentDataMember = DEF.GRAPH_RESOURCE_X;
            ResourceSeries.ValueScaleType = ScaleType.Numerical;

            //RT 아웃풋
            Series RTOutputSeries = new Series(DEF.GRAPH_RT_OUTPUT, ViewType.Bar);
            CHART_RT_OUTPUT.Series.Add(RTOutputSeries);
            RTOutputSeries.View.Colorizer = GeneralFunc.CreateColorizer(2);

            _RT_CHARTDT_Output = new DataTable(DEF.GRAPH_RT_OUTPUT);
            _RT_CHARTDT_Output.Columns.Add(DEF.GRAPH_RT_OUTPUT_X, typeof(Int32));
            _RT_CHARTDT_Output.Columns.Add(DEF.GRAPH_RT_OUTPUT_Y, typeof(Int32));

            RTOutputSeries.DataSource = _RT_CHARTDT_Output;
            RTOutputSeries.ArgumentScaleType = ScaleType.Numerical;
            RTOutputSeries.ArgumentDataMember = DEF.GRAPH_RT_OUTPUT_X;
            RTOutputSeries.ValueScaleType = ScaleType.Numerical;

            //RT셋업
            Series RTSetupSeries = new Series(DEF.GRAPH_RT_SETUP, ViewType.Bar);
            CHART_RT_SETUP.Series.Add(RTSetupSeries);
            RTSetupSeries.View.Colorizer = GeneralFunc.CreateColorizer(3);

            _RT_CHARTDT_Setup = new DataTable(DEF.GRAPH_RT_SETUP);
            _RT_CHARTDT_Setup.Columns.Add(DEF.GRAPH_RT_SETUP_X, typeof(Int32));
            _RT_CHARTDT_Setup.Columns.Add(DEF.GRAPH_RT_SETUP_Y, typeof(Int32));

            RTSetupSeries.DataSource = _RT_CHARTDT_Setup;
            RTSetupSeries.ArgumentScaleType = ScaleType.Numerical;
            RTSetupSeries.ArgumentDataMember = DEF.GRAPH_RT_SETUP_X;
            RTSetupSeries.ValueScaleType = ScaleType.Numerical;

            //RT리소스
            Series RTResourceSeries = new Series(DEF.GRAPH_RT_RESOURCE, ViewType.Bar);
            CHART_RT_RESOURCE.Series.Add(RTResourceSeries);
            RTResourceSeries.View.Colorizer = GeneralFunc.CreateColorizer(1);

            _RT_CHARTDT_Resource = new DataTable(DEF.GRAPH_RT_RESOURCE);
            _RT_CHARTDT_Resource.Columns.Add(DEF.GRAPH_RT_RESOURCE_X, typeof(Int32));
            _RT_CHARTDT_Resource.Columns.Add(DEF.GRAPH_RT_RESOURCE_Y, typeof(double));

            RTResourceSeries.DataSource = _RT_CHARTDT_Resource;
            RTResourceSeries.ArgumentScaleType = ScaleType.Numerical;
            RTResourceSeries.ArgumentDataMember = DEF.GRAPH_RT_RESOURCE_X;
            RTResourceSeries.ValueScaleType = ScaleType.Numerical;
        }
        public void SetDicJobState(List<ScheduleModel> sclist, int dsd)
        {
            foreach (ScheduleModel model in sclist)
            {
                MachineNode mn = DicMachine["M" + model.ID_Machine];

            }
        }
        public void StartNewDispatching(List<string> lstStr)
        {
            string versionInfo = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            System.Drawing.Point centerPoint = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Height / 2));
            SplashScreenManager.ShowForm(this, typeof(FormLoading));
            SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.RECEIVE_VERSION, versionInfo);
            SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETMAXPGBVALUE, 100);

            SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 10);
            InitializeSettings();
            SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 30);
            _lstSchedule = GeneralFunc.GetScheduleModels(lstStr, out _TotalMachineNum, out _TotalWorkingTime, out _DT_ScheduleList);
            SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 50);
            InitializeGrid();
            SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 70);
            InitializeGraph();
            SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 90);
            InitializeEyeShot();
            SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 100);
            SplashScreenManager.CloseForm();
        }

        public void SetDatatableNotsorted()
        {
            for (int i = 0; i < Grid_WF_SCHEDULE.Columns.Count; i++)
                Grid_WF_SCHEDULE.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            for (int i = 0; i < Grid_WF_SCHEDULELIST.Columns.Count; i++)
                Grid_WF_SCHEDULELIST.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            for (int i = 0; i < Grid_WF_SCHEDULELIST_ASSIGNED.Columns.Count; i++)
                Grid_WF_SCHEDULELIST_ASSIGNED.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        public void UpdateDicJob()
        {

        }
        public void Assign_Schedule(int step, List<ScheduleModel> lstmodel)
        {
            //DataTable SchedulesTimedDT = (DataTable)Grid_WF_SCHEDULE.DataSource;            


            //for(int step = 0; step < steps+1; step ++)
            //{
            int schedulelength = lstmodel[step].EndTime - lstmodel[step].StartTime;
            string JobName = lstmodel[step].JobType + lstmodel[step].ID_LOT;
            JobBoxNode jbNode = new JobBoxNode();
            jbNode.ScheduleData = lstmodel[step];
            jbNode.Name = JobName;

            DicJobBox.Add(JobName, jbNode);
            if (DicJobCount_IN.ContainsKey(lstmodel[step].JobType))
            {
                DicJobCount_IN[lstmodel[step].JobType]++;
            }
            else
            {
                DicJobCount_IN.Add(lstmodel[step].JobType, 1);
            }
            int LastBlock = 1;
            string LastJob = string.Empty;

            for (int j = 1; j < _TotalWorkingTime; j++)
            {
                string JobAssiged = _DT_ScheduleTable.Rows[lstmodel[step].ID_Machine][j].ToString();

                if (string.IsNullOrEmpty(JobAssiged))
                {
                    LastBlock = j;
                    break;
                }
                else
                {
                    LastJob = JobAssiged;
                    continue;
                }
            }

            if (!string.IsNullOrEmpty(LastJob) && LastJob.Substring(0, 1) != lstmodel[step].JobType)
            {
                for (int i = 0; i < DEF.SETUPTIME; i++)
                    _DT_ScheduleTable.Rows[lstmodel[step].ID_Machine][LastBlock + i] = "Setup";

                LastBlock += DEF.SETUPTIME;
            }

            for (int j = LastBlock; j < schedulelength + LastBlock; j++)
            {
                _DT_ScheduleTable.Rows[lstmodel[step].ID_Machine][j] = JobName;
            }
        }

        public void DeAssign_Schedule(int step, List<ScheduleModel> lstmodel)
        {
            step -= 1;
            int schedulelength = lstmodel[step].EndTime - lstmodel[step].StartTime;
            string JobName = lstmodel[step].JobType + lstmodel[step].ID_LOT;

            int LastBlock = 1;
            bool isSetup = false;
            string LastJob = string.Empty;

            for (int j = 1; j < _TotalWorkingTime; j++)
            {
                string JobAssiged = _DT_ScheduleTable.Rows[lstmodel[step].ID_Machine][j].ToString();

                if (string.IsNullOrEmpty(JobAssiged))
                {
                    break;
                }
                else
                {
                    if (JobAssiged.Equals(JobName))
                    {
                        if (LastJob.Contains("Set"))
                            isSetup = true;

                        break;
                    }
                    LastBlock = j;
                    LastJob = JobAssiged;
                }
            }

            if (isSetup)
            {
                LastBlock = LastBlock - DEF.SETUPTIME + 1;

                for (int i = 0; i < DEF.SETUPTIME; i++)
                    _DT_ScheduleTable.Rows[lstmodel[step].ID_Machine][LastBlock + i] = string.Empty;

                LastBlock += DEF.SETUPTIME;
            }
            else
            {
                if (!string.IsNullOrEmpty(LastJob))
                    LastBlock += 1;
            }


            for (int j = LastBlock; j < LastBlock + schedulelength; j++)
                _DT_ScheduleTable.Rows[lstmodel[step].ID_Machine][j] = string.Empty;
        }

        public void InitializeSchedule()
        {
            ResetSchedules();
            SetGraphByStep(-1);
            UpdateRealTimeGraph(null);
            List<StatesModel> lstState = GetModelStates_ByColumnIndex(1);
        }

        public void ResetSchedules()
        {
            Grid_WF_SCHEDULE.ClearSelection();

            _CurrentStep = 0;
            _DT_ScheduleList_Assigned.Rows.Clear();
            _DT_ScheduleTable.Rows.Clear();

            for (int i = 0; i < _TotalMachineNum; i++)
                _DT_ScheduleTable.Rows.Add(i.ToString());
        }

        public void SetInJob(Dictionary<string, int> dicjobcount)
        {
            try
            {
                foreach (Block en in model1.Blocks.ToList())
                {
                    if (en != null && en.Name.Contains("Job"))
                        model1.Blocks.Remove(en);
                }
                ClearEntity();

                List<Block> blocklist = InJobList(dicjobcount);

                for (int i = 0; i < blocklist.Count; i++)
                {
                    if(!model1.Blocks.Contains(blocklist[i]))
                    {
                        model1.Blocks.Add(blocklist[i]);

                        BlockReference boxBlockReference = new BlockReference(0, 0, 0, blocklist[i].Name, 1, 1, 1, 0);
                        boxBlockReference.MaterialName = blocklist[i].Name;

                        model1.Entities.Add(boxBlockReference);
                    }
                
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }
        
        public void SetinJobBox(Dictionary<string, int> dicjobcount)
        {


        }
        public List<Block> InJobList(Dictionary<string, int> jobList)
        {
            try
            {
                List<Block> bllist = new List<Block>();
                int count = 0;


                foreach (KeyValuePair<string, int> pair in jobList)
                {

                    Block BoxBlock = new Block("Job :" + pair.Key);

                    Mesh bodyMain = Createbolck.CreateBox(500, 400 ,300, GeneralFunc.SetColor(pair.Key), new Vector3D(0, 0, 0));
                    bodyMain.Translate(-5000, 7000 * (count + 1) / 3, 0);


                    BoxBlock.Entities.Add(bodyMain);
                    bllist.Add(BoxBlock);

                    count++;
                }

                return bllist;
            }
            catch (Exception e)
            {
                List<Block> bllist = new List<Block>();
                return bllist;
            }

        }

        public void CreateBlock_InJobBox()
        {
           

        }

        public void Set_InJobBox(Dictionary<string,int> jobCount)
        {
            Dictionary<string, List<double>> pos = new Dictionary<string, List<double>>();
            List<double> location = new List<double>();
            BlockReference reference;
            int index = 0;
            for (int i =0; i < jobCount.Count; i++)
            {

                location.Clear();
                location.Add(-5000);
                
                location.Add(7000*(i+1)/3);
                location.Add(0);

                pos.Add(jobCount.Keys.ToList()[i], location);
            }
            
           
            foreach (KeyValuePair<string, int> pair in jobCount)
            {
                
                Block block = new Block("In_JobBox"+"_"+pair.Key);

                Mesh jb = Mesh.CreateBox(500, 400, 300, Mesh.natureType.Smooth);

                jb.ColorMethod = colorMethodType.byEntity;
                jb.Color = GeneralFunc.SetColor(pair.Key);
                block.Entities.Add(jb);

                if (!model1.Blocks.Contains(block))
                    model1.Blocks.Add(block);

                for (int i = 0; i < pair.Value; i++)
                {
                    reference = new BlockReference(-5000, 7000 * (index + 1) / 3, 350 * i+10, "In_JobBox"+"_"+pair.Key, 0);
                    model1.Entities.Add(reference);
                    if (!DicJobBoxEntity.ContainsKey("In_JobBox" + "_" + pair.Key))
                        DicJobBoxEntity.Add("In_JobBox" + "_" + pair.Key, new List<Entity>());
                    else
                        DicJobBoxEntity["In_JobBox" + "_" + pair.Key].Add(reference);
                }
                index++;
            }
        }
        public void UpdateEndJob(MachineNode mn ,Dictionary<int,ScheduleModel> sch)
        {
            int index = 0;
            BlockReference reference;
            mn.BoxCount = sch.Count;
            foreach (KeyValuePair<int, ScheduleModel> pair in sch)
            {
            
                Block block = new Block("End_JobBox"+"_"+mn.Name+"_"+pair.Value.JobType+pair.Value.ID_LOT);

                Mesh jb = Mesh.CreateBox(500, 400, 300, Mesh.natureType.Smooth);

                jb.ColorMethod = colorMethodType.byEntity;
                jb.Color = GeneralFunc.SetColor(pair.Value.JobType);
                block.Entities.Add(jb);
                if (!model1.Blocks.Contains(block))
                    model1.Blocks.Add(block);

               
                reference = new BlockReference(mn.Position_box[0]+4500, mn.Position_box[1]+400, 350 * index, "End_JobBox" + "_" + mn.Name + "_" + pair.Value.JobType + pair.Value.ID_LOT, 0);
                model1.Entities.Add(reference);

                index++;
            }
        }
        public void  Update_InJobBox(string jobname,Dictionary<string,int> dicjob)
        {
            int index = 0;
            int count = dicjob[jobname];

            IEnumerable<Entity> selectjob = model1.Entities.ToList().Where(x => x.ToString() == "Referencing: In_JobBox" + "_" + jobname).ToList() ;
           
            LeaderAndText sd = model1.Labels.First(x => ((LeaderAndText)x).Text.Contains(jobname)) as LeaderAndText;
            if (sd != null)
                sd.Text = jobname+ " : "+ count.ToString();
            
            Entity lastEntity;
            if(selectjob.Count() !=0)
            {
                lastEntity = selectjob.Last();
                model1.Entities.Remove(lastEntity);
                //model1.Refresh();
            }
            //model1.Labels.Regen();

        }

        public void Update_EndJobBox()
        {
     

            IEnumerable<Entity> selectjob = model1.Entities.ToList().Where(x => x.ToString().Contains("Referencing: End_JobBox")).ToList();

            Entity lastEntity;
            if (selectjob.Count() != 0)
            {
                foreach(Entity en in selectjob)
                {
                    model1.Entities.Remove(en);
                }
               
            }
             
        }
        
        public void UpdateInJobLabel(Dictionary<string, int> dicjobcount)
        {
            //foreach (devDept.Eyeshot.Labels.Label en in model1.Labels.ToList())
            //{
            //    if (en.LabelData != null)
            //        model1.Labels.Remove(en);
            //}
            model1.Labels.Clear();
            List<LeaderAndText> labellist = sd.JoblistLabel(dicjobcount);


            //foreach (LeaderAndText label_ in labellist.ToList())
            //{
            //    model1.Labels.Add(label_);
            //}
            for (int z = 0; z < labellist.Count; z++)
            {
                model1.Labels.Add(labellist[z]);
            }

        }

        public void UpdateInJobLabel_TEXT(Dictionary<string, int> dicjobcount)
        {
            foreach(KeyValuePair<string,int> pair in dicjobcount)
            {

                LeaderAndText sd = model1.Labels.First(x => ((LeaderAndText)x).Text.Contains(pair.Key)) as LeaderAndText;
                if(sd != null)
                    sd.Text = pair.Key+  " : "+ pair.Value.ToString();

            }
            model1.Labels.Regen();
        }

        public void UpdateMachinLabel(Dictionary<string, MachineNode> dic)
        {
            //List<LeaderAndText> labellist = sd.MachineLabel(dic);

            //for (int z = 0; z < labellist.Count; z++)
            //{
            //    if (!model1.Labels.Contains(labellist[z]))
            //        model1.Labels.Add(labellist[z]);
            //}

           


            foreach (KeyValuePair<string,MachineNode> mn in  dic)
            {
                //MachineShape boXShape = DicBoxSahpe[mn.Value.ID];
                //boXShape.LabelBox.Visible = true;

                BlockReference br = model1.Entities.ToList().First(p => p.ToString().Contains("Referencing: "+mn.Value.Name)) as BlockReference;
                Entity ed = model1.Entities.ToList().First(p => p.ToString().Contains("Referencing: " + mn.Value.Name));
                if (br !=null)
                {
                    //int index = model1.Entities.IndexOf(br);
                    //br.Attributes["att1"].Visible = true;
                    //br.Attributes["att2"].Visible = true;
                    //br.Attributes["att3"].Visible = true;
                    //br.Attributes["att4"].Visible = true;
                    //br.Attributes["att5"].Visible = true;


                    //br.Attributes["att2"] = new AttributeReference("Job : " + mn.Value.WorkCount);
                    //br.Attributes["att3"] = new AttributeReference("Working : " + mn.Value.TotalworkTime);
                    //br.Attributes["att4"] = new AttributeReference("Set Up : " + mn.Value.TotalsetupTime);
                    //br.Attributes["att5"] = new AttributeReference("IDLE : " + mn.Value.TotalIdleTime);
                    //boXShape.Machinelabel[0] = new AttributeReference(mn.Key);
                    //boXShape.Machinelabel[1]= new AttributeReference("총 작업 수 : " + mn.Value.WorkCount.ToString());
                    //boXShape.Machinelabel[2] = new AttributeReference("총 작업 시간 : " + mn.Value.TotalworkTime.ToString());
                    //boXShape.Machinelabel[3] = new AttributeReference("총 셋업 시간 : " + mn.Value.TotalsetupTime.ToString());
                    //boXShape.Machinelabel[4] = new AttributeReference("총 유휴 시간 : " + mn.Value.TotalIdleTime.ToString());

                    br.Attributes["att2"].Value = "Job : " + mn.Value.WorkCount;
                    br.Attributes["att3"].Value = "Working : " + mn.Value.TotalworkTime;
                    br.Attributes["att4"].Value = "Set Up : " + mn.Value.TotalsetupTime;
                    br.Attributes["att5"].Value = "IDLE : " + mn.Value.TotalIdleTime;

                }


               // model1.Entities.Regen();
                model1.Invalidate();

            }
        }
        public void ClearSchedules()
        {
            _lstSchedule = new List<ScheduleModel>();
            Grid_WF_SCHEDULE.ClearSelection();
            Grid_WF_SCHEDULELIST.ClearSelection();
            Grid_WF_SCHEDULELIST_ASSIGNED.ClearSelection();

            if (_DT_ScheduleTable != null)
            {
                _DT_ScheduleTable.Clear();
                _DT_ScheduleTable.Columns.Clear();
                _DT_ScheduleList.Clear();
                _DT_ScheduleList.Columns.Clear();
                _DT_ScheduleList_Assigned.Clear();
                _DT_ScheduleList_Assigned.Columns.Clear();
            }

            //CHART_TARDY.Series.Clear();
            //CHART_SETUP.Series.Clear();
            //CHART_RESOURCE.Series.Clear();
            //CHART_RT_OUTPUT.Series.Clear();
            //CHART_RT_SETUP.Series.Clear();
            //CHART_RT_RESOURCE.Series.Clear();

            if (_CHARTDT_Setup != null)
                _CHARTDT_Setup.Clear();
            if (_CHARTDT_Resource != null)
                _CHARTDT_Resource.Clear();
            if (_CHARTDT_Tardy != null)
                _CHARTDT_Tardy.Clear();
            if (_RT_CHARTDT_Output != null)
                _RT_CHARTDT_Output.Clear();
            if (_RT_CHARTDT_Resource != null)
                _RT_CHARTDT_Resource.Clear();
            if (_RT_CHARTDT_Setup != null)
                _RT_CHARTDT_Setup.Clear();

            //if (_CHARTDT_Setup != null)
            //    _CHARTDT_Setup.Columns.Clear();
            //if (_CHARTDT_Resource != null)
            //    _CHARTDT_Resource.Columns.Clear();
            //if (_CHARTDT_Tardy != null)
            //    _CHARTDT_Tardy.Columns.Clear();
            //if (_RT_CHARTDT_Output != null)
            //    _RT_CHARTDT_Output.Columns.Clear();
            //if (_RT_CHARTDT_Resource != null)
            //    _RT_CHARTDT_Resource.Columns.Clear();
            //if (_RT_CHARTDT_Setup != null)
            //    _RT_CHARTDT_Setup.Columns.Clear();

            Grid_WF_SCHEDULE.SelectionMode = DataGridViewSelectionMode.CellSelect;

            if (model1.InvokeRequired)
                model1.BeginInvoke(new Action(() => model1.Clear()));
            else
                model1.Clear();

            if (model1.InvokeRequired)
                model1.BeginInvoke(new Action(() => model1.Focus()));
            else
                model1.Focus();

            ClearEyeShot();
            _DT_ScheduleList = GeneralFunc.GetNewScheduleListDT();
            _DT_ScheduleList_Assigned = GeneralFunc.GetNewScheduleListDT();
            _DT_ScheduleTable = GeneralFunc.GetNewScheduleDT(50, Convert.ToInt32(comboBox2.SelectedItem));

            if (Grid_WF_SCHEDULELIST.InvokeRequired)
                Grid_WF_SCHEDULELIST.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST.DataSource = _DT_ScheduleList));
            else
                Grid_WF_SCHEDULELIST.DataSource = _DT_ScheduleList;

            if (Grid_WF_SCHEDULELIST_ASSIGNED.InvokeRequired)
                Grid_WF_SCHEDULELIST_ASSIGNED.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST_ASSIGNED.DataSource = _DT_ScheduleList_Assigned));
            else
                Grid_WF_SCHEDULELIST_ASSIGNED.DataSource = _DT_ScheduleList_Assigned;

            if (Grid_WF_SCHEDULE.InvokeRequired)
                Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.DataSource = _DT_ScheduleTable));
            else
                Grid_WF_SCHEDULE.DataSource = _DT_ScheduleTable;
        }

        public void SetTimeLineAnimation()
        {
            if (_isTimelineAnimating)
            {
                BTN_MOVE.BeginInvoke(new Action(() => BTN_MOVE.Enabled = true));
                BTN_MOVE_BACK.BeginInvoke(new Action(() => BTN_MOVE_BACK.Enabled = true));
                BTN_MOVE_FIRST.BeginInvoke(new Action(() => BTN_MOVE_FIRST.Enabled = true));
                BTN_MOVE_FORWARD.BeginInvoke(new Action(() => BTN_MOVE_FORWARD.Enabled = true));
                BTN_MOVE_LAST.BeginInvoke(new Action(() => BTN_MOVE_LAST.Enabled = true));
                BTN_TIMELINE_MOVE.BeginInvoke(new Action(() => BTN_TIMELINE_MOVE.BackgroundImage = Properties.Resources.다운로드__2_));

                _isTimelineAnimating = false;
                TimeLineAnimationThread.Abort();
            }
            else
            {
                BTN_MOVE.BeginInvoke(new Action(() => BTN_MOVE.Enabled = false));
                BTN_MOVE_BACK.BeginInvoke(new Action(() => BTN_MOVE_BACK.Enabled = false));
                BTN_MOVE_FIRST.BeginInvoke(new Action(() => BTN_MOVE_FIRST.Enabled = false));
                BTN_MOVE_FORWARD.BeginInvoke(new Action(() => BTN_MOVE_FORWARD.Enabled = false));
                BTN_MOVE_LAST.BeginInvoke(new Action(() => BTN_MOVE_LAST.Enabled = false));
                BTN_TIMELINE_MOVE.BeginInvoke(new Action(() => BTN_TIMELINE_MOVE.BackgroundImage = Properties.Resources.다운로드__5_));

                _isTimelineAnimating = true;
                TimeLineAnimationThread = new Thread(new ParameterizedThreadStart(Delegate_TimeLineAnimation));

                TimeLineAnimationThread.Start(Grid_WF_SCHEDULE.Columns.Count);

                //testtest(Grid_WF_SCHEDULE.Columns.Count);
            }
        }

        public void SetSchedulAnimation()
        {
            if (_isScheduleAnimating)
            {
                BTN_MOVE_BACK.BeginInvoke(new Action(() => BTN_MOVE_BACK.Enabled = true));
                BTN_MOVE_FIRST.BeginInvoke(new Action(() => BTN_MOVE_FIRST.Enabled = true));
                BTN_MOVE_FORWARD.BeginInvoke(new Action(() => BTN_MOVE_FORWARD.Enabled = true));
                BTN_MOVE_LAST.BeginInvoke(new Action(() => BTN_MOVE_LAST.Enabled = true));
                BTN_TIMELINE_MOVE.BeginInvoke(new Action(() => BTN_TIMELINE_MOVE.Enabled = true));
                BTN_MOVE.BeginInvoke(new Action(() => BTN_MOVE.BackgroundImage = Properties.Resources.다운로드__2_));

                _isScheduleAnimating = false;
                ScheduleStackAnimationThread.Abort();
            }
            else
            {
                if (_CurrentStep == _TotalJobNum)
                    return;

                BTN_MOVE_BACK.BeginInvoke(new Action(() => BTN_MOVE_BACK.Enabled = false));
                BTN_MOVE_FIRST.BeginInvoke(new Action(() => BTN_MOVE_FIRST.Enabled = false));
                BTN_MOVE_FORWARD.BeginInvoke(new Action(() => BTN_MOVE_FORWARD.Enabled = false));
                BTN_MOVE_LAST.BeginInvoke(new Action(() => BTN_MOVE_LAST.Enabled = false));
                BTN_TIMELINE_MOVE.BeginInvoke(new Action(() => BTN_TIMELINE_MOVE.Enabled = false));
                BTN_MOVE.BeginInvoke(new Action(() => BTN_MOVE.BackgroundImage = Properties.Resources.다운로드__5_));

                _isScheduleAnimating = true;
                ScheduleStackAnimationThread = new Thread(new ParameterizedThreadStart(Delegate_ScheduleAnimation));
                ScheduleStackAnimationThread.Start(Grid_WF_SCHEDULE.Columns.Count);
            }
        }

        public void SetGraphByStep(int step)
        {
            _CHARTDT_Tardy.Rows.Clear();
            _CHARTDT_Setup.Rows.Clear();
            _CHARTDT_Resource.Rows.Clear();

            if (step < 0)
                return;

            for (int i = 0; i < _lstGraphicModel[step].lstTardy.Count; i++)
                _CHARTDT_Tardy.Rows.Add(i, _lstGraphicModel[step].lstTardy[i]);
            CHART_TARDY.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });


            for (int i = 0; i < _lstGraphicModel[step].lstSetup.Count; i++)
                _CHARTDT_Setup.Rows.Add(i, _lstGraphicModel[step].lstSetup[i]);
            CHART_SETUP.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });


            foreach (MachineUtilities util in _lstGraphicModel[step].lstMachineUtilities)
                _CHARTDT_Resource.Rows.Add(util.MachineIndex, util.Uitility_CurrenetRuned);
            CHART_RESOURCE.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });
        }

        public void UpdateRealTimeGraph(List<StatesModel> lstStates)
        {
            _RT_CHARTDT_Output.Rows.Clear();
            _RT_CHARTDT_Setup.Rows.Clear();
            _RT_CHARTDT_Resource.Rows.Clear();

            if (lstStates == null)
                return;

            foreach (StatesModel state in lstStates)
            {
                _RT_CHARTDT_Output.Rows.Add(state.MachineNumber, state.CompletedBox);
                _RT_CHARTDT_Setup.Rows.Add(state.MachineNumber, state.SetupTime);
                _RT_CHARTDT_Resource.Rows.Add(state.MachineNumber, state.Uitility_Timed);
            }
            CHART_RT_OUTPUT.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });
            CHART_RT_SETUP.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });
            CHART_RT_RESOURCE.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });
        }

        private void Delegate_TimeLineAnimation(object totalColumnNum)
        {
            try
            {
                for (int i = 1; i < (int)totalColumnNum; i++)
                {
                    Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.ClearSelection()));
                    Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect));
                    Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.Columns[(int)i].Selected = true));
                    List<StatesModel> lststates = GetModelStates_ByColumnIndex(i);

                    if (model1.InvokeRequired)
                        model1.BeginInvoke(new Action(() => Update3D(lststates,i)));
                    else
                        Update3D(lststates,i);



                    if (model1.InvokeRequired)
                        model1.BeginInvoke(new Action(() => model1.Refresh()));
                    else
                        model1.Refresh();

                    if (model1.InvokeRequired)
                        model1.BeginInvoke(new Action(() => model1.Focus()));
                    else
                        model1.Focus();


                    UpdateRealTimeGraph(lststates);

                    Thread.Sleep(_AnimationTic);
                }
                SetTimeLineAnimation();
                Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.ClearSelection()));
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private void Delegate_SelectedSchedule_Cell(object RowIndex)
        {
            try
            {
                Grid_WF_SCHEDULELIST_ASSIGNED.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST_ASSIGNED.ClearSelection()));
                Grid_WF_SCHEDULELIST_ASSIGNED.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST_ASSIGNED.CurrentCell = Grid_WF_SCHEDULELIST_ASSIGNED.Rows[(int)RowIndex].Cells[0]));
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private void Delegate_ScheduleAnimation(object x)
        {
            try
            {
                for (int i = _CurrentStep; i < _TotalJobNum; i++)
                {
                    _DT_ScheduleList_Assigned.Rows.Add(_lstSchedule[_CurrentStep].ID_LOT,
                        _lstSchedule[_CurrentStep].ID_Machine,
                        _lstSchedule[_CurrentStep].JobType,
                        _lstSchedule[_CurrentStep].ProcessingTime,
                        _lstSchedule[_CurrentStep].StartTime,
                        _lstSchedule[_CurrentStep].EndTime,
                        _lstSchedule[_CurrentStep].DueTime,
                        _lstSchedule[_CurrentStep].Setup,
                        _lstSchedule[_CurrentStep].Violation);

                    Assign_Schedule(_CurrentStep, _lstSchedule);


                    if (Grid_WF_SCHEDULELIST_ASSIGNED.InvokeRequired)
                    {
                        Grid_WF_SCHEDULELIST_ASSIGNED.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST_ASSIGNED.CurrentCell =
                        Grid_WF_SCHEDULELIST_ASSIGNED.Rows[Grid_WF_SCHEDULELIST_ASSIGNED.Rows.Count - 1].Cells[0]));
                    }

                    SetGraphByStep(_CurrentStep);
                    _CurrentStep++;
                    Thread.Sleep(_AnimationTic);
                }
                SetSchedulAnimation();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private void RunSplashScreen(string versionInfo)
        {
            System.Drawing.Point centerPoint = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Height / 2));
            SplashScreenManager.ShowForm(this, typeof(FormLaunchScreen), true, true, SplashFormStartPosition.Manual, centerPoint);
            SplashScreenManager.Default.SendCommand(FormLaunchScreen.SplashScreenCommand.RECEIVE_VERSION, versionInfo);
            SplashScreenManager.Default.SendCommand(FormLaunchScreen.SplashScreenCommand.SETMAXPGBVALUE, 100);
            SplashScreenManager.Default.SendCommand(FormLaunchScreen.SplashScreenCommand.SETCURRENTVALUE, 20);
            SplashScreenManager.CloseForm();
        }

        #endregion

        #region EyeShot Func

        public void InitializeEyeShot()
        {
            model1.BeginInvoke(new Action(() => SetTexture()));
            model1.BeginInvoke(new Action(() => ImportMachine3DS()));

            this.model1.SetView(viewType.vcFrontFaceTop);
            for (int i = 0; i < _TotalMachineNum; i++)
            {
                List<double> pos = new List<double>();
                MachineNode bn = new MachineNode(i, pos);
                DicMachine.Add(bn.Name, bn);
            }
            Set_Machine_Pos(Cal_Machine_Pos(_TotalMachineNum), DicMachine);
            double width = DicMachine[DicMachine.ElementAt(DicMachine.Count - 1).Key].Position_box[0];

            model1.BeginInvoke(new Action(() => SetPlate(width)));
            model1.BeginInvoke(new Action(() => CreateShapeMachine(DicMachine)));
            model1.BeginInvoke(new Action(() => CreateBoxBlock()));
            model1.BeginInvoke(new Action(() => CreateBlock_InJobBox()));
            model1.BeginInvoke(new Action(() => SetJobList_Machine(_lstSchedule)));

            model1.BeginInvoke(new Action(() => model1.ZoomFit()));
            model1.BeginInvoke(new Action(() => model1.Refresh()));
            model1.BeginInvoke(new Action(() => model1.Focus()));


            //model1.BeginInvoke(new Action(() => model1.SetView(viewType.vcFrontFaceTopRight)));
            //model1.BeginInvoke(new Action(() => model1.OriginSymbol.Visible = false));
            //model1.BeginInvoke(new Action(() => model1.Grid.Visible = false));

            if (model1.InvokeRequired)
                model1.BeginInvoke(new Action(() => model1.ZoomFit()));
            else
                model1.ZoomFit();

            if (model1.InvokeRequired)
                model1.BeginInvoke(new Action(() => model1.SetView(viewType.vcFrontFaceTopRight)));
            else
                model1.SetView(viewType.vcFrontFaceTopRight);

            if (model1.InvokeRequired)
                model1.BeginInvoke(new Action(() => model1.Refresh()));
            else
                model1.Refresh();

            if (model1.InvokeRequired)
                model1.BeginInvoke(new Action(() => model1.Focus()));
            else
                model1.Focus();

            //this.model1.ZoomFit();
            //this.model1.SetView(viewType.vcFrontFaceTopRight);
            //this.model1.Refresh();
            //model1.Focus();
        }
        public void SetPlate(double wd)
        {
            Mesh plate = Createbolck.CreateBox(wd * 3, wd*4.3, 1, "WhiteMetal", new Vector3D(-8000, -4000,-6));
            model1.Entities.Add(plate);
        }
        public void Set_Machine_Pos(List<int> ls, Dictionary<string, MachineNode> mc_dic)
        {


            int index = 0;
            int row_index = 0;
            int row_index2 = 0;
            if (ls[0] == 2)
            {

                foreach (MachineNode mn in mc_dic.Values)
                {
                    if (index <= ls[1] + ls[2])
                    {
                        mn.Position_box.Add(0);
                       // mn.Position_box.Add(index + 4000 * index);
                        mn.Position_box.Add(index + 6000 * index);
                        mn.Position_box.Add(0);

                        index++;
                    }
                    else if (index > ls[1] + ls[2])
                    {
                        //mn.Position_box.Add(4000);
                        mn.Position_box.Add(15000);
                        //mn.Position_box.Add(row_index + 4000 * row_index);
                        mn.Position_box.Add(row_index + 6000 * row_index);
                        mn.Position_box.Add(0);
                        row_index++;
                    }

                }
            }
            else
            {
                foreach (MachineNode mn in mc_dic.Values)
                {
                    if (index < ls[1] + ls[2])
                    {
                        mn.Position_box.Add(0);
                        //mn.Position_box.Add(index + 4000 * index);
                        mn.Position_box.Add(index + 6000 * index);
                        mn.Position_box.Add(0);

                        index++;
                    }
                    else if (index >= ls[1] + ls[2] && row_index <= ls[1] - 1)
                    {
                        //mn.Position_box.Add(4000);
                        mn.Position_box.Add(15000);
                        //mn.Position_box.Add(row_index + 4000 * row_index);
                        mn.Position_box.Add(row_index + 6000 * row_index);
                        mn.Position_box.Add(0);
                        row_index++;
                    }
                    else if (row_index > ls[1] - 1)
                    {
                        //mn.Position_box.Add(8000);
                        mn.Position_box.Add(30000);
                        //mn.Position_box.Add(row_index2 + 4000 * row_index2);
                        mn.Position_box.Add(row_index2 + 6000 * row_index2);
                        mn.Position_box.Add(0);
                        row_index2++;
                    }

                }

            }


        }
        public List<int> Cal_Machine_Pos(int mc_count)
        {
            int rowNo = 0;
            int truncate = 0;
            int remainder = 0;

            List<int> pos_list = new List<int>();
            if (mc_count <= 10)
            {
                rowNo = 2;
                truncate = Convert.ToInt32(Math.Truncate(Convert.ToDouble(mc_count / 2)));
                remainder = mc_count % 2;

            }
            else if (mc_count >= 11 && mc_count <= 20)
            {
                rowNo = 2;
                truncate = Convert.ToInt32(Math.Truncate(Convert.ToDouble(mc_count / 2)));
                remainder = mc_count % 2;
            }
            else if (mc_count >= 21 && mc_count <= 30)
            {
                rowNo = 3;
                truncate = Convert.ToInt32(Math.Truncate(Convert.ToDouble(mc_count / 3)));
                remainder = mc_count % 3;
            }

            pos_list.Add(rowNo);
            pos_list.Add(truncate);
            pos_list.Add(remainder);

            return pos_list;
        }

        public void ClearEyeShot()
        {
            DicMachine.Clear();
            DicBoxSahpe.Clear();
            DicStateSahpe.Clear();
            DicStateEntity.Clear();
            DicJobBox.Clear();
            DicJobCount_IN.Clear();
            DicJobCount_Out.Clear();
            DicJobState.Clear();
            DicJobBoxEntity.Clear();
            sd = new ProcessShape();
        }
        protected override void OnLoad(EventArgs e)
        {
            model1.ZoomFit();
        }
        public void AddNodeShape(MachineShape bs, MachineNode bn)
        {
            //model1.Blocks.Add(sd.CreateMachine_node(bs, bn));
            model1.Blocks.Add(sd.CreateMachine3DS_node(bs, bn, Entity3DS));

            BlockReference boxBlockReference = new BlockReference(0, 0, 0, bn.Name, 1, 1, 1, 0);
            boxBlockReference.Scale(8);
            //bn.Position_box.Clear();
            //bn.Position_box.Add(0);
            //bn.Position_box.Add(bn.ID * 2000);
            //bn.Position_box.Add(0);

            boxBlockReference.Attributes["att0"] = new AttributeReference("Ready");

            boxBlockReference.Attributes["att1"] = new AttributeReference(bn.Name);

            //boxBlockReference.Attributes["att2"] = new AttributeReference("총 작업 수 : 0");
            //boxBlockReference.Attributes["att3"] = new AttributeReference("총 작업 시간 : 0");
            //boxBlockReference.Attributes["att4"] = new AttributeReference("총 셋업 시간 : 0");
            //boxBlockReference.Attributes["att5"] = new AttributeReference("총 유휴 시간 : 0");
            boxBlockReference.Attributes["att2"] = new AttributeReference("Job : 0");
            boxBlockReference.Attributes["att3"] = new AttributeReference("Working : 0");
            boxBlockReference.Attributes["att4"] = new AttributeReference("Set Up : 0");
            boxBlockReference.Attributes["att5"] = new AttributeReference("IDLE : 0");


            boxBlockReference.Attributes["att1"].StyleName = "Consolas";
            
            boxBlockReference.Attributes["att2"].StyleName = "Consolas";
            boxBlockReference.Attributes["att3"].StyleName = "Consolas";
            boxBlockReference.Attributes["att4"].StyleName = "Consolas";
            boxBlockReference.Attributes["att5"].StyleName = "Consolas";
            boxBlockReference.Translate(bn.Position_box[0], bn.Position_box[1], bn.Position_box[2]);
            //boxBlockReference.Translate(bn.Position_box[0], bn.Position_box[1], 0);
            //model1.Labels.Add(new LeaderAndText(bn.Position_box[0]-800, bn.Position_box[1] , 800, bn.Name, new Font("Tahoma", 14.25f), Color.Navy, new Vector2D(0, 0)));
            model1.Entities.Add(boxBlockReference);
            bs.Machinelabel.Add(boxBlockReference.Attributes["att1"]);
            bs.Machinelabel.Add(boxBlockReference.Attributes["att2"]);
            bs.Machinelabel.Add(boxBlockReference.Attributes["att3"]);
            bs.Machinelabel.Add(boxBlockReference.Attributes["att4"]);
            bs.Machinelabel.Add(boxBlockReference.Attributes["att5"]);
            DicBoxSahpe.Add(bn.ID, bs);
            CreateStateBlock(bn);
        }

        private void UpdateMachineState(MachineNode machine)
        {
            Block stateShape = DicStateSahpe[DicMachine[machine.Name].ID];
            Entity en = model1.Entities.First(x => x == DicStateEntity[machine.ID]) as Entity;

            if (machine.MachineState is MACHINE_STATE.IDLE)
            {
                stateShape.Entities[0].Color = Color.Red;
                en.Visible = false;
            }
            else if (machine.MachineState is MACHINE_STATE.LOADING)
            {
                stateShape.Entities[0].Color = Color.Yellow;
                en.Visible = false;
            }
            else if (machine.MachineState is MACHINE_STATE.WORKING)
            {
                stateShape.Entities[0].Color = Color.Red;
                en.Visible =true;
            }
            //if (machine.MachineState is MACHINE_STATE.IDLE)
            //{
            //    stateShape.Entities[0].Color = Color.Red;
            //    en.Visible = true;
            //}
            //else if (machine.MachineState is MACHINE_STATE.LOADING)
            //{
            //    stateShape.Entities[0].Color = Color.Yellow;
            //    en.Visible = true;
            //}
            //else if (machine.MachineState is MACHINE_STATE.WORKING)
            //{
            //    stateShape.Entities[0].Color = Color.Green;
            //    en.Visible = false;
            //}

        }
        private void CreateShapeMachine(Dictionary<string, MachineNode> _dicBn)
        {
            try
            {
                foreach (MachineNode bn in _dicBn.Values)
                {

                    MachineShape bnShape = new MachineShape(bn);

                    AddNodeShape(bnShape, bn);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public void MaekBox_OBJ(int no)
        {


            for (int i = 0; i < no; i++)
            {
                BlockReference boxBlockReference = new BlockReference(0, 0, 0, "Box_OBJ", 1, 1, 1, 0);
                boxBlockReference.Scale(1);

                boxBlockReference.Translate(0, i * 1000, 0);
                model1.Labels.Add(new LeaderAndText(0, i * 1000 + 185.18, 800, "Box" + "No_000" + i.ToString(), new Font("Tahoma", 10.25f), Color.Red, new Vector2D(0, 30)));
                model1.Entities.Add(boxBlockReference);
            }
        }
        public void SetTexture()
        {
            this.model1.Materials.Add(new Material("WhiteMetal", Properties.Resources.white_metal));
            this.model1.Materials.Add(new Material("Metal3", Properties.Resources.metal3));
            this.model1.Materials.Add(new Material("Blackrubber", Properties.Resources.blackrubber));
            this.model1.Materials.Add(new Material("Display", Properties.Resources.display));
            this.model1.Materials.Add(new Material("Glass", Properties.Resources.glass1));
            this.model1.Materials.Add(new Material("KeyBoard", Properties.Resources.keyboard));
            this.model1.Materials.Add(new Material("Maple", Properties.Resources.Maple));
            this.model1.Materials.Add(new Material("Warnig", Properties.Resources.Warning_1));
            this.model1.Materials.Add(new Material("Metal2", Properties.Resources.metal2));
            this.model1.Materials.Add(new Material("Chrome", Properties.Resources.Chrome));

        }
        public void MaekBox(int no)
        {


            for (int i = 0; i < no; i++)
            {
                BlockReference boxBlockReference = new BlockReference(0, 0, 0, "Machine", 1, 1, 1, 0);
                boxBlockReference.Scale(1);

                boxBlockReference.Translate(0, i * 1000, 0);
                model1.Labels.Add(new LeaderAndText(0, i * 1000 + 185.18, 800, "Machine" + "No_000" + i.ToString(), new Font("Tahoma", 10.25f), Color.Red, new Vector2D(0, 30)));
                model1.Entities.Add(boxBlockReference);
            }
        }
        private void CreateBoxBlock()
        {
            model1.Blocks.Add(sd.CreateBox());
        }

        public void ClearEntity()
        {
            foreach (Entity en in model1.Entities.ToList())
            {
                
                if (en != null && en.MaterialName != null)
                {
                    model1.Entities.Remove(en);
                }

            }
        }
  
        private void UpdateBox(MachineNode mn)
        {
            foreach (Entity en in model1.Entities.ToList())
            {
                if (en != null && en.MaterialName != null && en.MaterialName.Contains(mn.Name))
                    model1.Entities.Remove(en);
                else if (en != null && en.MaterialName != null)
                {
                    model1.Entities.Remove(en);
                }

            }
        }



        private void CreateStateBlock(MachineNode mn)
        {
            Block sb = sd.CreateState(mn);

            model1.Blocks.Add(sb);

            Entity en = new Rotating("State" + mn.ID, mn);
            model1.Entities.Add(en);
            en.Visible = false;
            DicStateSahpe.Add(mn.ID, sb);
            DicStateEntity.Add(mn.ID, en);

        }
        public void UpdateInJob_Animation(MachineNode mn, string jobname)
        {
            Block sb = sd.CreateJobBox(mn, jobname);
            model1.Blocks.Add(sb);

            model1.Entities.Add(new TranslatingAlongZ("Box" + mn.ID+ "_"+jobname,mn));


        }
        private void UpdateBoxCountLabel(Dictionary<string, MachineNode> mndic)
        {
            if (model1.Labels.Count > _TotalMachineNum)
                model1.Labels.RemoveRange(_TotalMachineNum, model1.Labels.Count - _TotalMachineNum);

            foreach (MachineNode mn in mndic.Values)
            {
                model1.Labels.Add(new LeaderAndText(
                    mn.Position_box[0] + 4600,
                    mn.Position_box[1] + 300, 0,
                    " End Job : " + mn.BoxCount.ToString(),
                    new Font("Tahoma", 10.25f),
                    Color.White, new Vector2D(0, 0)));
            }

        }
        public void SetJobList_Machine(List<ScheduleModel> lstStates)
        {
            int count = 0;
            int end_count = 0;
            foreach (ScheduleModel model in lstStates.ToList())
            {
                MachineNode box = DicMachine["M" + model.ID_Machine];
                if (!box.Startjob.ContainsKey(model.StartTime))
                {
                    box.Startjob.Add(model.StartTime, model);
                    count++;
                }
                if (box.Startjob.ContainsKey(model.StartTime) && !box.workingJob.ContainsKey(model.StartTime))
                {
                    box.workingJob.Add(model.StartTime, model);

                }
                if (!box.EndJob.ContainsKey(model.EndTime))
                {
                    box.EndJob.Add(model.EndTime, model);
                    box.EndJobOff.Add(model.EndTime+1, model);
                    end_count++;
                }
                
                if(model.DueTime < model.EndTime)
                {
                    if(!box.DueDateJob.ContainsKey(model.JobType+model.ID_LOT))
                        box.DueDateJob.Add(model.JobType + model.ID_LOT, model);
                }

            }

        }
        public void Update3D(List<StatesModel> lstStates, int index)
        {
            try
            {
                if (index == 40)
                    ;
                Dictionary<int, ScheduleModel> CurEndJob = new Dictionary<int, ScheduleModel>();

                foreach (StatesModel model in lstStates.ToList())
                {

                    MachineNode box = DicMachine["M" + model.MachineNumber];
                    box.MachineState = model.MachineState;
                    
                    MachineShape boXShape = DicBoxSahpe[model.MachineNumber + 1];
                    BlockReference br = model1.Entities.ToList().First(p => p.ToString().Contains("Referencing: " + box.Name)) as BlockReference;
                    // Entity ed = model1.Entities.ToList().First(p => p.ToString().Contains("Referencing: " + box.Name));

                    if (br == null)
                    {
                        break;
                    }
                       

                    if (box.startjob.ContainsKey(index - 1))
                    {
                        string jobName = model.JobName.Last();
                        DicJobCount_IN[model.JobName.Last().Substring(0, 1)]--;
                        box.WorkCount++;

                        Update_InJobBox(model.JobName.Last().Substring(0, 1), DicJobCount_IN);
                        boXShape.UpdateJobColor(model.JobName.Last().Substring(0, 1));
                       // boXShape.JobMesh.Visible = true;
                        boXShape.OutJobMesh.Visible = false;

                  
                        //boXShape.StateName.TextString = model.JobName.Last().ToString();
                        br.Attributes["att0"].Value = model.JobName.Last().ToString();
                        br.Attributes["att0"].Color = GeneralFunc.SetColor(model.JobName.Last().Substring(0, 1));

                      
                        
                    }
                    if (box.DueDateJob.ContainsKey(model.JobName.Last()))
                    {
                        Block stateShape = DicStateSahpe[DicMachine[box.Name].ID];
                        Entity en = model1.Entities.First(x => x == DicStateEntity[box.ID]) as Entity;
                        if (box.DueDateJob[model.JobName.Last()].EndTime < index-1)
                        {
                            en.Visible = false;
                        }
                        else
                        {
                            en.Visible = true;
                        }
                    }

                    if (box.EndJob.ContainsKey(index - 1))
                    {

                        //Update_EndJobBox();
                        //boXShape.UpdateOutJobColor(model.JobName.Last().Substring(0, 1));
                        //boXShape. .Visible = true;
                        IEnumerable<KeyValuePair<int, ScheduleModel>> curEndJob = box.EndJob.Where(p => p.Key <= index-1);
                        CurEndJob = curEndJob.ToDictionary(p => p.Key, p => p.Value);
                        UpdateEndJob(box, CurEndJob);
                       
                        Block stateShape = DicStateSahpe[DicMachine[box.Name].ID];
                        Entity en = model1.Entities.First(x => x == DicStateEntity[box.ID]) as Entity;

                        en.Visible = false;

                    }

                    if (box.MachineState is MACHINE_STATE.IDLE)
                    {
                        box.TotalIdleTime++;
                        boXShape.JobMesh.Visible = false;
                        //boXShape.OutJobMesh.Visible = false;
                        //boXShape.StateName.TextString = "IDLE";
                        //boXShape.StateName.Color = Color.Black;

                        br.Attributes["att0"].Value = "IDLE";
                        br.Attributes["att0"].Color = Color.Black;

                    }
                    else if (box.MachineState is MACHINE_STATE.WORKING)
                    {
                        box.TotalworkTime++;
                     
                    }
                    else if (box.MachineState is MACHINE_STATE.LOADING)
                    {
                        box.TotalsetupTime++;
                        boXShape.JobMesh.Visible = false;
                        br.Attributes["att0"].Value = "SET UP";
                        br.Attributes["att0"].Color = Color.Red;
                        //boXShape.OutJobMesh.Visible = false;
                    }
                

                    //UpdateBox(box);
       
     

                
                    //boXShape.UpdateMachineState(box);

                    boXShape.UpdateMachineState_1(box);

                }
                //SetInJob(DicJobCount_IN);

                //UpdateBoxCountLabel(DicMachine);
                //UpdateInJobLabel(DicJobCount_IN);
                UpdateInJobLabel_TEXT(DicJobCount_IN);
                UpdateMachinLabel(DicMachine);
               // model1.Invalidate();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }

        }

        #endregion

        #region UI Func
  

        #endregion

        private void gridScheduleView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (string.IsNullOrEmpty(e.CellValue.ToString()))
                return;
            if (e.CellValue.ToString().Substring(0, 1).Contains("A"))
                e.Appearance.BackColor = COLOR_1.A_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("B"))
                e.Appearance.BackColor = COLOR_1.B_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("C"))
                e.Appearance.BackColor = COLOR_1.C_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("D"))
                e.Appearance.BackColor = COLOR_1.D_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("E"))
                e.Appearance.BackColor = COLOR_1.E_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("F"))
                e.Appearance.BackColor = COLOR_1.F_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("G"))
                e.Appearance.BackColor = COLOR_1.G_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("H"))
                e.Appearance.BackColor = COLOR_1.H_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("I"))
                e.Appearance.BackColor = COLOR_1.I_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("J"))
                e.Appearance.BackColor = COLOR_1.J_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("K"))
                e.Appearance.BackColor = COLOR_1.K_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("L"))
                e.Appearance.BackColor = COLOR_1.L_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("M"))
                e.Appearance.BackColor = COLOR_1.M_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("N"))
                e.Appearance.BackColor = COLOR_1.N_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("O"))
                e.Appearance.BackColor = COLOR_1.O_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("P"))
                e.Appearance.BackColor = COLOR_1.P_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("Q"))
                e.Appearance.BackColor = COLOR_1.Q_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("R"))
                e.Appearance.BackColor = COLOR_1.R_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("S") && GeneralFunc.IsNumeric(e.CellValue.ToString().Substring(0, 2)))
                e.Appearance.BackColor = COLOR_1.S_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("T"))
                e.Appearance.BackColor = COLOR_1.T_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("U"))
                e.Appearance.BackColor = COLOR_1.U_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("V"))
                e.Appearance.BackColor = COLOR_1.V_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("W"))
                e.Appearance.BackColor = COLOR_1.W_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("X"))
                e.Appearance.BackColor = COLOR_1.X_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("Y"))
                e.Appearance.BackColor = COLOR_1.Y_StringColor;
            if (e.CellValue.ToString().Substring(0, 1).Contains("Z"))
                e.Appearance.BackColor = COLOR_1.Z_StringColor;

            //if (e.CellValue.ToString().Substring(0, 1).Contains("A"))
            //    e.Appearance.BackColor = Color.Red;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("B"))
            //    e.Appearance.BackColor = Color.Green;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("C"))
            //    e.Appearance.BackColor = Color.DeepSkyBlue;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("D"))
            //    e.Appearance.BackColor = Color.Yellow;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("E"))
            //    e.Appearance.BackColor = Color.AliceBlue;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("F"))
            //    e.Appearance.BackColor = Color.Aquamarine;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("G"))
            //    e.Appearance.BackColor = Color.Beige;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("H"))
            //    e.Appearance.BackColor = Color.BlanchedAlmond;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("I"))
            //    e.Appearance.BackColor = Color.BlueViolet;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("J"))
            //    e.Appearance.BackColor = Color.Chartreuse;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("K"))
            //    e.Appearance.BackColor = Color.Chocolate;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("L"))
            //    e.Appearance.BackColor = Color.Coral;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("M"))
            //    e.Appearance.BackColor = Color.CornflowerBlue;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("N"))
            //    e.Appearance.BackColor = Color.Cornsilk;new Pen(Color.Black)
            //if (e.CellValue.ToString().Substring(0, 1).Contains("O"))
            //    e.Appearance.BackColor = Color.Crimson;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("P"))
            //    e.Appearance.BackColor = Color.Cyan;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("Q"))
            //    e.Appearance.BackColor = Color.DarkCyan;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("R"))
            //    e.Appearance.BackColor = Color.DarkBlue;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("S") && GeneralFunc.IsNumeric(e.CellValue.ToString().Substring(0, 2)))
            //    e.Appearance.BackColor = Color.DarkGoldenrod;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("T"))
            //    e.Appearance.BackColor = Color.DarkSalmon;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("U"))
            //    e.Appearance.BackColor = Color.DarkSeaGreen;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("V"))
            //    e.Appearance.BackColor = Color.DarkSlateGray;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("W"))
            //    e.Appearance.BackColor = Color.ForestGreen;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("X"))
            //    e.Appearance.BackColor = Color.IndianRed;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("Y"))
            //    e.Appearance.BackColor = Color.Orange;
            //if (e.CellValue.ToString().Substring(0, 1).Contains("Z"))
            //    e.Appearance.BackColor = Color.Navy;

            if (e.CellValue.ToString().Contains("Set"))
            {
                e.DisplayText = string.Empty;
                using (Pen pen = new Pen(Color.Black))
                {
                    e.Cache.DrawLine(pen, new System.Drawing.Point(e.Bounds.Left, e.Bounds.Top), new System.Drawing.Point(e.Bounds.Right, e.Bounds.Bottom));
                    e.Cache.DrawLine(pen, new System.Drawing.Point(e.Bounds.Right, e.Bounds.Top), new System.Drawing.Point(e.Bounds.Left, e.Bounds.Bottom));
                }
            }
        }

        private void gridScheduleView_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hi = view.CalcHitInfo(e.Location);
            if (hi.InColumn)
            {
                view.ClearSelection();
                for (int i = 0; i < view.RowCount; i++)
                {
                    view.SelectCell(i, hi.Column);
                }
            }
        }

        private void gridScheduleView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
        }

        private void Grid_WF_SCHEDULE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            if (string.IsNullOrEmpty(e.Value.ToString()))
                return;

            //if (e.Value.ToString().Substring(0, 1).Contains("A"))
            //    e.CellStyle.BackColor = COLOR.A_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("B"))
            //    e.CellStyle.BackColor = COLOR.B_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("C"))
            //    e.CellStyle.BackColor = COLOR.C_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("D"))
            //    e.CellStyle.BackColor = COLOR.D_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("E"))
            //    e.CellStyle.BackColor = COLOR.E_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("F"))
            //    e.CellStyle.BackColor = COLOR.F_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("G"))
            //    e.CellStyle.BackColor = COLOR.G_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("H"))
            //    e.CellStyle.BackColor = COLOR.H_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("I"))
            //    e.CellStyle.BackColor = COLOR.I_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("J"))
            //    e.CellStyle.BackColor = COLOR.J_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("K"))
            //    e.CellStyle.BackColor = COLOR.K_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("L"))
            //    e.CellStyle.BackColor = COLOR.L_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("M"))
            //    e.CellStyle.BackColor = COLOR.M_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("N"))
            //    e.CellStyle.BackColor = COLOR.N_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("O"))
            //    e.CellStyle.BackColor = COLOR.O_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("P"))
            //    e.CellStyle.BackColor = COLOR.P_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("Q"))
            //    e.CellStyle.BackColor = COLOR.Q_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("R"))
            //    e.CellStyle.BackColor = COLOR.R_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("S") && GeneralFunc.IsNumeric(e.Value.ToString().Substring(0, 2)))
            //    e.CellStyle.BackColor = COLOR.S_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("T"))
            //    e.CellStyle.BackColor = COLOR.T_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("U"))
            //    e.CellStyle.BackColor = COLOR.U_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("V"))
            //    e.CellStyle.BackColor = COLOR.V_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("W"))
            //    e.CellStyle.BackColor = COLOR.W_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("X"))
            //    e.CellStyle.BackColor = COLOR.X_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("Y"))
            //    e.CellStyle.BackColor = COLOR.Y_StringColor;
            //if (e.Value.ToString().Substring(0, 1).Contains("Z"))
            //    e.CellStyle.BackColor = COLOR.Z_StringColor;


            if (e.Value.ToString().Substring(0, 1).Contains("A"))
                e.CellStyle.BackColor = COLOR_1.A_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("B"))
                e.CellStyle.BackColor = COLOR_1.B_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("C"))
                e.CellStyle.BackColor = COLOR_1.C_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("D"))
                e.CellStyle.BackColor = COLOR_1.D_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("E"))
                e.CellStyle.BackColor = COLOR_1.E_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("F"))
                e.CellStyle.BackColor = COLOR_1.F_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("G"))
                e.CellStyle.BackColor = COLOR_1.G_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("H"))
                e.CellStyle.BackColor = COLOR_1.H_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("I"))
                e.CellStyle.BackColor = COLOR_1.I_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("J"))
                e.CellStyle.BackColor = COLOR_1.J_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("K"))
                e.CellStyle.BackColor = COLOR_1.K_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("L"))
                e.CellStyle.BackColor = COLOR_1.L_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("M"))
                e.CellStyle.BackColor = COLOR_1.M_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("N"))
                e.CellStyle.BackColor = COLOR_1.N_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("O"))
                e.CellStyle.BackColor = COLOR_1.O_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("P"))
                e.CellStyle.BackColor = COLOR_1.P_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("Q"))
                e.CellStyle.BackColor = COLOR_1.Q_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("R"))
                e.CellStyle.BackColor = COLOR_1.R_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("S") && GeneralFunc.IsNumeric(e.Value.ToString().Substring(0, 2)))
                e.CellStyle.BackColor = COLOR_1.S_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("T"))
                e.CellStyle.BackColor = COLOR_1.T_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("U"))
                e.CellStyle.BackColor = COLOR_1.U_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("V"))
                e.CellStyle.BackColor = COLOR_1.V_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("W"))
                e.CellStyle.BackColor = COLOR_1.W_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("X"))
                e.CellStyle.BackColor = COLOR_1.X_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("Y"))
                e.CellStyle.BackColor = COLOR_1.Y_StringColor;
            if (e.Value.ToString().Substring(0, 1).Contains("Z"))
                e.CellStyle.BackColor = COLOR_1.Z_StringColor;
        }

        private void Grid_WF_SCHEDULE_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value == null)
                return;

            if (string.IsNullOrEmpty(e.Value.ToString()))
                return;

            if (e.Value.ToString().Contains("Set"))
            {
                using (Brush gridBrush = new SolidBrush(this.Grid_WF_SCHEDULE.GridColor))
                {
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        using (Pen gridLinePen = new Pen(gridBrush))
                        {
                            using (Pen pen = new Pen(Color.Black, 1))
                            {
                                e.CellStyle.ForeColor = e.CellStyle.BackColor;
                                // Clear cell 
                                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                                //Bottom line drawing
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);

                                // here you force paint of content
                                e.PaintContent(e.ClipBounds);
                                e.Handled = true;

                                e.Graphics.DrawLine(pen, new System.Drawing.Point(e.CellBounds.Left, e.CellBounds.Top), new System.Drawing.Point(e.CellBounds.Right, e.CellBounds.Bottom));
                                e.Graphics.DrawLine(pen, new System.Drawing.Point(e.CellBounds.Right, e.CellBounds.Top), new System.Drawing.Point(e.CellBounds.Left, e.CellBounds.Bottom));
                            }
                        }
                    }
                }

            }
        }

        public List<StatesModel> GetModelStates_ByColumnIndex(int columnIndex)
         {
            List<StatesModel> lstState = new List<StatesModel>();
       
            for ( int i = 0;   i < Grid_WF_SCHEDULE.Rows.Count; i++)
            {
                List<String> listJob = new List<string>();
                List<String> endJob = new List<string>();
                int setupCount = 0;
                int procTime = 0;
               
                int endCount = 0;
                int idleTime = 0;
                for (int j = 1; j < columnIndex + 1; j++)
                {
                    string job = Grid_WF_SCHEDULE[j, i].Value.ToString();
               
                    if (job.Contains("Set"))
                    {
                        if (DicJobInfo.ContainsKey(listJob.Last()))
                        {
                            if (DicJobInfo[listJob.Last()].EndTime + 1 == j)
                            {
                                endCount++;
                                endJob.Add(listJob.Last());
                            }

                        }
                        setupCount++;
                    }
                    else if(string.IsNullOrEmpty(job))
                    {
                        if (DicJobInfo.ContainsKey(listJob.Last()))
                        {
                            if (DicJobInfo[listJob.Last()].EndTime + 1 == j)
                            {
                                endCount++;
                                endJob.Add(listJob.Last());
                            }

                        }

                    }
                       

                    if (!job.Contains("Set") && !string.IsNullOrEmpty(job))
                    {
                        procTime++;

                        if (!listJob.Contains(job))
                            listJob.Add(job);

                     
                    }
                    else if(string.IsNullOrEmpty(job))
                    {
                        idleTime++;
                    }
                    


                }

                string ScheduleValue = Grid_WF_SCHEDULE[columnIndex, i].Value.ToString();

                if (string.IsNullOrEmpty(ScheduleValue))
                {
                    lstState.Add(new StatesModel(i, MACHINE_STATE.IDLE, endCount, setupCount, procTime, columnIndex, listJob, endJob, idleTime));
                }
                else if (ScheduleValue.Contains("Set"))
                {
                    lstState.Add(new StatesModel(i, MACHINE_STATE.LOADING, endCount, setupCount, procTime, columnIndex, listJob, endJob, idleTime));
                }
                else if (GeneralFunc.IsNumeric(ScheduleValue.Remove(0, 1)))
                {
                    lstState.Add(new StatesModel(i, MACHINE_STATE.WORKING, endCount, setupCount, procTime, columnIndex, listJob, endJob, idleTime));
                }
            }

            return lstState;
        }

        private void Grid_WF_SCHEDULE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TimeLineAnimationThread != null && _isTimelineAnimating)
                {
                    BTN_MOVE.BeginInvoke(new Action(() => BTN_MOVE.Enabled = true));
                    BTN_MOVE_BACK.BeginInvoke(new Action(() => BTN_MOVE_BACK.Enabled = true));
                    BTN_MOVE_FIRST.BeginInvoke(new Action(() => BTN_MOVE_FIRST.Enabled = true));
                    BTN_MOVE_FORWARD.BeginInvoke(new Action(() => BTN_MOVE_FORWARD.Enabled = true));
                    BTN_MOVE_LAST.BeginInvoke(new Action(() => BTN_MOVE_LAST.Enabled = true));
                    BTN_TIMELINE_MOVE.BeginInvoke(new Action(() => BTN_TIMELINE_MOVE.BackgroundImage = Properties.Resources.다운로드__2_));

                    _isTimelineAnimating = false;
                    Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.ClearSelection()));
                    TimeLineAnimationThread.Abort();
                }

                if (ScheduleStackAnimationThread != null && _isScheduleAnimating)
                {
                    BTN_MOVE_BACK.BeginInvoke(new Action(() => BTN_MOVE_BACK.Enabled = true));
                    BTN_MOVE_FIRST.BeginInvoke(new Action(() => BTN_MOVE_FIRST.Enabled = true));
                    BTN_MOVE_FORWARD.BeginInvoke(new Action(() => BTN_MOVE_FORWARD.Enabled = true));
                    BTN_MOVE_LAST.BeginInvoke(new Action(() => BTN_MOVE_LAST.Enabled = true));
                    BTN_TIMELINE_MOVE.BeginInvoke(new Action(() => BTN_TIMELINE_MOVE.Enabled = true));
                    BTN_MOVE.BeginInvoke(new Action(() => BTN_MOVE.BackgroundImage = Properties.Resources.다운로드__2_));

                    _isScheduleAnimating = false;
                    Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.ClearSelection()));
                    ScheduleStackAnimationThread.Abort();
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            Grid_WF_SCHEDULE.ClearSelection();
            Grid_WF_SCHEDULE.ClearSelection();
            if (e.ColumnIndex == -1 && e.RowIndex == -1)
            {
                Grid_WF_SCHEDULE.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
                Grid_WF_SCHEDULE.SelectAll();
            }
            else if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                Grid_WF_SCHEDULE.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                Grid_WF_SCHEDULE.Rows[e.RowIndex].Selected = true;
            }
            else if (e.ColumnIndex > -1 && e.RowIndex == -1)
            {
                Grid_WF_SCHEDULE.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
                Grid_WF_SCHEDULE.Columns[e.ColumnIndex].Selected = true;

                if (e.ColumnIndex > 0)
                {
                    
                    List<StatesModel> lstState = GetModelStates_ByColumnIndex(e.ColumnIndex);
                   
                    UpdateSelectCol(lstState);
                    //Update3D(lstState, e.ColumnIndex);
                    UpdateRealTimeGraph(lstState);
                    model1.Focus();
                }
            }
            else
            {
                Grid_WF_SCHEDULE.SelectionMode = DataGridViewSelectionMode.CellSelect;
                Grid_WF_SCHEDULE.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                string value = Grid_WF_SCHEDULE.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (string.IsNullOrEmpty(value))
                    return;

                string value1 = value.Substring(0, 1);
                string value2 = value.Remove(0, 1);

                for (int i = 0; i < Grid_WF_SCHEDULELIST_ASSIGNED.Rows.Count; i++)
                    if (Grid_WF_SCHEDULELIST_ASSIGNED.Rows[i].Cells[2].Value.ToString().Equals(value1) && Grid_WF_SCHEDULELIST_ASSIGNED.Rows[i].Cells[0].Value.ToString().Equals(value2))
                    {
                        Thread CellselectionThread = new Thread(new ParameterizedThreadStart(Delegate_SelectedSchedule_Cell));
                        CellselectionThread.Start(i);
                    }

            }
        }

        /// <summary>
        /// Timed 애니메이션
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            double tic = Convert.ToDouble(comboBox3.SelectedItem);
            _AnimationTic = (int)(tic * 1000);
            SetTimeLineAnimation();
            model1.StartAnimation(1);
        }

        /// <summary>
        /// 다음스텝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (_CurrentStep == _TotalJobNum)
                return;

            Assign_Schedule(_CurrentStep, _lstSchedule);
            _DT_ScheduleList_Assigned.Rows.Add(_lstSchedule[_CurrentStep].ID_LOT,
                _lstSchedule[_CurrentStep].ID_Machine,
                _lstSchedule[_CurrentStep].JobType,
                _lstSchedule[_CurrentStep].ProcessingTime,
                _lstSchedule[_CurrentStep].StartTime,
                _lstSchedule[_CurrentStep].EndTime,
                _lstSchedule[_CurrentStep].DueTime,
                _lstSchedule[_CurrentStep].Setup,
                _lstSchedule[_CurrentStep].Violation);

            Grid_WF_SCHEDULELIST_ASSIGNED.CurrentCell =
                Grid_WF_SCHEDULELIST_ASSIGNED.Rows[Grid_WF_SCHEDULELIST_ASSIGNED.Rows.Count - 1].Cells[0];


            _CHARTDT_Tardy.Rows.Clear();

            SetGraphByStep(_CurrentStep);

            _CurrentStep++;
          
        }

        private void UpdateSelectCol(List<StatesModel> currInfo)
        {
            foreach(Entity en in model1.Entities.ToList())
            {
                if(en.ToString().Contains("Referencing: In_JobBox" + "_") || en.ToString().Contains("Referencing: End_JobBox"))
                {
                    if(model1.Entities.ToList().Contains(en))
                        model1.Entities.Remove(en);
                }
            }

           Dictionary<string, int> InJob = new Dictionary<string, int>(DicJobCount_IN_Clone);
 
           foreach(StatesModel model in currInfo)
            {
                Dictionary<int, ScheduleModel> dicendjob = new Dictionary<int, ScheduleModel>();
                MachineNode box = DicMachine["M" + model.MachineNumber];
                box.MachineState = model.MachineState;
                MachineShape boXShape = DicBoxSahpe[model.MachineNumber + 1];
                //boXShape.UpdateJobColor(model.JobName.Last().Substring(0, 1));
                boXShape.JobMesh.Visible = false;
                boXShape.UpdateJobColor(model.JobName.Last().Substring(0, 1));
                boXShape.UpdateMachineState_1(box);
                BlockReference br = model1.Entities.ToList().First(p => p.ToString().Contains("Referencing: " + box.Name)) as BlockReference;
                //UpdateMachineState(box);
                if (model.MachineState is MACHINE_STATE.WORKING)
                {
                    //boXShape.JobMesh.Visible = true;
                    br.Attributes["att0"].Value = model.JobName.Last().ToString();
                    br.Attributes["att0"].Color = GeneralFunc.SetColor(model.JobName.Last().Substring(0, 1));

                }
                else if (box.MachineState is MACHINE_STATE.IDLE)
                {
                    br.Attributes["att0"].Value = "IDLE";
                    br.Attributes["att0"].Color = Color.Black;

                }
                else if (box.MachineState is MACHINE_STATE.LOADING)
                {
                    
                    br.Attributes["att0"].Value = "SET UP";
                    br.Attributes["att0"].Color = Color.Red;
                    //boXShape.OutJobMesh.Visible = false;
                }
                else
                {
                    boXShape.JobMesh.Visible = false;
                }


                if (model.JobName.Count != 0)
                {
                    //boXShape.OutJobMesh.Visible = true ;
                    foreach (string name in model.JobName)
                    {
                        if (DicJobInfo.ContainsKey(name))
                        {
                          
                            InJob[name.Substring(0, 1)]--;
                        }

                    }
                    UpdateEndJob(box, dicendjob);

                }

                if (model.EndJob.Count !=0)
                {
                    //boXShape.OutJobMesh.Visible = true ;
                    foreach(string name in model.EndJob)
                    {
                        if (DicJobInfo.ContainsKey(name))
                        {
                            dicendjob.Add(DicJobInfo[name].EndTime, DicJobInfo[name]);
                          
                        }
                          
                    }
                    UpdateEndJob(box, dicendjob);
                    
                }
                box.WorkCount = model.JobName.Count;
                box.TotalsetupTime = model.SetupTime;
                box.TotalworkTime = model.WorkingTime;
                box.TotalIdleTime = model.IdleTime;
            }
           
            Set_InJobBox(InJob);
            UpdateInJobLabel(InJob);
            UpdateMachinLabel(DicMachine); 
        }
        /// <summary>
        /// 전스텝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (_CurrentStep == 0)
                return;

            DeAssign_Schedule(_CurrentStep, _lstSchedule);
            _DT_ScheduleList_Assigned.Rows.RemoveAt(_DT_ScheduleList_Assigned.Rows.Count - 1);
            _CurrentStep--;

            SetGraphByStep(_CurrentStep - 1);
        }

        /// <summary>
        /// 재생버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            double tic = Convert.ToDouble(comboBox3.SelectedItem);
            _AnimationTic = (int)(tic * 1000);
            SetSchedulAnimation();
        }

        /// <summary>
        /// 맨앞으로
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            InitializeSchedule();
        }

        /// <summary>
        /// 맨끝으로
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = _CurrentStep; i < _TotalJobNum; i++)
            {
                _DT_ScheduleList_Assigned.Rows.Add(_lstSchedule[_CurrentStep].ID_LOT,
                    _lstSchedule[_CurrentStep].ID_Machine,
                    _lstSchedule[_CurrentStep].JobType,
                    _lstSchedule[_CurrentStep].ProcessingTime,
                    _lstSchedule[_CurrentStep].StartTime,
                    _lstSchedule[_CurrentStep].EndTime,
                    _lstSchedule[_CurrentStep].DueTime,
                    _lstSchedule[_CurrentStep].Setup,
                    _lstSchedule[_CurrentStep].Violation);

                Assign_Schedule(_CurrentStep, _lstSchedule);
                _CurrentStep++;
            }
            SetGraphByStep(_CurrentStep - 1);
            //SetInJob(DicJobCount_IN);
            Set_InJobBox(DicJobCount_IN);
            UpdateInJobLabel(DicJobCount_IN);
            DicJobCount_IN_Clone = new Dictionary<string, int>(DicJobCount_IN);
            this.model1.Refresh();
            this.model1.ZoomFit();
            
        }

        private void BTN_INITIAL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로드한 스케줄대로 초기화합니다", "Initialize", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearSchedules();
                StartNewDispatching(_lstOriginalSchedule);
            }
        }

        private void BTN_CLEAR_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Job List를 남기고 작성된 스케쥴을 모두 삭제합니다", "Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearSchedules();
            }
        }

        private void BTN_LOGIC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(comboBox1.SelectedItem + " Rule로 스케쥴을 작성합니다", "New Schedule", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              
                if (_DT_ScheduleList != null&&_DT_ScheduleList.Rows.Count > 0)
                {
                    MessageBox.Show("이전 작성된 스케줄을 Clear 한 뒤 실행 가능합니다");
                    return;
                }

                int machines = Convert.ToInt32(comboBox2.SelectedItem);
                //List<string> lstStrSchedules = SchdulingRules.GetSchedule(comboBox1.SelectedIndex, machines, _DT_Job);

                //StartNewDispatching(lstStrSchedules);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (_lstSchedule != null)
            {
                if (MessageBox.Show("이전에 진행된 스케쥴을 삭제하고 다시 로드합니다", "Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ClearSchedules();
                }
                else
                {
                    return;
                }
            }

            if (ReadFiles())
            {
                string versionInfo = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                System.Drawing.Point centerPoint = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Height / 2));
                SplashScreenManager.ShowForm(this, typeof(FormLoading));
                SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.RECEIVE_VERSION, versionInfo);
                SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETMAXPGBVALUE, 100);
                SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 20);
                SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 40);
                InitializeGrid();
                SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 60);
                InitializeGraph();
                SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 80);
                InitializeEyeShot();
                SplashScreenManager.Default.SendCommand(FormLoading.SplashScreenCommand.SETCURRENTVALUE, 100);
                SplashScreenManager.CloseForm();
            }
            else
            {
                MessageBox.Show("형식에 맞지 않는 데이터입니다.");
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            SplashScreenManager.CloseForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SplashScreenManager.CloseForm();
        }
        //public ToolTipControllerShowEventArgs CreateShowArgs(MachineNode node)
        //{
        //    //ToolTipControllerShowEventArgs args = tooltipcontroller1.CreateShowArgs();

        //    //args.ToolTip = node.Name + "\r\n" + "총 작업 수 : " + node.WorkCount + "\r\n" + "총 작업 시간 : " + node.TotalworkTime + "\r\n" + "총 셋업 시간 : " + node.TotalsetupTime + "\r\n" + "총 유휴 시간 : " + node.TotalIdleTime;
        //    //args.Title = "Machine informaion";
        //    //args.IconType = ToolTipIconType.None;
        //    //args.IconSize = ToolTipIconSize.Large;

        //    //return args;


        //}
        private void model1_MouseMove(object sender, MouseEventArgs e)
        {
            
            //int index = this.model1.GetEntityUnderMouseCursor(e.Location);

            //if (index > -1 && index < this.model1.Entities.Count)
            //{
            //    if (model1.Entities[index].ToString().Contains("M"))
            //    {
            //        string[] ddd = model1.Entities[index].ToString().Split('M');
            //        if(DicMachine.ContainsKey("M" + ddd[1]))
            //        {
            //            MachineNode machineode = DicMachine["M" + ddd[1]];
            //            ToolTipControllerShowEventArgs arg = CreateShowArgs(machineode);
            //            tooltipcontroller1.ShowHint(arg, this.model1.PointToScreen(new System.Drawing.Point(e.X, e.Y)));
            //        }
                  
            //        return;
            //    }
               

            //}
            //else
            //{
            //    tooltipcontroller1.HideHint();
            //}
        }

        private void bt_JobLoad_Click(object sender, EventArgs e)
        {
            if (_lstSchedule != null)
            {
                if (MessageBox.Show("이전에 진행된 JOB LIST를 삭제하고 다시 로드합니다", "Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ClearSchedules();
                }
                else
                {
                    return;
                }
            }

            if (_DT_Job != null)
                ClearSchedules();
            if(ReadJobList())
            {
            

            }
            else
            {
                MessageBox.Show("형식에 맞지 않는 데이터입니다.");
            }

        }
        public bool ReadJobList()
        {
           
            _LoadCsvPath = GeneralFunc.OpenFiles();

            if (_LoadCsvPath == string.Empty)
                return false;

            List<string> lstReadCSV = GeneralFunc.ReadCsv(_LoadCsvPath);
            if (lstReadCSV == null)
                return false;

            //리스트로 이루어진 스케쥴 초기 모델


            DataTable DT_Job = GeneralFunc.GetNewJobDT();
            _DT_Job = DT_Job;


            for (int i = 1; i < lstReadCSV.Count; i++)
            {
                if (string.IsNullOrEmpty(lstReadCSV[i]))
                    continue;

                string[] split = lstReadCSV[i].Split(STR.COMMA);

                _DT_Job.Rows.Add(i, split[0], split[1], split[2]);
            }

            _TotalJobNum = _DT_Job.Rows.Count;


            //Grid_WF_JOB.BeginInvoke(new Action(() => Grid_WF_JOB.DataSource = _DT_Job));

            //Grid_WF_SCHEDULE.BeginInvoke(new Action(() => Grid_WF_SCHEDULE.Refresh()));
            //Grid_WF_SCHEDULELIST.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST.Refresh()));

            GB_JOB.BeginInvoke(new Action(() => GB_JOB.Text = "Job List : " + _TotalJobNum));
            GB_SCHEDULELIST.BeginInvoke(new Action(() => GB_SCHEDULELIST.Text = "Schedule List : " + _TotalJobNum));
            GB_SCHEDULELIST_ASSIGNED.BeginInvoke(new Action(() => GB_SCHEDULELIST_ASSIGNED.Text = "Assigned Schedule List : "));

            // 잡 DT 생성	
            if (Grid_WF_JOB.InvokeRequired)
                Grid_WF_JOB.BeginInvoke(new Action(() => Grid_WF_JOB.DataSource = _DT_Job));
            else
                Grid_WF_JOB.DataSource = _DT_Job;

            Grid_WF_SCHEDULELIST.BeginInvoke(new Action(() => Grid_WF_SCHEDULELIST.DataSource = _DT_ScheduleList));

            return true;
        }
    }
    

}
