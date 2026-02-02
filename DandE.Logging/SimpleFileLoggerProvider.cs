namespace DandE.Logging
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    public class SimpleFileLoggerProvider : ILoggerProvider
    {
        private readonly string _filePath;
        private readonly LogLevel _minLevel;

        public SimpleFileLoggerProvider(IConfiguration config)
        {
             if (!config.GetValue<bool>("Logging:SimpleFile:Enabled", true)) return;

            // Timestamp once at startup
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), $"log-{timestamp}.txt");

            var levelStr = config.GetValue<string>("Logging:LogLevel:DandE.Logging");
            _minLevel = Enum.TryParse<LogLevel>(levelStr, ignoreCase: true, out var parsed)
                ? parsed
                : LogLevel.Information;
        }

        public ILogger CreateLogger(string categoryName) => new SimpleFileLogger(_filePath, _minLevel);

        public void Dispose() { }
    }
}