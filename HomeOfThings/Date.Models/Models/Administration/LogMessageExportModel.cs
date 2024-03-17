namespace Date.Models.Models.Administration
{
    public class LogMessageExportModel
    {
        public int Id { get; set; }
        public string Trigger { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string ExceptionMessage { get; set; } = string.Empty;
        public string Stacktrace { get; set; } = string.Empty;
        public string TimeStamp { get; set; } = string.Empty;
    }
}
