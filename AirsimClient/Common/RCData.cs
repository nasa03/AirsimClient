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

using System;

namespace AirsimClient.Common
{
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
            return (uint)((Switches == Shifted ) ? 1 : 0);
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
                Math.Abs(Roll) > K||
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
