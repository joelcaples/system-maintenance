using System;
using System.Collections.Generic;

namespace login_tasks {

    class Program {

        static void Main(string[] args) {

            try {
                Console.Write("Pwd: ");
                var value = ReadLine.ReadPassword("Pwd:");

                var commands = new List<string>() {
                    $@"""C:\Program Files\VeraCrypt\VeraCrypt.exe"" /q /v \Device\Harddisk0\Partition2 /l V /password {value}",
                    $@"""C:\Program Files\VeraCrypt\VeraCrypt.exe"" /q /v \Device\Harddisk2\Partition1 /l W /password {value}"
                };

                foreach (var cmd in commands) {
                    System.Diagnostics.Process.Start("CMD.exe", $@"/C {cmd}");
                }
            }
            catch (Exception) { }
        }
    }
}
