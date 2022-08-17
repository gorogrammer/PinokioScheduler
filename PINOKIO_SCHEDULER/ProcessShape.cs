using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using devDept.Geometry;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot;
using PINOKIO_SCHEDULER.Definitions;
using devDept.Eyeshot.Labels;

namespace PINOKIO_SCHEDULER
{
    public class ProcessShape 
    {
        public ProcessShape()
        {
            
        }

        public Block CreateMachine()
        {
        

            Block BoxBlock = new Block("Machine");
            Mesh bodyMain = Createbolck.CreateBox(1000, 814.81, 765.96, "WhiteMetal", new Vector3D(0, 185.19, 21.28));
            BoxBlock.Entities.Add(bodyMain);

            

            Mesh bodyBottom = Createbolck.CreateBox(1000, 814.81, 21.27, "Metal3", new Vector3D(0, 185.19, 0));
            BoxBlock.Entities.Add(bodyBottom);

            Mesh bodyTop = Createbolck.CreateBox(1000, 814.81, 42.55, "Blackrubber", new Vector3D(0, 185.19, 787.23));
            BoxBlock.Entities.Add(bodyTop);

            Mesh alarmBase = Createbolck.CreateCylinder(18.51, 42.55, Color.DarkGray, new Vector3D(46.51, 259.26, 829.79));
            BoxBlock.Entities.Add(alarmBase);

            Mesh alarmGreen = Createbolck.CreateCylinder(18.51, 42.55, Color.Green, new Vector3D(46.51, 259.26, 872.34));
            BoxBlock.Entities.Add(alarmGreen);

            Mesh alarmOrange = Createbolck.CreateCylinder(18.51, 42.55, Color.DarkOrange, new Vector3D(46.51, 259.26, 914.89));
            BoxBlock.Entities.Add(alarmOrange);

            Mesh alarmRed = Createbolck.CreateCylinder(18.51, 42.55, Color.Red, new Vector3D(46.51, 259.26, 957.45));
            BoxBlock.Entities.Add(alarmRed);

            Mesh boxDisplay = Createbolck.CreateBox(186, 18.51, 150, "Display", new Vector3D(790.7, 181.48, 553.19));
            BoxBlock.Entities.Add(boxDisplay);

            Mesh boxGlass = Createbolck.CreateBox(534.88, 18.51, 425.53, "Glass", new Vector3D(116.28, 181.48, 297.87));
            BoxBlock.Entities.Add(boxGlass);

            Mesh keybox = Createbolck.CreateBox(186, 185.18, 42.55, "WhiteMetal", new Vector3D(790.7, 0, 340.42));
            BoxBlock.Entities.Add(keybox);

            Mesh keyboard = Createbolck.CreateBox(139.53, 111.11, 10, "Keyboard", new Vector3D(813.95, 18.52, 382.98));
            BoxBlock.Entities.Add(keyboard);


            Mesh stateMesh = Createbolck.CreateCylinder(100, 300, Color.Yellow, new Vector3D(80, 80, 914.89));
            BoxBlock.Entities.Add(stateMesh);


            return BoxBlock;
        }
        public Block CreateMachine3DS_node(MachineShape bs, MachineNode boxnode, Entity [] es)
        {
            bs.CoreNode = boxnode;
            Block BoxBlock = new Block(boxnode.Name);
            foreach(Entity sd in es)
            {
                BoxBlock.Entities.Add(sd);
            }

            //Text tt = new Text(500 / 8, -3300 / 8, 500 / 8, "Ready", 100);
         
            //tt.Color = Color.Black;

            //BoxBlock.Entities.Add(tt);


            devDept.Eyeshot.Entities.Attribute stateName = new devDept.Eyeshot.Entities.Attribute(0, 0, 0, "att0", "Ready", 120);
            stateName.Alignment = devDept.Eyeshot.Entities.Text.alignmentType.BaselineRight;
            stateName.TransformBy(new Translation(500 / 8, -3300 / 8, 500 / 8));
            stateName.ColorMethod = colorMethodType.byEntity;
            stateName.Color = Color.Red;
      
            BoxBlock.Entities.Add(stateName);

            Mesh workingJobBox = Createbolck.CreateBox(500/8, 400/8, 300/8, Color.Black, new Vector3D(500/8, 400/8, 2000/8));
            //workingJobBox.Translate(boxnode.Position_box[0] + 500/8, boxnode.Position_box[1] + 500/8, boxnode.Position_box[2] + 2000/8);
            workingJobBox.Visible = false;
            BoxBlock.Entities.Add(workingJobBox);

            Mesh outJobBox = Createbolck.CreateBox(500 / 8, 400 / 8, 300 / 8, Color.Black, new Vector3D(4500/8, 400 / 8, 0));
            //workingJobBox.Translate(boxnode.Position_box[0] + 500/8, boxnode.Position_box[1] + 500/8, boxnode.Position_box[2] + 2000/8);
            outJobBox.Visible = false;
            BoxBlock.Entities.Add(outJobBox);

            Mesh Bottom_State = Createbolck.CreateBox(6800 / 8, 3000 / 8, 8/ 8,Color.GhostWhite, new Vector3D(-175, -160, -1));
            BoxBlock.Entities.Add(Bottom_State);

            Mesh Bottom = Createbolck.CreateBox(7220 / 8, 3340/8, 8/8, "Warnig", new Vector3D(-200, -180, -1.5));
            BoxBlock.Entities.Add(Bottom);


            Mesh ds = Createbolck.CreateBox(5000 / 8, 8 / 8, 5300 / 8, Color.Black, new Vector3D(8000 / 8, 10/ 8, 0));
            ds.ColorMethod = colorMethodType.byEntity;
            ds.Color = Color.Navy;
            //BoxBlock.Entities.Add(ds);
            //ds.Visible = false;
            devDept.Eyeshot.Entities.Attribute a1 = new devDept.Eyeshot.Entities.Attribute(0, 0, 0, "att1", "Top Text", 60);
            a1.Alignment = devDept.Eyeshot.Entities.Text.alignmentType.TopLeft;
            a1.TransformBy(new Translation(8000 / 8, 0, 5000/8) * new Rotation(Math.PI / 2, Vector3D.AxisX));
            a1.ColorMethod = colorMethodType.byEntity;
            a1.Color = Color.Red;

            devDept.Eyeshot.Entities.Attribute a2 = new devDept.Eyeshot.Entities.Attribute(0, 0, 0, "att2", "Top Text", 60);
            a2.Alignment = devDept.Eyeshot.Entities.Text.alignmentType.TopLeft;
            a2.TransformBy(new Translation(8000 / 8, 0, 4000 / 8) * new Rotation(Math.PI / 2, Vector3D.AxisX));
            a2.ColorMethod = colorMethodType.byEntity;
            a2.Color = Color.Navy;

            devDept.Eyeshot.Entities.Attribute a3 = new devDept.Eyeshot.Entities.Attribute(0, 0, 0, "att3", "Top Text", 60);
            a3.Alignment = devDept.Eyeshot.Entities.Text.alignmentType.TopLeft;
            a3.TransformBy(new Translation(8000 / 8, 0, 3000 / 8) * new Rotation(Math.PI / 2, Vector3D.AxisX));
            a3.ColorMethod = colorMethodType.byEntity;
            a3.Color = Color.Navy;
            devDept.Eyeshot.Entities.Attribute a4 = new devDept.Eyeshot.Entities.Attribute(0, 0, 0, "att4", "Top Text", 60);
            a4.Alignment = devDept.Eyeshot.Entities.Text.alignmentType.TopLeft;
            a4.TransformBy(new Translation(8000 / 8, 0, 2000 / 8) * new Rotation(Math.PI / 2, Vector3D.AxisX));
            a4.ColorMethod = colorMethodType.byEntity;
            a4.Color = Color.Navy;
            devDept.Eyeshot.Entities.Attribute a5 = new devDept.Eyeshot.Entities.Attribute(0, 0, 0, "att5", "Top Text", 60);
            a5.Alignment = devDept.Eyeshot.Entities.Text.alignmentType.TopLeft;
            a5.TransformBy(new Translation(8000 / 8, 0, 1000 / 8) * new Rotation(Math.PI / 2, Vector3D.AxisX));
            a5.ColorMethod = colorMethodType.byEntity;
            a5.Color = Color.Navy;
            //a1.Visible = false;
            //a2.Visible = false;
            //a3.Visible = false;
            //a4.Visible = false;
            //a5.Visible = false;

            BoxBlock.Entities.Add(a1);
            BoxBlock.Entities.Add(a2);
            BoxBlock.Entities.Add(a3);
            BoxBlock.Entities.Add(a4);
            BoxBlock.Entities.Add(a5);

            bs.StateMesh = Bottom_State;
            bs.JobMesh = workingJobBox;
            bs.OutJobMesh = outJobBox;
            bs.LabelBox = ds;
            //bs.StateName = tt;



            return BoxBlock;

        }
        public Block CreateMachine_node(MachineShape bs,MachineNode boxnode)
        {
            bs.CoreNode = boxnode ;

            Block BoxBlock = new Block(boxnode.Name);
            Mesh bodyMain = Createbolck.CreateBox(1000, 814.81, 765.96, "WhiteMetal", new Vector3D(0, 185.19, 21.28));
            BoxBlock.Entities.Add(bodyMain);


            Mesh bodyBottom = Createbolck.CreateBox(1000, 814.81, 21.27, "Metal3", new Vector3D(0, 185.19, 0));
            BoxBlock.Entities.Add(bodyBottom);

            Mesh bodyTop = Createbolck.CreateBox(1000, 814.81, 42.55, "Blackrubber", new Vector3D(0, 185.19, 787.23));
            BoxBlock.Entities.Add(bodyTop);

            Mesh alarmBase = Createbolck.CreateCylinder(18.51, 42.55, Color.DarkGray, new Vector3D(46.51, 259.26, 829.79));
            BoxBlock.Entities.Add(alarmBase);

            Mesh alarmGreen = Createbolck.CreateCylinder(18.51, 42.55, Color.Green, new Vector3D(46.51, 259.26, 872.34));
            BoxBlock.Entities.Add(alarmGreen);

            Mesh alarmOrange = Createbolck.CreateCylinder(18.51, 42.55, Color.DarkOrange, new Vector3D(46.51, 259.26, 914.89));
            BoxBlock.Entities.Add(alarmOrange);

            Mesh alarmRed = Createbolck.CreateCylinder(18.51, 42.55, Color.Red, new Vector3D(46.51, 259.26, 957.45));
            BoxBlock.Entities.Add(alarmRed);

            Mesh boxDisplay = Createbolck.CreateBox(186, 18.51, 150, "Display", new Vector3D(790.7, 181.48, 553.19));
            BoxBlock.Entities.Add(boxDisplay);

            Mesh boxGlass = Createbolck.CreateBox(534.88, 18.51, 425.53, "Glass", new Vector3D(116.28, 181.48, 297.87));
            BoxBlock.Entities.Add(boxGlass);

            Mesh keybox = Createbolck.CreateBox(186, 185.18, 42.55, "WhiteMetal", new Vector3D(790.7, 0, 340.42));
            BoxBlock.Entities.Add(keybox);

            Mesh keyboard = Createbolck.CreateBox(139.53, 111.11, 10, "Keyboard", new Vector3D(813.95, 18.52, 382.98));
            BoxBlock.Entities.Add(keyboard);

            //Mesh stateMesh = Createbolck.CreateCylinder(50, 100, Color.Yellow, new Vector3D(500, 400, 914.89));
            //BoxBlock.Entities.Add(stateMesh);

            Mesh Bottom = Createbolck.CreateBox(1700,1600,5, "Warnig", new Vector3D(-200, -180, 0));
            BoxBlock.Entities.Add(Bottom);


            Mesh Bottom_yellow = Createbolck.CreateBox(1650, 1550, 5, "metal3", new Vector3D(-175, -160, 5));
            BoxBlock.Entities.Add(Bottom_yellow);
      

            Mesh tall_0 = Createbolck.CreateBox(50,50, 400, "Chrome", new Vector3D(-200, -180, 0));
            BoxBlock.Entities.Add(tall_0);


            Mesh tall_1 = Createbolck.CreateBox(50, 50, 400, "Chrome", new Vector3D(-200, 1370, 0));
            BoxBlock.Entities.Add(tall_1);

            Mesh tall_2 = Createbolck.CreateBox(50, 50, 400, "Chrome", new Vector3D(1450, 1370, 0));
            BoxBlock.Entities.Add(tall_2);
            Mesh tall_3 = Createbolck.CreateBox(50, 50, 400, "Chrome", new Vector3D(1450, -180, 0));
            BoxBlock.Entities.Add(tall_3);

            Mesh wall_0 = Createbolck.CreateBox(50, 1500, 50, "Chrome", new Vector3D(-200, -130, 350));
            BoxBlock.Entities.Add(wall_0);

            Mesh wall_1 = Createbolck.CreateBox(1600, 50, 50, "Chrome", new Vector3D(-150, 1370, 350));
            BoxBlock.Entities.Add(wall_1);

            Mesh wall_2 = Createbolck.CreateBox(50, 1500, 50, "Chrome", new Vector3D(1450, -130, 350));
            BoxBlock.Entities.Add(wall_2);

            Mesh workingJobBox = Createbolck.CreateBox(500, 400, 300, Color.Black, new Vector3D(500, 400, 4000));
            workingJobBox.Visible = false;
            BoxBlock.Entities.Add(workingJobBox);


            //bs.StateMesh = stateMesh;
            bs.JobMesh = workingJobBox;


            return BoxBlock;
        }

