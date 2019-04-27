using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
    public class KinematicsState
    {
        public readonly Vector3 Position;


        public readonly Quaternion Orientation;


        public readonly Vector3 LinearVelocity;


        public readonly Vector3 AngularVelocity;


        public readonly Vector3 LinearAcceleration;


        public readonly Vector3 AngularAcceleration;

        internal KinematicsState(
            Vector3 Position,
            Quaternion Orientation,
            Vector3 LinearVelocity,
            Vector3 AngularVelocity,
            Vector3 LinearAcceleration,
            Vector3 AngularAcceleration
            )
        {
            this.Position = Position;
            this.Orientation = Orientation;
            this.LinearVelocity = LinearVelocity;
            this.AngularVelocity = AngularVelocity;
            this.LinearAcceleration = LinearAcceleration;
            this.AngularAcceleration = AngularAcceleration;
        }
    }
}
