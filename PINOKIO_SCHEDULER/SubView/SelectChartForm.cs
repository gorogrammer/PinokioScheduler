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
using DevExpress.Utils;

namespace PINOKIO_SCHEDULER.SubView
{
    public partial class SelectChartForm : Form
    {
        public MainForm_Ribbon Main;
        public DataTable _seltDT;
        public List<GraphModel> lstGraph;
        public void load_SelectChart(string charName)
        {
            if(charName == "TARDY")
            {
                Series TardySeries = new Series(DEF.GRAPH_TARDY, ViewType.StackedLine);
                Series TardySumSeries = new Series("Tardiness Accum", ViewType.StackedLine);

                SelectChart.Series.Add(TardySeries);
                SelectChart.Series.Add(TardySumSeries);
                //   SelectChart.Series.Add(TardySumSeries);

                _seltDT = new DataTable();
                _seltDT.Columns.Add("Time", typeof(Int32));
                _seltDT.Columns.Add("Value", typeof(Int32));
                _seltDT.Columns.Add("Accum", typeof(Int32));
                XYDiagram diagram = SelectChart.Diagram as XYDiagram;
                diagram.AxisX.WholeRange.SideMarginsValue = 0;

                ((XYDiagram)SelectChart.Diagram).SecondaryAxesY.Clear();
                SecondaryAxisY secondAxisY = new SecondaryAxisY();
                ((XYDiagram)SelectChart.Diagram).SecondaryAxesY.Add(secondAxisY);

                TardySeries.DataSource = _seltDT;
                TardySeries.ArgumentScaleType = ScaleType.Numerical;
                TardySeries.ArgumentDataMember = "Time";
                TardySeries.ValueScaleType = ScaleType.Numerical;


                TardySumSeries.DataSource = _seltDT;
                TardySumSeries.ArgumentScaleType = ScaleType.Numerical;
                TardySumSeries.ArgumentDataMember = "Time";
                TardySumSeries.ValueScaleType = ScaleType.Numerical;
                ((LineSeriesView)SelectChart.Series[1].View).AxisY = ((XYDiagram)SelectChart.Diagram).SecondaryAxesY[0];

                foreach (KeyValuePair<int, TimeGrapgh> pair in Main._dicGraphTime)
                {
                    _seltDT.Rows.Add(pair.Key, pair.Value.TardySum,pair.Value.TardyAccum);
                }

                SelectChart.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });
                SelectChart.Series[1].ValueDataMembers.AddRange(new string[] { "Accum" });

                ((XYDiagram)SelectChart.Diagram).AxisX.Title.Text = "Time";
                ((XYDiagram)SelectChart.Diagram).AxisX.Title.Visibility = DefaultBoolean.True;

                ((XYDiagram)SelectChart.Diagram).AxisY.Title.Text = "Tardy Sum";
                ((XYDiagram)SelectChart.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
            }
            else if(charName == "SETUP")
            {
                Series SetupSeries = new Series(DEF.GRAPH_SETUP, ViewType.StackedLine);

                SelectChart.Series.Add(SetupSeries);

                XYDiagram diagram = SelectChart.Diagram as XYDiagram;
                diagram.AxisX.WholeRange.SideMarginsValue = 0;
                _seltDT = new DataTable();
                _seltDT.Columns.Add("Time", typeof(Int32));
                _seltDT.Columns.Add("Value", typeof(Int32));
                _seltDT.Columns.Add("Accum", typeof(Int32));

                SetupSeries.DataSource = _seltDT;
                SetupSeries.ArgumentScaleType = ScaleType.Numerical;
                SetupSeries.ArgumentDataMember = "Time";
                SetupSeries.ValueScaleType = ScaleType.Numerical;

                foreach (KeyValuePair<int, TimeGrapgh> pair in Main._dicGraphTime)
                {
                    _seltDT.Rows.Add(pair.Key, pair.Value.SetUpSum);
                }
                SelectChart.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });

                ((XYDiagram)SelectChart.Diagram).AxisX.Title.Text = "Time";
                ((XYDiagram)SelectChart.Diagram).AxisX.Title.Visibility = DefaultBoolean.True;

