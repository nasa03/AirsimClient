using AirsimClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Car
{
    public class CarState
    {
        public readonly float Speed;


        public readonly int Gear;


        public readonly float RPM;


        public readonly float MaxRPM;


        public readonly bool Handbrake;


        public readonly KinematicsState KinematicsEstimated;


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
