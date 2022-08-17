using PINOKIO_SCHEDULER.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINOKIO_SCHEDULER
{
    public class MachineNode
    {
        private int id = 0;
        private string name;
        private string label_text;
        private List<double> position_box;
        private List<double> position_boxlabel;
        private Enum stateName;
        private int boxCount;
        private int workCount;
        private double totalworkTime;
        private double totalsetupTime;
        private double totalIdleTime;
        private int currIndex;
        private double _util;
        private int makeSpan;

        public Dictionary<int, ScheduleModel> startjob = new Dictionary<int, ScheduleModel>();
        public Dictionary<int, ScheduleModel> workingJob = new Dictionary<int, ScheduleModel>();
        public Dictionary<int, ScheduleModel> endJob = new Dictionary<int, ScheduleModel>();
        public Dictionary<int, ScheduleModel> endJobOff = new Dictionary<int, ScheduleModel>();
        public Dictionary<string, ScheduleModel> dueDateJob = new Dictionary<string, ScheduleModel>();
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int CurIndex
        {
            get { return currIndex; }
            set { currIndex = value; }
        }
        public int MakeSpan
        {
            get {
                int endTime = 0;
                makeSpan = this.endJob.Keys.ToList()[endJob.Count - 1];
                
                
                return makeSpan; }
        
        }

        public int  TotalViolation
        {
            get{
                int totalTime = 0;
                foreach(KeyValuePair<string,ScheduleModel> pair in DueDateJob)
                {
                    totalTime += pair.Value.Violation;
                }


                return totalTime;

            }
        }


        public int BoxCount
        {
            get { return boxCount; }
            set { boxCount = value; }
        }
        public int WorkCount
        {
            get { return workCount; }
            set { workCount = value; }
        }
        public double TotalworkTime
        {
            get { return totalworkTime; }
            set { totalworkTime = value; }
        }

        public double Util
        {
            get
            {
                return _util;
            }
            set { _util = value; }
        }
        public double TotalsetupTime
        {
            get { return totalsetupTime; }
            set { totalsetupTime = value; }
        }

        public double TotalIdleTime
        {
            get { return totalIdleTime; }
            set { totalIdleTime = value; }
        }
        public Dictionary<int, ScheduleModel> WorkingJob
        {
            get { return workingJob; }
            set { workingJob = value; }
        }

        public Dictionary<int, ScheduleModel> Startjob
        {
            get { return startjob; }
            set { startjob = value; }
        }
        public Dictionary<int, ScheduleModel> EndJob
        {
            get { return endJob; }
            set { endJob = value; }
        }

        public Dictionary<string, ScheduleModel> DueDateJob
        {
            get { return dueDateJob; }
            set { dueDateJob = value; }
        }


        public Dictionary<int, ScheduleModel> EndJobOff
        {
            get { return endJobOff; }
            set { endJobOff = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Label_text
        {
            get { return label_text; }
            set { label_text = value; }
        }

        public List<double> Position_box
        {
            get { return position_box; }
            set { position_box = value; }
        }
        public List<double> Position_boxlabel
        {
            get { return position_boxlabel; }
            set { position_boxlabel = value; }
        }


        public Enum MachineState
        {
            get { return stateName; }
            set { stateName = value; }
        }

        


        public MachineNode(int boxiD, List<double> pos_box)

        {
            _util = 0;
            BoxCount = 0;
            WorkCount = 0;
            TotalIdleTime = 0;
            TotalworkTime = 1;
            TotalsetupTime = 0;
            ID = boxiD;
            currIndex = 0;
            Name = "M" + ID.ToString() ;

            Position_box = pos_box;
            
            Label_text = Name;
            MachineState = MACHINE_STATE.IDLE;
            ID++;
        }


    }
}
