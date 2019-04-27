using Microsoft.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
    public class EnvironmentState
    {
        public readonly Vector3 Position;


        public readonly GeographyPoint GeoPoint;


        public readonly Vector3 Gravity;


        public readonly float AirPressure;


        public readonly float Temperature;


        public readonly float AirDensity;
        
        internal EnvironmentState(
            Vector3 Position, 
            GeographyPoint GeoPoint, 
            Vector3 Gravity,
            float AirPressure,
            float Temperature,
            float AirDensity
            )
        {
            this.Position = Position;
            this.GeoPoint = GeoPoint;
            this.Gravity = Gravity;
            this.AirPressure = AirPressure;
            this.Temperature = Temperature;
            this.AirDensity = AirDensity;
        }
    }
}
