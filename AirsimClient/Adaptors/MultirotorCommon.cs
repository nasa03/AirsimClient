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

using AirsimClient.MultiRotor;
using MessagePack;
using Newtonsoft.Json;

namespace AirsimClient.Adaptors
{
    [MessagePackObject]
    internal class MultirotorStateRpc : IAdaptable<MultirotorState>
    {
        [JsonProperty("collision")]
        [Key("collision")]
        public CollisionInfoRpc Collision { get; set; }


        [JsonProperty("kinematics_estimated")]
        [Key("kinematics_estimated")]
        public KinematicsStateRpc KinematicsEstimated { get; set; }


        [JsonProperty("gps_location")]
        [Key("gps_location")]
        public GeoPointRpc GpsLocation { get; set; }


        [JsonProperty("time_stamp")]
        [Key("time_stamp")]
        public ulong TimeStamp { get; set; }


        [JsonProperty("landed_state")]
        [Key("landed_state")]
        public LandedState LandedState { get; set; }


        [JsonProperty("rc_data")]
        [Key("rc_data")]
        public RCDataRpc RCData { get; set; }

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

    [MessagePackObject]
    internal class YawModeRpc : IAdaptable<YawMode>
    {
        [JsonProperty("is_rate")]
        [Key("is_rate")]
        public bool IsRate { get; set; }


        [JsonProperty("yaw_or_rate")]
        [Key("yaw_or_rate")]
        public float YawOrRate { get; set; }


        public YawMode AdaptTo()
        {
            return new YawMode(IsRate, YawOrRate);
        }

        internal static YawModeRpc AdaptFrom(YawMode Input)
        {
            return new YawModeRpc()
            {
                IsRate = Input.IsRate,
                YawOrRate = Input.YawOrRate
            };

        }
    }
}
