using System;
using System.Collections.Generic;
using System.Text;

namespace CartesianTools
{
    public class LazyCartesianPosition : ICartesianPosition
    {
        public int GetPositionX(CartesianPlane plane)
        {
            throw new NotImplementedException();
        }

        public (int, int) GetPositionXY(CartesianPlane plane)
        {
            throw new NotImplementedException();
        }

        public int GetPositionY(CartesianPlane plane)
        {
            throw new NotImplementedException();
        }
    }
}
