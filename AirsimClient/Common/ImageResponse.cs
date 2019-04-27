using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
    public class ImageResponse
    {
        public readonly byte[] ImageDataUInt8;


        public readonly float[] ImageDataFloat;


        public readonly string CameraName;


        public readonly Vector3 CameraPosition;


        public readonly Quaternion CameraOrientation;


        public readonly ulong TimeStamp;


        public readonly string Message;


        public readonly bool PixelsAsFloat;


        public readonly bool Compress;


        public readonly int Width, Height;


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
