using AirsimClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Car
{
    public class CarControls
    {
        public float Throttle { get; set; }


        public float Steering { get; set; }


        public float Brake { get; set; }


        public bool Handbrake { get; set; }


        public bool IsManualGear { get; set; }


        public int ManualGear { get; set; }


        public bool GearImmediate { get; set; }
    }
}
