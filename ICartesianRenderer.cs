namespace CartesianTools
{
    /// <summary>
    ///     A generic interface representing a renderer capable of producing 2D Cartesian maps from a 
    ///     <see cref="CartesianPlane"/> entity.
    /// </summary>
    public interface ICartesianRenderer
    {
        /// <summary>
        ///     Checks whether this renderer is capable of rendering a specific <see cref="CartesianPlane"/>.
        /// </summary>
        /// <param name="plane">The <see cref="CartesianPlane"/> to check.</param>
        /// <returns>A boolean representing whether this renderer is capable of rendering the provided <see cref="CartesianPlane"/>.</returns>
        bool CanRenderPlane(CartesianPlane plane);

        /// <summary>
        ///     Attempts to render this a specific <see cref="CartesianPlane"/>.
        /// </summary>
        /// <param name="plane">The <see cref="CartesianPlane"/> to render.</param>
        /// <returns>A <see cref="RenderedMap"/> utility entity representing the renderered map.</returns>
        RenderedMap Render(CartesianPlane plane);
    }
}