        public Block CreateBox()
        {
            Block BoxBlock = new Block("Box");
           
            Mesh bodyMain = Createbolck.CreateBox(150, 120, 70, "Maple", new Vector3D(0, 0, 0));
            BoxBlock.Entities.Add(bodyMain);

            return BoxBlock;
        }

        public Block CreateState(MachineNode mn)
        {
            Block BoxBlock = new Block("State" + mn.ID);

            Bitmap alert = new Bitmap(Properties.Resources.alert__1__removebg_preview);
            alert.RotateFlip(RotateFlipType.Rotate180FlipXY);

            Picture img = new Picture(Plane.XZ, new Point3D(mn.Position_box[0] + 2000, mn.Position_box[1] + 500, mn.Position_box[2] + 2000), 2000, 2000, alert);
            img.ColorMethod = colorMethodType.byEntity;
            img.Color = Color.Transparent;


            //Mesh bodyMain = Createbolck.CreateCylinder(300, 500, Color.Red, new Vector3D(0, 0, 0));


            //Mesh body = Createbolck.CreateCylinder(300, 2000, Color.Red, new Vector3D(0, 0, 0));
            //bodyMain.Translate(mn.Position_box[0]+2000 , mn.Position_box[1]+500 , mn.Position_box[2] +2000 );
            //bodyMain.EdgeStyle = Mesh.edgeStyleType.Sharp;

            //body.Translate(mn.Position_box[0] + 2000, mn.Position_box[1] + 500, mn.Position_box[2] + 2800);
            //body.EdgeStyle = Mesh.edgeStyleType.Sharp;


            //BoxBlock.Entities.Add(bodyMain);
            //BoxBlock.Entities.Add(body);

            BoxBlock.Entities.Add(img);

            return BoxBlock;
        }

