using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINOKIO_SCHEDULER.Definitions;
using PINOKIO_SCHEDULER.GeneralFunctions;
using PINOKIO_SCHEDULER.JOB;

namespace PINOKIO_SCHEDULER.Model
{
    public class DispatchingModel
    {
        public int Id_Machine { get; set; }
        public int LastEndTime { get; set; }
        public string LastJob { get; set; }

        public List<string> WorkJob { get; set; }

        public DispatchingModel(int id_Machine, int lastEndTime, string lastJob)
        {
            Id_Machine = id_Machine;
            LastEndTime = lastEndTime;
            LastJob = lastJob;
            WorkJob = new List<string>();
        }
    }
    public class SchdulingRules
    {
        public static List<string> GetSchedule(int ruleType, int machineNumber, DataTable dt, Problem pr)
        {
            if (ruleType == 0)
            {
                return FIFO_RoundRobin(machineNumber, dt, pr);
            }
            else if (ruleType == 1)
            {
                return EDD(machineNumber, dt, pr);
            }
            else if (ruleType == 2)
            {
                return SetupFirst(machineNumber, dt, pr);
            }
            else if (ruleType == 3)
            {
                return LST(machineNumber, dt, pr);
            }
            else if (ruleType == 4)
            {
                return CR(machineNumber, dt, pr);
            }
            else if (ruleType == 5)
            {
                return HASA(machineNumber, dt, pr);
            }
            return null;
        }

        public static List<string> FIFO_RoundRobin(int machineNumber, DataTable dt, Problem pr)
        {
            List<string> lstDispatching = new List<string>();
            lstDispatching.Add(machineNumber + ",,,,,,,,,");

            List<DispatchingModel> lstdp = new List<DispatchingModel>();
            for (int i = 0; i < machineNumber; i++)
                lstdp.Add(new DispatchingModel(i, 0, string.Empty));

            int LastMachine = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (LastMachine > machineNumber - 1)
                    LastMachine = 0;

                DispatchingModel machine = GeneralFunc.SelectMachine(lstdp);
                int Id_Lot = Convert.ToInt32(dt.Rows[i][0].ToString());
                int Id_Machine = LastMachine;
                string JobType = dt.Rows[i][1].ToString();
                int ProcessingTime = Convert.ToInt32(dt.Rows[i][2].ToString()); ;
                int SetupTime = 2;

                if (pr.Dic_JobType_Setting.ContainsKey(JobType))///6.옵션이 있을 경우 및 셋업타임 가져옴
                {
                    SetupTime = pr.Dic_JobType_Setting[JobType].SetUp_Time;

                    if (pr.Dic_JobType_Setting[JobType].ProcessTime_Machine.Count() != 0)
                        ProcessingTime = Convert.ToInt32(dt.Rows[i][2].ToString()) * pr.Dic_JobType_Setting[JobType].ProcessTime_Machine[Id_Machine];
                }

                int StartTime = 0;
                int EndTime = 0;
                int DueDate = Convert.ToInt32(dt.Rows[i][3].ToString());
                //string isSetup = "X";
                int isSetup = 0;
                int Violation = 0;

                ////////////
                DispatchingModel dispModel = lstdp.Find(x => x.Id_Machine.Equals(Id_Machine));

                StartTime = dispModel.LastEndTime;
                EndTime = StartTime + ProcessingTime;
                Violation = EndTime - DueDate;
                dispModel.WorkJob.Add(JobType);

                if (Violation < 0)
                    Violation = 0;

                if (string.IsNullOrEmpty(dispModel.LastJob)) //장비에 전작업이 없고 첫 작업이면 걍 추가
                {
                    dispModel.LastEndTime += ProcessingTime;
                    isSetup = 0;
                }
                else // 전 작업이 있을 경우
                {
                    if (!dispModel.LastJob.Equals(JobType))
                    {
                        if (SetupTime != 2)
                        {
                           
                            StartTime += SetupTime;
                            EndTime += SetupTime;
                            dispModel.LastEndTime = dispModel.LastEndTime + ProcessingTime + SetupTime;
                        }
                        else
                        {
                            
                            StartTime += 2;
                            EndTime += 2;
                            dispModel.LastEndTime = dispModel.LastEndTime + ProcessingTime + 2;
                        }

                        //isSetup = "O";
                        isSetup = SetupTime;
                        Violation = EndTime - DueDate;

                        if (Violation < 0)
                            Violation = 0;
                    }
                    else
                    {
                        
                        dispModel.LastEndTime += ProcessingTime;
                    }
                }

                dispModel.LastJob = JobType;
                /////////////

                lstDispatching.Add(Id_Lot + "," + Id_Machine + "," + JobType + "," + ProcessingTime + "," + StartTime + "," + EndTime + "," + DueDate + "," + isSetup + "," + Violation + "," + SetupTime);

                LastMachine++;
            }

