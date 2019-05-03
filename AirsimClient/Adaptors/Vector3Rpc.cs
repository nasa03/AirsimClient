﻿#region MIT License (c) 2018 Isaac Walker

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

using Newtonsoft.Json;
using System.Numerics;

namespace AirsimClient.Adaptors
{
    /// <summary>
    /// Adaptor for Numerics' Vector3 transer over Rpc
    /// </summary>
    internal class Vector3Rpc : IAdaptable<Vector3>
    {
        [JsonProperty("x_val")]
        internal float X { get; set; }


        [JsonProperty("y_val")]
        internal float Y { get; set; }


        [JsonProperty("z_val")]
        internal float Z { get; set; }


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
}
