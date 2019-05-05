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
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Car
{
    /// <summary>
    /// Controls sent to the car
    /// </summary>
    public class CarControls
    {
        /// <summary>
        /// Specifies the amount of Throttle -1.0f to 1.0f
        /// </summary>
        public float Throttle { get; set; }


        /// <summary>
        /// Specifies the amount of Steering -1.0f to 1.0f (Left/Right)
        /// </summary>
        public float Steering { get; set; }


        /// <summary>
        /// Specifies the strength of the brake on the car 0.0f to 1.0f
        /// </summary>
        public float Brake { get; set; }


        /// <summary>
        /// Specifies whether the Handbrake is engaged
        /// </summary>
        public bool Handbrake { get; set; }


        /// <summary>
        /// Specifies whether or not manual gear is engaged
        /// </summary>
        public bool IsManualGear { get; set; }


        /// <summary>
        /// Specifies which gear is engaged 0 to 5
        /// </summary>
        public int ManualGear { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public bool GearImmediate { get; set; }
    }


    /// <summary>
    /// Describes the State of the Car
    /// </summary>
    public class CarState
    {
        /// <summary>
        /// The current speed of the car
        /// </summary>
        public readonly float Speed;


        /// <summary>
        /// The gear currently engaged
        /// </summary>
        public readonly int Gear;


        /// <summary>
        /// The Revolutions Per Minute of the wheels of the Car
        /// </summary>
        public readonly float RPM;


        /// <summary>
        /// The Max Revolutions Per Minute of the wheels allowed on the car
        /// </summary>
        public readonly float MaxRPM;


        /// <summary>
        /// States whether or not the handbrake is engaged
        /// </summary>
        public readonly bool Handbrake;


        /// <summary>
        /// The current Kinematics of the car
        /// </summary>
        public readonly KinematicsState KinematicsEstimated;


        /// <summary>
        /// The timestamp of when the state was measured
        /// </summary>
        public readonly ulong TimeStamp;

        internal CarState(
            float Speed,
            int Gear,
            float RPM,
            float MaxRPM,
            bool Handbrake,
            KinematicsState KinematicsEstimated,
            ulong TimeStamp
            )
        {
            this.Speed = Speed;
            this.Gear = Gear;
            this.RPM = RPM;
            this.MaxRPM = MaxRPM;
            this.Handbrake = Handbrake;
            this.KinematicsEstimated = KinematicsEstimated;
            this.TimeStamp = TimeStamp;
        }
    }
}
