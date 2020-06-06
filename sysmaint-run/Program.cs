using System;
using System.Diagnostics;

namespace SysMaint.Run {

    class Program {

        static void Main(string[] args) {

            try {

                var value = ReadLine.ReadPassword("Pwd:");
                var commands = ConfigLogic.GetTasks();

                foreach (var cmd in commands) {
                    var process = new Process() {
                        StartInfo = new ProcessStartInfo() {
                            FileName = cmd.FilePath,
                            Arguments = cmd.Arguments
                        }
                    };
                    try {
                        Console.WriteLine($@"Running {cmd.TaskName}...");
                        process.Start();
                        process.WaitForExit();
                    } catch (Exception e) {
                        Console.WriteLine($@"{process.StartInfo.FileName} {process.StartInfo.Arguments}");
                        throw (e);
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
