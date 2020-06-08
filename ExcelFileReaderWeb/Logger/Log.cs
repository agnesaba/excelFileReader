using Microsoft.Extensions.Logging;
using System;
namespace ExcelFileReaderWeb.Logger
{
    public class Log : ILog
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
            ILoggerFactory loggerFactory = new LoggerFactory();
            ILogger logger = loggerFactory.CreateLogger<Log>();
            logger.LogInformation(message);
        }
    }
}
