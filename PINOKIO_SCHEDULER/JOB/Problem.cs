using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINOKIO_SCHEDULER.JOB
{
    public class Problem
    {
   
        public int Machine_Count
        {
            get; set;
        }
        public int SetUp
        {
            get; set;
        }

        public int Processing
        {
            get; set;
        }

        public int Job_Type_Count
        {
            get; set;
        }
        public Dictionary<string,Job_Setting_Value> Dic_JobType_Setting
        {
            get; set;
        }

        public Problem()
        {
            Dic_JobType_Setting = new Dictionary<string, Job_Setting_Value>();
        }
    }

    public class Job_Setting_Value
    {
        public string TYPE
        {
            get; set;
        }

        public Dictionary<int,int> ProcessTime_Machine
        {
            get; set;
        }

        public int SetUp_Time
        {
            get; set;
        }

        public Job_Setting_Value()
        {
            ProcessTime_Machine = new Dictionary<int, int>();
        }
    }
}