            return lstDispatching;


        }

        public static List<string> EDD(int machineNumber, DataTable data, Problem pr)
        {
            List<JobModel> dt = new List<JobModel>();

            for (int i = 0; i < data.Rows.Count; i++)
                dt.Add(new JobModel(i, data.Rows[i][1].ToString(), Convert.ToInt32(data.Rows[i][2].ToString()), Convert.ToInt32(data.Rows[i][3].ToString())));

            dt = dt.OrderBy(x => x.DueTime).ToList();

            List<string> lstDispatching = new List<string>();
            lstDispatching.Add(machineNumber + ",,,,,,,,");

            List<DispatchingModel> lstdp = new List<DispatchingModel>();
            for (int i = 0; i < machineNumber; i++)
                lstdp.Add(new DispatchingModel(i, 0, string.Empty));

            for (int i = 0; i < dt.Count; i++)
            {
                int Id_Lot = dt[i].ID_Lot;
                int Id_Machine = GeneralFunc.SelectMachine(lstdp).Id_Machine; ;
                string JobType = dt[i].JobType;
                int ProcessingTime = Convert.ToInt32(dt[i].Quantity);
                int SetupTime = DEF.SETUPTIME;
                int isSetup = 0;
                int StartTime = 0;
                int EndTime = 0;
                int DueDate = dt[i].DueTime;
                int Violation = 0;

                if (pr.Dic_JobType_Setting.ContainsKey(JobType))///옵션이 있을 경우 및 셋업타임 가져옴
                {
                    SetupTime = pr.Dic_JobType_Setting[JobType].SetUp_Time;

                    if (pr.Dic_JobType_Setting[JobType].ProcessTime_Machine.Count() != 0)
                        ProcessingTime = Convert.ToInt32(dt[i].Quantity) * pr.Dic_JobType_Setting[JobType].ProcessTime_Machine[Id_Machine];
                }

                ////////////
                DispatchingModel dispModel = lstdp.Find(x => x.Id_Machine.Equals(Id_Machine));

                StartTime = dispModel.LastEndTime;
                EndTime = StartTime + ProcessingTime;
                Violation = EndTime - DueDate;

                if (Violation < 0)
                    Violation = 0;

                if (string.IsNullOrEmpty(dispModel.LastJob)) //장비에 전작업이 없고 첫 작업이면 걍 추가
                {
                    dispModel.LastEndTime += ProcessingTime;
                    isSetup = 0;
                }
                else
                {
                    if (!dispModel.LastJob.Equals(JobType))// 셋업발생
                    {

                        if (SetupTime != 2)
                        {
                            StartTime += SetupTime;
                            EndTime += SetupTime;
                            dispModel.LastEndTime = dispModel.LastEndTime + ProcessingTime + SetupTime;
                        }
                        else
                        {
                            StartTime += 2;
                            EndTime += 2;
                            dispModel.LastEndTime = dispModel.LastEndTime + ProcessingTime + 2;
                        }
                        isSetup = SetupTime;
                        Violation = EndTime - DueDate;

                        if (Violation < 0)
                            Violation = 0;
                    }
                    else
                    {
                        dispModel.LastEndTime += ProcessingTime;
                    }
                }

                dispModel.LastJob = JobType;
                /////////////

                lstDispatching.Add(Id_Lot + "," + Id_Machine + "," + JobType + "," + ProcessingTime + "," + StartTime + "," + EndTime + "," + DueDate + "," + isSetup + "," + Violation + "," + SetupTime);
            }

            return lstDispatching;
        }

