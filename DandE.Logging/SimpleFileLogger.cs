namespace DandE.Logging
{
    using Microsoft.Extensions.Logging;

    public class SimpleFileLogger : ILogger
    {
        private readonly string _filePath;
        private readonly LogLevel _minLevel;
        private readonly object _lock = new();

        public SimpleFileLogger(string filePath, LogLevel minLevel) 
        { 
            _filePath = filePath; 
            _minLevel = minLevel;
        }

        public IDisposable? BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) 
        {
            return logLevel >= _minLevel && _filePath != null;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;
            if (formatter == null) return;

            var message = formatter(state, exception);
            if (string.IsNullOrEmpty(message)) return;

            var logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{logLevel}] {message}";
            if (exception != null) logLine += $"{Environment.NewLine}{exception}";

            lock (_lock)
            {
                File.AppendAllText(_filePath, logLine + Environment.NewLine);
            }
        }
    }
}