using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using devDept.Eyeshot.Entities;

using devDept.Eyeshot;
using devDept.Geometry;
using System.Drawing;
using devDept.Eyeshot.Labels;
using PINOKIO_SCHEDULER.Definitions;

namespace PINOKIO_SCHEDULER
{

    public class MachineShape
    {
        private Entity _boxMesh;
        private Entity _jobMesh;
        private Entity _outjobMesh;
        private Entity _stateMesh;
        private MachineNode _coreNode;
        private Entity _labelBox;

        private List<AttributeReference> _machinelabel = new List<AttributeReference>();


        public Entity StateMesh
        {
            get { return _stateMesh; }
            set { _stateMesh = value; }
        }
        public Text StateName
        {
            get; set;

        }

        public Entity LabelBox
        {
            get { return _labelBox; }
            set { _labelBox = value; }
        }
        public List<AttributeReference> Machinelabel
        {
            get { return _machinelabel; }
            set { _machinelabel = value; }
        }



        public Entity JobMesh
        {
            get { return _jobMesh; }
            set { _jobMesh = value; }
        }

        public Entity OutJobMesh
        {
            get { return _outjobMesh; }
            set { _outjobMesh = value; }
        }

        public MachineShape(MachineNode bn)
        {

        }
        public void initPos(List<double> pos)
        {
           
        }
        public MachineNode CoreNode
        {
            get { return _coreNode; }
            set { _coreNode = value; }
        }

        public void UpdateMachineState(MachineNode machine)
        {

            if (machine.MachineState is MACHINE_STATE.IDLE) 
            {
                StateMesh.Color = Color.Red;
            }
            else if (machine.MachineState is MACHINE_STATE.LOADING)
            {
                StateMesh.Color = Color.Yellow;
            }
            else if (machine.MachineState is MACHINE_STATE.WORKING)
            {
                StateMesh.Color = Color.Green;
            }
           
        }
        public void UpdateMachineState_1(MachineNode machine)
        {

            if (machine.MachineState is MACHINE_STATE.IDLE)
            {
                StateMesh.Color = Color.Transparent;
            }
            else if (machine.MachineState is MACHINE_STATE.LOADING)
            {
                StateMesh.Color = Color.Red;
            }
            else if (machine.MachineState is MACHINE_STATE.WORKING)
            {
                StateMesh.Color = this.JobMesh.Color; ;
            }

        }

        public void UpdateJobColor(string Name)
        {
            JobMesh.Color = SetColor(Name);
           
        }

        public void UpdateOutJobColor(string Name)
        {
            OutJobMesh.Color = SetColor(Name);

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