        public Block CreateJobBox(MachineNode mn, string jobname)
        {
            Block BoxBlock = new Block("Box" + mn.ID+"_"+jobname);


            Mesh bodyMain = Createbolck.CreateCylinder(250, 500, SetColor(jobname), new Vector3D(0, 0, 0));
            bodyMain.Translate(mn.Position_box[0] + 500, mn.Position_box[1] + 500, 0);
            BoxBlock.Entities.Add(bodyMain);


            return BoxBlock;
        }

       
        public List<LeaderAndText> JoblistLabel(Dictionary<string, int> jobList)
        {
            try
            {
                List<LeaderAndText> bllist = new List<LeaderAndText>();
                int count = 0;
                foreach (KeyValuePair<string, int> pair in jobList)
                {
                    LeaderAndText dsd = new LeaderAndText(new LeaderAndText(-4800, 7000 * (count + 1) / 3, 4, pair.Key + " : " + pair.Value, new Font("Tahoma", 9.25f), SetColor(pair.Key), new devDept.Geometry.Vector2D(0, 0)));
                    dsd.FillColor = Color.Transparent;

                    bllist.Add(dsd);

                    count++;
                }
                return bllist;
            }
            catch(Exception e)
            {
                List<LeaderAndText> bllist = new List<LeaderAndText>();
                return bllist;
            }
           
        }

