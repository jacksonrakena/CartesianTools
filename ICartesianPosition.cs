using System;
using System.Collections.Generic;
using System.Text;

namespace CartesianTools
{
    public interface ICartesianPosition
    {
        int GetPositionX(CartesianPlane plane);
        int GetPositionY(CartesianPlane plane);
        (int, int) GetPositionXY(CartesianPlane plane);
    }
}
