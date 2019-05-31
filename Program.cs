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
                Width = 10
            });

            plane.InsertPositions(CartesianPosition.CreateFunction(x => x^2, plane));
            Console.WriteLine(string.Join(Environment.NewLine, plane.Render()));
            File.WriteAllText("output.txt", string.Join(Environment.NewLine, plane.Render()));
            Console.ReadKey();
        }
    }
}