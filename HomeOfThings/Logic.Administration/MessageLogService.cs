using Database.HotContext;
using Date.Models.Entities.Log;
using Date.Models.Models.Administration;
using Logic.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            TimeStamp = message.TimeStamp.ToString("dd.MM.yyyy - HH:mm:ss")
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

        public async Task<bool> ThrowException()
        {
            try
            {
                throw new Exception("This is a exception!");

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

                return true;
            }
        }
    }
}
