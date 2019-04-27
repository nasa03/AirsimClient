using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
    public class ImageRequest
    {
        public readonly string CameraName;


        public readonly ImageType ImageType;


        public readonly bool PixelsAsFloat;


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