        public static List<string> SetupFirst(int machineNumber, DataTable data, Problem pr)
        {
            List<JobModel> dt = new List<JobModel>();
            for (int i = 0; i < data.Rows.Count; i++)
                dt.Add(new JobModel(i, data.Rows[i][1].ToString(), Convert.ToInt32(data.Rows[i][2].ToString()), Convert.ToInt32(data.Rows[i][3].ToString())));

            //DueTime으로 정렬
            dt = dt.OrderBy(x => x.DueTime).ToList();

            List<string> lstDispatching = new List<string>();
            lstDispatching.Add(machineNumber + ",,,,,,,,");

            List<DispatchingModel> lstdp = new List<DispatchingModel>();
            for (int i = 0; i < machineNumber; i++)
                lstdp.Add(new DispatchingModel(i, 0, string.Empty));

            List<string> LstJobTypes = dt.Select(x => x.JobType).ToList().Distinct().ToList();
            int JobTypesIndex = 0;

            //setupFirst는 job 타입별로 한개씩 할당함 (A-B-C-A-B-C...)
            while (dt.Count > 0)
            {
                //Jobtype이 한바퀴 돌았으면 다시 초기화 해줌
                if (JobTypesIndex > LstJobTypes.Count - 1)
                    JobTypesIndex = 0;

                //JOB을 타입별로 찾음
                JobModel job = dt.Find(x => x.JobType.Equals(LstJobTypes[JobTypesIndex]));
                JobTypesIndex++;

                //다음차수 jobtype이 없을때 다음 jobtype으로 재진입
                if (job == null)
                    continue;

                DispatchingModel DP_LeastMakeSpan = lstdp.OrderBy(x => x.LastEndTime).ToList()[0];
                if (!string.IsNullOrEmpty(DP_LeastMakeSpan.LastJob))
                {
                    DP_LeastMakeSpan = lstdp.FindAll(x => x.LastJob.Equals(job.JobType)).OrderBy(x => x.LastEndTime).ToList()[0];
                }
                int Id_Lot = job.ID_Lot;
                string JobType = job.JobType;
                int DueDate = job.DueTime;
                int Id_Machine = DP_LeastMakeSpan.Id_Machine;
                int ProcessingTime = job.Quantity;
                int SetupTime = DEF.SETUPTIME;
                int StartTime = 0;
                int EndTime = 0;
                int isSetup = 0;
                int Violation = 0;

                if (pr.Dic_JobType_Setting.ContainsKey(JobType))///6.옵션이 있을 경우 및 셋업타임 가져옴
                {
                    SetupTime = pr.Dic_JobType_Setting[JobType].SetUp_Time;

                    if (pr.Dic_JobType_Setting[JobType].ProcessTime_Machine.Count() != 0)
                        ProcessingTime = Convert.ToInt32(job.Quantity) * pr.Dic_JobType_Setting[JobType].ProcessTime_Machine[Id_Machine];
                }

                List<DispatchingModel> LstarrangeDP = lstdp.FindAll(x => x.LastJob.Equals(JobType)).OrderBy(x => x.LastEndTime).ToList();

                //설비 같은거 찾음
                if (LstarrangeDP.Count > 0 && lstdp[Id_Machine].LastEndTime != 0)
                    Id_Machine = LstarrangeDP[0].Id_Machine;

                ////////////
                DispatchingModel dispModel = lstdp.Find(x => x.Id_Machine.Equals(Id_Machine));

                StartTime = dispModel.LastEndTime;
                EndTime = StartTime + ProcessingTime;
                Violation = EndTime - DueDate;

                if (Violation < 0)
                    Violation = 0;

                if (string.IsNullOrEmpty(dispModel.LastJob)) //장비에 전작업이 없고 첫 작업이면 걍 추가
                {
                    dispModel.LastEndTime += ProcessingTime;
                    SetupTime = 0;
                }
                else
                {
                    if (!dispModel.LastJob.Equals(JobType))// 셋업발생
                    {
                       // SetupTime = pr.Dic_JobType_Setting[JobType].SetUp_Time;
                        StartTime += DEF.SETUPTIME;
                        EndTime += DEF.SETUPTIME;
                        dispModel.LastEndTime = dispModel.LastEndTime + ProcessingTime + DEF.SETUPTIME;
                        isSetup = SetupTime;
                        Violation = EndTime - DueDate;

                        if (Violation < 0)
                            Violation = 0;
                    }
                    else
                    {
                        SetupTime = 0;
                        dispModel.LastEndTime += ProcessingTime;
                    }
                }

                dispModel.LastJob = JobType;
                /////////////

                lstDispatching.Add(Id_Lot + "," + Id_Machine + "," + JobType + "," + ProcessingTime + "," + StartTime + "," + EndTime + "," + DueDate + "," + isSetup + "," + Violation + "," + SetupTime);

                dt.Remove(dt.Find(x => x.ID_Lot == Id_Lot));
            }

            return lstDispatching;
        }

