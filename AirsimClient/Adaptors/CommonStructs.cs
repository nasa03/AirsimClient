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

using MessagePack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Adaptors
{

    /// <summary>
    /// Adapts the CollisionInfo for transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class CollisionInfoRpc : IAdaptable<CollisionInfo>
    {
        [Key("has_collided")]
        public bool HasCollided { get; set; }


        [JsonProperty("normal")]
        [Key("normal")]
        public Vector3Rpc Normal { get; set; }


        [JsonProperty("impact_point")]
        [Key("impact_point")]
        public Vector3Rpc ImpactPoint { get; set; }


        [JsonProperty("position")]
        [Key("position")]
        public Vector3Rpc Position { get; set; }


        [Key("penetration_depth")]
        public float PenetrationDepth { get; set; }


        [Key("time_stamp")]
        public ulong TimeStamp { get; set; }


        [Key("collision_count")]
        public uint CollisionCount { get; set; }


        [Key("object_name")]
        public string ObjectName { get; set; }


        [Key("object_id")]
        public int ObjectId { get; set; }

        public CollisionInfo AdaptTo()
        {
            return new CollisionInfo(
                HasCollided,
                Normal.AdaptTo(),
                ImpactPoint.AdaptTo(),
                Position.AdaptTo(),
                PenetrationDepth,
                TimeStamp,
                CollisionCount,
                ObjectName,
                ObjectId);
        }

        internal static CollisionInfoRpc AdaptFrom(CollisionInfo info)
        {
            return new CollisionInfoRpc()
            {
                CollisionCount = info.CollisionCount,
                HasCollided = info.HasCollided,
                ImpactPoint = Vector3Rpc.AdaptFrom(info.ImpactPoint),
                Normal = Vector3Rpc.AdaptFrom(info.Normal),
                ObjectId = info.ObjectId,
                TimeStamp = info.TimeStamp,
                ObjectName = info.ObjectName,
                PenetrationDepth = info.PenetrationDepth,
                Position = Vector3Rpc.AdaptFrom(info.Position)

            };

        }
    }

    /// <summary>
    /// Adapts the CameraInfo for transer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class CameraInfoRpc : IAdaptable<CameraInfo>
    {
        [JsonProperty("pose")]
        [Key("pose")]
        public PoseRpc Pose { get; set; }


        [Key("fov")]
        public float FOV { get; set; }


        [JsonProperty("proj_mat")]
        [Key("proj_mat")]
        public ProjectionMatrixRpc ProjMat { get; set; }

        public CameraInfo AdaptTo()
        {
            return new CameraInfo(Pose.AdaptTo(), FOV, ProjMat.AdaptTo());
        }

        internal static CameraInfoRpc AdaptFrom(CameraInfo info)
        {
            return new CameraInfoRpc()
            {
                Pose = PoseRpc.AdaptFrom(info.Pose),
                FOV = info.FOV,
                ProjMat = ProjectionMatrixRpc.AdaptFrom(info.ProjMat)
            };
        }
    }

    /// <summary>
    /// Adapts the GeoPoint for transfer over Rpv
    /// </summary>
    [MessagePackObject]
    internal class GeoPointRpc : IAdaptable<GeoPoint>
    {
        [JsonProperty("altitude")]
        [Key("altitude")]
        public double Altitude { get; set; }


        [JsonProperty("latitude")]
        [Key("latitude")]
        public double Latitude { get; set; }


        [JsonProperty("longitude")]
        [Key("longitude")]
        public double Longitude { get; set; }

        public GeoPoint AdaptTo()
        {
            return new GeoPoint(Altitude, Latitude, Longitude);
        }
    }

    /// <summary>
    /// Adapts the ProjectionMatrix for transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class ProjectionMatrixRpc : IAdaptable<ProjectionMatrix>
    {
        [Key("matrix")]
        public float[][] Matrix { get; set; }

        public ProjectionMatrix AdaptTo()
        {
            return new ProjectionMatrix(Matrix);
        }

        internal static ProjectionMatrixRpc AdaptFrom(ProjectionMatrix projectionMatrix)
        {
            return new ProjectionMatrixRpc()
            { Matrix = projectionMatrix.Matrix };
        }
    }

    [MessagePackObject]
    internal class RCDataRpc : IAdaptable<RCData>
    {
        [Key("time_stamp")]
        public ulong TimeStamp { get; set; }


        [Key("pitch")]
        public float Pitch { get; set; }


        [Key("roll")]
        public float Roll { get; set; }


        [Key("throttle")]
        public float Throttle { get; set; }


        [Key("yaw")]
        public float Yaw { get; set; }


        [Key("left_z")]
        public float LeftZ { get; set; }


        [Key("right_z")]
        public float RightZ { get; set; }


        [Key("switches")]
        public ushort Switches { get; set; }


        [Key("vendor_id")]
        public string VendorId { get; set; }


        [Key("is_initialized")]
        public bool IsInitialized { get; set; }


        [Key("is_valid")]
        public bool IsValid { get; set; }

        public RCData AdaptTo()
        {
            return new RCData(
                TimeStamp,
                Pitch,
                Roll,
                Throttle,
                Yaw,
                LeftZ,
                RightZ,
                Switches,
                VendorId,
                IsInitialized,
                IsValid
                );
        }

        internal static RCDataRpc AdaptFrom(RCData data)
        {
            return new RCDataRpc()
            {
                IsInitialized = data.IsInitialized,
                Switches = data.Switches,
                TimeStamp = data.TimeStamp,
                IsValid = data.IsValid,
                LeftZ = data.LeftZ,
                Pitch = data.Pitch,
                RightZ = data.RightZ,
                Roll = data.Roll,
                Throttle = data.Throttle,
                VendorId = data.VendorId,
                Yaw = data.Yaw
            };

        }

    }

    [MessagePackObject]
    internal class LidarDataRpc : IAdaptable<LidarData>
    {
        [JsonProperty("time_stamp")]
        [Key("time_stamp")]
        public long TimeStamp { get; set; }


        [JsonProperty("point_cloud")]
        [Key("point_cloud")]
        public float[] PointCloud { get; set; }


        [JsonProperty("pose")]
        [Key("pose")]
        public PoseRpc Pose { get; set; }

        public LidarData AdaptTo()
        {
            return new LidarData(TimeStamp, PointCloud, Pose.AdaptTo());
        }
    }

}
