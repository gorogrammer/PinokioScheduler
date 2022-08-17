using PINOKIO_SCHEDULER.Definitions;
using PINOKIO_SCHEDULER.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string ToPY_GetMachine_LastTime(string msg, Dictionary<string, ScheduleLog> log)
        {
            if (!msg.Contains("\n"))
                return "syntax Error";
            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);

            string returnString = string.Empty;
            returnString = "LAST TIME : "+log[split[0]].LastTime.ToString() + STR.ENTER;
            returnString += "JOB COUNT : " + log[split[0]].JobCount.ToString() + STR.ENTER;
            returnString += "SET UP TIME COUNT : " + log[split[0]].SetUpTimeCount.ToString() + STR.ENTER;
            returnString += "Operating RATIO : " + log[split[0]].Operatingratio.ToString() + STR.ENTER;
            returnString += "WORKING TIME : " + log[split[0]].WorkingTime.ToString() + STR.ENTER;
            returnString += "DUETIME COUNT : " + log[split[0]].DueDateDic.Count().ToString() + STR.ENTER;

            return returnString;
        }
        public static string FromPY_SetScheduleSingle(string msg, int TotalMachineNumber, DataTable data, List<ScheduleModel> lstSchedule, out ScheduleModel ScheduledModel)
        {
            ScheduledModel = null;
            string returnString = string.Empty;

            if (!msg.Contains("\n"))
                return "syntax Error";

            string[] split = msg.Split(STR.ENTER)[1].Split(STR.COMMA);

            var resultRow = data.AsEnumerable().Where(myRow => myRow[0].ToString() == split[0] && myRow[1].ToString() == split[2]);

            //사용자가 보낸 작업이 JOB DT에 있는지 확인해줌
            if (resultRow.Count() < 1)
                return "No JobName in JobTable";

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

    }
}
