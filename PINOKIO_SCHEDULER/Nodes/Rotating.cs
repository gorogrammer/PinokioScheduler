using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINOKIO_SCHEDULER.Nodes
{


    public class Rotating : BlockReference
    {

        double alpha;
        double test;
        List<double> pos = new List<double>();
        public Rotating(string blockName, MachineNode mn)
            : base(0, 0, 0, blockName, 1, 1, 1, 0)
        {
            pos = mn.Position_box;
        }


    

        protected override void Animate(int frameNumber)
        {

            alpha += 2.5f;

            if (alpha > 359)

                alpha = 0;

            test += 2f;

            if (test > 359)

                test = 0;
        }

        private Transformation customTransform;

        public override void MoveTo(DrawParams data)
        {
            base.MoveTo(data);

            //*new devDept.Geometry.Rotation(Utility.DegToRad(alpha), new Vector3D(0, 0, 10));
            // the 100 value is added to facilitate the zoom fit for demo purpose, you can safely remove 00
            customTransform = new devDept.Geometry.Rotation(Utility.DegToRad(alpha), new Vector3D(1, 0, 0), new Point3D(pos[0]+500, pos[1]+500 , pos[2]+2000));

            data.RenderContext.MultMatrixModelView(customTransform);
        }

        public override bool IsInFrustum(FrustumParams data, Point3D center, double radius)
        {
            // Call the base with the transformed "center", to avoid undesired clipping
            return base.IsInFrustum(data, customTransform * center, radius);
        }
    }

}
