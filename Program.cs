using System;
using System.IO;
using System.Linq;

namespace CartesianTools
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                File.Delete("output.txt");
            }
            catch
            {
                
            }
            var plane = new CartesianPlane(new CartesianConfiguration
            {
                Height = 10,
                Width = 10,
                Renderer = new DefaultCartesianRenderer()
            });

            plane.InsertPositions(CartesianPosition.CreateFunction(x => x^2, plane));
            Console.WriteLine(string.Join(Environment.NewLine, plane.RenderMatrix()));
            File.WriteAllText("output.txt", string.Join(Environment.NewLine, plane.RenderMatrix()));
            Console.ReadKey();
        }
    }
}