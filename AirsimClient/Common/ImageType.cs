using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
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
