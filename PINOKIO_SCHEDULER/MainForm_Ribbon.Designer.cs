
namespace PINOKIO_SCHEDULER
{
    partial class MainForm_Ribbon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm_Ribbon));
            devDept.Eyeshot.CancelToolBarButton cancelToolBarButton4 = new devDept.Eyeshot.CancelToolBarButton("Cancel", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ProgressBar progressBar4 = new devDept.Eyeshot.ProgressBar(devDept.Eyeshot.ProgressBar.styleType.Circular, 0, "Idle", System.Drawing.Color.Black, System.Drawing.Color.Transparent, System.Drawing.Color.Green, 1D, true, cancelToolBarButton4, false, 0.1D, true);
            devDept.Graphics.BackgroundSettings backgroundSettings4 = new devDept.Graphics.BackgroundSettings(devDept.Graphics.backgroundStyleType.LinearGradient, System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231))))), System.Drawing.Color.DodgerBlue, System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), 0.75D, null, devDept.Graphics.colorThemeType.Auto, 0.33D);
            devDept.Eyeshot.Camera camera4 = new devDept.Eyeshot.Camera(new devDept.Geometry.Point3D(0D, 0D, 45D), 380D, new devDept.Geometry.Quaternion(0.018434349666532526D, 0.039532590434972079D, 0.42221602280006187D, 0.90544518284475428D), devDept.Graphics.projectionType.Perspective, 40D, 4.4100002055134109D, false, 0.001D);
            devDept.Eyeshot.HomeToolBarButton homeToolBarButton4 = new devDept.Eyeshot.HomeToolBarButton("Home", devDept.Eyeshot.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.MagnifyingGlassToolBarButton magnifyingGlassToolBarButton4 = new devDept.Eyeshot.MagnifyingGlassToolBarButton("Magnifying Glass", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomWindowToolBarButton zoomWindowToolBarButton4 = new devDept.Eyeshot.ZoomWindowToolBarButton("Zoom Window", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomToolBarButton zoomToolBarButton4 = new devDept.Eyeshot.ZoomToolBarButton("Zoom", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.PanToolBarButton panToolBarButton4 = new devDept.Eyeshot.PanToolBarButton("Pan", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.RotateToolBarButton rotateToolBarButton4 = new devDept.Eyeshot.RotateToolBarButton("Rotate", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomFitToolBarButton zoomFitToolBarButton4 = new devDept.Eyeshot.ZoomFitToolBarButton("Zoom Fit", devDept.Eyeshot.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.ToolBar toolBar4 = new devDept.Eyeshot.ToolBar(devDept.Eyeshot.ToolBar.positionType.HorizontalTopCenter, true, new devDept.Eyeshot.ToolBarButton[] {
            ((devDept.Eyeshot.ToolBarButton)(homeToolBarButton4)),
            ((devDept.Eyeshot.ToolBarButton)(magnifyingGlassToolBarButton4)),
            ((devDept.Eyeshot.ToolBarButton)(zoomWindowToolBarButton4)),
            ((devDept.Eyeshot.ToolBarButton)(zoomToolBarButton4)),
            ((devDept.Eyeshot.ToolBarButton)(panToolBarButton4)),
            ((devDept.Eyeshot.ToolBarButton)(rotateToolBarButton4)),
            ((devDept.Eyeshot.ToolBarButton)(zoomFitToolBarButton4))});
            devDept.Eyeshot.Grid grid4 = new devDept.Eyeshot.Grid(new devDept.Geometry.Point3D(-100D, -100D, 0D), new devDept.Geometry.Point3D(100D, 100D, 0D), 10D, new devDept.Geometry.Plane(new devDept.Geometry.Point3D(0D, 0D, 0D), new devDept.Geometry.Vector3D(0D, 0D, 1D)), System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), false, true, false, false, 10, 100, 10, System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90))))), System.Drawing.Color.Transparent, false, System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))));
            devDept.Eyeshot.RotateSettings rotateSettings4 = new devDept.Eyeshot.RotateSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.None), 10D, true, 1D, devDept.Eyeshot.rotationType.Trackball, devDept.Eyeshot.rotationCenterType.CursorLocation, new devDept.Geometry.Point3D(0D, 0D, 0D), false);
            devDept.Eyeshot.ZoomSettings zoomSettings4 = new devDept.Eyeshot.ZoomSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.Shift), 25, true, devDept.Eyeshot.zoomStyleType.AtCursorLocation, false, 1D, System.Drawing.Color.Empty, devDept.Eyeshot.Camera.perspectiveFitType.Accurate, false, 10, true);
            devDept.Eyeshot.PanSettings panSettings4 = new devDept.Eyeshot.PanSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.Ctrl), 25, true);
            devDept.Eyeshot.NavigationSettings navigationSettings4 = new devDept.Eyeshot.NavigationSettings(devDept.Eyeshot.Camera.navigationType.Examine, new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Left, devDept.Eyeshot.modifierKeys.None), new devDept.Geometry.Point3D(-1000D, -1000D, -1000D), new devDept.Geometry.Point3D(1000D, 1000D, 1000D), 8D, 50D, 50D);
            devDept.Eyeshot.Viewport.SavedViewsManager savedViewsManager4 = new devDept.Eyeshot.Viewport.SavedViewsManager(8);
            devDept.Eyeshot.Viewport viewport4 = new devDept.Eyeshot.Viewport(new System.Drawing.Point(0, 0), new System.Drawing.Size(812, 441), backgroundSettings4, camera4, new devDept.Eyeshot.ToolBar[] {
            toolBar4}, devDept.Eyeshot.displayType.Rendered, true, false, false, false, new devDept.Eyeshot.Grid[] {
            grid4}, false, rotateSettings4, zoomSettings4, panSettings4, navigationSettings4, savedViewsManager4, devDept.Eyeshot.viewType.Trimetric);
            devDept.Eyeshot.CoordinateSystemIcon coordinateSystemIcon4 = new devDept.Eyeshot.CoordinateSystemIcon(System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80))))), System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80))))), System.Drawing.Color.OrangeRed, "Origin", "X", "Y", "Z", true, devDept.Eyeshot.coordinateSystemPositionType.BottomLeft, 37, false);
            devDept.Eyeshot.OriginSymbol originSymbol4 = new devDept.Eyeshot.OriginSymbol(10, devDept.Eyeshot.originSymbolStyleType.Ball, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Blue, "Origin", "X", "Y", "Z", true, null, false);
            devDept.Eyeshot.ViewCubeIcon viewCubeIcon4 = new devDept.Eyeshot.ViewCubeIcon(devDept.Eyeshot.coordinateSystemPositionType.TopRight, true, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(20)))), ((int)(((byte)(147))))), true, "FRONT", "BACK", "LEFT", "RIGHT", "TOP", "BOTTOM", System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), 'S', 'N', 'W', 'E', true, System.Drawing.Color.White, System.Drawing.Color.Black, 120, true, true, null, null, null, null, null, null, false);
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbProblemSetting = new DevExpress.XtraBars.BarButtonItem();
            this.bbMakeJobList = new DevExpress.XtraBars.BarButtonItem();
            this.bbOpenJobList = new DevExpress.XtraBars.BarButtonItem();
            this.bbOpenSchedule = new DevExpress.XtraBars.BarButtonItem();
            this.bbExportSchedule = new DevExpress.XtraBars.BarButtonItem();
            this.bbExportJobList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.bbSimPlay = new DevExpress.XtraBars.BarButtonItem();
            this.bbSimulPause = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bb_ExpansionJobList = new DevExpress.XtraBars.BarButtonItem();
            this.bb_ExpansionSchedule = new DevExpress.XtraBars.BarButtonItem();
            this.zoom_Schedule = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemZoomTrackBar3 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
            this.bt_AimationOnOFF = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.bt_Duedate = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.bb_ClearJobList = new DevExpress.XtraBars.BarButtonItem();
            this.bb_Clear_Schedule = new DevExpress.XtraBars.BarButtonItem();
            this.bb_about = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.rpModeling = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpAnalysis = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemZoomTrackBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
            this.repositoryItemTrackBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemTrackBar();
            this.repositoryItemTrackBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemTrackBar();
            this.repositoryItemZoomTrackBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.GB_JOB = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BTN_LOGIC = new System.Windows.Forms.Button();
            this.GB_SCHEDULELIST = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Grid_WF_SCHEDULELIST = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lb_time = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CHART_TARDY = new DevExpress.XtraCharts.ChartControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CHART_SETUP = new DevExpress.XtraCharts.ChartControl();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CHART_RESOURCE = new DevExpress.XtraCharts.ChartControl();
            this.GB_RT_OUTPUT = new System.Windows.Forms.GroupBox();
            this.CHART_RT_OUTPUT = new DevExpress.XtraCharts.ChartControl();
            this.GB_RT_SETUP = new System.Windows.Forms.GroupBox();
            this.CHART_RT_SETUP = new DevExpress.XtraCharts.ChartControl();
            this.GB_TIMED_RESOURCE = new System.Windows.Forms.GroupBox();
            this.CHART_RT_RESOURCE = new DevExpress.XtraCharts.ChartControl();
            this.GB_SCHEDULE = new System.Windows.Forms.GroupBox();
            this.GC_WF_SCHEDULE = new DevExpress.XtraGrid.GridControl();
            this.Grid_WF_SCHEDULE = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.model1 = new devDept.Eyeshot.Model();
            this.GB_SCHEDULELIST_ASSIGNED = new System.Windows.Forms.GroupBox();
            this.Grid_WF_SCHEDULELIST_ASSIGNED = new System.Windows.Forms.DataGridView();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Grid_WF_JOB = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTrackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.GB_JOB.SuspendLayout();
            this.GB_SCHEDULELIST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULELIST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_TARDY)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_SETUP)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RESOURCE)).BeginInit();
            this.GB_RT_OUTPUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_OUTPUT)).BeginInit();
            this.GB_RT_SETUP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_SETUP)).BeginInit();
            this.GB_TIMED_RESOURCE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_RESOURCE)).BeginInit();
            this.GB_SCHEDULE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GC_WF_SCHEDULE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).BeginInit();
            this.GB_SCHEDULELIST_ASSIGNED.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULELIST_ASSIGNED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_JOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.bbProblemSetting,
            this.bbMakeJobList,
            this.bbOpenJobList,
            this.bbOpenSchedule,
            this.bbExportSchedule,
            this.bbExportJobList,
            this.barButtonItem7,
            this.bbSimPlay,
            this.bbSimulPause,
            this.barButtonItem1,
            this.bb_ExpansionJobList,
            this.bb_ExpansionSchedule,
            this.zoom_Schedule,
            this.bt_AimationOnOFF,
            this.bt_Duedate,
            this.bb_ClearJobList,
            this.bb_Clear_Schedule,
            this.bb_about,
            this.barButtonItem4});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 29;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpModeling,
            this.rpAnalysis});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemZoomTrackBar1,
            this.repositoryItemTrackBar1,
            this.repositoryItemTrackBar2,
            this.repositoryItemZoomTrackBar2,
            this.repositoryItemZoomTrackBar3,
            this.repositoryItemTextEdit1});
            this.ribbon.Size = new System.Drawing.Size(1714, 166);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbProblemSetting
            // 
            this.bbProblemSetting.Caption = "Problem Setting";
            this.bbProblemSetting.Id = 1;
            this.bbProblemSetting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbProblemSetting.ImageOptions.Image")));
            this.bbProblemSetting.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbProblemSetting.ImageOptions.LargeImage")));
            this.bbProblemSetting.Name = "bbProblemSetting";
            this.bbProblemSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbProblemSetting_ItemClick);
            // 
            // bbMakeJobList
            // 
            this.bbMakeJobList.Caption = "Make Job List";
            this.bbMakeJobList.Id = 2;
            this.bbMakeJobList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbMakeJobList.ImageOptions.Image")));
            this.bbMakeJobList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbMakeJobList.ImageOptions.LargeImage")));
            this.bbMakeJobList.Name = "bbMakeJobList";
            this.bbMakeJobList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbMakeJobList_ItemClick);
            // 
            // bbOpenJobList
            // 
            this.bbOpenJobList.Caption = "Import Job List";
            this.bbOpenJobList.Id = 3;
            this.bbOpenJobList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbOpenJobList.ImageOptions.Image")));
            this.bbOpenJobList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbOpenJobList.ImageOptions.LargeImage")));
            this.bbOpenJobList.Name = "bbOpenJobList";
            this.bbOpenJobList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbOpenJobList_ItemClick);
            // 
            // bbOpenSchedule
            // 
            this.bbOpenSchedule.Caption = "Open Schedule";
            this.bbOpenSchedule.Id = 4;
            this.bbOpenSchedule.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbOpenSchedule.ImageOptions.Image")));
            this.bbOpenSchedule.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbOpenSchedule.ImageOptions.LargeImage")));
            this.bbOpenSchedule.Name = "bbOpenSchedule";
            this.bbOpenSchedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbOpenSchedule_ItemClick);
            // 
            // bbExportSchedule
            // 
            this.bbExportSchedule.Caption = "Export Schedule";
            this.bbExportSchedule.Id = 5;
            this.bbExportSchedule.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbExportSchedule.ImageOptions.Image")));
            this.bbExportSchedule.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbExportSchedule.ImageOptions.LargeImage")));
            this.bbExportSchedule.Name = "bbExportSchedule";
            this.bbExportSchedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbExportSchedule_ItemClick);
            // 
            // bbExportJobList
            // 
            this.bbExportJobList.Caption = "Export Job List";
            this.bbExportJobList.Id = 6;
            this.bbExportJobList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbExportJobList.ImageOptions.Image")));
            this.bbExportJobList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbExportJobList.ImageOptions.LargeImage")));
            this.bbExportJobList.Name = "bbExportJobList";
            this.bbExportJobList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbExportJobList_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Id = 7;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // bbSimPlay
            // 
            this.bbSimPlay.Caption = "Play";
            this.bbSimPlay.Id = 8;
            this.bbSimPlay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbSimPlay.ImageOptions.Image")));
            this.bbSimPlay.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbSimPlay.ImageOptions.LargeImage")));
            this.bbSimPlay.Name = "bbSimPlay";
            this.bbSimPlay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbSimPlay_ItemClick);
            // 
            // bbSimulPause
            // 
            this.bbSimulPause.Caption = "Pause";
            this.bbSimulPause.Id = 9;
            this.bbSimulPause.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbSimulPause.ImageOptions.Image")));
            this.bbSimulPause.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbSimulPause.ImageOptions.LargeImage")));
            this.bbSimulPause.Name = "bbSimulPause";
            this.bbSimulPause.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbSimulPause.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbSimulPause_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Report";
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bb_ExpansionJobList
            // 
            this.bb_ExpansionJobList.Caption = "Job List Windows";
            this.bb_ExpansionJobList.Id = 11;
            this.bb_ExpansionJobList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bb_ExpansionJobList.ImageOptions.Image")));
            this.bb_ExpansionJobList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bb_ExpansionJobList.ImageOptions.LargeImage")));
            this.bb_ExpansionJobList.Name = "bb_ExpansionJobList";
            this.bb_ExpansionJobList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bb_ExpansionJobList_ItemClick);
            // 
            // bb_ExpansionSchedule
            // 
            this.bb_ExpansionSchedule.Caption = "Schedule Windows";
            this.bb_ExpansionSchedule.Id = 12;
            this.bb_ExpansionSchedule.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bb_ExpansionSchedule.ImageOptions.Image")));
            this.bb_ExpansionSchedule.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bb_ExpansionSchedule.ImageOptions.LargeImage")));
            this.bb_ExpansionSchedule.Name = "bb_ExpansionSchedule";
            this.bb_ExpansionSchedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bb_ExpansionSchedule_ItemClick);
            // 
            // zoom_Schedule
            // 
            this.zoom_Schedule.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.zoom_Schedule.Edit = this.repositoryItemZoomTrackBar3;
            this.zoom_Schedule.EditValue = "35";
            this.zoom_Schedule.EditWidth = 210;
            this.zoom_Schedule.Id = 17;
            this.zoom_Schedule.Name = "zoom_Schedule";
            this.zoom_Schedule.EditValueChanged += new System.EventHandler(this.zoom_Schedule_EditValueChanged);
            // 
            // repositoryItemZoomTrackBar3
            // 
            this.repositoryItemZoomTrackBar3.Maximum = 70;
            this.repositoryItemZoomTrackBar3.Name = "repositoryItemZoomTrackBar3";
            this.repositoryItemZoomTrackBar3.SmallChange = 5;
            // 
            // bt_AimationOnOFF
            // 
            this.bt_AimationOnOFF.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bt_AimationOnOFF.BindableChecked = true;
            this.bt_AimationOnOFF.Caption = "Animation [On/Off]           ";
            this.bt_AimationOnOFF.Checked = true;
            this.bt_AimationOnOFF.Id = 19;
            this.bt_AimationOnOFF.Name = "bt_AimationOnOFF";
            this.bt_AimationOnOFF.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_AimationOnOFF_CheckedChanged);
            // 
            // bt_Duedate
            // 
            this.bt_Duedate.AllowHtmlText = DevExpress.Utils.DefaultBoolean.False;
            this.bt_Duedate.BindableChecked = true;
            this.bt_Duedate.Caption = "DueDate Violation [On/Off]";
            this.bt_Duedate.CausesValidation = true;
            this.bt_Duedate.Checked = true;
            this.bt_Duedate.Id = 21;
            this.bt_Duedate.Name = "bt_Duedate";
            this.bt_Duedate.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_Duedate_CheckedChanged);
            // 
            // bb_ClearJobList
            // 
            this.bb_ClearJobList.Caption = "Clear Job List";
            this.bb_ClearJobList.Id = 22;
            this.bb_ClearJobList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bb_ClearJobList.ImageOptions.Image")));
            this.bb_ClearJobList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bb_ClearJobList.ImageOptions.LargeImage")));
            this.bb_ClearJobList.Name = "bb_ClearJobList";
            this.bb_ClearJobList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bb_ClearJobList_ItemClick);
            // 
            // bb_Clear_Schedule
            // 
            this.bb_Clear_Schedule.Caption = "Clear Schedule";
            this.bb_Clear_Schedule.Id = 23;
            this.bb_Clear_Schedule.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bb_Clear_Schedule.ImageOptions.Image")));
            this.bb_Clear_Schedule.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bb_Clear_Schedule.ImageOptions.LargeImage")));
            this.bb_Clear_Schedule.Name = "bb_Clear_Schedule";
            this.bb_Clear_Schedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bb_Clear_Schedule_ItemClick);
            // 
            // bb_about
            // 
            this.bb_about.Caption = "about";
            this.bb_about.Id = 27;
            this.bb_about.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bb_about.ImageOptions.Image")));
            this.bb_about.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bb_about.ImageOptions.LargeImage")));
            this.bb_about.Name = "bb_about";
            this.bb_about.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bb_about_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Clear Selection";
            this.barButtonItem4.Id = 28;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // rpModeling
            // 
            this.rpModeling.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.ribbonPageGroup2,
            this.ribbonPageGroup6});
            this.rpModeling.Name = "rpModeling";
            this.rpModeling.Text = "Scheduling";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbProblemSetting);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.bbMakeJobList);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbOpenJobList);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbExportJobList);
            this.ribbonPageGroup4.ItemLinks.Add(this.bb_ExpansionJobList);
            this.ribbonPageGroup4.ItemLinks.Add(this.bb_ClearJobList);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.bbOpenSchedule);
            this.ribbonPageGroup5.ItemLinks.Add(this.bbExportSchedule);
            this.ribbonPageGroup5.ItemLinks.Add(this.bb_ExpansionSchedule);
            this.ribbonPageGroup5.ItemLinks.Add(this.bb_Clear_Schedule);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup5.ItemLinks.Add(this.zoom_Schedule);
            this.ribbonPageGroup5.ItemLinks.Add(this.bt_AimationOnOFF);
            this.ribbonPageGroup5.ItemLinks.Add(this.bt_Duedate);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbSimPlay);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbSimulPause);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.bb_about);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // rpAnalysis
            // 
            this.rpAnalysis.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.rpAnalysis.Name = "rpAnalysis";
            this.rpAnalysis.Text = "Analysis";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // repositoryItemZoomTrackBar1
            // 
            this.repositoryItemZoomTrackBar1.Maximum = 50;
            this.repositoryItemZoomTrackBar1.Name = "repositoryItemZoomTrackBar1";
            // 
            // repositoryItemTrackBar1
            // 
            this.repositoryItemTrackBar1.LabelAppearance.Options.UseTextOptions = true;
            this.repositoryItemTrackBar1.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemTrackBar1.Name = "repositoryItemTrackBar1";
            // 
            // repositoryItemTrackBar2
            // 
            this.repositoryItemTrackBar2.LabelAppearance.Options.UseTextOptions = true;
            this.repositoryItemTrackBar2.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemTrackBar2.Maximum = 1000;
            this.repositoryItemTrackBar2.Name = "repositoryItemTrackBar2";
            // 
            // repositoryItemZoomTrackBar2
            // 
            this.repositoryItemZoomTrackBar2.Maximum = 100;
            this.repositoryItemZoomTrackBar2.Name = "repositoryItemZoomTrackBar2";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 892);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1714, 26);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 166);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 726);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // GB_JOB
            // 
            this.GB_JOB.Controls.Add(this.Grid_WF_JOB);
            this.GB_JOB.Location = new System.Drawing.Point(12, 12);
            this.GB_JOB.Name = "GB_JOB";
            this.GB_JOB.Size = new System.Drawing.Size(448, 150);
            this.GB_JOB.TabIndex = 5;
            this.GB_JOB.TabStop = false;
            this.GB_JOB.Text = "Job List";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "FIFO-Round Robin",
            "EDD",
            "Setup First",
            "LST",
            "CR"});
            this.comboBox1.Location = new System.Drawing.Point(178, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 22);
            this.comboBox1.TabIndex = 3;
            // 
            // BTN_LOGIC
            // 
            this.BTN_LOGIC.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTN_LOGIC.Location = new System.Drawing.Point(351, 0);
            this.BTN_LOGIC.Name = "BTN_LOGIC";
            this.BTN_LOGIC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BTN_LOGIC.Size = new System.Drawing.Size(79, 27);
            this.BTN_LOGIC.TabIndex = 2;
            this.BTN_LOGIC.Text = "Scheduling";
            this.BTN_LOGIC.UseVisualStyleBackColor = true;
            this.BTN_LOGIC.Click += new System.EventHandler(this.BTN_LOGIC_Click);
            // 
            // GB_SCHEDULELIST
            // 
            this.GB_SCHEDULELIST.Controls.Add(this.splitContainer1);
            this.GB_SCHEDULELIST.Location = new System.Drawing.Point(12, 166);
            this.GB_SCHEDULELIST.Name = "GB_SCHEDULELIST";
            this.GB_SCHEDULELIST.Size = new System.Drawing.Size(448, 287);
            this.GB_SCHEDULELIST.TabIndex = 0;
            this.GB_SCHEDULELIST.TabStop = false;
            this.GB_SCHEDULELIST.Text = "Schedule List";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 18);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BTN_LOGIC);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Grid_WF_SCHEDULELIST);
            this.splitContainer1.Size = new System.Drawing.Size(442, 266);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 0;
            // 
            // Grid_WF_SCHEDULELIST
            // 
            this.Grid_WF_SCHEDULELIST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_WF_SCHEDULELIST.Location = new System.Drawing.Point(0, 0);
            this.Grid_WF_SCHEDULELIST.MainView = this.gridView2;
            this.Grid_WF_SCHEDULELIST.MenuManager = this.ribbon;
            this.Grid_WF_SCHEDULELIST.Name = "Grid_WF_SCHEDULELIST";
            this.Grid_WF_SCHEDULELIST.Size = new System.Drawing.Size(442, 234);
            this.Grid_WF_SCHEDULELIST.TabIndex = 0;
            this.Grid_WF_SCHEDULELIST.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.Grid_WF_SCHEDULELIST.Click += new System.EventHandler(this.Grid_WF_SCHEDULELIST_Click);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.Appearance.Row.Options.UseTextOptions = true;
            this.gridView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.GridControl = this.Grid_WF_SCHEDULELIST;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.gridView2.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView2_RowClick);
            this.gridView2.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView2_RowCellClick);
            this.gridView2.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView2_RowCellStyle);
            this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
            this.gridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView2_KeyDown);
            this.gridView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView2_MouseDown);
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lb_time.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lb_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lb_time.Location = new System.Drawing.Point(102, 0);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(104, 14);
            this.lb_time.TabIndex = 0;
            this.lb_time.Text = "Execution Time : ";
            this.lb_time.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CHART_TARDY);
            this.groupBox4.Location = new System.Drawing.Point(1280, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(209, 137);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tardiness";
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
            this.CHART_TARDY.Size = new System.Drawing.Size(203, 116);
            this.CHART_TARDY.TabIndex = 0;
            this.CHART_TARDY.Click += new System.EventHandler(this.CHART_TARDY_Click);
            this.CHART_TARDY.DoubleClick += new System.EventHandler(this.CHART_TARDY_DoubleClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CHART_SETUP);
            this.groupBox5.Location = new System.Drawing.Point(1280, 153);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(209, 148);
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
            this.CHART_SETUP.Size = new System.Drawing.Size(203, 127);
            this.CHART_SETUP.TabIndex = 1;
            this.CHART_SETUP.Click += new System.EventHandler(this.CHART_SETUP_Click);
            this.CHART_SETUP.DoubleClick += new System.EventHandler(this.CHART_SETUP_DoubleClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CHART_RESOURCE);
            this.groupBox6.Location = new System.Drawing.Point(1280, 305);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(209, 148);
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
            this.CHART_RESOURCE.Size = new System.Drawing.Size(203, 127);
            this.CHART_RESOURCE.TabIndex = 0;
            this.CHART_RESOURCE.Click += new System.EventHandler(this.CHART_RESOURCE_Click);
            this.CHART_RESOURCE.DoubleClick += new System.EventHandler(this.CHART_RESOURCE_DoubleClick);
            // 
            // GB_RT_OUTPUT
            // 
            this.GB_RT_OUTPUT.Controls.Add(this.CHART_RT_OUTPUT);
            this.GB_RT_OUTPUT.Location = new System.Drawing.Point(1493, 12);
            this.GB_RT_OUTPUT.Name = "GB_RT_OUTPUT";
            this.GB_RT_OUTPUT.Size = new System.Drawing.Size(206, 137);
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
            this.CHART_RT_OUTPUT.Size = new System.Drawing.Size(200, 116);
            this.CHART_RT_OUTPUT.TabIndex = 0;
            // 
            // GB_RT_SETUP
            // 
            this.GB_RT_SETUP.Controls.Add(this.CHART_RT_SETUP);
            this.GB_RT_SETUP.Location = new System.Drawing.Point(1493, 153);
            this.GB_RT_SETUP.Name = "GB_RT_SETUP";
            this.GB_RT_SETUP.Size = new System.Drawing.Size(206, 148);
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
            this.CHART_RT_SETUP.Size = new System.Drawing.Size(200, 127);
            this.CHART_RT_SETUP.TabIndex = 1;
            // 
            // GB_TIMED_RESOURCE
            // 
            this.GB_TIMED_RESOURCE.Controls.Add(this.CHART_RT_RESOURCE);
            this.GB_TIMED_RESOURCE.Location = new System.Drawing.Point(1493, 305);
            this.GB_TIMED_RESOURCE.Name = "GB_TIMED_RESOURCE";
            this.GB_TIMED_RESOURCE.Size = new System.Drawing.Size(206, 148);
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
            this.CHART_RT_RESOURCE.Size = new System.Drawing.Size(200, 127);
            this.CHART_RT_RESOURCE.TabIndex = 0;
            // 
            // GB_SCHEDULE
            // 
            this.GB_SCHEDULE.Controls.Add(this.GC_WF_SCHEDULE);
            this.GB_SCHEDULE.Controls.Add(this.lb_time);
            this.GB_SCHEDULE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_SCHEDULE.Location = new System.Drawing.Point(0, 0);
            this.GB_SCHEDULE.Name = "GB_SCHEDULE";
            this.GB_SCHEDULE.Size = new System.Drawing.Size(1711, 251);
            this.GB_SCHEDULE.TabIndex = 2;
            this.GB_SCHEDULE.TabStop = false;
            this.GB_SCHEDULE.Text = "Schedule Table";
            // 
            // GC_WF_SCHEDULE
            // 
            this.GC_WF_SCHEDULE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GC_WF_SCHEDULE.Location = new System.Drawing.Point(3, 18);
            this.GC_WF_SCHEDULE.MainView = this.Grid_WF_SCHEDULE;
            this.GC_WF_SCHEDULE.MenuManager = this.ribbon;
            this.GC_WF_SCHEDULE.Name = "GC_WF_SCHEDULE";
            this.GC_WF_SCHEDULE.Size = new System.Drawing.Size(1705, 230);
            this.GC_WF_SCHEDULE.TabIndex = 0;
            this.GC_WF_SCHEDULE.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Grid_WF_SCHEDULE});
            // 
            // Grid_WF_SCHEDULE
            // 
            this.Grid_WF_SCHEDULE.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.Grid_WF_SCHEDULE.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Grid_WF_SCHEDULE.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Grid_WF_SCHEDULE.Appearance.Row.Options.UseTextOptions = true;
            this.Grid_WF_SCHEDULE.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Grid_WF_SCHEDULE.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Grid_WF_SCHEDULE.GridControl = this.GC_WF_SCHEDULE;
            this.Grid_WF_SCHEDULE.Name = "Grid_WF_SCHEDULE";
            this.Grid_WF_SCHEDULE.OptionsBehavior.Editable = false;
            this.Grid_WF_SCHEDULE.OptionsCustomization.AllowColumnMoving = false;
            this.Grid_WF_SCHEDULE.OptionsCustomization.AllowFilter = false;
            this.Grid_WF_SCHEDULE.OptionsCustomization.AllowSort = false;
            this.Grid_WF_SCHEDULE.OptionsFilter.AllowFilterEditor = false;
            this.Grid_WF_SCHEDULE.OptionsPrint.UsePrintStyles = false;
            this.Grid_WF_SCHEDULE.OptionsSelection.MultiSelect = true;
            this.Grid_WF_SCHEDULE.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.Grid_WF_SCHEDULE.OptionsView.ColumnAutoWidth = false;
            this.Grid_WF_SCHEDULE.OptionsView.ShowGroupPanel = false;
            this.Grid_WF_SCHEDULE.OptionsView.ShowIndicator = false;
            this.Grid_WF_SCHEDULE.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.Grid_WF_SCHEDULE_RowCellClick);
            this.Grid_WF_SCHEDULE.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.Grid_WF_SCHEDULE_CellMerge);
            this.Grid_WF_SCHEDULE.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.Grid_WF_SCHEDULE_CustomDrawCell);
            this.Grid_WF_SCHEDULE.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.Grid_WF_SCHEDULE_RowCellStyle);
            this.Grid_WF_SCHEDULE.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.Grid_WF_SCHEDULE_FocusedColumnChanged);
            this.Grid_WF_SCHEDULE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_WF_SCHEDULE_KeyDown);
            this.Grid_WF_SCHEDULE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridScheduleView_MouseDown);
            // 
            // model1
            // 
            this.model1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.model1.Cursor = System.Windows.Forms.Cursors.Default;
            this.model1.Location = new System.Drawing.Point(464, 12);
            this.model1.Name = "model1";
            this.model1.ProgressBar = progressBar4;
            this.model1.Size = new System.Drawing.Size(812, 441);
            this.model1.TabIndex = 1;
            this.model1.Text = "model1";
            coordinateSystemIcon4.LabelFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            viewport4.CoordinateSystemIcon = coordinateSystemIcon4;
            viewport4.Legends = new devDept.Eyeshot.Legend[0];
            originSymbol4.LabelFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            viewport4.OriginSymbol = originSymbol4;
            viewCubeIcon4.Font = null;
            viewCubeIcon4.InitialRotation = new devDept.Geometry.Quaternion(0D, 0D, 0D, 1D);
            viewport4.ViewCubeIcon = viewCubeIcon4;
            this.model1.Viewports.Add(viewport4);
            this.model1.WaitCursorMode = devDept.Eyeshot.waitCursorType.Never;
            // 
            // GB_SCHEDULELIST_ASSIGNED
            // 
            this.GB_SCHEDULELIST_ASSIGNED.Controls.Add(this.Grid_WF_SCHEDULELIST_ASSIGNED);
            this.GB_SCHEDULELIST_ASSIGNED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_SCHEDULELIST_ASSIGNED.Location = new System.Drawing.Point(0, 0);
            this.GB_SCHEDULELIST_ASSIGNED.Name = "GB_SCHEDULELIST_ASSIGNED";
            this.GB_SCHEDULELIST_ASSIGNED.Size = new System.Drawing.Size(467, 149);
            this.GB_SCHEDULELIST_ASSIGNED.TabIndex = 0;
            this.GB_SCHEDULELIST_ASSIGNED.TabStop = false;
            this.GB_SCHEDULELIST_ASSIGNED.Text = "Assugned Schedule List";
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
            this.Grid_WF_SCHEDULELIST_ASSIGNED.Location = new System.Drawing.Point(3, 17);
            this.Grid_WF_SCHEDULELIST_ASSIGNED.Name = "Grid_WF_SCHEDULELIST_ASSIGNED";
            this.Grid_WF_SCHEDULELIST_ASSIGNED.ReadOnly = true;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.RowTemplate.Height = 23;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_WF_SCHEDULELIST_ASSIGNED.Size = new System.Drawing.Size(461, 129);
            this.Grid_WF_SCHEDULELIST_ASSIGNED.TabIndex = 2;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Expansion Job List";
            this.barButtonItem2.Id = 11;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Expansion Job List";
            this.barButtonItem3.Id = 11;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(3, 166);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.layoutControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.GB_SCHEDULE);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1711, 726);
            this.splitContainerControl1.SplitterPosition = 465;
            this.splitContainerControl1.TabIndex = 6;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.GB_RT_SETUP);
            this.layoutControl1.Controls.Add(this.GB_TIMED_RESOURCE);
            this.layoutControl1.Controls.Add(this.GB_RT_OUTPUT);
            this.layoutControl1.Controls.Add(this.groupBox5);
            this.layoutControl1.Controls.Add(this.groupBox6);
            this.layoutControl1.Controls.Add(this.groupBox4);
            this.layoutControl1.Controls.Add(this.GB_JOB);
            this.layoutControl1.Controls.Add(this.GB_SCHEDULELIST);
            this.layoutControl1.Controls.Add(this.model1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2134, 295, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1711, 465);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1711, 465);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.GB_JOB;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(452, 154);
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.GB_SCHEDULELIST;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 154);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(452, 291);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.model1;
            this.layoutControlItem3.Location = new System.Drawing.Point(452, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(816, 445);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.groupBox4;
            this.layoutControlItem4.Location = new System.Drawing.Point(1268, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(213, 141);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.groupBox5;
            this.layoutControlItem5.Location = new System.Drawing.Point(1268, 141);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(213, 152);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.groupBox6;
            this.layoutControlItem6.Location = new System.Drawing.Point(1268, 293);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(213, 152);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.GB_RT_OUTPUT;
            this.layoutControlItem7.Location = new System.Drawing.Point(1481, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(210, 141);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.GB_RT_SETUP;
            this.layoutControlItem8.Location = new System.Drawing.Point(1481, 141);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(210, 152);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.GB_TIMED_RESOURCE;
            this.layoutControlItem9.Location = new System.Drawing.Point(1481, 293);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(210, 152);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // Grid_WF_JOB
            // 
            this.Grid_WF_JOB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_WF_JOB.Location = new System.Drawing.Point(3, 18);
            this.Grid_WF_JOB.MainView = this.gridView1;
            this.Grid_WF_JOB.MenuManager = this.ribbon;
            this.Grid_WF_JOB.Name = "Grid_WF_JOB";
            this.Grid_WF_JOB.Size = new System.Drawing.Size(442, 129);
            this.Grid_WF_JOB.TabIndex = 1;
            this.Grid_WF_JOB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.GridControl = this.Grid_WF_JOB;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.gridView1.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // MainForm_Ribbon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1714, 918);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IconOptions.Image = global::PINOKIO_SCHEDULER.Properties.Resources.INU_워드마크;
            this.KeyPreview = true;
            this.Name = "MainForm_Ribbon";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Virtual Testbed for AI Machine Scheduling (VAMS)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_Ribbon_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTrackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.GB_JOB.ResumeLayout(false);
            this.GB_SCHEDULELIST.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULELIST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_TARDY)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_SETUP)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RESOURCE)).EndInit();
            this.GB_RT_OUTPUT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_OUTPUT)).EndInit();
            this.GB_RT_SETUP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_SETUP)).EndInit();
            this.GB_TIMED_RESOURCE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CHART_RT_RESOURCE)).EndInit();
            this.GB_SCHEDULE.ResumeLayout(false);
            this.GB_SCHEDULE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GC_WF_SCHEDULE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).EndInit();
            this.GB_SCHEDULELIST_ASSIGNED.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_SCHEDULELIST_ASSIGNED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_WF_JOB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpModeling;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem bbProblemSetting;
        private DevExpress.XtraBars.BarButtonItem bbMakeJobList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpAnalysis;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbOpenJobList;
        private DevExpress.XtraBars.BarButtonItem bbOpenSchedule;
        private DevExpress.XtraBars.BarButtonItem bbExportSchedule;
        private DevExpress.XtraBars.BarButtonItem bbExportJobList;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox GB_JOB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BTN_LOGIC;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox GB_RT_OUTPUT;
        private DevExpress.XtraCharts.ChartControl CHART_RT_OUTPUT;
        private System.Windows.Forms.GroupBox GB_RT_SETUP;
        private DevExpress.XtraCharts.ChartControl CHART_RT_SETUP;
        private System.Windows.Forms.GroupBox GB_TIMED_RESOURCE;
        private DevExpress.XtraCharts.ChartControl CHART_RT_RESOURCE;
        private devDept.Eyeshot.Model model1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.GroupBox GB_SCHEDULELIST;
        private DevExpress.XtraBars.BarButtonItem bbSimPlay;
        private DevExpress.XtraBars.BarButtonItem bbSimulPause;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.GroupBox GB_SCHEDULELIST_ASSIGNED;
        private System.Windows.Forms.DataGridView Grid_WF_SCHEDULELIST_ASSIGNED;
        private System.Windows.Forms.Label lb_time;
        public DevExpress.XtraGrid.GridControl Grid_WF_SCHEDULELIST;
        private DevExpress.XtraBars.BarButtonItem bb_ExpansionJobList;
        private DevExpress.XtraBars.BarButtonItem bb_ExpansionSchedule;
        public DevExpress.XtraCharts.ChartControl CHART_TARDY;
        public DevExpress.XtraCharts.ChartControl CHART_SETUP;
        public DevExpress.XtraCharts.ChartControl CHART_RESOURCE;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar repositoryItemZoomTrackBar1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTrackBar repositoryItemTrackBar2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTrackBar repositoryItemTrackBar1;
        public DevExpress.XtraGrid.GridControl GC_WF_SCHEDULE;
        public DevExpress.XtraGrid.Views.Grid.GridView Grid_WF_SCHEDULE;
        private DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar repositoryItemZoomTrackBar2;
        private DevExpress.XtraBars.BarEditItem zoom_Schedule;
        private DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar repositoryItemZoomTrackBar3;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraBars.BarToggleSwitchItem bt_AimationOnOFF;
        public DevExpress.XtraBars.BarToggleSwitchItem bt_Duedate;
        private DevExpress.XtraBars.BarButtonItem bb_ClearJobList;
        private DevExpress.XtraBars.BarButtonItem bb_Clear_Schedule;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem bb_about;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        public System.Windows.Forms.GroupBox GB_SCHEDULE;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        public DevExpress.XtraGrid.GridControl Grid_WF_JOB;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}