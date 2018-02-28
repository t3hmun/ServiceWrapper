namespace t3h.ServiceWrapper
{
    using System.Configuration;
    using System.IO;
    using System.ServiceProcess;
    using Serilog;
    using Serilog.Events;

    public partial class WrapperService : ServiceBase
    {
        private readonly ILogger _logger;

        public WrapperService()
        {
            InitializeComponent();

            var config = ConfigurationManager.AppSettings;
            var logFolder = config["LogFolder"];
            var logLevelStr = config["LogLevel"];
            var logLevel = logLevelStr == "Information"
                ? LogEventLevel.Information
                : logLevelStr == "Debug"
                    ? LogEventLevel.Debug
                    : LogEventLevel.Verbose;

            var logFileName = "niceWrappedService.log";

            var logFilePath = Path.Combine(logFolder, logFileName);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(logFilePath, logLevel, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            _logger = Log.Logger.ForContext<WrapperService>();

            _logger.Information("Service Intitialising...");

            // Init the main class of your service here.

            _logger.Information("...service Intitialised.");
        }

        protected override void OnStart(string[] args)
        {
            _logger.Information("Service starting...");

            // Start the main process of your service here.

            _logger.Information("...service started.");
        }

        protected override void OnStop()
        {
            _logger.Information("Service stopping...");

            // Shutdown code for your service here.

            _logger.Information("...service stopped.");
        }
    }
}