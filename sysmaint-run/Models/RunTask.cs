namespace SysMaint.Run.Models {

    class RunTaskData {
        public RunTask[] RunTasks;
    }

    class RunTask {
        public string FilePath { get; set; }
        public string Arguments { get; set; }
        public string TaskName { get; set; }
    }
}
