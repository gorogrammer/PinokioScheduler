using PINOKIO_SCHEDULER.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using devDept.Geometry;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Graphics;
using devDept.Eyeshot.Labels;


namespace PINOKIO_SCHEDULER.Nodes
{
    public class JobBoxNode
    {
        private int id = 0;
        private string name;
        private string label_text;
        private List<double> position_JobBox;
        private List<double> position_JobBoxlabel;
        private Enum stateName;
        private int startTime;
        private int processTime;
        private int endTime;
        private int dueDateTime;
        private string jobType;
        private int jobLot;
        private bool visible;

        private ScheduleModel scheduleData;
        private Entity jobBoxEntity;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Entity JobBoxEntity
        {
            get { return jobBoxEntity; }
            set { jobBoxEntity = value; }
        }


        public ScheduleModel ScheduleData
        {
            get { return scheduleData; }
            set { scheduleData = value; }
        }

        public int StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        public int ProcessTime
        {
            get { return processTime; }
            set { processTime = value; }
        }
        public int EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        public int DueDateTime
        {
            get { return dueDateTime; }
            set { dueDateTime = value; }
        }

        public string JobType
        {
            get { return jobType; }
            set { jobType = value; }
        }

        public int JobLot
        {
            get { return jobLot; }
            set { jobLot = value; }
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

        public List<double> Position_JobBox
        {
            get { return position_JobBox; }
            set { position_JobBox = value; }
        }
        public List<double> Position_JobBoxlabel
        {
            get { return position_JobBoxlabel; }
            set { position_JobBoxlabel = value; }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public JobBoxNode(int jobBoxID, List<double> pos_box)

        {
            StartTime = 0;
            EndTime = 0;
            ProcessTime = 0;
            DueDateTime = 0;
           
            ID = jobBoxID;
            Name = jobType + jobLot.ToString();

            Position_JobBox = pos_box;

            Label_text = Name;

        }
        public JobBoxNode()
        {
           
        }


    }
}
