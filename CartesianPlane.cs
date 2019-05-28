using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartesianTools
{
    public class CartesianPlane
    {
        public CartesianPlane(CartesianConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public CartesianConfiguration Configuration { get; }
        
        private readonly List<CartesianPosition> _positions = new List<CartesianPosition>();

        public CartesianPlane InsertPosition(CartesianPosition position)
        {
            if (position.PositionX > Configuration.Width) throw new InvalidOperationException($"The provided Cartesian X position, {position.PositionX}, is bigger than the width of the Cartesian plane, {Configuration.Width}.");
            if (position.PositionY > Configuration.Height) throw new InvalidOperationException($"The provided Cartesian Y position, {position.PositionY}, is bigger than the height of the Cartesian plane, {Configuration.Height}.");
            _positions.Add(position);
            return this;
        }

        public CartesianPlane InsertPositions(IEnumerable<CartesianPosition> positions)
        {
            foreach (var position in positions)
            {
                InsertPosition(position);
            }

            return this;
        }

        public IEnumerable<CartesianPosition> GetPositions()
        {
            return _positions;
        }
        
        public string[] RenderMatrix()
        {
            return Configuration.Renderer.Render(this);
        }
    }
}