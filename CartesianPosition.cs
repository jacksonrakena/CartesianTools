using System;
using System.Collections.Generic;
using System.Linq;

namespace CartesianTools
{
    public class CartesianPosition : ICartesianPosition
    {
        public int PositionX { get; }
        public int PositionY { get; }

        public CartesianPosition(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public int GetPositionX(CartesianPlane plane)
        {
            return PositionX;
        }

        public int GetPositionY(CartesianPlane plane)
        {
            return PositionY;
        }

        public (int, int) GetPositionXY(CartesianPlane plane)
        {
            return (PositionX, PositionY);
        }

        public static IEnumerable<ICartesianPosition> CreateMap(int x, IEnumerable<int> y)
        {
            return y.Select(ypos => new CartesianPosition(x, ypos)).ToList();
        }

        public static IEnumerable<ICartesianPosition> CreateMap(IEnumerable<int> x, int y)
        {
            return x.Select(xpos => new CartesianPosition(xpos, y));
        }

        /// <summary>
        ///     Creates a map of Cartesian points. For each element of <code>x</code>, a Cartesian position will be generated
        ///     with that X co-ordinate and every co-ordinate (element) of <code>y</code>.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static IEnumerable<ICartesianPosition> CreateMap(IEnumerable<int> x, IEnumerable<int> y)
        {
            return (from x0 in x from y0 in y select new CartesianPosition(x0, y0)).ToList();
        }

        /// <summary>
        ///     Creates a map of Cartesian points by resolving using an algebraic function. For each <code>x</code> position 
        ///     (calculated from the width of the provided plane), a <code>y</code> position will be generated using <code>yResolve</code>.
        /// </summary>
        /// <param name="yResolve"></param>
        /// <param name="plane"></param>
        /// <returns></returns>
        public static IEnumerable<ICartesianPosition> CreateFunction(Func<int, int> yResolve, CartesianPlane plane)
        {
            var xLimit = plane.Configuration.Width;
            return (from x in Enumerable.Range(0, xLimit)
                    let y = yResolve(x)
                    where y <= plane.Configuration.Height
                    select new CartesianPosition(x, y)).ToList();
        }

        /// <summary>
        ///     Creates a line of Cartesian points ascending using the mathematical function <code>y = x</code>.
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        public static IEnumerable<ICartesianPosition> CreateLine(CartesianPlane plane) =>
            CreateFunction(x => x, plane);

        /// <summary>
        ///     Creates a reversed line of Cartesian points descending using the mathematical function <code>y = -x</code>.
        ///     <note>
        ///     This line is currently unable to be displayed on CartesianTools 0.1.0.
        ///     </note>
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        public static IEnumerable<ICartesianPosition> CreateReverseLine(CartesianPlane plane) =>
            CreateFunction(x => 0 - x, plane);
    }
}