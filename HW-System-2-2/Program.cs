using System.Diagnostics;

namespace HW_System_2_2
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

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("User's option (1 - kill | else - wait for exit): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Killing the process");
                        process.Kill();
                        break;
                    default:
                        Console.WriteLine("Waiting for the process to exit");
                        process.WaitForExit();
                        break;
                }
                Console.ResetColor();
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
