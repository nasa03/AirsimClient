using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Common
{
    public class ProjectionMatrix
    {
        public readonly float[][] Matrix;

        internal ProjectionMatrix(float[][] Matrix)
        {
            this.Matrix = Matrix;
        }
    }
}
