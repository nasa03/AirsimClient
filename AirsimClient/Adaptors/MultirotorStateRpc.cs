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

using AirsimClient.MultiRotor;
using MessagePack;
using Newtonsoft.Json;


namespace AirsimClient.Adaptors
{
    [MessagePackObject]
    internal class MultirotorStateRpc : IAdaptable<MultirotorState>
    {
        [JsonProperty("collision")]
        internal CollisionInfoRpc Collision { get; set; }


        [JsonProperty("kinematics_estimated")]
        internal KinematicsStateRpc KinematicsEstimated { get; set; }


        [JsonProperty("gps_location")]
        internal GeoPointRpc GpsLocation { get; set; }


        [JsonProperty("time_stamp")]
        internal ulong TimeStamp { get; set; }


        [JsonProperty("landed_state")]
        internal LandedState LandedState { get; set; }


        [JsonProperty("rc_data")]
        internal RCDataRpc RCData { get; set; }

        public MultirotorState AdaptTo()
        {
            return new MultirotorState(
                Collision.AdaptTo(),
                KinematicsEstimated.AdaptTo(),
                GpsLocation.AdaptTo(),
                TimeStamp,
                LandedState,
                RCData.AdaptTo());
        }
    }
}
