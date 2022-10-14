using PINOKIO_SCHEDULER.Definitions;
using PINOKIO_SCHEDULER.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINOKIO_SCHEDULER.SubView;

namespace PINOKIO_SCHEDULER.GeneralFunctions
{
    public static class PySocket
    {
        public static string ToPY_GetJobList(DataTable data)
        {
            if (data == null || data.Rows.Count < 1)
                return "ERROR";

            string returnString = string.Empty;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                //returnString += i + STR.COMMA;
                returnString += data.Rows[i][1].ToString() + STR.COMMA;
                returnString += data.Rows[i][2].ToString() + STR.COMMA;
                returnString += data.Rows[i][3].ToString() + STR.ENTER;
            }

            return returnString;
        }
        public static string ToPY_GetSortJobList(string msg,DataTable data)
        {
            if (data == null || data.Rows.Count < 1)
                return "Error";

            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);
            string returnString = string.Empty;
            if(split[0] == "")
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    //returnString += i + STR.COMMA;
                    returnString += data.Rows[i][0].ToString() + STR.COMMA;
                    returnString += data.Rows[i][1].ToString() + STR.COMMA;
                    returnString += data.Rows[i][2].ToString() + STR.COMMA;
                    returnString += data.Rows[i][3].ToString() + STR.COMMA;
                }
            }
            else if (data.Columns.Contains(split[0]))
            {
                DataView dataView = new DataView(data);
                dataView.Sort = split[0] + " ASC";
                DataTable SortDt = dataView.ToTable();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    //returnString += i + STR.COMMA;
                    returnString += SortDt.Rows[i][0].ToString() + STR.COMMA;
                    returnString += SortDt.Rows[i][1].ToString() + STR.COMMA;
                    returnString += SortDt.Rows[i][2].ToString() + STR.COMMA;
                    returnString += SortDt.Rows[i][3].ToString() + STR.COMMA;
                }
            }
            else
            {
                returnString += "Column명이 잘못되었습니다. Column목록 [";
                foreach(DataColumn columns in data.Columns)
                {
                    returnString += columns.ToString() + ", ";
                }
                returnString += "]";
            }

            return returnString;
        }

        public static Dictionary<string,int> ToPY_GetJobCount(DataTable data)
        {

            string name = string.Empty;
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
              
                name = data.Rows[i][1].ToString();

                if (!dic.ContainsKey(name))
                    dic.Add(name, 1);
                else
                    dic[name]++;

            }

            return dic;
        }

        public static string ToPY_GetJobList_Current(Dictionary<string,RemainJob> remaindic)
        {
            remaindic = remaindic.OrderByDescending(x => x.Value.RemainCount).ToDictionary(p => p.Key, p => p.Value);
            if (remaindic == null || remaindic.Count < 1)
                return "ERROR";

            string returnString = string.Empty;
                       
            foreach(KeyValuePair<string,RemainJob> pair in remaindic)
            {
                returnString += pair.Key + STR.COMMA+pair.Value.RemainCount.ToString() + STR.ENTER;
                //returnString += pair.Value.RemainCount.ToString() + STR.ENTER;
            }

            return returnString;
        }
        public static string ToPY_Calcul_Tardy(string msg,JOB.Problem pr,List<DispatchingModel> PY_istdp)
        {
            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);
            DispatchingModel selectMachine = PY_istdp.Find(x => x.Id_Machine.Equals(Int32.Parse(split[0])));          
            int ProcessingTime = pr.Dic_JobType_Setting[split[1]].ProcessTime_Machine[Int32.Parse(split[0])] * Int32.Parse(split[2]);
            int StartTime = selectMachine.LastEndTime;
            int EndTime = StartTime + ProcessingTime;
            int DueDate = Int32.Parse(split[3]);

            int Violation = EndTime - DueDate;
            if (Violation < 0)
                Violation = 0;
            return Violation.ToString();
        }
        public static string ToPY_Calcul_TardyJobList(string msg, JOB.Problem pr, List<DispatchingModel> PY_istdp, Dictionary<string, JobModel> DicJobList)
        {
            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);
            DispatchingModel selectMachine = PY_istdp.Find(x => x.Id_Machine.Equals(Int32.Parse(split[0])));
            int Violation = 0;
            foreach (JobModel joblst in DicJobList.Values)
            {
                if (joblst.ID_Lot.Equals(Int32.Parse(split[1])))
                {
                    int ProcessingTime = pr.Dic_JobType_Setting[joblst.JobType].ProcessTime_Machine[Int32.Parse(split[0])] * joblst.Quantity;
                    int StartTime = selectMachine.LastEndTime;
                    int EndTime = StartTime + ProcessingTime;
                    int DueDate = joblst.DueTime;

                    Violation = EndTime - DueDate;
                    if (Violation < 0)
                        Violation = 0;

                }

            }

            return Violation.ToString();

        }
        public static string ToPY_GetJobList_byJobType(DataTable data)
        {
            if (data == null || data.Rows.Count < 1)
                return "ERROR";

            string returnString = string.Empty;

            Dictionary<string, int> dicJob = new Dictionary<string, int>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                string jobType = data.Rows[i][1].ToString();

                if (dicJob.ContainsKey(jobType))
                    dicJob[jobType] += 1;
                else
                    dicJob.Add(jobType, 1);
            }

            var NeWdicJob = dicJob.OrderBy(x => x.Key);

            foreach (var kvp in NeWdicJob)
                returnString += kvp.Key + STR.COMMA + kvp.Value + STR.ENTER;

            return returnString;
        }
        public static string ToPY_Calcul_SetupTime(string msg, Dictionary<string, MachineNode> DicMachine, JOB.Problem pr)
        {
            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);
            if(DicMachine["M"+split[0]].EndJob.Values.ElementAt(DicMachine["M"+split[0]].EndJob.Count - 1).JobType == split[1])
            {
                return "Occurred SetupTime : 0";
            }
            else
            {
                return "Occurred SetupTime : " + pr.Dic_JobType_Setting[split[1]].SetUp_Time.ToString();

            }
        }
        public static string ToPY_Calcul_ProcessingTime(string msg, JOB.Problem pr)
        {
            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);
            int PT = pr.Dic_JobType_Setting[split[1]].ProcessTime_Machine[Int32.Parse(split[0])] * Int32.Parse(split[2]);

            return PT.ToString();
        }
        public static string ToPY_Calcul_ProcessingTimeID(string msg, JOB.Problem pr, Dictionary<string, JobModel> DicJobList)
        {
            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);

            
            foreach (JobModel joblst in DicJobList.Values)
            {
                if(joblst.ID_Lot.Equals(Int32.Parse(split[1])))
                {
                    int PT = pr.Dic_JobType_Setting[joblst.JobType].ProcessTime_Machine[Int32.Parse(split[0])] * joblst.Quantity;

                    return PT.ToString();
                }
                
            }
            return "Error";
        }
        public static string ToPY_GetAllocPos(string msg, List<DispatchingModel> PY_istdp)
        {
            if(PY_istdp.Count ==0)
            {
                return "Error";
            }
            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);
            string Machine_id = string.Empty;
            string index = string.Empty;
            foreach (DispatchingModel dp in PY_istdp)
            {
                if (dp.WorkJob.Contains(split[0]))
                {
                    for(int i =0; i< dp.WorkJob.Count; i++)
                    {
                        if (dp.WorkJob[i].Equals(split[0]))
                        {
                            Machine_id = dp.Id_Machine.ToString();
                            index = i.ToString();
                        }
                            
                    }
                }

            }
            return Machine_id + "," + index;
        }
        public static string ToPY_GetMachineCompleteTime(string msg , List<DispatchingModel> PY_istdp)
        {
            string[] split = msg.Split(STR.ENTER);
            int Ctime = 0;
            if (split[0].Contains("MAX"))
            {
                int Max = 0;
                for (int i = 0; i < PY_istdp.Count; i++)
                {
                    
                    if(PY_istdp[i].LastEndTime > Max)
                    {
                        Max = PY_istdp[i].LastEndTime;
                    }
                }
                Ctime = Max;
            }
            else if (split[0].Contains("MIN"))
            {
                int Min = Int32.MaxValue;
                for (int i = 0; i < PY_istdp.Count; i++)
                {
                    if (PY_istdp[i].LastEndTime < Min)
                    {
                        Min = PY_istdp[i].LastEndTime;
                    }
                }
                Ctime = Min;
            }
            
            return Ctime.ToString();
        }
        public static string ToPY_GetMachine_LastTime(string msg, List<DispatchingModel> PY_istdp)
        {
            if (!msg.Contains("\n"))
                return "syntax Error";
            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);
            string returnString = string.Empty;

            foreach (DispatchingModel model in PY_istdp)
            {
                string job_lot = string.Empty;
                string LastJob = "null";
                if (model.WorkJob.Count > 0)
                {
                    job_lot = model.WorkJob[model.WorkJob.Count - 1];
                }
                else
                {
                    job_lot = "null";
                }
                if(model.LastJob != string.Empty)
                {
                    LastJob = model.LastJob;
                }
                returnString += model.Id_Machine.ToString() + " , " + LastJob + ", " + job_lot + "," + model.LastEndTime.ToString() + ",";
            }

           

            return returnString;
        }
        public static string FromPY_SetScheduleSingle(string msg, int TotalMachineNumber, DataTable data, List<ScheduleModel> lstSchedule, out ScheduleModel ScheduledModel)
        {
            ScheduledModel = null;
            string returnString = string.Empty;

            if (!msg.Contains("\n"))
                return "syntax Error";

            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);
            if (data != null)
            {
                var ResultRow = data.AsEnumerable().Where(myRow => myRow[0].ToString() == split[0] && myRow[1].ToString() == split[2]);


                //사용자가 보낸 작업이 JOB DT에 있는지 확인해줌
                if (ResultRow == null || ResultRow.Count() < 0)
                    return "No JobName in JobTable";

            }
            else
                return "No JobTable";
            //사용자 머신번호가 다른지 확인해줌
            if (Convert.ToInt32(split[1]) >= TotalMachineNumber)
                return "No MachineName in Last Settings";

            int id_LOT = Convert.ToInt32(split[0]);
            int id_Machine = Convert.ToInt32(split[1]);
            string JOB_TYPE = split[2];

            bool isSetup = false;

            if (split[7].ToUpper().Contains("O"))
                isSetup = true;

            ScheduleModel LastscheduledModel = lstSchedule.Find(x => x.ID_LOT == id_LOT && x.ID_Machine == id_Machine && x.JobType == JOB_TYPE);

            if (LastscheduledModel != null)
                return "Already Scheduled";

            ///수정 필요
            //ScheduledModel = new ScheduleModel(
            //    id_LOT, id_Machine, JOB_TYPE,
            //    Convert.ToInt32(split[3]),
            //    Convert.ToInt32(split[4]),
            //    Convert.ToInt32(split[5]),
            //    Convert.ToInt32(split[6]),
            //    isSetup,
            //    Convert.ToInt32(split[8])
            //    , Convert.ToInt32(split[9]));

            return "Success";
        }
        public static JOB.Problem FromPY_ProblemSetting(string lststr)
        {
            JOB.Problem problem = new JOB.Problem();
            DataTable dt = new DataTable();
            dt.Columns.Add("Job Type");
            dt.Columns.Add("Machine Arr");
            dt.Columns.Add("Processing Time");
            dt.Columns.Add("Setup Time");
            List<string> jobTpye = new List<string>();
            PY_MakeJobTpye(jobTpye);
            string[] splittedSchedule = lststr.Split(STR.ENTER);
            Dictionary<string, JOB.Job_Setting_Value> DicJobTypeValue = new Dictionary<string, JOB.Job_Setting_Value>();
            
           string[] split = splittedSchedule[1].Split(STR.COMMA);
            
            problem.Job_Type_Count = int.Parse(split[0]);
            problem.Machine_Count = int.Parse(split[1]);
            bool Arragement = bool.Parse(split[2]);
            int Max_ptime = int.Parse(split[3]);
            bool Pro_option = bool.Parse(split[4]);
            int SetupTime = int.Parse(split[5]);
            string Init_MachineArr = PY_InitMachineArr(problem.Machine_Count);
            string Init_pr = PY_InitProcessing(problem.Machine_Count);
            int MachineNo = problem.Machine_Count;
            for (int i = 0; i < problem.Job_Type_Count; i++)
            {
                if (Arragement)
                {
                    Init_MachineArr = PY_MachineArrRandom(problem.Machine_Count,out MachineNo);
                    Init_pr = PY_InitProcessing(MachineNo);
                }
                if (Pro_option)
                {
                    Init_pr = PY_InitProcessingRandom(MachineNo, Max_ptime);
                }
                
                dt.Rows.Add(jobTpye[i], Init_MachineArr, Init_pr, SetupTime);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JOB.Job_Setting_Value jobvalue = new JOB.Job_Setting_Value();
                List<object> sd = dt.Rows[i].ItemArray.ToList();
                jobvalue.TYPE = sd[0].ToString();
                jobvalue.SetUp_Time = Convert.ToInt32(sd[3]);
                if (jobvalue.SetUp_Time >= 21)
                {
                    break;
                }

                if (sd[1].ToString() == "" && sd[2].ToString() == "")
                {
                    if (sd[1] == string.Empty)
                    {
                        
                           // error = true;
                            continue;
                        
                    }

                }
                else if (!sd[1].ToString().Contains('/'))
                {
                    jobvalue.ProcessTime_Machine.Add(Convert.ToInt32(sd[1].ToString()), Convert.ToInt32(sd[2].ToString()));
                }
                else if (sd[1].ToString().Contains('/'))
                {
                    string[] machine_arr = sd[1].ToString().Split('/');
                    string[] processing = sd[2].ToString().Split('/');
                    if (machine_arr.Length != processing.Length)
                    {
                        break;
                    }

                    for (int x = 0; x < machine_arr.Count(); x++)
                    {
                        jobvalue.ProcessTime_Machine.Add(Convert.ToInt32(machine_arr[x]), Convert.ToInt32(processing[x]));
                    }
                }

                DicJobTypeValue.Add(sd[0].ToString(), jobvalue);
            }
            problem.Dic_JobType_Setting = DicJobTypeValue;
            return problem;
        }
        public static DataTable FromPY_JobListSetting(string lststr, JOB.Problem Problem_Value)
        {
            DataTable DT_MakeJob_Wegiht = new DataTable();
            try
            {
                Dictionary<string, double> DicJobTypeWeight = new Dictionary<string, double>();
                string[] splittedJobList = lststr.Split(STR.ENTER);
                string[] split = splittedJobList[1].Split(STR.COMMA);
                int counts = Convert.ToInt32(split[0]);
                int ID = 0;
                List<double> duedatelist = new List<double>();
                List<string> jobtypeList = new List<string>();
                int quantity_Max = Int32.Parse(split[3]) + 1;
                int dueRand_Max = Int32.Parse(split[4]);
                // double tightness = Convert.ToDouble(1.0);

                double JobtypeCount = Convert.ToDouble(Problem_Value.Job_Type_Count);

                foreach (KeyValuePair<string, JOB.Job_Setting_Value> pair in Problem_Value.Dic_JobType_Setting)
                {
                    double pp = ((double)1 / (double)JobtypeCount);
                    double ss = Math.Round(pp, 3);
                    DicJobTypeWeight.Add(pair.Key, ss);

                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Job ID");
                dt.Columns.Add("Job Type");
                dt.Columns.Add("Quantity", typeof(Int32));
                dt.Columns.Add("Due Date", typeof(Int32));
                DataColumn[] dtkey = new DataColumn[1];
                dtkey[0] = dt.Columns["Job ID"];
                dt.PrimaryKey = dtkey;
                DT_MakeJob_Wegiht = dt;

                // RefreshWegih();
                WeightedRandom randomjop = new WeightedRandom(DicJobTypeWeight);
                for (int i = 0; i < counts; i++)
                {
                    string typeName = randomjop.getRandom(i);
                    jobtypeList.Add(typeName);
                }

                for (int i = 0; i < counts; i++)
                {
                    string typeName = jobtypeList[i];
                    // sdsd.Add(typeName);
                    Random randDue = new Random(Guid.NewGuid().GetHashCode());
                    Random random = new Random(Guid.NewGuid().GetHashCode());
                    int Quantity_Mix = Maths.MinQuant(Problem_Value.Dic_JobType_Setting[typeName].ProcessTime_Machine);
                    int qunt = random.Next(1, quantity_Max);
                    int MaxJobProsTime = Int32.Parse(split[2]);
                    int RanDue = randDue.Next(qunt * MaxJobProsTime, (qunt * MaxJobProsTime * dueRand_Max) + 1);
                    DT_MakeJob_Wegiht.Rows.Add(i, typeName, qunt, RanDue);
                    duedatelist.Add(RanDue);
                }


                //  gc_MakeJobList.DataSource = DT_MakeJob_Wegiht;
                //  JobListTable = DT_MakeJob_Wegiht;
                //  tb_DueDate_Max.Text = duedatelist.Max().ToString();
                //  tb_DueDate_Min.Text = duedatelist.Min().ToString();

                return DT_MakeJob_Wegiht;
            }
            catch
            {
                return DT_MakeJob_Wegiht;
            }
        }
        public static DataTable FromPY_SetJobList(string lststr)
        {
            DataTable DT_Job = GeneralFunc.GetNewJobDT();

            string[] splittedSchedule = lststr.Split(STR.ENTER);

            for (int i = 1; i < splittedSchedule.Length; i++)
            {
                if (string.IsNullOrEmpty(splittedSchedule[i]))
                    continue;

                string[] split = splittedSchedule[i].Split(STR.COMMA);

                DT_Job.Rows.Add(i, split[0], split[1], split[2]);
            }

            return DT_Job;
        }    
        public static List<string> FromPY_SetScheduleList(string lststr)
        {
            List<string> LstSchedule = new List<string>();

            string[] splittedSchedule = lststr.Split('\n');

            for (int i = 1; i < splittedSchedule.Length; i++)
            {
                if (string.IsNullOrEmpty(splittedSchedule[i]))
                    continue;

                LstSchedule.Add(splittedSchedule[i]);
            }

            return LstSchedule;
        }
        private static string PY_InitMachineArr(int no)
        {
            string machinearr = string.Empty;
            
            for (int i = 0; i < no; i++)
            {
                if (i == no - 1)
                {
                    machinearr += i;
                }
                else
                {
                    machinearr += i + "/";
                }

            }

            return machinearr;
        }
        private static string PY_MachineArrRandom(int no,out int machinenum)
        {
            Random randint = new Random(Guid.NewGuid().GetHashCode());
            Random randmc = new Random(Guid.NewGuid().GetHashCode());
            string machinearr = string.Empty;
            int machineno = randint.Next(1, no + 1);
            List<int> randomNum = new List<int>();
            machinenum = machineno;
            for (int i = 0; i < machineno; i++)
            {
                int mc = 0;
                do
                {
                    mc= randmc.Next(0, machineno);
                } 
                while (randomNum.Contains(mc));


                randomNum.Add(mc);
            }
            randomNum.Sort();
            for (int i = 0; i < machineno; i++)
            {
                if (i == machineno - 1)
                {
                    machinearr += randomNum[i];
                }
                else
                {
                    machinearr += randomNum[i] + "/";
                }

            }

            return machinearr;
        }
        private static string PY_InitProcessingRandom(int no,int max_ptime)
        {
            string machinearr = string.Empty;
            Random randint = new Random(Guid.NewGuid().GetHashCode());                  
            for (int i = 0; i < no; i++)
            {
                int ptime = randint.Next(1, max_ptime + 1);
                if (i == no - 1)
                {
                    machinearr += ptime;
                }
                else
                {
                    machinearr += ptime + "/";
                }

            }

            return machinearr;
        }
        private static string PY_InitProcessing(int no)
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
        private static void PY_MakeJobTpye(List<string> jobTpye)
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
      
    }
}