        public static List<string> LST(int machineNumber, DataTable data, Problem pr)
        {
            List<JobModel> dt = new List<JobModel>();

            for (int i = 0; i < data.Rows.Count; i++)
                dt.Add(new JobModel(i, data.Rows[i][1].ToString(), Convert.ToInt32(data.Rows[i][2].ToString()), Convert.ToInt32(data.Rows[i][3].ToString())));

            //LST(Leat slack time) : 슬랙 시간(여유시간)이 가장 적은 것 우선
            //slack == DT - 현재시간 - 작업시간            
            //현 정책에서 machine type별로 proctime이 달라지므로 매번 계산 필요
            //1. 일단 (DT - PT) 낮은순 로 정렬
            dt = dt.OrderBy(x => x.DueTime - x.Quantity).ToList();

            List<string> lstDispatching = new List<string>();
            lstDispatching.Add(machineNumber + ",,,,,,,,");

            List<DispatchingModel> lstdp = new List<DispatchingModel>();
            for (int i = 0; i < machineNumber; i++)
                lstdp.Add(new DispatchingModel(i, 0, string.Empty));

            //Dictionary<int, List<Tuple<int, ScheduleModel>>> DiclstMPTPair = new Dictionary<int, List<Tuple<int, ScheduleModel>>>();

            //2. 잡 할당을 다 할때까지 반복
            while (dt.Count > 0)
            {


                Dictionary<int, List<Tuple<int, ScheduleModel>>> DiclstMPTPair = new Dictionary<int, List<Tuple<int, ScheduleModel>>>();


                //Dictionary<int, ScheduleModel> lstMPTPair = new Dictionary<int, ScheduleModel>();

                foreach (DispatchingModel dis in lstdp)
                {

                    List<Tuple<int, ScheduleModel>> test = new List<Tuple<int, ScheduleModel>>();
                    List<Tuple<int, ScheduleModel>> lstMPTPair = new List<Tuple<int, ScheduleModel>>();
                    for (int i = 0; i < dt.Count; i++)
                    {

                        int Id_Lot = dt[i].ID_Lot;
                        string JobType = dt[i].JobType;
                        int DueDate = dt[i].DueTime;

                        int Id_Machine = dis.Id_Machine;

                        int ProcessingTime = Convert.ToInt32(dt[i].Quantity);
                        int SetupTime = DEF.SETUPTIME;
                        int StartTime = 0;
                        int EndTime = 0;
                        int isSetup = 0;
                        int Violation = 0;
                        int slack = 0;

                        if (pr.Dic_JobType_Setting.ContainsKey(JobType))///6.옵션이 있을 경우 및 셋업타임 가져옴
                        {
                            SetupTime = pr.Dic_JobType_Setting[JobType].SetUp_Time;

                            if (pr.Dic_JobType_Setting[JobType].ProcessTime_Machine.Count() != 0)
                                ProcessingTime = Convert.ToInt32(dt[i].Quantity) * pr.Dic_JobType_Setting[JobType].ProcessTime_Machine[Id_Machine];
                        }

                        //7. 할당된 머신과 비교해서 셋업발생여부 체크
                        if (lstdp[Id_Machine].LastJob.Equals(JobType))
                        {
                            isSetup = 0;
                            SetupTime = 0;
                        }
                        else
                        {
                            if (lstdp[Id_Machine].LastJob.Equals(string.Empty))
                            {
                                isSetup = 0;
                                SetupTime = 0;
                            }
                            else
                            {
                                isSetup =SetupTime;
                            }
                        }


                        //8. 할당된 머신으로부터 Starttime 및 EndTime, Slack 계산
                        StartTime = lstdp[Id_Machine].LastEndTime + SetupTime; //스타트 타임을 셋업 발생시 더해주는 개념
                        EndTime = StartTime + ProcessingTime;
                        //9. slack의 계산은 듀타임과 작업종료 사이의 여유시간임
                        slack = dt[i].DueTime - EndTime;

                        Violation = EndTime - DueDate;
                        if (Violation < 0)
                            Violation = 0;

                        //10. 선정된 머신마다 모든 잡을 할당하고 slack이 가장 낮은 것을 할당함
                        //lstMPTPair.Add(slack, new ScheduleModel(Id_Lot, Id_Machine, JobType, ProcessingTime, StartTime, EndTime, DueDate, SetupTime, Violation, SetupTime));

                        lstMPTPair.Add(new Tuple<int, ScheduleModel>(slack, new ScheduleModel(Id_Lot, Id_Machine, JobType, ProcessingTime, StartTime, EndTime, DueDate, isSetup, Violation, SetupTime)));
                        test = lstMPTPair;
                    }
                    DiclstMPTPair.Add(dis.Id_Machine, test);
                }
                Dictionary<int, Tuple<int, ScheduleModel>> sss = new Dictionary<int, Tuple<int, ScheduleModel>>();

                Dictionary<int, Tuple<int, ScheduleModel>> sssYes = new Dictionary<int, Tuple<int, ScheduleModel>>();
                foreach (KeyValuePair<int, List<Tuple<int, ScheduleModel>>> pair in DiclstMPTPair)
                {
                    List<Tuple<int, ScheduleModel>> Nosetup = new List<Tuple<int, ScheduleModel>>();

                    List<Tuple<int, ScheduleModel>> Yessetup = new List<Tuple<int, ScheduleModel>>();

                    foreach (Tuple<int, ScheduleModel> aaa in pair.Value)
                    {
                        if ((lstdp[pair.Key].LastJob.Equals(aaa.Item2.JobType)))
                        {
                            Nosetup.Add(aaa);
                        }
                        else
                        {
                            Yessetup.Add(aaa);
                        }
                    }

                    //List<Tuple<int, ScheduleModel>> copy = pair.Value.OrderBy(x => x.Item1).ToList();

                    //sss.Add(pair.Key, copy[0]);
                    if (Nosetup.Count != 0)
                    {
                        Nosetup = Nosetup.OrderBy(x => x.Item1).ToList();
                        sss.Add(pair.Key, Nosetup[0]);
                    }
                    else
                    {
                        Yessetup = Yessetup.OrderBy(x => x.Item1).ToList();
                        sssYes.Add(pair.Key, Yessetup[0]);
                    }


                }


                sss = sss.OrderBy(x => x.Value.Item2.EndTime).ToDictionary(p => p.Key, p => p.Value);
                sssYes = sssYes.OrderBy(x => x.Value.Item2.EndTime).ToDictionary(p => p.Key, p => p.Value);

                if (sss.Count > 0 && sssYes.Count > 0 && lstdp[sssYes.Keys.ElementAt(0)].LastEndTime <= lstdp[sss.Keys.ElementAt(0)].LastEndTime)
                {
                    lstdp[sssYes.Keys.ElementAt(0)].LastEndTime = sssYes.Values.ElementAt(0).Item2.EndTime;
                    lstdp[sssYes.Keys.ElementAt(0)].LastJob = sssYes.Values.ElementAt(0).Item2.JobType;
                    lstDispatching.Add(GeneralFunc.GetScheduleToString(sssYes.Values.ElementAt(0).Item2));

                    dt.Remove(dt.Find(x => x.ID_Lot == sssYes.Values.ElementAt(0).Item2.ID_LOT));
                }
                else if (sss.Count > 0 && sssYes.Count > 0 && lstdp[sssYes.Keys.ElementAt(0)].LastEndTime >= lstdp[sss.Keys.ElementAt(0)].LastEndTime)
                {
                    lstdp[sss.Keys.ElementAt(0)].LastEndTime = sss.Values.ElementAt(0).Item2.EndTime;
                    lstdp[sss.Keys.ElementAt(0)].LastJob = sss.Values.ElementAt(0).Item2.JobType;
                    lstDispatching.Add(GeneralFunc.GetScheduleToString(sss.Values.ElementAt(0).Item2));

                    dt.Remove(dt.Find(x => x.ID_Lot == sss.Values.ElementAt(0).Item2.ID_LOT));

                }
                else if (sss.Count() != 0 && sssYes.Count == 0)
                {
                    sss = sss.OrderBy(x => x.Value.Item2.EndTime).ToDictionary(p => p.Key, p => p.Value);


                    //lstMPTPair = lstMPTPair.OrderBy(x => x.Item1).ToList();
                    lstdp[sss.Keys.ElementAt(0)].LastEndTime = sss.Values.ElementAt(0).Item2.EndTime;
                    lstdp[sss.Keys.ElementAt(0)].LastJob = sss.Values.ElementAt(0).Item2.JobType;
                    lstDispatching.Add(GeneralFunc.GetScheduleToString(sss.Values.ElementAt(0).Item2));

                    dt.Remove(dt.Find(x => x.ID_Lot == sss.Values.ElementAt(0).Item2.ID_LOT));
                }
                else
                {
                    sssYes = sssYes.OrderBy(x => x.Value.Item2.EndTime).ToDictionary(p => p.Key, p => p.Value);


                    //lstMPTPair = lstMPTPair.OrderBy(x => x.Item1).ToList();
                    lstdp[sssYes.Keys.ElementAt(0)].LastEndTime = sssYes.Values.ElementAt(0).Item2.EndTime;
                    lstdp[sssYes.Keys.ElementAt(0)].LastJob = sssYes.Values.ElementAt(0).Item2.JobType;
                    lstDispatching.Add(GeneralFunc.GetScheduleToString(sssYes.Values.ElementAt(0).Item2));

                    dt.Remove(dt.Find(x => x.ID_Lot == sssYes.Values.ElementAt(0).Item2.ID_LOT));
                }


            }


            return lstDispatching;
        }

