using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot;
using devDept.Graphics;
using devDept.Geometry;

namespace PINOKIO_SCHEDULER.Nodes
{
    public class TranslatingAlongZ : BlockReference
    {
        private double xPos, yPos, zPos;
        private double sin, cos;
        private Transformation customTransform;
        double alpha = 5000;
        List<double> pos = new List<double>();
        public TranslatingAlongZ(string blockName, MachineNode mn)
            : base(0, 0, 0, blockName, 1, 1, 1, 0)
        {
            pos = mn.Position_box;
        }

        protected override void Animate(int frameNumber)
        {
            // frameNumber is incremented each time this function is called
            // it represents the time passing an can be used to index an array
            // 3D positions for example.

            // angle in degrees
            alpha -= 100;
            if (alpha <= 0)

                alpha = 5000;

       
            //base.Animate(frameNumber);


        }

        public override void MoveTo(DrawParams data)
        {
            base.MoveTo(data);

            customTransform = new Translation(pos[0] + 500, pos[1] + 500, zPos);
            data.RenderContext.MultMatrixModelView(customTransform);
        }

        public override bool IsInFrustum(FrustumParams data, Point3D center, double radius)
        {
            // Call the base with the transformed "center", to avoid undesired clipping
            return base.IsInFrustum(data, customTransform * center, radius);
        }
    }
}
