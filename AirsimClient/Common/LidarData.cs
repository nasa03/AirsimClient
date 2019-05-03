#region MIT License (c) 2018 Isaac Walker

// Copyright 2018 Isaac Walker
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
// associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute,
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion MIT License (c) 2018 Isaac Walker

namespace AirsimClient.Common
{
    /// <summary>
    /// The data retrieved from a lidar reading
    /// </summary>
    public class LidarData
    {
        /// <summary>
        /// The timestamp when the lidar reading was taken
        /// </summary>
        public readonly int TimeStamp;


        /// <summary>
        /// The X,Y,Z points of the lidar reading
        /// </summary>
        public readonly float[] PointCloud;


        /// <summary>
        /// The pose of the lidar sensor of this reading
        /// </summary>
        public readonly Pose Pose;

        internal LidarData(int TimeStamp, float[] PointCloud, Pose Pose)
        {
            this.TimeStamp = TimeStamp;
            this.PointCloud = PointCloud;
            this.Pose = Pose;
        }
    }
}
