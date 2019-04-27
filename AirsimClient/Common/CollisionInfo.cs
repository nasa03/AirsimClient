using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
    public class CollisionInfo
    {
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
