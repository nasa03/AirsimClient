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
    /// The current state of the environment
    /// </summary>
    public class EnvironmentState
    {

        public Vector3 Position { get; private set; }


        public  Vector3 Gravity { get; private set; }


        public float AirPressure { get; private set; }


        public float Temperature { get; private set; }


        public float AirDensity { get; private set; }
        
        public  EnvironmentState(
            Vector3 Position, 
            Vector3 Gravity,
            float AirPressure,
            float Temperature,
            float AirDensity
            )
        {
            this.Position = Position;
            this.Gravity = Gravity;
            this.AirPressure = AirPressure;
            this.Temperature = Temperature;
            this.AirDensity = AirDensity;
        }
    }
}
