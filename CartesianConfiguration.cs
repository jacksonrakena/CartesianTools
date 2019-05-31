namespace CartesianTools
{
    /// <summary>
    ///     A data entity holding information for a <see cref="CartesianPlane"/>.
    /// </summary>
    public class CartesianConfiguration
    {
        /// <summary>
        ///     The height of the plane.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        ///     The width of the plane.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        ///     The renderer to use when rendering the plane. The renderer must support this plane,
        ///     which is validated by using the <see cref="ICartesianRenderer.CanRenderPlane(CartesianPlane)"/> method.
        ///     Defaults to <see cref="DefaultCartesianRenderer"/>.
        /// </summary>
        public ICartesianRenderer Renderer
        {
            get
            {
                return _renderer ?? DefaultCartesianRenderer.Instance;
            }
            set
            {
                _renderer = value;
            }
        }

        private ICartesianRenderer _renderer;
    }
}