        public List<LeaderAndText> MachineLabel(Dictionary<string, MachineNode> machine)
        {
            try
            {
                List<LeaderAndText> bllist = new List<LeaderAndText>();
               
                foreach (KeyValuePair<string, MachineNode> pair in machine)
                {
                    Point3D pointlabel = new Point3D();
                    pointlabel.X = pair.Value.Position_box[0] + 8000;
                    pointlabel.Y = pair.Value.Position_box[1] + 100;
                    pointlabel.Z = 0;

                    string machineinfo = pair.Key + "\r\n"+"총 작업 수 : " + pair.Value.WorkCount + "\r\n" + "총 작업 시간 : " + pair.Value.TotalworkTime + "\r\n" + "총 셋업 시간 : " + pair.Value.TotalsetupTime + "\r\n" + "총 유휴 시간 : " + pair.Value.TotalIdleTime;
                    LeaderAndText dsd = new LeaderAndText(pair.Value.Position_box[0]+8000, pair.Value.Position_box[1] + 100, 0, machineinfo, new Font("Tahoma", 6.25f), Color.White, new Vector2D(0,0));
                    dsd.FillColor = Color.DarkGray;
                    
                  
                
                    bllist.Add(dsd);

                
                }
                return bllist;
            }
            catch (Exception e)
            {
                List<LeaderAndText> bllist = new List<LeaderAndText>();
                return bllist;
            }

        }

