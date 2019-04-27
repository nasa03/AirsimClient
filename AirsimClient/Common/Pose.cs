using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
    public class Pose
    {
        public readonly Vector3 Position;


        public readonly Quaternion Orientation;

        internal Pose(Vector3 Position, Quaternion Orientation)
        {
            this.Position = Position;
            this.Orientation = Orientation;
        }
    }
}
