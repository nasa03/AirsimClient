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
    /// Adaptor for ImnageRequest for transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class ImageRequestRpc : IAdaptable<ImageRequest>
    {
        [Key("camera_name")]
        public string CameraName { get; set; }


        [JsonProperty("image_type")]
        [Key("image_type")]
        public ImageType ImageType { get; set; }


        [Key("pixels_as_float")]
        public bool PixelsAsFloat { get; set; }


        [Key("compress")]
        public bool Compress { get; set; }

        public ImageRequest AdaptTo()
        {
            return new ImageRequest(
                CameraName,
                ImageType,
                PixelsAsFloat,
                Compress
                );
        }

        internal static ImageRequestRpc AdaptFrom(ImageRequest request)
        {
            return new ImageRequestRpc()
            {
                CameraName = request.CameraName,
                Compress = request.Compress,
                ImageType = request.ImageType,
                PixelsAsFloat = request.PixelsAsFloat
            };

        }
    }

    /// <summary>
    /// Adaptor for  ImageResponse for Transfer over Rpc
    /// </summary>
    [MessagePackObject]
    internal class ImageResponseRpc : IAdaptable<ImageResponse>
    {
        [JsonProperty("image_data_uint8")]
        [Key("image_data_uint8")]
        public byte[] ImageDataUInt8 { get; set; }


        [JsonProperty("image_data_float")]
        [Key("image_data_float")]
        public float[] ImageDataFloat { get; set; }


        [Key("camera_name")]
        public string CameraName { get; set; }


        [JsonProperty("camera_position")]
        [Key("camera_position")]
        public Vector3Rpc CameraPosition { get; set; }


        [JsonProperty("camera_orientation")]
        [Key("camera_orientation")]
        public QuaternionRpc CameraOrientation { get; set; }


        [JsonProperty("time_stamp")]
        [Key("time_stamp")]
        public ulong TimeStamp { get; set; }


        [Key("message")]
        public string Message { get; set; }


        [Key("pixels_as_float")]
        public bool PixelsAsFloat { get; set; }


        [Key("compress")]
        public bool Compress { get; set; }


        [Key("width")]
        public int Width { get; set; }


        [Key("height")]
        public int Height { get; set; }


        [JsonProperty("image_type")]
        [Key("image_type")]
        public ImageType ImageType { get; set; }

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
