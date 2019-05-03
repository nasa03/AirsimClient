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
    /// <summary>
    /// Adapts the CollisionInfo for transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class CollisionInfoRpc : IAdaptable<CollisionInfo>
    {
        [JsonProperty("has_collided")]
        internal bool HasCollided { get; set; }


        [JsonProperty("normal")]
        internal Vector3Rpc Normal { get; set; }


        [JsonProperty("impact_point")]
        internal Vector3Rpc ImpactPoint { get; set; }


        [JsonProperty("position")]
        internal Vector3Rpc Position { get; set; }


        [JsonProperty("penetration_depth")]
        internal float PenetrationDepth { get; set; }


        [JsonProperty("time_stamp")]
        internal ulong TimeStamp { get; set; }


        [JsonProperty("collision_count")]
        internal uint CollisionCount { get; set; }


        [JsonProperty("object_name")]
        internal string ObjectName { get; set; }


        [JsonProperty("object_id")]
        internal int ObjectId { get; set; }

        public CollisionInfo AdaptTo()
        {
            return new CollisionInfo(
                HasCollided,
                Normal.AdaptTo(),
                ImpactPoint.AdaptTo(),
                Position.AdaptTo(),
                PenetrationDepth,
                TimeStamp,
                CollisionCount,
                ObjectName,
                ObjectId);
        }

        internal static CollisionInfoRpc AdaptFrom(CollisionInfo info)
        {
            return new CollisionInfoRpc()
            {
                CollisionCount = info.CollisionCount,
                HasCollided = info.HasCollided,
                ImpactPoint = Vector3Rpc.AdaptFrom(info.ImpactPoint),
                Normal = Vector3Rpc.AdaptFrom(info.Normal),
                ObjectId = info.ObjectId,
                TimeStamp = info.TimeStamp,
                ObjectName = info.ObjectName,
                PenetrationDepth = info.PenetrationDepth,
                Position = Vector3Rpc.AdaptFrom(info.Position)
                
            };

        }


    }
}
