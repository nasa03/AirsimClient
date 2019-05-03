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

namespace AirsimClient.Common
{
    /// <summary>
    /// Request for taking an image from a camera
    /// </summary>
    public class ImageRequest
    {
        /// <summary>
        /// The name of the camera from which the image is taken
        /// </summary>
        public readonly string CameraName;


        /// <summary>
        /// The Type of image taken
        /// </summary>
        public readonly ImageType ImageType;


        /// <summary>
        /// Are the pixels as floats, otherwise uint8's
        /// </summary>
        public readonly bool PixelsAsFloat;


        /// <summary>
        /// Is the image compressed
        /// </summary>
        public readonly bool Compress;

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
}
