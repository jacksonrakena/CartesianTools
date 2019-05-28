using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartesianTools
{
    public class DefaultCartesianRenderer: ICartesianRenderer
    {
        public string[] Render(CartesianPlane plane)
        {
            var rows = new List<string>();
            
            foreach (var rowIndex in Enumerable.Range(0, plane.Configuration.Height))
            {
                var positions = plane.GetPositions();
                var row = new StringBuilder();
                row.Append(plane.Configuration.Height - rowIndex - 1 + " ");
                foreach (var rowPosition in Enumerable.Range(0, plane.Configuration.Width))
                {
                    var cart = positions.FirstOrDefault(p => p.PositionX == rowPosition && p.PositionY == plane.Configuration.Height - rowIndex - 1);
                    row.Append(cart != null ? "+" : "-");
                }

                rows.Add(row.ToString());
            }
            rows.Add("YX" + string.Join("", Enumerable.Range(0, plane.Configuration.Width)));

            return rows.ToArray();
        }
    }
}