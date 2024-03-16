using System.ComponentModel.DataAnnotations;

namespace Date.Models.Entities.Log
{
    public class LogEntity: AEntityBase, IEntityBase
    {
        public int Id => LogMessageId;
        [Key]
        public int LogMessageId { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ExMessage { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Trigger { get; set; } = string.Empty;
    }
}
