using System;
using System.Collections.Generic;
using System.Diagnostics;

using SysMaint.Run.Models;

namespace SysMaint.Run {

    class Program {

        static void Main(string[] args) {

            try {

                var value = ReadLine.ReadPassword("Pwd:");

                var commands = new List<RunTask>() {
                    //Mount main drive
                    new RunTask() {FilePath=$@"""C:\Program Files\VeraCrypt\VeraCrypt.exe""", Arguments=$@"/q /v \Device\Harddisk0\Partition2 /l V /password {value}", TaskName="Mount Main Drive" },
                    //Mount Backup drive
                    new RunTask() {FilePath=$@"""C:\Program Files\VeraCrypt\VeraCrypt.exe""", Arguments=$@"/q /v \Device\Harddisk2\Partition1 /l W /password {value}", TaskName="Mount Backup Drive" },
                    //Create synctoy pair
                    new RunTask() {FilePath=$@"""C:\Program Files\SyncToy 2.1\Synctoy.exe""", Arguments=$@"-d(left=V:\,right=W:\bu-current\,name=bu_local_sd,operation=echo)", TaskName="Configure Backup Job" },
                    //Use synctoy to backup the SD card to the mounted volume
                    new RunTask() {FilePath=$@"""C:\Program Files\SyncToy 2.1\Synctoycmd.exe""", Arguments=$@"-R bu_local_sd", TaskName="Backup"  },
                     //Remove synctoy pair
                    new RunTask() {FilePath=$@"""C:\Program Files\SyncToy 2.1\Synctoy.exe""", Arguments=$@"-ubu_local_sd", TaskName="Teardown Backup Job"  }
                };

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