        public static List<string> CR(int machineNumber, DataTable data, Problem pr)
        {
            List<JobModel> dt = new List<JobModel>();

            for (int i = 0; i < data.Rows.Count; i++)
                dt.Add(new JobModel(i, data.Rows[i][1].ToString(), Convert.ToInt32(data.Rows[i][2].ToString()), Convert.ToInt32(data.Rows[i][3].ToString())));

            //CR(Critical ratio) : 납기 남은기간 대비 작업시간의 비율을 고려함
            //CR == DT - 현재시간 / 작업시간
            //현 정책에서 machine type별로 proctime이 달라지므로 매번 계산 필요
            //1. 일단 (DT - PT) 낮은순 로 정렬
            dt = dt.OrderBy(x => x.DueTime - x.Quantity).ToList();

            List<string> lstDispatching = new List<string>();
            lstDispatching.Add(machineNumber + ",,,,,,,,");

            List<DispatchingModel> lstdp = new List<DispatchingModel>();
            for (int i = 0; i < machineNumber; i++)
                lstdp.Add(new DispatchingModel(i, 0, string.Empty));

            //2. 잡 할당을 다 할때까지 반복
            while (dt.Count > 0)
            {

                Dictionary<int, List<Tuple<double, ScheduleModel>>> DiclstMPTPair = new Dictionary<int, List<Tuple<double, ScheduleModel>>>();

                foreach (DispatchingModel dis in lstdp)
                {
                    List<Tuple<double, ScheduleModel>> test = new List<Tuple<double, ScheduleModel>>();
                    List<Tuple<double, ScheduleModel>> lstMPTPair = new List<Tuple<double, ScheduleModel>>();

                    for (int i = 0; i < dt.Count; i++)
                    {
                        int Id_Lot = dt[i].ID_Lot;
                        string JobType = dt[i].JobType;
                        int DueDate = dt[i].DueTime;
                        int Id_Machine = dis.Id_Machine;
                        int ProcessingTime = Convert.ToInt32(dt[i].Quantity); ;
                        int SetupTime = DEF.SETUPTIME;
                        int StartTime = 0;
                        int EndTime = 0;
                        int isSetup = 0;
                        int Violation = 0;
                        double cr = 0;

                        if (pr.Dic_JobType_Setting.ContainsKey(JobType))///6.옵션이 있을 경우 및 셋업타임 가져옴
                        {
                            SetupTime = pr.Dic_JobType_Setting[JobType].SetUp_Time;

                            if (pr.Dic_JobType_Setting[JobType].ProcessTime_Machine.Count() != 0)
                                ProcessingTime = Convert.ToInt32(dt[i].Quantity) * pr.Dic_JobType_Setting[JobType].ProcessTime_Machine[Id_Machine];
                        }

                        //7. 할당된 머신과 비교해서 셋업발생여부 체크
                        if (lstdp[Id_Machine].LastJob.Equals(JobType))
                        {
                            isSetup = 0;
                            SetupTime = 0;
                        }
                        else
                        {
                            if (lstdp[Id_Machine].LastJob.Equals(string.Empty))
                            {
                                isSetup = 0;
                                SetupTime = 0;
                            }
                            else
                            {
                                isSetup = SetupTime;
                            }
                        }

                        //8. 할당된 머신으로부터 Starttime 및 EndTime, cr 계산
                        StartTime = lstdp[Id_Machine].LastEndTime + SetupTime;  //스타트 타임을 셋업 발생시 더해주는 개념
                        EndTime = StartTime + ProcessingTime;
                        //9. cr 계산은 듀타임 -현재시간을 작업시간으로 나눈 비율임
                        cr = Math.Round(Convert.ToDouble((dt[i].DueTime - StartTime) / ProcessingTime), 2);

                        Violation = EndTime - DueDate;
                        if (Violation < 0)
                            Violation = 0;

                        //10. 선정된 머신마다 모든 잡을 할당하고 slack이 가장 낮은 것을 할당함
                        lstMPTPair.Add(new Tuple<double, ScheduleModel>(cr, new ScheduleModel(Id_Lot, Id_Machine, JobType, ProcessingTime, StartTime, EndTime, DueDate, isSetup, Violation, SetupTime)));
                        test = lstMPTPair;
                    }
                    DiclstMPTPair.Add(dis.Id_Machine, test);
                }



                Dictionary<int, Tuple<double, ScheduleModel>> sss = new Dictionary<int, Tuple<double, ScheduleModel>>();

                Dictionary<int, Tuple<double, ScheduleModel>> sssYes = new Dictionary<int, Tuple<double, ScheduleModel>>();
                foreach (KeyValuePair<int, List<Tuple<double, ScheduleModel>>> pair in DiclstMPTPair)
                {
                    List<Tuple<double, ScheduleModel>> Nosetup = new List<Tuple<double, ScheduleModel>>();

                    List<Tuple<double, ScheduleModel>> Yessetup = new List<Tuple<double, ScheduleModel>>();

                    foreach (Tuple<double, ScheduleModel> aaa in pair.Value)
                    {
                        if ((lstdp[pair.Key].LastJob.Equals(aaa.Item2.JobType)))
                        {
                            Nosetup.Add(aaa);
                        }
                        else
                        {
                            Yessetup.Add(aaa);
                        }
                    }

                    //List<Tuple<int, ScheduleModel>> copy = pair.Value.OrderBy(x => x.Item1).ToList();

                    //sss.Add(pair.Key, copy[0]);
                    if (Nosetup.Count != 0)
                    {
                        Nosetup = Nosetup.OrderBy(x => x.Item1).ToList();
                        sss.Add(pair.Key, Nosetup[0]);
                    }
                    else
                    {
                        Yessetup = Yessetup.OrderBy(x => x.Item1).ToList();
                        sssYes.Add(pair.Key, Yessetup[0]);
                    }


                }


                sss = sss.OrderBy(x => x.Value.Item2.EndTime).ToDictionary(p => p.Key, p => p.Value);
                sssYes = sssYes.OrderBy(x => x.Value.Item2.EndTime).ToDictionary(p => p.Key, p => p.Value);

                if (sss.Count > 0 && sssYes.Count > 0 && lstdp[sssYes.Keys.ElementAt(0)].LastEndTime <= lstdp[sss.Keys.ElementAt(0)].LastEndTime)
                {
                    lstdp[sssYes.Keys.ElementAt(0)].LastEndTime = sssYes.Values.ElementAt(0).Item2.EndTime;
                    lstdp[sssYes.Keys.ElementAt(0)].LastJob = sssYes.Values.ElementAt(0).Item2.JobType;
                    lstDispatching.Add(GeneralFunc.GetScheduleToString(sssYes.Values.ElementAt(0).Item2));

                    dt.Remove(dt.Find(x => x.ID_Lot == sssYes.Values.ElementAt(0).Item2.ID_LOT));
                }
                else if (sss.Count > 0 && sssYes.Count > 0 && lstdp[sssYes.Keys.ElementAt(0)].LastEndTime >= lstdp[sss.Keys.ElementAt(0)].LastEndTime)
                {
                    lstdp[sss.Keys.ElementAt(0)].LastEndTime = sss.Values.ElementAt(0).Item2.EndTime;
                    lstdp[sss.Keys.ElementAt(0)].LastJob = sss.Values.ElementAt(0).Item2.JobType;
                    lstDispatching.Add(GeneralFunc.GetScheduleToString(sss.Values.ElementAt(0).Item2));

                    dt.Remove(dt.Find(x => x.ID_Lot == sss.Values.ElementAt(0).Item2.ID_LOT));

                }
                else if (sss.Count() != 0 && sssYes.Count == 0)
                {
                    sss = sss.OrderBy(x => x.Value.Item2.EndTime).ToDictionary(p => p.Key, p => p.Value);


                    //lstMPTPair = lstMPTPair.OrderBy(x => x.Item1).ToList();
                    lstdp[sss.Keys.ElementAt(0)].LastEndTime = sss.Values.ElementAt(0).Item2.EndTime;
                    lstdp[sss.Keys.ElementAt(0)].LastJob = sss.Values.ElementAt(0).Item2.JobType;
                    lstDispatching.Add(GeneralFunc.GetScheduleToString(sss.Values.ElementAt(0).Item2));

                    dt.Remove(dt.Find(x => x.ID_Lot == sss.Values.ElementAt(0).Item2.ID_LOT));
                }
                else
                {
                    sssYes = sssYes.OrderBy(x => x.Value.Item2.EndTime).ToDictionary(p => p.Key, p => p.Value);


                    //lstMPTPair = lstMPTPair.OrderBy(x => x.Item1).ToList();
                    lstdp[sssYes.Keys.ElementAt(0)].LastEndTime = sssYes.Values.ElementAt(0).Item2.EndTime;
                    lstdp[sssYes.Keys.ElementAt(0)].LastJob = sssYes.Values.ElementAt(0).Item2.JobType;
                    lstDispatching.Add(GeneralFunc.GetScheduleToString(sssYes.Values.ElementAt(0).Item2));

                    dt.Remove(dt.Find(x => x.ID_Lot == sssYes.Values.ElementAt(0).Item2.ID_LOT));
                }
            }


            return lstDispatching;
        }

