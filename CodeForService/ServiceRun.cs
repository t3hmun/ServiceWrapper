namespace t3h.CodeForService
{
    using System.Threading;
    using Serilog;

    public class ServiceRun
    {
        private readonly ILogger _logger;
        private readonly AutoResetEvent _waiter = new AutoResetEvent(true);
        private bool _kill;
        private Thread _runThread;

        public ServiceRun(ILogger logger = null)
        {
            if (logger == null)
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .CreateLogger();
                _logger = Log.Logger;
            }
            else
            {
                _logger = logger.ForContext<ServiceRun>();
            }

            _logger.Debug("Hello from ServiceRun ctor.");
        }

        public void Start()
        {
            _runThread = new Thread(Run);
            _runThread.Start();
        }

        /// <summary>
        ///     This is a rather silly way to make a timer.
        /// </summary>
        private void Run()
        {
            while (!_kill)
            {
                DoThing();

                // Do the thing every 100 seconds.
                // Block the thread, wastes minimal CPU.
                _waiter.WaitOne(100000);
            }

            _logger.Information("Bye bye time.");
        }

        private void DoThing()
        {
            _logger.Information("Really useful service work happening.");
        }

        public void Stop()
        {
            _kill = true;
            _waiter.Set();
            _runThread?.Join(5000);
        }
    }
}