using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINOKIO_SCHEDULER.Model
{
    public class StatesModel
    {
        public StatesModel(int machineNumber, Enum machineState, int completedBox, int setupTime, int processingTime, int totalWorkTime, List<string> jobList, List<string> endJoblist,int idletime)
        {
            MachineNumber = machineNumber;
            stateName = machineState;
            CompletedBox = completedBox;
            SetupTime = setupTime;
            ProcessingTime = processingTime;
            TotalWorkTime = totalWorkTime;
            JobName = jobList;
            EndJob = endJoblist;
            IdleTime = idletime;
        }

        public int ProcessingTime { get; set; }
        public int TotalWorkTime { get; set; }
        public int SetupTime { get; set; }
        public int IdleTime { get; set; }
        public List<string> JobName { get; set; }
        public List<string> EndJob { get; set; }

        public double Uitility_Timed
        {
            get { return (double)ProcessingTime / TotalWorkTime * 100; }
        }

        public int WorkingTime
        {
            get { return TotalWorkTime - SetupTime; }
        }

        public int MachineNumber { get; set; }
        private Enum stateName;

        public Enum MachineState
        {
            get { return stateName; }
            set { stateName = value; }
        }

        public int CompletedBox { get; set; }

    }
}