        public Color SetColor(string name)
        {
            Color setcolor = new Color();
            if (name.Contains("A"))
                setcolor = COLOR_1.A_StringColor;
            if (name.Contains("B"))
                setcolor = COLOR_1.B_StringColor;
            if (name.Contains("C"))
                setcolor = COLOR_1.C_StringColor;
            if (name.Contains("D"))
                setcolor = COLOR_1.D_StringColor;
            if (name.Contains("E"))
                setcolor = COLOR_1.E_StringColor;
            if (name.Contains("F"))
                setcolor = COLOR_1.F_StringColor;
            if (name.Contains("G"))
                setcolor = COLOR_1.G_StringColor;
            if (name.Contains("H"))
                setcolor = COLOR_1.H_StringColor;
            if (name.Contains("I"))
                setcolor = COLOR_1.I_StringColor;
            if (name.Contains("J"))
                setcolor = COLOR_1.J_StringColor;
            if (name.Contains("K"))
                setcolor = COLOR_1.K_StringColor;
            if (name.Contains("L"))
                setcolor = COLOR_1.L_StringColor;
            if (name.Contains("M"))
                setcolor = COLOR_1.M_StringColor;
            if (name.Contains("N"))
                setcolor = COLOR_1.N_StringColor;
            if (name.Contains("O"))
                setcolor = COLOR_1.O_StringColor;
            if (name.Contains("P"))
                setcolor = COLOR_1.P_StringColor;
            if (name.Contains("Q"))
                setcolor = COLOR_1.Q_StringColor;
            if (name.Contains("R"))
                setcolor = COLOR_1.R_StringColor;
            if (name.Contains("S"))
                setcolor = COLOR_1.S_StringColor;
            if (name.Contains("T"))
                setcolor = COLOR_1.T_StringColor;
            if (name.Contains("U"))
                setcolor = COLOR_1.U_StringColor;
            if (name.Contains("V"))
                setcolor = COLOR_1.V_StringColor;
            if (name.Contains("W"))
                setcolor = COLOR_1.W_StringColor;
            if (name.Contains("X"))
                setcolor = COLOR_1.X_StringColor;
            if (name.Contains("Y"))
                setcolor = COLOR_1.Y_StringColor;
            if (name.Contains("Z"))
                setcolor = COLOR_1.Z_StringColor;

            return setcolor;
        }
    }
}