        public static List<string> HASA(int machineNumber, DataTable data, Problem pr)
        {
            List<JobModel> dt = new List<JobModel>();
            float TargetValue = 0;

            for (int i = 0; i < data.Rows.Count; i++)
                dt.Add(new JobModel(i, data.Rows[i][1].ToString(), Convert.ToInt32(data.Rows[i][2].ToString()), Convert.ToInt32(data.Rows[i][3].ToString())));

            int[,] matrix = new int[dt.Count, machineNumber];
            int[,] defaultProceesing = new int[dt.Count, machineNumber];
            int[] Min_Time = new int[dt.Count];
            int[] Min_Index = new int[dt.Count];
            List<string> lstDispatching = new List<string>();
            lstDispatching.Add(machineNumber + ",,,,,,,,,");
            List<DispatchingModel> lstdp = new List<DispatchingModel>();
            for (int i = 0; i < machineNumber; i++)
                lstdp.Add(new DispatchingModel(i, 0, string.Empty));
            for (int i = 0; i < dt.Count; i++)
            {
                string JobType = dt[i].JobType;
                int ProcessingTime = Convert.ToInt32(dt[i].Quantity);
                for (int j = 0; j < lstdp.Count; j++)
                {
                    matrix[i, j] = ProcessingTime * pr.Dic_JobType_Setting[JobType].ProcessTime_Machine[lstdp[j].Id_Machine];
                    defaultProceesing[i, j] = ProcessingTime * pr.Dic_JobType_Setting[JobType].ProcessTime_Machine[lstdp[j].Id_Machine];
                    
                }
                
            }
        for (int j=0; j< dt.Count; j++)
         {
                
              //  int Lotindex = 0;
            for (int i = 0; i < dt.Count; i++)
            {
                int[] MinValue = new int[machineNumber];
                int ArraySize = sizeof(int) * machineNumber;
                System.Buffer.BlockCopy(matrix, i * ArraySize, MinValue, 0, ArraySize);
                    
                Min_Index[i] = Maths.MinIndex(MinValue);                                 
                 Min_Time[i] = MinValue[Min_Index[i]];
                    
                
                 
            }

            float AverageValue = Maths.Average(Min_Time,dt.Count);
            TargetValue = (float)AverageValue / 2;
            int ValueIndex = Maths.Near(Min_Time, TargetValue);
            int Machineindex = Min_Index[ValueIndex];
            DispatchingModel dispatchingModel = lstdp[Machineindex];
                int Id_Machine = Machineindex;
                string JobType = dt[ValueIndex].JobType;
                int Id_Lot = dt[ValueIndex].ID_Lot;
                int ProcessingTime = defaultProceesing[ValueIndex,Machineindex];
                int StartTime = dispatchingModel.LastEndTime;
                int EndTime = StartTime + ProcessingTime;
                int DueDate = dt[ValueIndex].DueTime;
                int isSetup = 0;
                int Violation = EndTime - DueDate;
                if (Violation < 0)
                    Violation = 0;
                int SetupTime = 0;
                dispatchingModel.LastEndTime = StartTime + ProcessingTime;
                for (int i=0; i< lstdp.Count; i++)
                {
                    matrix[ValueIndex,i] = Int32.MaxValue;
                    
                }
                for(int i=0; i< dt.Count; i++)
                {

                    if (i != ValueIndex) {
                        if (matrix[i, Machineindex] != Int32.MaxValue)
                        {
                            matrix[i, Machineindex] = matrix[i, Machineindex] + ProcessingTime;
                        }
                }
}
                lstDispatching.Add(Id_Lot + "," + Id_Machine + "," + JobType + "," + ProcessingTime + "," + StartTime + "," + EndTime + "," + DueDate + "," + isSetup + "," + Violation + "," + SetupTime);
            }
            return lstDispatching;
        }

    }

}
