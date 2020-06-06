using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;
using SysMaint.Run.Models;

namespace SysMaint.Run {
    static class ConfigLogic {
        public static IEnumerable<RunTask> GetTasks() {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            var results = JsonConvert.DeserializeObject<RunTaskData>(File.ReadAllText(filePath));

            return results.RunTasks;

        }
    }
}
