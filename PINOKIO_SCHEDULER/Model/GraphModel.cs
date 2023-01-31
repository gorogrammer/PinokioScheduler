using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINOKIO_SCHEDULER.Model
{

    public class TimeGrapgh
    {
        int _tardyAccum = 0;
        public int TardyAccum
        {
            get { return _tardyAccum; }
            set { _tardyAccum = value; }

        }
        public int TimeIndex { get; set; }
        public int TardySum { get; set; }
        public int SetUpSum { get; set; }
        public int TardyCount { get; set; }

        public TimeGrapgh(int time, int tardysum, int tardycount, int setupSum)
        {
            TimeIndex = time;
            TardySum = tardysum;
            TardyCount = tardycount;
            SetUpSum = setupSum;
        }
    }
    public class GraphModel
    {
        public int Stepindex { get; set; }
        public int TardySum { get; set; }
        public int SetUpSum { get; set; }
        public int MaxTime { get; set; }

        public List<int> lstTardy;

        public List<int> lstSetup;

        public List<MachineUtilities> lstMachineUtilities { get; set; }
        //수정 필요
        public GraphModel(int stepindex, ScheduleModel schedule)
        {
            lstMachineUtilities = new List<MachineUtilities>();
            lstTardy = new List<int>();
            lstSetup = new List<int>();

            Stepindex = stepindex;

            TardySum = schedule.Violation;

            if (schedule.Setup !=0)
                SetUpSum += schedule.Setup;

            MaxTime = schedule.EndTime;

            lstMachineUtilities.Add(new MachineUtilities(schedule.ID_Machine, schedule.ProcessingTime, SetUpSum, schedule.EndTime, schedule.EndTime));
            lstTardy.Add(TardySum);
            lstSetup.Add(SetUpSum);
        }

        public GraphModel GetAccumulatedGraphModel(ScheduleModel schedule)
        {
            GraphModel model = new GraphModel(Stepindex+1, schedule);
            model.TardySum = model.TardySum+ this.TardySum;
            model.SetUpSum = model.SetUpSum + this.SetUpSum;

            model.lstTardy = new List<int>();
            model.lstSetup = new List<int>();

            foreach (int tar in lstTardy)
                model.lstTardy.Add(tar);

            foreach (int set in lstSetup)
                model.lstSetup.Add(set);

            model.lstTardy.Add(model.TardySum);
            model.lstSetup.Add(model.SetUpSum);


            if (model.MaxTime == 37)
                ;

            if (model.MaxTime == 39)
                ;

            if (this.MaxTime == 39)
                ;

            if (this.MaxTime == 37)
                ;
            if (model.MaxTime < this.MaxTime)
                model.MaxTime = this.MaxTime;

            MachineUtilities lastUtil = model.lstMachineUtilities[0];
            model.lstMachineUtilities = new List<MachineUtilities>();
            foreach (MachineUtilities utiles in this.lstMachineUtilities)
                model.lstMachineUtilities.Add(new MachineUtilities(utiles.MachineIndex, utiles.WorkingTime, utiles.SetupTime, schedule.EndTime, model.MaxTime));

            MachineUtilities util = model.lstMachineUtilities.Find(x => x.MachineIndex.Equals(schedule.ID_Machine));

            if (util != null)
            {
                util.WorkingTime = util.WorkingTime + schedule.ProcessingTime;
                util.SetupTime = util.SetupTime + model.SetUpSum;
                util.LastEndTime_Pure = schedule.EndTime;
                util.LastEndTime_Stepped = model.MaxTime;
            }
            else
            {
                model.lstMachineUtilities.Add(new MachineUtilities(schedule.ID_Machine, schedule.ProcessingTime, model.SetUpSum, schedule.EndTime, model.MaxTime));
            }

            return model;
        }

    }

    public class MachineUtilities
    {
        public int MachineIndex { get; set; }
        public int WorkingTime { get; set; }
        public int SetupTime { get; set; }
        public int LastEndTime_Pure { get; set; }
        public int LastEndTime_Stepped { get; set; }

        public MachineUtilities(int machineIndex, int workingTime, int setupTime, int lastEndTime, int lastEndTime_Stepped)
        {
            MachineIndex = machineIndex;
            WorkingTime = workingTime;
            SetupTime = setupTime;
            LastEndTime_Pure = lastEndTime;
            LastEndTime_Stepped = lastEndTime_Stepped;
        }

        public double Uitility_Pure
        {
            get { return (double) WorkingTime / LastEndTime_Pure * 100; }
        }

        public double Uitility_CurrenetRuned
        {
            get { return (double)WorkingTime / LastEndTime_Stepped * 100; }
        }

    }
}
