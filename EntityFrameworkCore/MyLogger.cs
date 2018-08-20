using System;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore
{
    public class MyLogger : ILoggerFactory
    {
        private PrivLogger _logger;
        
        public void AddProvider(ILoggerProvider provider)
        {
            throw new System.NotImplementedException();
        }

        public ILogger CreateLogger(string categoryName)
        {
            if (this._logger == null)
            {
                this._logger = new PrivLogger();                
            }

            return this._logger;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        private class PrivLogger : ILogger
        {
            public static NLog.Logger _nlogLogger;

            public PrivLogger()
            {
                if (_nlogLogger == null)
                {
                    _nlogLogger = NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
                }
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                switch (logLevel)
                {
                    // not logging debug info
                    case LogLevel.Debug:
                        return false;

                    default:
                        return true;
                }
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                var message = formatter(state, exception);
                
                switch (logLevel)
                {
                    case LogLevel.Critical:
                        _nlogLogger.Log(NLog.LogLevel.Fatal, message);
                        break;

                    case LogLevel.Debug:
                        _nlogLogger.Log(NLog.LogLevel.Debug, message);
                        break;

                    case LogLevel.Error:
                        _nlogLogger.Log(NLog.LogLevel.Error, message);
                        break;

                    case LogLevel.Information:
                        _nlogLogger.Log(NLog.LogLevel.Info, message);
                        break;

                    case LogLevel.None:
                        _nlogLogger.Log(NLog.LogLevel.Trace, message);
                        break;

                    case LogLevel.Warning:
                        _nlogLogger.Log(NLog.LogLevel.Warn, message);
                        break;
                }

                
            }
        }
    }

    
}
