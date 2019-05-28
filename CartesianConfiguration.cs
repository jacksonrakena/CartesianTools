namespace CartesianTools
{
    public class CartesianConfiguration
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public ICartesianRenderer Renderer { get; set; }
    }
}