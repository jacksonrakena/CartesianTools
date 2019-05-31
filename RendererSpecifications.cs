using System;
using System.Collections.Generic;
using System.Text;

namespace CartesianTools
{
    public class RendererSpecifications
    {
        public int MaxMapHeight { get; }
        public int MaxMapWidth { get; }

        public RendererSpecifications(int maxMapHeight, int maxMapWidth)
        {
            MaxMapHeight = maxMapHeight;
            MaxMapWidth = maxMapWidth;
        }
    }
}
