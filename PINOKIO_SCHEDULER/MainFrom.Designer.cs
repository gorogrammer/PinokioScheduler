
namespace PINOKIO_SCHEDULER
{
    partial class MainFrom
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            devDept.Eyeshot.CancelToolBarButton cancelToolBarButton1 = new devDept.Eyeshot.CancelToolBarButton("Cancel", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ProgressBar progressBar1 = new devDept.Eyeshot.ProgressBar(devDept.Eyeshot.ProgressBar.styleType.Circular, 0, "Idle", System.Drawing.Color.Black, System.Drawing.Color.Transparent, System.Drawing.Color.Green, 1D, true, cancelToolBarButton1, false, 0.1D, true);
            devDept.Graphics.BackgroundSettings backgroundSettings1 = new devDept.Graphics.BackgroundSettings(devDept.Graphics.backgroundStyleType.LinearGradient, System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231))))), System.Drawing.Color.DodgerBlue, System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), 0.75D, null, devDept.Graphics.colorThemeType.Auto, 0.33D);
            devDept.Eyeshot.Camera camera1 = new devDept.Eyeshot.Camera(new devDept.Geometry.Point3D(0D, 0D, 45D), 380D, new devDept.Geometry.Quaternion(0.018434349666532526D, 0.039532590434972079D, 0.42221602280006187D, 0.90544518284475428D), devDept.Graphics.projectionType.Perspective, 40D, 6.4400001599997889D, false, 0.001D);
            devDept.Eyeshot.HomeToolBarButton homeToolBarButton1 = new devDept.Eyeshot.HomeToolBarButton("Home", devDept.Eyeshot.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.MagnifyingGlassToolBarButton magnifyingGlassToolBarButton1 = new devDept.Eyeshot.MagnifyingGlassToolBarButton("Magnifying Glass", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomWindowToolBarButton zoomWindowToolBarButton1 = new devDept.Eyeshot.ZoomWindowToolBarButton("Zoom Window", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomToolBarButton zoomToolBarButton1 = new devDept.Eyeshot.ZoomToolBarButton("Zoom", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.PanToolBarButton panToolBarButton1 = new devDept.Eyeshot.PanToolBarButton("Pan", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.RotateToolBarButton rotateToolBarButton1 = new devDept.Eyeshot.RotateToolBarButton("Rotate", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomFitToolBarButton zoomFitToolBarButton1 = new devDept.Eyeshot.ZoomFitToolBarButton("Zoom Fit", devDept.Eyeshot.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.ToolBar toolBar1 = new devDept.Eyeshot.ToolBar(devDept.Eyeshot.ToolBar.positionType.HorizontalTopCenter, true, new devDept.Eyeshot.ToolBarButton[] {
            ((devDept.Eyeshot.ToolBarButton)(homeToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(magnifyingGlassToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(zoomWindowToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(zoomToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(panToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(rotateToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(zoomFitToolBarButton1))});
            devDept.Eyeshot.Grid grid1 = new devDept.Eyeshot.Grid(new devDept.Geometry.Point3D(-100D, -100D, 0D), new devDept.Geometry.Point3D(100D, 100D, 0D), 10D, new devDept.Geometry.Plane(new devDept.Geometry.Point3D(0D, 0D, 0D), new devDept.Geometry.Vector3D(0D, 0D, 1D)), System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), false, true, false, false, 10, 100, 10, System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90))))), System.Drawing.Color.Transparent, false, System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))));
            devDept.Eyeshot.RotateSettings rotateSettings1 = new devDept.Eyeshot.RotateSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.None), 10D, true, 1D, devDept.Eyeshot.rotationType.Trackball, devDept.Eyeshot.rotationCenterType.CursorLocation, new devDept.Geometry.Point3D(0D, 0D, 0D), false);
            devDept.Eyeshot.ZoomSettings zoomSettings1 = new devDept.Eyeshot.ZoomSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.Shift), 25, true, devDept.Eyeshot.zoomStyleType.AtCursorLocation, false, 1D, System.Drawing.Color.Empty, devDept.Eyeshot.Camera.perspectiveFitType.Accurate, false, 10, true);
            devDept.Eyeshot.PanSettings panSettings1 = new devDept.Eyeshot.PanSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.Ctrl), 25, true);
            devDept.Eyeshot.NavigationSettings navigationSettings1 = new devDept.Eyeshot.NavigationSettings(devDept.Eyeshot.Camera.navigationType.Examine, new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Left, devDept.Eyeshot.modifierKeys.None), new devDept.Geometry.Point3D(-1000D, -1000D, -1000D), new devDept.Geometry.Point3D(1000D, 1000D, 1000D), 8D, 50D, 50D);
            devDept.Eyeshot.Viewport.SavedViewsManager savedViewsManager1 = new devDept.Eyeshot.Viewport.SavedViewsManager(8);
            devDept.Eyeshot.Viewport viewport1 = new devDept.Eyeshot.Viewport(new System.Drawing.Point(0, 0), new System.Drawing.Size(1228, 644), backgroundSettings1, camera1, new devDept.Eyeshot.ToolBar[] {
            toolBar1}, devDept.Eyeshot.displayType.Rendered, true, false, false, false, new devDept.Eyeshot.Grid[] {
            grid1}, false, rotateSettings1, zoomSettings1, panSettings1, navigationSettings1, savedViewsManager1, devDept.Eyeshot.viewType.Trimetric);
            devDept.Eyeshot.CoordinateSystemIcon coordinateSystemIcon1 = new devDept.Eyeshot.CoordinateSystemIcon(System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80))))), System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80))))), System.Drawing.Color.OrangeRed, "Origin", "X", "Y", "Z", true, devDept.Eyeshot.coordinateSystemPositionType.BottomLeft, 37, false);
            devDept.Eyeshot.OriginSymbol originSymbol1 = new devDept.Eyeshot.OriginSymbol(10, devDept.Eyeshot.originSymbolStyleType.Ball, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Blue, "Origin", "X", "Y", "Z", true, null, false);
            devDept.Eyeshot.ViewCubeIcon viewCubeIcon1 = new devDept.Eyeshot.ViewCubeIcon(devDept.Eyeshot.coordinateSystemPositionType.TopRight, true, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(20)))), ((int)(((byte)(147))))), true, "FRONT", "BACK", "LEFT", "RIGHT", "TOP", "BOTTOM", System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), 'S', 'N', 'W', 'E', true, System.Drawing.Color.White, System.Drawing.Color.Black, 120, true, true, null, null, null, null, null, null, false);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_JobLoad = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GB_List = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.GB_JOB = new System.Windows.Forms.GroupBox();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.Grid_WF_JOB = new System.Windows.Forms.DataGridView();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BTN_LOGIC = new System.Windows.Forms.Button();
            this.BTN_CLEAR = new System.Windows.Forms.Button();
            this.BTN_INITIAL = new System.Windows.Forms.Button();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.GB_SCHEDULELIST = new System.Windows.Forms.GroupBox();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GB_SCHEDULELIST_ASSIGNED = new System.Windows.Forms.GroupBox();
            this.Grid_WF_SCHEDULELIST_ASSIGNED = new System.Windows.Forms.DataGridView();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CHART_TARDY = new DevExpress.XtraCharts.ChartControl();
            this.splitContainer11 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CHART_SETUP = new DevExpress.XtraCharts.ChartControl();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CHART_RESOURCE = new DevExpress.XtraCharts.ChartControl();
            this.splitContainer12 = new System.Windows.Forms.SplitContainer();
            this.GB_RT_OUTPUT = new System.Windows.Forms.GroupBox();
            this.CHART_RT_OUTPUT = new DevExpress.XtraCharts.ChartControl();
            this.splitContainer13 = new System.Windows.Forms.SplitContainer();
            this.GB_RT_SETUP = new System.Windows.Forms.GroupBox();
            this.CHART_RT_SETUP = new DevExpress.XtraCharts.ChartControl();
            this.GB_TIMED_RESOURCE = new System.Windows.Forms.GroupBox();
            this.CHART_RT_RESOURCE = new DevExpress.XtraCharts.ChartControl();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.GB_SCHEDULE = new System.Windows.Forms.GroupBox();
            this.Grid_WF_SCHEDULE = new System.Windows.Forms.DataGridView();
            this.model1 = new devDept.Eyeshot.Model();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BTN_TIMELINE_MOVE = new System.Windows.Forms.Button();
            this.BTN_MOVE_FIRST = new System.Windows.Forms.Button();
            this.BTN_MOVE_LAST = new System.Windows.Forms.Button();
            this.BTN_MOVE = new System.Windows.Forms.Button();
            this.BTN_MOVE_FORWARD = new System.Windows.Forms.Button();
            this.BTN_MOVE_BACK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Grid_WF_SCHEDULELIST = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GB_List.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.GB_JOB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_JOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.GB_SCHEDULELIST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.Panel1.SuspendLayout();
            this.splitContainer9.Panel2.SuspendLayout();
            this.splitContainer9.SuspendLayout();
            this.GB_SCHEDULELIST_ASSIGNED.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULELIST_ASSIGNED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_TARDY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).BeginInit();
            this.splitContainer11.Panel1.SuspendLayout();
            this.splitContainer11.Panel2.SuspendLayout();
            this.splitContainer11.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_SETUP)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RESOURCE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).BeginInit();
            this.splitContainer12.Panel1.SuspendLayout();
            this.splitContainer12.Panel2.SuspendLayout();
            this.splitContainer12.SuspendLayout();
            this.GB_RT_OUTPUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_OUTPUT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).BeginInit();
            this.splitContainer13.Panel1.SuspendLayout();
            this.splitContainer13.Panel2.SuspendLayout();
            this.splitContainer13.SuspendLayout();
            this.GB_RT_SETUP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_SETUP)).BeginInit();
            this.GB_TIMED_RESOURCE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_RESOURCE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            this.GB_SCHEDULE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULELIST)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 430;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer8);
            this.splitContainer1.Size = new System.Drawing.Size(1662, 933);
            this.splitContainer1.SplitterDistance = 430;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.GB_List);
            this.splitContainer2.Size = new System.Drawing.Size(430, 933);
            this.splitContainer2.SplitterDistance = 53;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bt_JobLoad);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(0, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load and Settings";
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Items.AddRange(new object[] {
            "0.3",
            "0.5",
            "0.7",
            "1.0"});
            this.comboBox3.Location = new System.Drawing.Point(366, 26);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(58, 22);
            this.comboBox3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Animation interval";
            // 
            // bt_JobLoad
            // 
            this.bt_JobLoad.Location = new System.Drawing.Point(81, 23);
            this.bt_JobLoad.Name = "bt_JobLoad";
            this.bt_JobLoad.Size = new System.Drawing.Size(69, 27);
            this.bt_JobLoad.TabIndex = 4;
            this.bt_JobLoad.Text = "Job";
            this.bt_JobLoad.UseVisualStyleBackColor = true;
            this.bt_JobLoad.Click += new System.EventHandler(this.bt_JobLoad_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Schedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // GB_List
            // 
            this.GB_List.Controls.Add(this.splitContainer3);
            this.GB_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_List.Location = new System.Drawing.Point(0, 0);
            this.GB_List.Name = "GB_List";
            this.GB_List.Size = new System.Drawing.Size(430, 875);
            this.GB_List.TabIndex = 1;
            this.GB_List.TabStop = false;
            this.GB_List.Text = "Lists";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 18);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(424, 854);
            this.splitContainer3.SplitterDistance = 507;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 2;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.GB_JOB);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer7);
            this.splitContainer4.Size = new System.Drawing.Size(424, 507);
            this.splitContainer4.SplitterDistance = 130;
            this.splitContainer4.SplitterWidth = 5;
            this.splitContainer4.TabIndex = 0;
            // 
            // GB_JOB
            // 
            this.GB_JOB.Controls.Add(this.splitContainer10);
            this.GB_JOB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_JOB.Location = new System.Drawing.Point(0, 0);
            this.GB_JOB.Name = "GB_JOB";
            this.GB_JOB.Size = new System.Drawing.Size(424, 130);
            this.GB_JOB.TabIndex = 4;
            this.GB_JOB.TabStop = false;
            this.GB_JOB.Text = "Job List";
            // 
            // splitContainer10
            // 
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer10.Location = new System.Drawing.Point(3, 18);
            this.splitContainer10.Name = "splitContainer10";
            this.splitContainer10.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.Grid_WF_JOB);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.comboBox2);
            this.splitContainer10.Panel2.Controls.Add(this.label3);
            this.splitContainer10.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer10.Panel2.Controls.Add(this.BTN_LOGIC);
            this.splitContainer10.Panel2.Controls.Add(this.BTN_CLEAR);
            this.splitContainer10.Panel2.Controls.Add(this.BTN_INITIAL);
            this.splitContainer10.Panel2MinSize = 30;
            this.splitContainer10.Size = new System.Drawing.Size(418, 109);
            this.splitContainer10.SplitterDistance = 75;
            this.splitContainer10.TabIndex = 1;
            // 
            // Grid_WF_JOB
            // 
            this.Grid_WF_JOB.AllowUserToAddRows = false;
            this.Grid_WF_JOB.AllowUserToDeleteRows = false;
            this.Grid_WF_JOB.AllowUserToResizeColumns = false;
            this.Grid_WF_JOB.AllowUserToResizeRows = false;
            this.Grid_WF_JOB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid_WF_JOB.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Grid_WF_JOB.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.Grid_WF_JOB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grid_WF_JOB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_WF_JOB.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grid_WF_JOB.Location = new System.Drawing.Point(0, 0);
            this.Grid_WF_JOB.Name = "Grid_WF_JOB";
            this.Grid_WF_JOB.ReadOnly = true;
            this.Grid_WF_JOB.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid_WF_JOB.RowTemplate.Height = 23;
            this.Grid_WF_JOB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_WF_JOB.Size = new System.Drawing.Size(418, 75);
            this.Grid_WF_JOB.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.comboBox2.Location = new System.Drawing.Point(196, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(47, 22);
            this.comboBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "M";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "FIFO-Round Robin",
            "EDD",
            "Setup First"});
            this.comboBox1.Location = new System.Drawing.Point(248, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(85, 22);
            this.comboBox1.TabIndex = 3;
            // 
            // BTN_LOGIC
            // 
            this.BTN_LOGIC.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTN_LOGIC.Location = new System.Drawing.Point(339, 1);
            this.BTN_LOGIC.Name = "BTN_LOGIC";
            this.BTN_LOGIC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BTN_LOGIC.Size = new System.Drawing.Size(79, 27);
            this.BTN_LOGIC.TabIndex = 2;
            this.BTN_LOGIC.Text = "Diapatching";
            this.BTN_LOGIC.UseVisualStyleBackColor = true;
            this.BTN_LOGIC.Click += new System.EventHandler(this.BTN_LOGIC_Click);
            // 
            // BTN_CLEAR
            // 
            this.BTN_CLEAR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BTN_CLEAR.Location = new System.Drawing.Point(65, 1);
            this.BTN_CLEAR.Name = "BTN_CLEAR";
            this.BTN_CLEAR.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BTN_CLEAR.Size = new System.Drawing.Size(100, 27);
            this.BTN_CLEAR.TabIndex = 2;
            this.BTN_CLEAR.Text = "Clear Schedule";
            this.BTN_CLEAR.UseVisualStyleBackColor = true;
            this.BTN_CLEAR.Click += new System.EventHandler(this.BTN_CLEAR_Click);
            // 
            // BTN_INITIAL
            // 
            this.BTN_INITIAL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BTN_INITIAL.Location = new System.Drawing.Point(0, 2);
            this.BTN_INITIAL.Name = "BTN_INITIAL";
            this.BTN_INITIAL.Size = new System.Drawing.Size(59, 27);
            this.BTN_INITIAL.TabIndex = 1;
            this.BTN_INITIAL.Text = "Initialize";
            this.BTN_INITIAL.UseVisualStyleBackColor = true;
            this.BTN_INITIAL.Click += new System.EventHandler(this.BTN_INITIAL_Click);
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.GB_SCHEDULELIST);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.GB_SCHEDULELIST_ASSIGNED);
            this.splitContainer7.Size = new System.Drawing.Size(424, 372);
            this.splitContainer7.SplitterDistance = 190;
            this.splitContainer7.TabIndex = 1;
            // 
            // GB_SCHEDULELIST
            // 
            this.GB_SCHEDULELIST.Controls.Add(this.splitContainer9);
            this.GB_SCHEDULELIST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_SCHEDULELIST.Location = new System.Drawing.Point(0, 0);
            this.GB_SCHEDULELIST.Name = "GB_SCHEDULELIST";
            this.GB_SCHEDULELIST.Size = new System.Drawing.Size(424, 190);
            this.GB_SCHEDULELIST.TabIndex = 0;
            this.GB_SCHEDULELIST.TabStop = false;
            this.GB_SCHEDULELIST.Text = "Schedule List";
            // 
            // splitContainer9
            // 
            this.splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer9.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer9.Location = new System.Drawing.Point(3, 18);
            this.splitContainer9.Name = "splitContainer9";
            this.splitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer9.Panel1
            // 
            this.splitContainer9.Panel1.Controls.Add(this.Grid_WF_SCHEDULELIST);
            // 
            // splitContainer9.Panel2
            // 
            this.splitContainer9.Panel2.Controls.Add(this.label2);
            this.splitContainer9.Panel2.Controls.Add(this.label1);
            this.splitContainer9.Panel2.Controls.Add(this.BTN_TIMELINE_MOVE);
            this.splitContainer9.Panel2.Controls.Add(this.BTN_MOVE_FIRST);
            this.splitContainer9.Panel2.Controls.Add(this.BTN_MOVE_LAST);
            this.splitContainer9.Panel2.Controls.Add(this.BTN_MOVE);
            this.splitContainer9.Panel2.Controls.Add(this.BTN_MOVE_FORWARD);
            this.splitContainer9.Panel2.Controls.Add(this.BTN_MOVE_BACK);
            this.splitContainer9.Panel2MinSize = 40;
            this.splitContainer9.Size = new System.Drawing.Size(418, 169);
            this.splitContainer9.SplitterDistance = 125;
            this.splitContainer9.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dispatching";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Timed";
            // 
            // GB_SCHEDULELIST_ASSIGNED
            // 
            this.GB_SCHEDULELIST_ASSIGNED.Controls.Add(this.Grid_WF_SCHEDULELIST_ASSIGNED);
            this.GB_SCHEDULELIST_ASSIGNED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_SCHEDULELIST_ASSIGNED.Location = new System.Drawing.Point(0, 0);
            this.GB_SCHEDULELIST_ASSIGNED.Name = "GB_SCHEDULELIST_ASSIGNED";
            this.GB_SCHEDULELIST_ASSIGNED.Size = new System.Drawing.Size(424, 178);
            this.GB_SCHEDULELIST_ASSIGNED.TabIndex = 2;
            this.GB_SCHEDULELIST_ASSIGNED.TabStop = false;
            this.GB_SCHEDULELIST_ASSIGNED.Text = "Assigned Schedule List";
            // 
            // Grid_WF_SCHEDULELIST_ASSIGNED
            // 
            this.Grid_WF_SCHEDULELIST_ASSIGNED.AllowUserToAddRows = false;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.AllowUserToDeleteRows = false;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.AllowUserToResizeColumns = false;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.AllowUserToResizeRows = false;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.Location = new System.Drawing.Point(3, 18);
            this.Grid_WF_SCHEDULELIST_ASSIGNED.Name = "Grid_WF_SCHEDULELIST_ASSIGNED";
            this.Grid_WF_SCHEDULELIST_ASSIGNED.ReadOnly = true;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.RowTemplate.Height = 23;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.Size = new System.Drawing.Size(418, 157);
            this.Grid_WF_SCHEDULELIST_ASSIGNED.TabIndex = 1;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.splitContainer6);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer12);
            this.splitContainer5.Size = new System.Drawing.Size(424, 342);
            this.splitContainer5.SplitterDistance = 169;
            this.splitContainer5.TabIndex = 0;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.splitContainer11);
            this.splitContainer6.Size = new System.Drawing.Size(424, 169);
            this.splitContainer6.SplitterDistance = 126;
            this.splitContainer6.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CHART_TARDY);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(126, 169);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tardy";
            // 
            // CHART_TARDY
            // 
            this.CHART_TARDY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CHART_TARDY.Legend.Name = "Default Legend";
            this.CHART_TARDY.Legend.TextVisible = false;
            this.CHART_TARDY.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.CHART_TARDY.Location = new System.Drawing.Point(3, 18);
            this.CHART_TARDY.Name = "CHART_TARDY";
            this.CHART_TARDY.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.CHART_TARDY.Size = new System.Drawing.Size(120, 148);
            this.CHART_TARDY.TabIndex = 0;
            // 
            // splitContainer11
            // 
            this.splitContainer11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer11.Location = new System.Drawing.Point(0, 0);
            this.splitContainer11.Name = "splitContainer11";
            // 
            // splitContainer11.Panel1
            // 
            this.splitContainer11.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainer11.Panel2
            // 
            this.splitContainer11.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer11.Size = new System.Drawing.Size(294, 169);
            this.splitContainer11.SplitterDistance = 149;
            this.splitContainer11.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CHART_SETUP);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(149, 169);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Setup Changes";
            // 
            // CHART_SETUP
            // 
            this.CHART_SETUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CHART_SETUP.Legend.Name = "Default Legend";
            this.CHART_SETUP.Legend.TextVisible = false;
            this.CHART_SETUP.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.CHART_SETUP.Location = new System.Drawing.Point(3, 18);
            this.CHART_SETUP.Name = "CHART_SETUP";
            this.CHART_SETUP.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.CHART_SETUP.Size = new System.Drawing.Size(143, 148);
            this.CHART_SETUP.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CHART_RESOURCE);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(141, 169);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Resource Utilities";
            // 
            // CHART_RESOURCE
            // 
            this.CHART_RESOURCE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CHART_RESOURCE.Legend.Name = "Default Legend";
            this.CHART_RESOURCE.Legend.TextVisible = false;
            this.CHART_RESOURCE.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.CHART_RESOURCE.Location = new System.Drawing.Point(3, 18);
            this.CHART_RESOURCE.Name = "CHART_RESOURCE";
            this.CHART_RESOURCE.PaletteName = "Apex";
            this.CHART_RESOURCE.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.CHART_RESOURCE.Size = new System.Drawing.Size(135, 148);
            this.CHART_RESOURCE.TabIndex = 0;
            // 
            // splitContainer12
            // 
            this.splitContainer12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer12.Location = new System.Drawing.Point(0, 0);
            this.splitContainer12.Name = "splitContainer12";
            // 
            // splitContainer12.Panel1
            // 
            this.splitContainer12.Panel1.Controls.Add(this.GB_RT_OUTPUT);
            // 
            // splitContainer12.Panel2
            // 
            this.splitContainer12.Panel2.Controls.Add(this.splitContainer13);
            this.splitContainer12.Size = new System.Drawing.Size(424, 169);
            this.splitContainer12.SplitterDistance = 126;
            this.splitContainer12.TabIndex = 1;
            // 
            // GB_RT_OUTPUT
            // 
            this.GB_RT_OUTPUT.Controls.Add(this.CHART_RT_OUTPUT);
            this.GB_RT_OUTPUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_RT_OUTPUT.Location = new System.Drawing.Point(0, 0);
            this.GB_RT_OUTPUT.Name = "GB_RT_OUTPUT";
            this.GB_RT_OUTPUT.Size = new System.Drawing.Size(126, 169);
            this.GB_RT_OUTPUT.TabIndex = 0;
            this.GB_RT_OUTPUT.TabStop = false;
            this.GB_RT_OUTPUT.Text = "Real-Time Output";
            // 
            // CHART_RT_OUTPUT
            // 
            this.CHART_RT_OUTPUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CHART_RT_OUTPUT.Legend.Name = "Default Legend";
            this.CHART_RT_OUTPUT.Legend.TextVisible = false;
            this.CHART_RT_OUTPUT.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.CHART_RT_OUTPUT.Location = new System.Drawing.Point(3, 18);
            this.CHART_RT_OUTPUT.Name = "CHART_RT_OUTPUT";
            this.CHART_RT_OUTPUT.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.CHART_RT_OUTPUT.Size = new System.Drawing.Size(120, 148);
            this.CHART_RT_OUTPUT.TabIndex = 0;
            // 
            // splitContainer13
            // 
            this.splitContainer13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer13.Location = new System.Drawing.Point(0, 0);
            this.splitContainer13.Name = "splitContainer13";
            // 
            // splitContainer13.Panel1
            // 
            this.splitContainer13.Panel1.Controls.Add(this.GB_RT_SETUP);
            // 
            // splitContainer13.Panel2
            // 
            this.splitContainer13.Panel2.Controls.Add(this.GB_TIMED_RESOURCE);
            this.splitContainer13.Size = new System.Drawing.Size(294, 169);
            this.splitContainer13.SplitterDistance = 149;
            this.splitContainer13.TabIndex = 0;
            // 
            // GB_RT_SETUP
            // 
            this.GB_RT_SETUP.Controls.Add(this.CHART_RT_SETUP);
            this.GB_RT_SETUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_RT_SETUP.Location = new System.Drawing.Point(0, 0);
            this.GB_RT_SETUP.Name = "GB_RT_SETUP";
            this.GB_RT_SETUP.Size = new System.Drawing.Size(149, 169);
            this.GB_RT_SETUP.TabIndex = 0;
            this.GB_RT_SETUP.TabStop = false;
            this.GB_RT_SETUP.Text = "Real-Time Setup Changes";
            // 
            // CHART_RT_SETUP
            // 
            this.CHART_RT_SETUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CHART_RT_SETUP.Legend.Name = "Default Legend";
            this.CHART_RT_SETUP.Legend.TextVisible = false;
            this.CHART_RT_SETUP.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.CHART_RT_SETUP.Location = new System.Drawing.Point(3, 18);
            this.CHART_RT_SETUP.Name = "CHART_RT_SETUP";
            this.CHART_RT_SETUP.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.CHART_RT_SETUP.Size = new System.Drawing.Size(143, 148);
            this.CHART_RT_SETUP.TabIndex = 1;
            // 
            // GB_TIMED_RESOURCE
            // 
            this.GB_TIMED_RESOURCE.Controls.Add(this.CHART_RT_RESOURCE);
            this.GB_TIMED_RESOURCE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_TIMED_RESOURCE.Location = new System.Drawing.Point(0, 0);
            this.GB_TIMED_RESOURCE.Name = "GB_TIMED_RESOURCE";
            this.GB_TIMED_RESOURCE.Size = new System.Drawing.Size(141, 169);
            this.GB_TIMED_RESOURCE.TabIndex = 0;
            this.GB_TIMED_RESOURCE.TabStop = false;
            this.GB_TIMED_RESOURCE.Text = "Real-Time Resource Utilities";
            // 
            // CHART_RT_RESOURCE
            // 
            this.CHART_RT_RESOURCE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CHART_RT_RESOURCE.Legend.Name = "Default Legend";
            this.CHART_RT_RESOURCE.Legend.TextVisible = false;
            this.CHART_RT_RESOURCE.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.CHART_RT_RESOURCE.Location = new System.Drawing.Point(3, 18);
            this.CHART_RT_RESOURCE.Name = "CHART_RT_RESOURCE";
            this.CHART_RT_RESOURCE.PaletteName = "Apex";
            this.CHART_RT_RESOURCE.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.CHART_RT_RESOURCE.Size = new System.Drawing.Size(135, 148);
            this.CHART_RT_RESOURCE.TabIndex = 0;
            // 
            // splitContainer8
            // 
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.Location = new System.Drawing.Point(0, 0);
            this.splitContainer8.Name = "splitContainer8";
            this.splitContainer8.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.GB_SCHEDULE);
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.label5);
            this.splitContainer8.Panel2.Controls.Add(this.model1);
            this.splitContainer8.Size = new System.Drawing.Size(1228, 933);
            this.splitContainer8.SplitterDistance = 285;
            this.splitContainer8.TabIndex = 0;
            // 
            // GB_SCHEDULE
            // 
            this.GB_SCHEDULE.Controls.Add(this.Grid_WF_SCHEDULE);
            this.GB_SCHEDULE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_SCHEDULE.Location = new System.Drawing.Point(0, 0);
            this.GB_SCHEDULE.Name = "GB_SCHEDULE";
            this.GB_SCHEDULE.Size = new System.Drawing.Size(1228, 285);
            this.GB_SCHEDULE.TabIndex = 2;
            this.GB_SCHEDULE.TabStop = false;
            this.GB_SCHEDULE.Text = "SCHEDULE TABLE";
            // 
            // Grid_WF_SCHEDULE
            // 
            this.Grid_WF_SCHEDULE.AllowUserToAddRows = false;
            this.Grid_WF_SCHEDULE.AllowUserToDeleteRows = false;
            this.Grid_WF_SCHEDULE.AllowUserToResizeColumns = false;
            this.Grid_WF_SCHEDULE.AllowUserToResizeRows = false;
            this.Grid_WF_SCHEDULE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid_WF_SCHEDULE.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Grid_WF_SCHEDULE.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.Grid_WF_SCHEDULE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grid_WF_SCHEDULE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_WF_SCHEDULE.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grid_WF_SCHEDULE.Location = new System.Drawing.Point(3, 18);
            this.Grid_WF_SCHEDULE.Name = "Grid_WF_SCHEDULE";
            this.Grid_WF_SCHEDULE.ReadOnly = true;
            this.Grid_WF_SCHEDULE.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid_WF_SCHEDULE.RowTemplate.Height = 23;
            this.Grid_WF_SCHEDULE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Grid_WF_SCHEDULE.Size = new System.Drawing.Size(1222, 264);
            this.Grid_WF_SCHEDULE.TabIndex = 0;
            this.Grid_WF_SCHEDULE.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_WF_SCHEDULE_CellClick);
            this.Grid_WF_SCHEDULE.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grid_WF_SCHEDULE_CellFormatting);
            this.Grid_WF_SCHEDULE.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.Grid_WF_SCHEDULE_CellPainting);
            // 
            // model1
            // 
            this.model1.Cursor = System.Windows.Forms.Cursors.Default;
            this.model1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.model1.Location = new System.Drawing.Point(0, 0);
            this.model1.Name = "model1";
            this.model1.ProgressBar = progressBar1;
            this.model1.Size = new System.Drawing.Size(1228, 644);
            this.model1.TabIndex = 1;
            this.model1.Text = "model1";
            coordinateSystemIcon1.LabelFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            viewport1.CoordinateSystemIcon = coordinateSystemIcon1;
            viewport1.Legends = new devDept.Eyeshot.Legend[0];
            originSymbol1.LabelFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            viewport1.OriginSymbol = originSymbol1;
            viewCubeIcon1.Font = null;
            viewCubeIcon1.InitialRotation = new devDept.Geometry.Quaternion(0D, 0D, 0D, 1D);
            viewport1.ViewCubeIcon = viewCubeIcon1;
            this.model1.Viewports.Add(viewport1);
            this.model1.WaitCursorMode = devDept.Eyeshot.waitCursorType.Never;
            this.model1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.model1_MouseMove);
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // BTN_TIMELINE_MOVE
            // 
            this.BTN_TIMELINE_MOVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_TIMELINE_MOVE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_TIMELINE_MOVE.BackgroundImage")));
            this.BTN_TIMELINE_MOVE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_TIMELINE_MOVE.Location = new System.Drawing.Point(370, 2);
            this.BTN_TIMELINE_MOVE.Name = "BTN_TIMELINE_MOVE";
            this.BTN_TIMELINE_MOVE.Size = new System.Drawing.Size(45, 33);
            this.BTN_TIMELINE_MOVE.TabIndex = 6;
            this.BTN_TIMELINE_MOVE.UseVisualStyleBackColor = true;
            this.BTN_TIMELINE_MOVE.Click += new System.EventHandler(this.button4_Click);
            // 
            // BTN_MOVE_FIRST
            // 
            this.BTN_MOVE_FIRST.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_MOVE_FIRST.BackgroundImage")));
            this.BTN_MOVE_FIRST.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MOVE_FIRST.Location = new System.Drawing.Point(70, 3);
            this.BTN_MOVE_FIRST.Name = "BTN_MOVE_FIRST";
            this.BTN_MOVE_FIRST.Size = new System.Drawing.Size(45, 33);
            this.BTN_MOVE_FIRST.TabIndex = 5;
            this.BTN_MOVE_FIRST.UseVisualStyleBackColor = true;
            this.BTN_MOVE_FIRST.Click += new System.EventHandler(this.button9_Click);
            // 
            // BTN_MOVE_LAST
            // 
            this.BTN_MOVE_LAST.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_MOVE_LAST.BackgroundImage")));
            this.BTN_MOVE_LAST.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MOVE_LAST.Location = new System.Drawing.Point(274, 3);
            this.BTN_MOVE_LAST.Name = "BTN_MOVE_LAST";
            this.BTN_MOVE_LAST.Size = new System.Drawing.Size(45, 33);
            this.BTN_MOVE_LAST.TabIndex = 4;
            this.BTN_MOVE_LAST.UseVisualStyleBackColor = true;
            this.BTN_MOVE_LAST.Click += new System.EventHandler(this.button8_Click);
            // 
            // BTN_MOVE
            // 
            this.BTN_MOVE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_MOVE.BackgroundImage")));
            this.BTN_MOVE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MOVE.Location = new System.Drawing.Point(172, 3);
            this.BTN_MOVE.Name = "BTN_MOVE";
            this.BTN_MOVE.Size = new System.Drawing.Size(45, 33);
            this.BTN_MOVE.TabIndex = 3;
            this.BTN_MOVE.UseVisualStyleBackColor = true;
            this.BTN_MOVE.Click += new System.EventHandler(this.button7_Click);
            // 
            // BTN_MOVE_FORWARD
            // 
            this.BTN_MOVE_FORWARD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_MOVE_FORWARD.BackgroundImage")));
            this.BTN_MOVE_FORWARD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MOVE_FORWARD.Location = new System.Drawing.Point(223, 3);
            this.BTN_MOVE_FORWARD.Name = "BTN_MOVE_FORWARD";
            this.BTN_MOVE_FORWARD.Size = new System.Drawing.Size(45, 33);
            this.BTN_MOVE_FORWARD.TabIndex = 2;
            this.BTN_MOVE_FORWARD.UseVisualStyleBackColor = true;
            this.BTN_MOVE_FORWARD.Click += new System.EventHandler(this.button6_Click);
            // 
            // BTN_MOVE_BACK
            // 
            this.BTN_MOVE_BACK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_MOVE_BACK.BackgroundImage")));
            this.BTN_MOVE_BACK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MOVE_BACK.Location = new System.Drawing.Point(121, 3);
            this.BTN_MOVE_BACK.Name = "BTN_MOVE_BACK";
            this.BTN_MOVE_BACK.Size = new System.Drawing.Size(45, 33);
            this.BTN_MOVE_BACK.TabIndex = 1;
            this.BTN_MOVE_BACK.UseVisualStyleBackColor = true;
            this.BTN_MOVE_BACK.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "label5";
            // 
            // Grid_WF_SCHEDULELIST
            // 
            this.Grid_WF_SCHEDULELIST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_WF_SCHEDULELIST.Location = new System.Drawing.Point(36, 14);
            this.Grid_WF_SCHEDULELIST.Name = "Grid_WF_SCHEDULELIST";
            this.Grid_WF_SCHEDULELIST.RowTemplate.Height = 23;
            this.Grid_WF_SCHEDULELIST.Size = new System.Drawing.Size(240, 150);
            this.Grid_WF_SCHEDULELIST.TabIndex = 0;
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1662, 933);
            this.Controls.Add(this.splitContainer1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MainFrom.IconOptions.Image")));
            this.Name = "MainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScheduleSimulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GB_List.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.GB_JOB.ResumeLayout(false);
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel2.ResumeLayout(false);
            this.splitContainer10.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_JOB)).EndInit();
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.GB_SCHEDULELIST.ResumeLayout(false);
            this.splitContainer9.Panel1.ResumeLayout(false);
            this.splitContainer9.Panel2.ResumeLayout(false);
            this.splitContainer9.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            this.GB_SCHEDULELIST_ASSIGNED.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULELIST_ASSIGNED)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_TARDY)).EndInit();
            this.splitContainer11.Panel1.ResumeLayout(false);
            this.splitContainer11.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).EndInit();
            this.splitContainer11.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_SETUP)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RESOURCE)).EndInit();
            this.splitContainer12.Panel1.ResumeLayout(false);
            this.splitContainer12.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).EndInit();
            this.splitContainer12.ResumeLayout(false);
            this.GB_RT_OUTPUT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_OUTPUT)).EndInit();
            this.splitContainer13.Panel1.ResumeLayout(false);
            this.splitContainer13.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).EndInit();
            this.splitContainer13.ResumeLayout(false);
            this.GB_RT_SETUP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_SETUP)).EndInit();
            this.GB_TIMED_RESOURCE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_RESOURCE)).EndInit();
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel2.ResumeLayout(false);
            this.splitContainer8.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
            this.splitContainer8.ResumeLayout(false);
            this.GB_SCHEDULE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULELIST)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.GroupBox GB_SCHEDULE;
        private devDept.Eyeshot.Model model1;
        private System.Windows.Forms.DataGridView Grid_WF_SCHEDULE;
        private System.Windows.Forms.GroupBox GB_List;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox GB_JOB;
        private System.Windows.Forms.SplitContainer splitContainer10;
        private System.Windows.Forms.DataGridView Grid_WF_JOB;
        private System.Windows.Forms.Button BTN_INITIAL;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraCharts.ChartControl CHART_TARDY;
        private System.Windows.Forms.SplitContainer splitContainer11;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevExpress.XtraCharts.ChartControl CHART_SETUP;
        private System.Windows.Forms.GroupBox groupBox6;
        private DevExpress.XtraCharts.ChartControl CHART_RESOURCE;
        private System.Windows.Forms.SplitContainer splitContainer12;
        private System.Windows.Forms.GroupBox GB_RT_OUTPUT;
        private DevExpress.XtraCharts.ChartControl CHART_RT_OUTPUT;
        private System.Windows.Forms.SplitContainer splitContainer13;
        private System.Windows.Forms.GroupBox GB_RT_SETUP;
        private DevExpress.XtraCharts.ChartControl CHART_RT_SETUP;
        private System.Windows.Forms.GroupBox GB_TIMED_RESOURCE;
        private DevExpress.XtraCharts.ChartControl CHART_RT_RESOURCE;
        private System.Windows.Forms.Button BTN_CLEAR;
        private System.Windows.Forms.Button BTN_LOGIC;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.GroupBox GB_SCHEDULELIST;
        private System.Windows.Forms.GroupBox GB_SCHEDULELIST_ASSIGNED;
        private System.Windows.Forms.DataGridView Grid_WF_SCHEDULELIST_ASSIGNED;
        private System.Windows.Forms.SplitContainer splitContainer9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_TIMELINE_MOVE;
        private System.Windows.Forms.Button BTN_MOVE_FIRST;
        private System.Windows.Forms.Button BTN_MOVE_LAST;
        private System.Windows.Forms.Button BTN_MOVE;
        private System.Windows.Forms.Button BTN_MOVE_FORWARD;
        private System.Windows.Forms.Button BTN_MOVE_BACK;
        private System.Windows.Forms.Button bt_JobLoad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView Grid_WF_SCHEDULELIST;
    }
}

