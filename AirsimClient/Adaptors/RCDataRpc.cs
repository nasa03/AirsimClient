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
    [MessagePackObject]
    internal class RCDataRpc : IAdaptable<RCData>
    {
        [JsonProperty("time_stamp")]
        internal ulong TimeStamp { get; set; }


        [JsonProperty("pitch")]
        internal float Pitch { get; set; }


        [JsonProperty("roll")]
        internal float Roll { get; set; }


        [JsonProperty("throttle")]
        internal float Throttle { get; set; }


        [JsonProperty("yaw")]
        internal float Yaw { get; set; }


        [JsonProperty("left_z")]
        internal float LeftZ { get; set; }


        [JsonProperty("right_z")]
        internal float RightZ { get; set; }


        [JsonProperty("switches")]
        internal ushort Switches { get; set; }


        [JsonProperty("vendor_id")]
        internal string VendorId { get; set; }


        [JsonProperty("is_initialized")]
        internal bool IsInitialized { get; set; }


        [JsonProperty("is_valid")]
        internal bool IsValid { get; set; }

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
}