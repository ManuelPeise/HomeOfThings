using Database.HotContext;
using Date.Models.Entities.Log;
using Date.Models.Models.Administration;
using Logic.Shared;
using Microsoft.AspNetCore.Http;

namespace Logic.Administration
{
    public class MessageLogService : ALogicBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessageLogService(DatabaseContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<LogMessageExportModel>> LoadLogMessages()
        {
            try
            {
                var logMessageEntities = await LogRepository.GetAllAsync();

                return (from message in logMessageEntities
                        select new LogMessageExportModel
                        {
                            Id = message.Id,
                            Message = message.Message,
                            ExceptionMessage = message.ExMessage,
                            Stacktrace = message.StackTrace,
                            Trigger = message.Trigger,
                            TimeStamp = message.TimeStamp.ToString("yyyy-MM-ddTHH:mm:ss")
                        }).ToList();

            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = "Loading log messages from database failed!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace,
                    Trigger = nameof(MessageLogService),
                    TimeStamp = DateTime.UtcNow,
                });

                await Save(_httpContextAccessor.HttpContext);

                return new List<LogMessageExportModel>();
            }
        }

        public async Task<bool> DeleteMessage(int id)
        {
            try
            {
                LogRepository.DeleteMessage(id);

                await Save(_httpContextAccessor.HttpContext);

                return true;
            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = $"Could not delete log message [{id}] from database failed!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace,
                    Trigger = nameof(MessageLogService),
                    TimeStamp = DateTime.UtcNow,
                });

                await Save(_httpContextAccessor.HttpContext);

                return true;
            }
        }
    }
}
