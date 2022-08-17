using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINOKIO_SCHEDULER.Model
{
    public class ScheduleModel
    {
        public int ID_LOT { get; set; }
        public int ID_Machine { get; set; }
        public string JobType { get; set; }
        public int ProcessingTime { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int DueTime { get; set; }
        public int Setup { get; set; }
        public int Violation { get; set; }
        public int SetUpTime { get; set; }
        public int Quantity { get; set; }

        //public ScheduleModel(int iD_LOT, int iD_Machine, string jobType, int processingTime, int startTime, int endTime, int dueTime, bool setup, int violation,int setuptime)
        //{
        //    ID_LOT = iD_LOT;
        //    ID_Machine = iD_Machine;
        //    JobType = jobType;
        //    ProcessingTime = processingTime;
        //    StartTime = startTime;
        //    EndTime = endTime;
        //    DueTime = dueTime;
        //    Setup = setup;
        //    Violation = violation;
        //    SetUpTime = setuptime;
        //}
        public ScheduleModel(int iD_LOT, int iD_Machine, string jobType, int processingTime, int startTime, int endTime, int dueTime, int setup, int violation, int setuptime)
        {
            ID_LOT = iD_LOT;
            ID_Machine = iD_Machine;
            JobType = jobType;
            ProcessingTime = processingTime;
            StartTime = startTime;
            EndTime = endTime;
            DueTime = dueTime;
            Setup = setup;
            Violation = violation;
            SetUpTime = setuptime;
           // Quantity = quant;
        }
    }
}
