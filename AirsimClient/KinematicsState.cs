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

using System.Numerics;

namespace AirsimClient
{
    /// <summary>
    /// The Kinematics of the vehicle
    /// </summary>
    public class KinematicsState
    {
        /// <summary>
        /// The position of the vehicle
        /// </summary>
        public Vector3 Position { get; private set; }


        /// <summary>
        /// The Orientation of the vehicle
        /// </summary>
        public Quaternion Orientation { get; private set; }


        /// <summary>
        /// The linear velocity of the vehicle
        /// </summary>
        public Vector3 LinearVelocity { get; private set; }


        /// <summary>
        /// The angular velocity of the car
        /// </summary>
        public Vector3 AngularVelocity { get; private set; }


        /// <summary>
        /// The linear acceleration of the car
        /// </summary>
        public Vector3 LinearAcceleration { get; private set; }


        /// <summary>
        /// The angular acceleration of the car
        /// </summary>
        public Vector3 AngularAcceleration { get; private set; }

        public KinematicsState(
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
