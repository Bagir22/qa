using System.Globalization;

namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Ошибка");
            return;
        }
        
        try
        {
            double[] sides = new Double[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                if (double.TryParse(args[i], NumberStyles.Any, CultureInfo.InvariantCulture, out double side))
                {  
                    sides[i] = side;
                }
                else
                {
                    Console.WriteLine("Ошибка");
                    return;
                }
            }

            Array.Sort(sides);
            
            var type = GetTriangleType(sides);
            Console.WriteLine(type);
        }
        catch 
        {
            Console.WriteLine("Ошибка");
            throw;
        }
    }
    
    private static string GetTriangleType(double[] sides)
    {
        if (sides[0] > 0 && sides[1] > 0 && sides[2] > 0)
        {
            if (sides[0] + sides[1] > sides[2])
            {
                if (sides[0] == sides[1] && sides[1] == sides[2])
                {
                    return "Равносторонний";
                }
                else if (sides[0] == sides[1] || sides[1] == sides[2] || sides[0] == sides[2])
                {
                    return "Равнобедренный";
                }

                return "Обычный";
            }
            
            return "Нетреугольник";
        }

        return "Ошибка";
    }
}