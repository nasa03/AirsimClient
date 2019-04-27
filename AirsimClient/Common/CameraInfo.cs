using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
    public class CameraInfo
    {
        public readonly Pose Pose;


        public readonly float FOV;


        public readonly ProjectionMatrix ProjMat;

        internal CameraInfo(
            Pose Pose,
            float FOV,
            ProjectionMatrix ProjMat
            )
        {
            this.Pose = Pose;
            this.FOV = FOV;
            this.ProjMat = ProjMat;
        }
     }
}
