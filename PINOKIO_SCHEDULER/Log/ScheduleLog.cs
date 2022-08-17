using PINOKIO_SCHEDULER.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINOKIO_SCHEDULER
{
    public class RemainJob
    {
        public string Job { get; set; }

        public int RemainCount { get; set; }

    }
    public class ScheduleLog
    {
        public MainForm_Ribbon Main;
        int machineNO;
        int lastTime;
        List<ScheduleModel> ScheduleList = new List<ScheduleModel>();
        List<string> JobList = new List<string>();
        int setuptime;
        int setuptimecount;
        int idletime;
        int workingtime;
        double operatingratio;
        Dictionary<string, int> dueDateDic; 

        public string DueDateList
        {

            get {
                StringBuilder sd = new StringBuilder();
            
                if(DueDateDic.Count>0)
                {
                    
                    foreach (KeyValuePair<string,int> pair in DueDateDic)
                    {
                       
                        if (sd.Length<3)
                            sd.Append("["+pair.Key+","+pair.Value.ToString()+"]");
                        else
                            sd.Append(", [" + pair.Key + "," + pair.Value.ToString() + "]");
                    }
                }
                else
                {
                    sd.Append("None");
                }

                return sd.ToString();
            
            
            }
        }
        public int SetUpTime
        {
            get { return setuptimecount*2; }


        }
        public double Operatingratio
        {
            get { return (double)WorkingTime / LastTime * 100; }


        }
        public Dictionary<string,int> DueDateDic
        {
            get { return dueDateDic; }
            set { dueDateDic = value; }

        }
        public int JobCount
        {
            get { return JobList.Count; }
        }

        public int WorkingTime
        {
            get { return workingtime; }
            set { workingtime = value; }

        }

     

        public int MachineNo
        { get { return machineNO; } }


        public string Name { get { return "M" + MachineNo; } }

        //public int JobCount { get { return JobList.Count; } }

        public int LastTime { get; set; } 

        public int SetUpTimeCount { get { return setuptimecount; } }
    
        public int IdleTime { get { return idletime; } }
        public int CalLastTime(List<ScheduleModel> list)
        {
            int _last = 0;
            foreach(ScheduleModel sd in list)
            {
                _last = sd.ProcessingTime + _last;

            }
            _last = _last + setuptime;
            return _last;
        }
        public ScheduleLog(ScheduleModel jl )
        {
            machineNO = jl.ID_Machine;
            setuptimecount = 0;
            LastTime = 0;
            setuptime = 0;
            workingtime = 0;
            dueDateDic = new Dictionary<string, int>();
            if (!ScheduleList.Contains(jl))
                ScheduleList.Add(jl);


            GetInfo(ScheduleList);
        }
        public void GetInfo(List<ScheduleModel> ScheduleList)
        {
            string jobname = string.Empty;
            foreach (ScheduleModel model in ScheduleList)
            {
                jobname = model.JobType + model.ID_LOT;
                LastTime +=model.ProcessingTime;
                workingtime +=model.ProcessingTime;
                if (model.Setup !=0)
                {
                    LastTime += 2;
                    setuptime += 2;
                    setuptimecount++;
                }
                if (!JobList.Contains(jobname))
                    JobList.Add(jobname);

                if(model.EndTime > model.DueTime)
                {
                    dueDateDic.Add(jobname, model.EndTime - model.DueTime);
                }
            }

        }
        public void UpdateLog(ScheduleModel model)
        {
            string jobname = model.JobType + model.ID_LOT;
            LastTime += model.ProcessingTime;
            workingtime += model.ProcessingTime;
            if (model.Setup!=0)
            {
                LastTime += 2;
                setuptime += 2;
                setuptimecount++;
            }

            if (!JobList.Contains(jobname))
                JobList.Add(jobname);

            if (model.EndTime > model.DueTime)
            {
                if(!dueDateDic.ContainsKey(jobname))
                    dueDateDic.Add(jobname, model.EndTime - model.DueTime);
            }
        }

        public void DeleteLog(ScheduleModel model)
        {
            string jobname = model.JobType + model.ID_LOT;
            LastTime -= model.ProcessingTime;
            workingtime -= model.ProcessingTime;
            if (model.Setup!=0)
            {
                LastTime -= 2;
                setuptime -= 2;
                setuptimecount--;
            }

            if (JobList.Contains(jobname))
                JobList.Remove(jobname);

            if (model.EndTime > model.DueTime)
            {
                if (dueDateDic.ContainsKey(jobname))
                    dueDateDic.Remove(jobname);
            }
        }
    }
}