                ((XYDiagram)SelectChart.Diagram).AxisY.Title.Text = "Setup Time Sum";
                ((XYDiagram)SelectChart.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
            }
            else if(charName == "RESOURCE")
            {
                //리소스
                Series ResourceSeries = new Series(DEF.GRAPH_RESOURCE, ViewType.Bar);
                SelectChart.Series.Add(ResourceSeries);
                ResourceSeries.View.Colorizer = GeneralFunc.CreateColorizer(1);

                _seltDT = new DataTable(DEF.GRAPH_RESOURCE);
                _seltDT.Columns.Add(DEF.GRAPH_RESOURCE_X, typeof(Int32));
                _seltDT.Columns.Add(DEF.GRAPH_RESOURCE_Y, typeof(double));

                ResourceSeries.DataSource = _seltDT;
                ResourceSeries.ArgumentScaleType = ScaleType.Numerical;
                ResourceSeries.ArgumentDataMember = DEF.GRAPH_RESOURCE_X;
                ResourceSeries.ValueScaleType = ScaleType.Numerical;


                foreach (MachineUtilities util in Main._lstGraphicModel[Main._CurrentStep - 1].lstMachineUtilities)
                    _seltDT.Rows.Add(util.MachineIndex, Math.Round(util.Uitility_CurrenetRuned, 2));
                SelectChart.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });

                ((XYDiagram)SelectChart.Diagram).AxisX.Title.Text = "Machine ID";
                ((XYDiagram)SelectChart.Diagram).AxisX.Title.Visibility = DefaultBoolean.True;

                ((XYDiagram)SelectChart.Diagram).AxisY.Title.Text = "Util";
                ((XYDiagram)SelectChart.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
            }
         

            ////RT 아웃풋
            //Series RTOutputSeries = new Series(DEF.GRAPH_RT_OUTPUT, ViewType.Bar);
            //CHART_RT_OUTPUT.Series.Add(RTOutputSeries);
            //RTOutputSeries.View.Colorizer = GeneralFunc.CreateColorizer(2);

            //_RT_CHARTDT_Output = new DataTable(DEF.GRAPH_RT_OUTPUT);
            //_RT_CHARTDT_Output.Columns.Add(DEF.GRAPH_RT_OUTPUT_X, typeof(Int32));
            //_RT_CHARTDT_Output.Columns.Add(DEF.GRAPH_RT_OUTPUT_Y, typeof(Int32));

            //RTOutputSeries.DataSource = _RT_CHARTDT_Output;
            //RTOutputSeries.ArgumentScaleType = ScaleType.Numerical;
            //RTOutputSeries.ArgumentDataMember = DEF.GRAPH_RT_OUTPUT_X;
            //RTOutputSeries.ValueScaleType = ScaleType.Numerical;

            ////RT셋업
            //Series RTSetupSeries = new Series(DEF.GRAPH_RT_SETUP, ViewType.Bar);
            //CHART_RT_SETUP.Series.Add(RTSetupSeries);
            //RTSetupSeries.View.Colorizer = GeneralFunc.CreateColorizer(3);

            //_RT_CHARTDT_Setup = new DataTable(DEF.GRAPH_RT_SETUP);
            //_RT_CHARTDT_Setup.Columns.Add(DEF.GRAPH_RT_SETUP_X, typeof(Int32));
            //_RT_CHARTDT_Setup.Columns.Add(DEF.GRAPH_RT_SETUP_Y, typeof(Int32));

            //RTSetupSeries.DataSource = _RT_CHARTDT_Setup;
            //RTSetupSeries.ArgumentScaleType = ScaleType.Numerical;
            //RTSetupSeries.ArgumentDataMember = DEF.GRAPH_RT_SETUP_X;
            //RTSetupSeries.ValueScaleType = ScaleType.Numerical;

            ////RT리소스
            //Series RTResourceSeries = new Series(DEF.GRAPH_RT_RESOURCE, ViewType.Bar);
            //CHART_RT_RESOURCE.Series.Add(RTResourceSeries);
            //RTResourceSeries.View.Colorizer = GeneralFunc.CreateColorizer(1);

            //_RT_CHARTDT_Resource = new DataTable(DEF.GRAPH_RT_RESOURCE);
            //_RT_CHARTDT_Resource.Columns.Add(DEF.GRAPH_RT_RESOURCE_X, typeof(Int32));
            //_RT_CHARTDT_Resource.Columns.Add(DEF.GRAPH_RT_RESOURCE_Y, typeof(double));

            //RTResourceSeries.DataSource = _RT_CHARTDT_Resource;
            //RTResourceSeries.ArgumentScaleType = ScaleType.Numerical;
            //RTResourceSeries.ArgumentDataMember = DEF.GRAPH_RT_RESOURCE_X;
            //RTResourceSeries.ValueScaleType = ScaleType.Numerical;

        }
        public SelectChartForm()
        {
            InitializeComponent();
        }
    }
}
