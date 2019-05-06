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

using AirsimClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient
{
    /// <summary>
    /// A geography point
    /// </summary>
    public class GeoPoint
    {
        /// <summary>
        /// Altitude
        /// </summary>
        public double Altitude { get; private set; }


        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; private set; }


        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; private set; }

        public GeoPoint(double Altitude, double Latitude, double Longitude)
        {
            this.Altitude = Altitude;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }

    /// <summary>
    /// The data retrieved from a lidar reading
    /// </summary>
    public class LidarData
    {
        /// <summary>
        /// The timestamp when the lidar reading was taken
        /// </summary>
        public long TimeStamp { get; private set; }


        /// <summary>
        /// The X,Y,Z points of the lidar reading
        /// </summary>
        public float[] PointCloud { get; private set; }


        /// <summary>
        /// The pose of the lidar sensor of this reading
        /// </summary>
        public Pose Pose { get; private set; }

        internal LidarData(long TimeStamp, float[] PointCloud, Pose Pose)
        {
            this.TimeStamp = TimeStamp;
            this.PointCloud = PointCloud;
            this.Pose = Pose;
        }
    }

    public class ProjectionMatrix
    {
        public float[][] Matrix { get; private set; }

        public ProjectionMatrix(float[][] Matrix)
        {
            this.Matrix = Matrix;
        }

        public void SetTo(float val)
        {
            for (int i = 0; i < Matrix.Length; i++)
                for (int j = 0; j < Matrix.Length; j++)
                    Matrix[i][j] = val;
        }
    }

    /// <summary>
    /// The information of a Camera
    /// </summary>
    public class CameraInfo
    {
        /// <summary>
        /// The pose of the camera
        /// </summary>
        public Pose Pose { get; private set; }


        /// <summary>
        /// The field of vision of the camera
        /// </summary>
        public float FOV { get; private set; }


        /// <summary>
        /// The projection matrix of the camera
        /// </summary>
        public ProjectionMatrix ProjMat { get; private set; }

        public CameraInfo(
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

    /// <summary>
    /// The data about a collision event
    /// </summary>
    public class CollisionInfo
    {
        /// <summary>
        /// Whether the collision has occured
        /// </summary>
        public readonly bool HasCollided;


        public Vector3 Normal { get; private set; }


        public Vector3 ImpactPoint { get; private set; }


        public Vector3 Position { get; private set; }


        public float PenetrationDepth { get; private set; }


        public ulong TimeStamp { get; private set; }


        public uint CollisionCount { get; private set; }


        public string ObjectName { get; private set; }


        public int ObjectId { get; private set; }

        internal CollisionInfo(
            bool HasCollided,
            Vector3 Normal,
            Vector3 ImpactPoint,
            Vector3 Position,
            float PenetrationDepth,
            ulong TimeStamp,
            uint CollisionCount,
            string ObjectName,
            int ObjectId)
        {
            this.Normal = Normal;
            this.ImpactPoint = ImpactPoint;
            this.Position = Position;
            this.PenetrationDepth = PenetrationDepth;
            this.TimeStamp = TimeStamp;
            this.CollisionCount = CollisionCount;
            this.ObjectName = ObjectName;
            this.ObjectId = ObjectId;
        }
    }


    public class RCData
    {
        public ulong TimeStamp { get; private set; } = 0;


        public float Pitch { get; private set; } = 0;


        public float Roll { get; private set; } = 0;


        public float Throttle { get; private set; } = 0;


        public float Yaw { get; private set; } = 0;


        public float LeftZ { get; private set; } = 0;


        public float RightZ { get; private set; } = 0;


        public ushort Switches { get; private set; } = 0;


        public string VendorId { get; private set; } = string.Empty;


        public bool IsInitialized { get; private set; } = false;


        public bool IsValid { get; private set; } = false;

        public uint GetSwitch(ushort Index)
        {
            ushort Shifted = (ushort)(1 << Index);
            return (uint)((Switches == Shifted) ? 1 : 0);
        }

        public void Add(RCData Other)
        {
            Pitch += Other.Pitch; Roll += Other.Roll; Throttle += Other.Throttle; Yaw += Other.Yaw;
        }

        public void Subtract(RCData Other)
        {
            Pitch -= Other.Pitch; Roll -= Other.Roll; Throttle -= Other.Throttle; Yaw -= Other.Yaw;
        }

        public void DivideBy(float K)
        {
            Pitch /= K; Roll /= K; Throttle /= K; Yaw /= K;
        }

        public bool IsAnyMoreThan(float K)
        {
            return Math.Abs(Pitch) > K ||
                Math.Abs(Roll) > K ||
                Math.Abs(Throttle) > K ||
                Math.Abs(Yaw) > K;
        }

        public override string ToString()
        {
            return string.Format("RCData[pitch={0}, roll={1}, throttle={2} yaw={3}]", Pitch, Roll, Throttle, Yaw);
        }

        public RCData(ulong TimeStamp, float Pitch, float Roll, float Throttle, float Yaw, float LeftZ, float RightZ,
            ushort Switches, string VendorId, bool IsInitialized, bool IsValid)
        {
            this.TimeStamp = TimeStamp;
            this.Pitch = Pitch;
            this.Roll = Roll;
            this.Throttle = Throttle;
            this.Yaw = Yaw;
            this.LeftZ = LeftZ;
            this.RightZ = RightZ;
            this.Switches = Switches;
            this.VendorId = VendorId;
            this.IsInitialized = IsInitialized;
            this.IsValid = IsValid;
        }
    }

}
