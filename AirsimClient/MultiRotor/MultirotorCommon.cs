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

using AirsimClient.Adaptors;
using AirsimClient.Common;

namespace AirsimClient.MultiRotor
{
    public enum DrivetrainType
    {
        MaxDegreeOfFreedom = 0,
        Forwardonly
    }

    public enum LandedState : uint
    {
        Landed = 0,
        Flying = 1
    }

    public class YawMode
    {
        public bool IsRate { get; private set; } = true;


        public float YawOrRate { get; private set; } = 0.0f;

        public YawMode(bool IsRateVal, float YawOrRateVal)
        {
            IsRate = IsRateVal;
            YawOrRate = YawOrRateVal;
        }

        public YawMode Zero => new YawMode(true, 0.0f);

        public void SetZeroRate()
        {
            IsRate = true;
            YawOrRate = 0.0f;
        }
    }

    public class MultirotorApiParams
    {
        public float VelToBreakingDist { get; set; } = 0.5f;


        public float MinBreakingDist { get; set; } = 1f;


        public float MaxBreakingDistance { get; set; } = 3f;


        public float BreakingVel { get; set; } = 1.0f;


        public float MinVelForBreaking { get; set; } = 3f;


        public float DistanceAccuracy { get; set; } = 0.1f;


        public float ObsClearance { get; set; } = 2f;


        public float ObsWindow { get; set; } = 0f;
    }

    public class MultirotorState
    {
        public CollisionInfo Collision { get; private set; }


        public KinematicsState KinematicsEstimated { get; private set; }


        public GeoPoint GpsLocation { get; private set; }


        public ulong TimeStamp { get; private set; }


        public LandedState LandedState { get; private set; }


        public RCData RCData { get; private set; }

        public MultirotorState(
            CollisionInfo Collision,
            KinematicsState KinematicsEstimated,
            GeoPoint GpsLocation,
            ulong TimeStamp,
            LandedState LandedState,
            RCData RCData)
        {
            this.Collision = Collision;
            this.KinematicsEstimated = KinematicsEstimated;
            this.GpsLocation = GpsLocation;
            this.TimeStamp = TimeStamp;
            this.LandedState = LandedState;
            this.RCData = RCData;
        }
    }




}
