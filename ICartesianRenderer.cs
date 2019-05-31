namespace CartesianTools
{
    public interface ICartesianRenderer
    {
        bool CanRenderPlane(CartesianPlane plane);
        RenderedMap Render(CartesianPlane plane);
    }
}