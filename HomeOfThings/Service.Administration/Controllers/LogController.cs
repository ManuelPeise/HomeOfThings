﻿using Database.HotContext;
using Date.Models.Models.Administration;
using Logic.Administration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;

namespace Service.Administration.Controllers
{
    public class LogController: ApiControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogController(DatabaseContext databaseContext, IHttpContextAccessor httpContextAccessor)
        {
            _databaseContext = databaseContext;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet(Name ="GetLogMessages")]
        public async Task<List<LogMessageExportModel>> GetLogMessages()
        {
            var service = new MessageLogService(_databaseContext, _httpContextAccessor);

            return await service.LoadLogMessages();

        }

        [HttpPost("{id}", Name = "DeleteLogMessage")]
        public async Task<bool> DeleteLogMessage(int id)
        {
            var service = new MessageLogService(_databaseContext, _httpContextAccessor);

            return await service.DeleteMessage(id);
        }
    }
}
