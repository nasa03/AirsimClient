using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
    public enum WeatherParameter : int
    {
        Rain = 0,
        RoadWetness = 1,
        Snow = 2,
        RoadSnow = 3,
        MapleLeaf = 4,
        RoadLeaf = 5,
        Dust = 6,
        Fog = 7,
        Enabled
    }
}
