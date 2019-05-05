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
    /// Request for taking an image from a camera
    /// </summary>
    public class ImageRequest
    {
        /// <summary>
        /// The name of the camera from which the image is taken
        /// </summary>
        public string CameraName { get; private set; }


        /// <summary>
        /// The Type of image taken
        /// </summary>
        public ImageType ImageType { get; private set; }


        /// <summary>
        /// Are the pixels as floats, otherwise uint8's
        /// </summary>
        public bool PixelsAsFloat { get; private set; }


        /// <summary>
        /// Is the image compressed
        /// </summary>
        public  bool Compress { get; private set; }

        public ImageRequest(
            string CameraName,
            ImageType ImageType,
            bool PixelsAsFloat,
            bool Compress
            )
        {
            this.CameraName = CameraName;
            this.ImageType = ImageType;
            this.PixelsAsFloat = PixelsAsFloat;
            this.Compress = Compress;
        }
    }

    /// <summary>
    /// A response to the ImageRequest
    /// </summary>
    public class ImageResponse
    {
        /// <summary>
        /// Image data as byte array
        /// </summary>
        public byte[] ImageDataUInt8 { get; private set; }


        /// <summary>
        /// Image data as float array
        /// </summary>
        public float[] ImageDataFloat { get; private set; }


        /// <summary>
        /// The name of the camera from which the image was taken
        /// </summary>
        public string CameraName { get; private set; }


        /// <summary>
        /// The position of the camera from which the image was taken
        /// </summary>
        public Vector3 CameraPosition { get; private set; }


        /// <summary>
        /// The orientation of the camera from which the image was taken
        /// </summary>
        public Quaternion CameraOrientation { get; private set; }


        /// <summary>
        /// The timestamp at which the image was taken
        /// </summary>
        public ulong TimeStamp { get; private set; }


        public string Message { get; private set; }


        /// <summary>
        /// Specifies whether the image array is in floats
        /// </summary>
        public bool PixelsAsFloat { get; private set; }


        /// <summary>
        /// Specifies whether the image is compressed
        /// </summary>
        public bool Compress { get; private set; }


        /// <summary>
        /// The width, in pixels, of the image
        /// </summary>
        public int Width { get; private set; }


        /// <summary>
        /// The height, in pixels of the image
        /// </summary>
        public int Height { get; private set; }


        /// <summary>
        /// The type of the image
        /// </summary>
        public ImageType ImageType { get; private set; }

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

    /// <summary>
    /// Enumerations of the types of images that can be taken
    /// </summary>
    public enum ImageType : int
    {
        Scene = 0,
        DepthPlanner,
        DepthPerspective,
        DepthVis,
        DisparityNormalised,
        Segmentation,
        SurfaceNormals,
        Infrared,
        Count
    }
}
