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

namespace AirsimClient.Car
{
    /// <summary>
    /// Controls sent to the car
    /// </summary>
    public class CarControls
    {
        /// <summary>
        /// Specifies the amount of Throttle -1.0f to 1.0f
        /// </summary>
        public float Throttle { get; set; }


        /// <summary>
        /// Specifies the amount of Steering -1.0f to 1.0f (Left/Right)
        /// </summary>
        public float Steering { get; set; }


        /// <summary>
        /// Specifies the strength of the brake on the car 0.0f to 1.0f
        /// </summary>
        public float Brake { get; set; }


        /// <summary>
        /// Specifies whether the Handbrake is engaged
        /// </summary>
        public bool Handbrake { get; set; }


        /// <summary>
        /// Specifies whether or not manual gear is engaged
        /// </summary>
        public bool IsManualGear { get; set; }


        /// <summary>
        /// Specifies which gear is engaged 0 to 5
        /// </summary>
        public int ManualGear { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public bool GearImmediate { get; set; }
    }
}
