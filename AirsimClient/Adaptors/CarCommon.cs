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

using AirsimClient.Car;
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
    /// Adapts the CarControls for transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class CarControlsRpc : IAdaptable<CarControls>
    {       
        [Key("throttle")]
        public float Throttle { get; set; }

       
        [Key("steering")]
        public float Steering { get; set; }


        [Key("brake")]
        public float Brake { get; set; }


        [Key("handbrake")]
        public bool Handbrake { get; set; }


        [Key("is_manual_gear")]
        public bool IsManualGear { get; set; }


        [Key("manual_gear")]
        public int ManualGear { get; set; }


        [Key("gear_immediate")]
        public bool GearImmediate { get; set; }

        public CarControls AdaptTo(
            )
        {
            return new CarControls()
            {
                Throttle = Throttle,
                Steering = Steering,
                Brake = Brake,
                Handbrake = Handbrake,
                IsManualGear = IsManualGear,
                GearImmediate = GearImmediate,
                ManualGear = ManualGear
            };

        }

        internal static CarControlsRpc AdaptFrom(CarControls controls)
        {
            CarControlsRpc adaptor = new CarControlsRpc()
            {
                Throttle = controls.Throttle,
                Steering = controls.Steering,
                Brake = controls.Brake,
                Handbrake = controls.Handbrake,
                IsManualGear = controls.IsManualGear,
                ManualGear = controls.ManualGear,
                GearImmediate = controls.GearImmediate
            };

            return adaptor;
        }

    }

    /// <summary>
    /// Adapts the CarState for transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class CarStateRpc : IAdaptable<CarState>
    {
        [Key("speed")]
        public float Speed { get; set; }


        [Key("gear")]
        public int Gear { get; set; }


        [Key("rpm")]
        public float RPM { get; set; }


        [Key("maxrpm")]
        public float MaxRPM { get; set; }


        [Key("handbrake")]
        public bool Handbrake { get; set; }


        [JsonProperty("kinematics_estimated")]
        [Key("kinematics_estimated")]
        public KinematicsStateRpc KinematicsEstimated { get; set; } 


        [Key("timestamp")]
        public ulong TimeStamp { get; set; }

        public CarState AdaptTo()
        {
            return new CarState(
                Speed,
                Gear,
                RPM,
                MaxRPM,
                Handbrake,
                KinematicsEstimated.AdaptTo(),
                TimeStamp
                );
        }
    }
}
