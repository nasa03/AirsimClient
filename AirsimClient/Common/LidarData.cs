using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
    public class LidarData
    {
        public readonly int TimeStamp;


        public readonly float[] PointCloud;


        public readonly Pose Pose;

        internal LidarData(int TimeStamp, float[] PointCloud, Pose Pose)
        {
            this.TimeStamp = TimeStamp;
            this.PointCloud = PointCloud;
            this.Pose = Pose;
        }
    }
}
