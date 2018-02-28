namespace ServiceWrapper
{
    using System.ServiceProcess;
    using t3h.ServiceWrapper;

    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WrapperService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}