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
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Adaptors
{
    /// <summary>
    /// Adaptor for Numerics' Vector3 transer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class Vector3Rpc : IAdaptable<Vector3>
    {

        [Key("x_val")]
        public float X { get; set; }


        [Key("y_val")]
        public float Y { get; set; }


        [Key("z_val")]
        public float Z { get; set; }


        public Vector3 AdaptTo()
        {
            return new Vector3(X, Y, Z);
        }

        internal static Vector3Rpc AdaptFrom(Vector3 vector3)
        {
            return new Vector3Rpc()
            {
                X = vector3.X,
                Y = vector3.Y,
                Z = vector3.Z
            };
        }
    }

    /// <summary>
    /// Adapts the Quaternion object for transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class QuaternionRpc : IAdaptable<Quaternion>
    {
        [Key("w_val")]
        public float W { get; set; }


        [Key("x_val")]
        public float X { get; set; }


        [Key("y_val")]
        public float Y { get; set; }


        [Key("z_val")]
        public float Z { get; set; }

        public Quaternion AdaptTo()
        {
            return new Quaternion(X, Y, Z, W);
        }

        internal static QuaternionRpc AdaptFrom(Quaternion q)
        {
            return new QuaternionRpc()
            {
                W = q.W,
                X = q.X,
                Y = q.Y,
                Z = q.Z
            };
        }
    }

    /// <summary>
    /// Adapts the Pose object for transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class PoseRpc : IAdaptable<Pose>
    {
        [JsonProperty("position")]
        [Key("position")]
        public Vector3Rpc Position { get; set; }


        [JsonProperty("orientation")]
        [Key("orientation")]
        public QuaternionRpc Orientation { get; set; }

        public Pose AdaptTo()
        {
            return new Pose(Position.AdaptTo(), Orientation.AdaptTo());
        }

        internal static PoseRpc AdaptFrom(Pose pose)
        {
            return new PoseRpc()
            {
                Position = Vector3Rpc.AdaptFrom(pose.Position),
                Orientation = QuaternionRpc.AdaptFrom(pose.Orientation)
            };
        }


    }
}
