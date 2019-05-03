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
    /// Adaptor for  ImageResponse for Transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class ImageResponseRpc : IAdaptable<ImageResponse>
    {
        [JsonProperty("image_data_uint8")]
        internal byte[] ImageDataUInt8 { get; set; }


        [JsonProperty("image_data_float")]
        internal float[] ImageDataFloat { get; set; }


        [JsonProperty("camera_name")]
        internal string CameraName { get; set; }


        [JsonProperty("camera_position")]
        internal Vector3Rpc CameraPosition { get; set; }


        [JsonProperty("camera_orientation")]
        internal QuaternionRpc CameraOrientation { get; set; }


        [JsonProperty("time_stamp")]
        internal ulong TimeStamp { get; set; }


        [JsonProperty("message")]
        internal string Message { get; set; }


        [JsonProperty("pixels_as_float")]
        internal bool PixelsAsFloat { get; set; }


        [JsonProperty("compress")]
        internal bool Compress { get; set; }


        [JsonProperty("width")]
        internal int Width { get; set; }


        [JsonProperty("height")]
        internal int Height { get; set; }


        [JsonProperty("image_type")]
        internal ImageType ImageType { get; set; }

        public ImageResponse AdaptTo()
        {
            return new ImageResponse(
                ImageDataUInt8,
                ImageDataFloat,
                CameraName,
                CameraPosition.AdaptTo(),
                CameraOrientation.AdaptTo(),
                TimeStamp,
                Message,
                PixelsAsFloat,
                Compress,
                Width,
                Height,
                ImageType
                );
        }
    }
}
