using System.Diagnostics;
using System.Text;

namespace Lab1Test;

class Program
{
    const string ErrorResult = "> error;";
    const string SuccessResult = "> success;";
    
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: ./Lab1Test <input-file> <output-file>");   
            return;
        }
        
        string inputFile = args[0];
        string outputFile = args[1];
        
        using (StreamReader reader = new StreamReader(inputFile))
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            while (!reader.EndOfStream)
            {
                string text = reader.ReadLine();
                string[] values = text.Split(" ");
                
                string expectedResult = values[values.Length - 1];
                values = values.Take(values.Length - 1).ToArray();
                string triangleArgs = string.Join(" ", values);
                
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.FileName = "./Lab1";
                process.StartInfo.Arguments = triangleArgs;
                process.Start();

                string result = process.StandardOutput.ReadToEnd().Trim();
                process.WaitForExit();

                if (expectedResult == result)
                {
                    writer.WriteLine(SuccessResult);
                }
                else
                {
                    Console.WriteLine($"{result} {expectedResult} {triangleArgs}");
                    writer.WriteLine(ErrorResult);
                }
            }
        }
    }
}