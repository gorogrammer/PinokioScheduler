using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINOKIO_SCHEDULER.Model
{
    public class JobModel
    {
        public int ID_Lot { get; set; }
        public string JobType { get; set; }
        public int Quantity { get; set; }
        public int DueTime { get; set; }

        public JobModel(int iD_Lot, string jobType, int processingTime, int dueTime)
        {
            ID_Lot = iD_Lot;
            JobType = jobType;
            Quantity = processingTime;
            DueTime = dueTime;
        }

    }
}
