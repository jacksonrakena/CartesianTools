using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartesianTools
{
    /// <summary>
    ///     The default <see cref="ICartesianRenderer"/> for the CartesianTools library.
    /// </summary>
    public class DefaultCartesianRenderer : ICartesianRenderer
    {
        public readonly static int MaxMapWidth = 100;
        public readonly static int MaxMapHeight = 100;

        public readonly static DefaultCartesianRenderer Instance = new DefaultCartesianRenderer();

        /// <inheritdoc />
        public bool CanRenderPlane(CartesianPlane plane)
        {
            return !(plane.Configuration.Width > MaxMapWidth
                || plane.Configuration.Height > MaxMapHeight);
        }

        /// <inheritdoc />
        public RenderedMap Render(CartesianPlane plane)
        {
            var rows = new List<string>();
            
            foreach (var rowIndex in Enumerable.Range(0, plane.Configuration.Height))
            {
                var positions = plane.GetPositions();
                var row = new StringBuilder();
                row.Append(plane.Configuration.Height - rowIndex - 1 + " ");
                foreach (var rowPosition in Enumerable.Range(0, plane.Configuration.Width))
                {
                    var cart = positions.Any(p => p.GetPositionX(plane) == rowPosition && p.GetPositionY(plane) == plane.Configuration.Height - rowIndex - 1);
                    row.Append(cart ? "+" : "-");
                }

                rows.Add(row.ToString());
            }
            rows.Add("YX" + string.Join("", Enumerable.Range(0, plane.Configuration.Width)));

            return new RenderedMap(rows);
        }
    }
}