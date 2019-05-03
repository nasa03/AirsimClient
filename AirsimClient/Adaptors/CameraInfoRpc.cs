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
    /// Adapts the CameraInfo for transer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class CameraInfoRpc : IAdaptable<CameraInfo>
    {
        [JsonProperty("pose")]
        internal PoseRpc Pose { get; set; }


        [JsonProperty("fov")]
        internal float FOV { get; set; }


        [JsonProperty("proj_mat")]
        internal ProjectionMatrixRpc ProjMat { get; set; }

        public CameraInfo AdaptTo()
        {
            return new CameraInfo(Pose.AdaptTo(), FOV, ProjMat.AdaptTo());
        }

        internal static CameraInfoRpc AdaptFrom(CameraInfo info)
        {
            return new CameraInfoRpc()
            {
                Pose = PoseRpc.AdaptFrom(info.Pose),
                FOV = info.FOV,
                ProjMat = ProjectionMatrixRpc.AdaptFrom(info.ProjMat)
            };
        }
    }
}
