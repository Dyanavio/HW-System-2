using System.Diagnostics;

namespace HW_System_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process()
            { 
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent + @"\Child\bin\Debug\net9.0\Child.exe",
                    UseShellExecute = true,
                    CreateNoWindow = false
                }
            };

            try
            {
                process.Start();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("CHILD PROCESS LAUNCHED");

                Console.ResetColor();
                Console.WriteLine($"ID: {process.Id}");
                process.WaitForExit();

                Console.ResetColor();
                Console.WriteLine($"\nTotal (relative) time: {process.ExitTime - process.StartTime} s");
                
                Console.WriteLine($"Exit code: {process?.ExitCode}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            finally
            {
                Console.ResetColor();
            }

        }
    }
}
