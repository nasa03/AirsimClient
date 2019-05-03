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

using System.Numerics;

namespace AirsimClient.Common
{
    /// <summary>
    /// The data about a collision event
    /// </summary>
    public class CollisionInfo
    {
        /// <summary>
        /// Whether the collision has occured
        /// </summary>
        public readonly bool HasCollided;


        public readonly Vector3 Normal;


        public readonly Vector3 ImpactPoint;


        public readonly Vector3 Position;


        public readonly float PenetrationDepth;


        public readonly ulong TimeStamp;


        public readonly uint CollisionCount;


        public readonly string ObjectName;


        public readonly int ObjectId;

        internal CollisionInfo(
            bool HasCollided,
            Vector3 Normal,
            Vector3 ImpactPoint,
            Vector3 Position,
            float PenetrationDepth,
            ulong TimeStamp,
            uint CollisionCount,
            string ObjectName,
            int ObjectId)
        {
            this.Normal = Normal;
            this.ImpactPoint = ImpactPoint;
            this.Position = Position;
            this.PenetrationDepth = PenetrationDepth;
            this.TimeStamp = TimeStamp;
            this.CollisionCount = CollisionCount;
            this.ObjectName = ObjectName;
            this.ObjectId = ObjectId;
        }
    }
}
