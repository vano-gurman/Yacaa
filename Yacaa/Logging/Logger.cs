using System;
using Yacaa.Interfaces.Logging;
using NLogManager = NLog.LogManager;
using NLogger = NLog.Logger;

namespace Yacaa.Logging
{
    public class Logger : ILogger
    {
        private readonly NLogger _logger = NLogManager.GetCurrentClassLogger();

        public void Trace(string message, params object[] args)
        {
            _logger.Trace(message, args);
        }

        public void Debug(string message, params object[] args)
        {
            _logger.Debug(message, args);
        }

        public void Info(string message, params object[] args)
        {
            _logger.Info(message, args);
        }

        public void Warn(string message, params object[] args)
        {
            _logger.Warn(message, args);
        }

        public void Error(string message, params object[] args)
        {
            _logger.Error(message, args);
        }

        public void Error(Exception exception, string message = null, params object[] args)
        {
            _logger.Error(exception, message, args);
        }

        public void Fatal(string message, params object[] args)
        {
            _logger.Fatal(message, args);
        }

        public void Fatal(Exception exception, string message = null, params object[] args)
        {
            _logger.Fatal(exception, message, args);
        }
    }
}