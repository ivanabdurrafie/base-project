using todo_api.Application.Common.Interfaces;
using System;

namespace todo_api.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
