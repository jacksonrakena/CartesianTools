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

            if (!Configuration.Renderer.CanRenderPlane(this)) throw new ArgumentException(
                $"Configuration violates the specifications for {Configuration.Renderer.GetType().Name}.",
                nameof(Configuration));
        }
        
        public CartesianConfiguration Configuration { get; }
        
        private readonly List<ICartesianPosition> _positions = new List<ICartesianPosition>();

        public CartesianPlane InsertPosition(ICartesianPosition position)
        {
            var (x, y) = position.GetPositionXY(this);
            if (x > Configuration.Width) throw new InvalidOperationException($"The provided Cartesian X position, {x}, is bigger than the width of the Cartesian plane, {Configuration.Width}.");
            if (y > Configuration.Height) throw new InvalidOperationException($"The provided Cartesian Y position, {y}, is bigger than the height of the Cartesian plane, {Configuration.Height}.");
            _positions.Add(position);
            return this;
        }

        public CartesianPlane InsertPositions(IEnumerable<ICartesianPosition> positions)
        {
            foreach (var position in positions)
            {
                InsertPosition(position);
            }

            return this;
        }

        public IEnumerable<ICartesianPosition> GetPositions()
        {
            return _positions;
        }
        
        public RenderedMap Render()
        {
            return Configuration.Renderer.Render(this);
        }
    }
}