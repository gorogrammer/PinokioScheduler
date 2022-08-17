using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PINOKIO_SCHEDULER.Definitions;
using PINOKIO_SCHEDULER.Model;

namespace PINOKIO_SCHEDULER.GeneralFunctions
{
    public static class GeneralFunc
    {
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        public static string OpenFiles()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Csv Files(*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!openFileDialog.FileName.ToUpper().Contains(".CSV"))
                {
                    XtraMessageBox.Show("CSV 파일이 아닙니다.");
                    return string.Empty;
                }
                return openFileDialog.FileName;
            }
            else
                return string.Empty;
        }

        public static string OpenFilesXls()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Xls Files(*.xls) | *.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!openFileDialog.FileName.ToUpper().Contains(".XLS"))
                {
                    XtraMessageBox.Show("XLS 파일이 아닙니다.");
                    return string.Empty;
                }
                return openFileDialog.FileName;
            }
            else
                return string.Empty;
        }

        public static List<string> ReadCsv(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            List<string> lstStr = new List<string>();
            StreamReader sr = new StreamReader(path);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();//string[] data = line.Split(',');
                lstStr.Add(line);
            }
            return lstStr;
        }

        public static List<string> ReadXls(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            List<string> lstStr = new List<string>();
            StreamReader sr = new StreamReader(path);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();//string[] data = line.Split(',');
                lstStr.Add(line);
            }
            return lstStr;
        }

        public static DataTable GetNewScheduleListDT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_IDLOT, typeof(Int32));
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_IDMACHINE);
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_JOBTYPE);
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_PROCTIME, typeof(Int32));
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_STARTTIME, typeof(Int32));
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_ENDTIME, typeof(Int32));
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_DUETIME,typeof(Int32));
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_SETUP, typeof(Int32));
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_VIOLATION, typeof(Int32));

            //dt.Columns["Due Date"].DataType = typeof(Int32);
            return dt;
        }

        public static DataTable GetNewJobDT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_IDLOT);
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_JOBTYPE);
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_QUANTITY);
            dt.Columns.Add(DEF.GRID_SCHEDULES_COL_DUETIME);

            return dt;
        }      

        public static DataTable GetNewScheduleDT(int _TotalWorkingTime, int _TotalMachineNum)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("M");

            for (int i = 0; i < _TotalWorkingTime + 2; i++)
                dt.Columns.Add(i.ToString());

            for (int i = 0; i < _TotalMachineNum; i++)
                dt.Rows.Add(i.ToString());

            return dt;
        }

        public static List<ScheduleModel> GetScheduleModels(List<string> lstStr, out int MachineNumber, out int EndTime, out DataTable dt)
        {
            try
            {
                dt = GetNewScheduleListDT();
                List<int> machineNo = new List<int>();

                MachineNumber = 0;
                EndTime = 0;
                List<ScheduleModel> lstSM = new List<ScheduleModel>();

                foreach (string str in lstStr)
                {
                    string[] Lines = str.Split(',');
                    if (Lines[1] == string.Empty)
                    {
                        MachineNumber = Convert.ToInt32(Lines[0]);
                        continue;
                    }

                    if (Lines[0] == "Lot ID")
                    {

                        continue;
                    }
                    if (Lines[0] == string.Empty || Lines[1] == string.Empty || Lines[2] == string.Empty || Lines[3] == string.Empty || Lines[4] == string.Empty || Lines[5] == string.Empty ||
                        Lines[6] == string.Empty || Lines[7] == string.Empty || Lines[8] == string.Empty)
                        return null;

                    for (int i = 0; i < 9; i++)
                    {

                        if (i != 2 && !Lines[i].All(char.IsDigit))
                        {
                            MessageBox.Show("입력값에 숫자가 아닌 문자가 들어가 있습니다.");
                            return null;
                        }

                    }



                    int endtimeNow = Convert.ToInt32(Lines[5]);

                    if (endtimeNow > EndTime)
                        EndTime = endtimeNow;

                    //bool isSetUP = false;

                    //if (Lines[7].ToUpper().Contains("O"))
                    //    isSetUP = true;
                    ScheduleModel model = null;
                    if (Lines.Length == 10)
                    {
                        model = new ScheduleModel(Convert.ToInt32(Lines[0]), Convert.ToInt32(Lines[1]), Lines[2], Convert.ToInt32(Lines[3]),
                       Convert.ToInt32(Lines[4]), Convert.ToInt32(Lines[5]), Convert.ToInt32(Lines[6]), Convert.ToInt32(Lines[7]), Convert.ToInt32(Lines[8]), Convert.ToInt32(Lines[9]));
                    }
                    else
                    {
                        model = new ScheduleModel(Convert.ToInt32(Lines[0]), Convert.ToInt32(Lines[1]), Lines[2], Convert.ToInt32(Lines[3]),
                     Convert.ToInt32(Lines[4]), Convert.ToInt32(Lines[5]), Convert.ToInt32(Lines[6]), Convert.ToInt32(Lines[7]), Convert.ToInt32(Lines[8]), Convert.ToInt32(Lines[7]));
                    }


                    lstSM.Add(model);
                    dt.Rows.Add(Convert.ToInt32(Lines[0]), Convert.ToInt32(Lines[1]), Lines[2], Convert.ToInt32(Lines[3]),
                        Convert.ToInt32(Lines[4]), Convert.ToInt32(Lines[5]), Convert.ToInt32(Lines[6]), Convert.ToInt32(Lines[7]), Convert.ToInt32(Lines[8]));

                    if (!machineNo.Contains(Convert.ToInt32(Lines[1])))
                        machineNo.Add(Convert.ToInt32(Lines[1]));



                }
                MachineNumber = machineNo.Count();
                return lstSM;
            }
            catch
            {
                MachineNumber = 0;
                EndTime = 0;
                dt = null;

                return null;
            }
           
        }
        public static List<ScheduleModel> GetScheduleModels_Import(List<string> lstStr, out int MachineNumber, out int EndTime, out DataTable dt)
        {
            try
            {
                dt = GetNewScheduleListDT();
                List<int> machineNo = new List<int>();

                MachineNumber = 0;
                EndTime = 0;
                List<ScheduleModel> lstSM = new List<ScheduleModel>();

                foreach (string str in lstStr)
                {
                    string[] Lines = str.Split(',');
                    //if (Lines[1] == string.Empty)
                    //{
                    //    MachineNumber = Convert.ToInt32(Lines[0]);
                    //    continue;
                    //}

                    if (Lines[0] == "Lot ID")
                    {

                        continue;
                    }
                    if (Lines[0] == string.Empty || Lines[1] == string.Empty || Lines[2] == string.Empty || Lines[3] == string.Empty || Lines[4] == string.Empty || Lines[5] == string.Empty ||
                        Lines[6] == string.Empty || Lines[7] == string.Empty || Lines[8] == string.Empty)
                        return null;

                    for (int i = 0; i < 9; i++)
                    {

                        if (i != 2 && !Lines[i].All(char.IsDigit))
                        {
                            MessageBox.Show("입력값에 숫자가 아닌 문자가 들어가 있습니다.");
                            return null;
                        }

                    }



                    int endtimeNow = Convert.ToInt32(Lines[5]);

                    if (endtimeNow > EndTime)
                        EndTime = endtimeNow;

                    //bool isSetUP = false;

                    //if (Lines[7].ToUpper().Contains("O"))
                    //    isSetUP = true;
                    ScheduleModel model = null;
                    if (Lines.Length == 10)
                    {
                        model = new ScheduleModel(Convert.ToInt32(Lines[0]), Convert.ToInt32(Lines[1]), Lines[2], Convert.ToInt32(Lines[3]),
                       Convert.ToInt32(Lines[4]), Convert.ToInt32(Lines[5]), Convert.ToInt32(Lines[6]), Convert.ToInt32(Lines[7]), Convert.ToInt32(Lines[8]), Convert.ToInt32(Lines[9]));
                    }
                    else
                    {
                        model = new ScheduleModel(Convert.ToInt32(Lines[0]), Convert.ToInt32(Lines[1]), Lines[2], Convert.ToInt32(Lines[3]),
                     Convert.ToInt32(Lines[4]), Convert.ToInt32(Lines[5]), Convert.ToInt32(Lines[6]), Convert.ToInt32(Lines[7]), Convert.ToInt32(Lines[8]), Convert.ToInt32(Lines[7]));
                    }


                    lstSM.Add(model);
                    dt.Rows.Add(Convert.ToInt32(Lines[0]), Convert.ToInt32(Lines[1]), Lines[2], Convert.ToInt32(Lines[3]),
                        Convert.ToInt32(Lines[4]), Convert.ToInt32(Lines[5]), Convert.ToInt32(Lines[6]), Convert.ToInt32(Lines[7]), Convert.ToInt32(Lines[8]));

                    if (!machineNo.Contains(Convert.ToInt32(Lines[1])))
                        machineNo.Add(Convert.ToInt32(Lines[1]));



                }
                MachineNumber = machineNo.Count();
                return lstSM;
            }
            catch
            {
                MachineNumber = 0;
                EndTime = 0;
                dt = null;

                return null;
            }

        }

        public static List<GraphModel> GetGraphicModels(List<ScheduleModel> lstSchedule)
        {
            if(lstSchedule == null)
                return new List<GraphModel>();

            List<GraphModel> lstGraph = new List<GraphModel>();

            for(int i=0; i < lstSchedule.Count; i++)
            {
                if (i == 0)
                    lstGraph.Add(new GraphModel(i, lstSchedule[i]));
                else
                    lstGraph.Add(lstGraph[i -1].GetAccumulatedGraphModel(lstSchedule[i]));
            }


            return new List<GraphModel>(lstGraph);
        }

        public static ChartColorizerBase CreateColorizer(int i)
        {
            if (i == 1)
            {
                Palette palette = new Palette("Custom");
                palette.Add(Color.FromArgb(255, 255, 90, 25), Color.FromArgb(255, 255, 90, 25));
                palette.Add(Color.FromArgb(255, 229, 227, 53), Color.FromArgb(255, 229, 227, 53));
                palette.Add(Color.FromArgb(255, 110, 201, 92), Color.FromArgb(255, 110, 201, 92));

                RangeColorizer colorizer = new RangeColorizer()
                {
                    LegendItemPattern = "{V1} - {V2} HPI",
                    Palette = palette
                };
                colorizer.RangeStops.AddRange(new double[] { 22, 30, 38, 46, 54, 64 });
                return colorizer;
            }
            else if( i==2)
            {
                Palette palette = new Palette("Custom");
                palette.Add(Color.FromArgb(255, 225, 90, 25), Color.FromArgb(255, 225, 90, 25));
                palette.Add(Color.FromArgb(255, 199, 227, 53), Color.FromArgb(255, 199, 227, 53));
                palette.Add(Color.FromArgb(255, 70, 201, 92), Color.FromArgb(255, 70, 201, 92));

                RangeColorizer colorizer = new RangeColorizer()
                {
                    LegendItemPattern = "{V1} - {V2} HPI",
                    Palette = palette
                };
                colorizer.RangeStops.AddRange(new double[] { 22, 30, 38, 46, 54, 64 });
                return colorizer;
            }
            else
            {
                Palette palette = new Palette("Custom");
                palette.Add(Color.FromArgb(255, 255, 30, 25), Color.FromArgb(255, 255, 30, 25));
                palette.Add(Color.FromArgb(255, 229, 187, 53), Color.FromArgb(255, 229, 187, 53));
                palette.Add(Color.FromArgb(255, 110, 141, 92), Color.FromArgb(255, 110, 141, 92));

                RangeColorizer colorizer = new RangeColorizer()
                {
                    LegendItemPattern = "{V1} - {V2} HPI",
                    Palette = palette
                };
                colorizer.RangeStops.AddRange(new double[] { 22, 30, 38, 46, 54, 64 });
                return colorizer;
            }
        }

        //public static Color SetColor(string name)
        //{
        //    Color setcolor = new Color();
        //    if (name.Contains("A"))
        //        setcolor = COLOR.A_StringColor;
        //    if (name.Contains("B"))
        //        setcolor = COLOR.B_StringColor;
        //    if (name.Contains("C"))
        //        setcolor = COLOR.C_StringColor;
        //    if (name.Contains("D"))
        //        setcolor = COLOR.D_StringColor;
        //    if (name.Contains("E"))
        //        setcolor = COLOR.E_StringColor;
        //    if (name.Contains("F"))
        //        setcolor = COLOR.F_StringColor;
        //    if (name.Contains("G"))
        //        setcolor = COLOR.G_StringColor;
        //    if (name.Contains("H"))
        //        setcolor = COLOR.H_StringColor;
        //    if (name.Contains("I"))
        //        setcolor = COLOR.I_StringColor;
        //    if (name.Contains("J"))
        //        setcolor = COLOR.J_StringColor;
        //    if (name.Contains("K"))
        //        setcolor = COLOR.K_StringColor;
        //    if (name.Contains("L"))
        //        setcolor = COLOR.L_StringColor;
        //    if (name.Contains("M"))
        //        setcolor = COLOR.M_StringColor;
        //    if (name.Contains("N"))
        //        setcolor = COLOR.N_StringColor;
        //    if (name.Contains("O"))
        //        setcolor = COLOR.O_StringColor;
        //    if (name.Contains("P"))
        //        setcolor = COLOR.P_StringColor;
        //    if (name.Contains("Q"))
        //        setcolor = COLOR.Q_StringColor;
        //    if (name.Contains("R"))
        //        setcolor = COLOR.R_StringColor;
        //    if (name.Contains("S"))
        //        setcolor = COLOR.S_StringColor;
        //    if (name.Contains("T"))
        //        setcolor = COLOR.T_StringColor;
        //    if (name.Contains("U"))
        //        setcolor = COLOR.U_StringColor;
        //    if (name.Contains("V"))
        //        setcolor = COLOR.V_StringColor;
        //    if (name.Contains("W"))
        //        setcolor = COLOR.W_StringColor;
        //    if (name.Contains("X"))
        //        setcolor = COLOR.X_StringColor;
        //    if (name.Contains("Y"))
        //        setcolor = COLOR.Y_StringColor;
        //    if (name.Contains("Z"))
        //        setcolor = COLOR.Z_StringColor;

        //    return setcolor;
        //}
        public static Color SetColor(string name)
        {
            Color setcolor = new Color();
            if (name.Contains("A"))
                setcolor = COLOR_1.A_StringColor;
            if (name.Contains("B"))
                setcolor = COLOR_1.B_StringColor;
            if (name.Contains("C"))
                setcolor = COLOR_1.C_StringColor;
            if (name.Contains("D"))
                setcolor = COLOR_1.D_StringColor;
            if (name.Contains("E"))
                setcolor = COLOR_1.E_StringColor;
            if (name.Contains("F"))
                setcolor = COLOR_1.F_StringColor;
            if (name.Contains("G"))
                setcolor = COLOR_1.G_StringColor;
            if (name.Contains("H"))
                setcolor = COLOR_1.H_StringColor;
            if (name.Contains("I"))
                setcolor = COLOR_1.I_StringColor;
            if (name.Contains("J"))
                setcolor = COLOR_1.J_StringColor;
            if (name.Contains("K"))
                setcolor = COLOR_1.K_StringColor;
            if (name.Contains("L"))
                setcolor = COLOR_1.L_StringColor;
            if (name.Contains("M"))
                setcolor = COLOR_1.M_StringColor;
            if (name.Contains("N"))
                setcolor = COLOR_1.N_StringColor;
            if (name.Contains("O"))
                setcolor = COLOR_1.O_StringColor;
            if (name.Contains("P"))
                setcolor = COLOR_1.P_StringColor;
            if (name.Contains("Q"))
                setcolor = COLOR_1.Q_StringColor;
            if (name.Contains("R"))
                setcolor = COLOR_1.R_StringColor;
            if (name.Contains("S"))
                setcolor = COLOR_1.S_StringColor;
            if (name.Contains("T"))
                setcolor = COLOR_1.T_StringColor;
            if (name.Contains("U"))
                setcolor = COLOR_1.U_StringColor;
            if (name.Contains("V"))
                setcolor = COLOR_1.V_StringColor;
            if (name.Contains("W"))
                setcolor = COLOR_1.W_StringColor;
            if (name.Contains("X"))
                setcolor = COLOR_1.X_StringColor;
            if (name.Contains("Y"))
                setcolor = COLOR_1.Y_StringColor;
            if (name.Contains("Z"))
                setcolor = COLOR_1.Z_StringColor;

            return setcolor;
        }

        public static DispatchingModel SelectMachine(List<DispatchingModel> lstmn)
        {
            if (lstmn.Count > 0)
                return lstmn.OrderBy(x => x.LastEndTime).ToList()[0];
            else
                return null;
        }

        public static string GetScheduleToString(ScheduleModel model)
        {
            return model.ID_LOT + "," + model.ID_Machine + "," + model.JobType + "," + model.ProcessingTime + "," + model.StartTime + "," + model.EndTime + ","
                + model.DueTime + "," + model.SetUpTime + "," + model.Violation + "," + model.SetUpTime;
        }
    }
}
