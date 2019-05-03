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

namespace AirsimClient.Common
{
    /// <summary>
    /// A response to the ImageRequest
    /// </summary>
    public class ImageResponse
    {
        /// <summary>
        /// Image data as byte array
        /// </summary>
        public readonly byte[] ImageDataUInt8;


        /// <summary>
        /// Image data as float array
        /// </summary>
        public readonly float[] ImageDataFloat;


        /// <summary>
        /// The name of the camera from which the image was taken
        /// </summary>
        public readonly string CameraName;


        /// <summary>
        /// The position of the camera from which the image was taken
        /// </summary>
        public readonly Vector3 CameraPosition;


        /// <summary>
        /// The orientation of the camera from which the image was taken
        /// </summary>
        public readonly Quaternion CameraOrientation;


        /// <summary>
        /// The timestamp at which the image was taken
        /// </summary>
        public readonly ulong TimeStamp;


        public readonly string Message;


        /// <summary>
        /// Specifies whether the image array is in floats
        /// </summary>
        public readonly bool PixelsAsFloat;


        /// <summary>
        /// Specifies whether the image is compressed
        /// </summary>
        public readonly bool Compress;


        /// <summary>
        /// The width, in pixels, of the image
        /// </summary>
        public readonly int Width;
            

        /// <summary>
        /// The height, in pixels of the image
        /// </summary>
        public readonly int Height;


        /// <summary>
        /// The type of the image
        /// </summary>
        public readonly ImageType ImageType;

        internal ImageResponse(
            byte[] ImageDataUInt8,
            float[] ImageDataFloat,
            string CameraName,
            Vector3 CameraPosition,
            Quaternion CameraOrientation,
            ulong TimeStamp,
            string Message,
            bool PixelsAsFloat,
            bool Compress,
            int Width,
            int Height,
            ImageType ImageType
            )
        {
            this.ImageDataUInt8 = ImageDataUInt8;
            this.ImageDataFloat = ImageDataFloat;
            this.CameraName = CameraName;
            this.CameraPosition = CameraPosition;
            this.CameraOrientation = CameraOrientation;
            this.TimeStamp = TimeStamp;
            this.Message = Message;
            this.PixelsAsFloat = PixelsAsFloat;
            this.Compress = Compress;
            this.Width = Width;
            this.Height = Height;
            this.ImageType = ImageType;
        }
    }
}
