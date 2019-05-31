namespace CartesianTools
{
    public interface ICartesianRenderer
    {
        RendererSpecifications GetSpecifications();
        bool CheckSpecifications(CartesianPlane plane);
        RenderedMap Render(CartesianPlane plane);
    }
}