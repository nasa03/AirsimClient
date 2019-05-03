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
using MessagePack;
using Newtonsoft.Json;


namespace AirsimClient.Adaptors
{
    /// <summary>
    /// Adapts the KinematicsState for transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class KinematicsStateRpc : IAdaptable<KinematicsState>
    {
        [JsonProperty("position")]
        internal Vector3Rpc Position { get; set; }


        [JsonProperty("orientation")]
        internal QuaternionRpc Orientation { get; set; }


        [JsonProperty("linear_velocity")]
        internal Vector3Rpc LinearVelocity { get; set; }


        [JsonProperty("linear_acceleration")]
        internal Vector3Rpc LinearAcceleration { get; set; }


        [JsonProperty("angular_velocity")]
        internal Vector3Rpc AngularVelocity { get; set; }


        [JsonProperty("angular_acceleration")]
        internal Vector3Rpc AngularAcceleration { get; set; }

        public KinematicsState AdaptTo()
        {
            return new KinematicsState
                (
                Position.AdaptTo(),
                Orientation.AdaptTo(),
                LinearVelocity.AdaptTo(),
                AngularVelocity.AdaptTo(),
                LinearAcceleration.AdaptTo(),
                AngularAcceleration.AdaptTo()
                );
        }
    }
}
