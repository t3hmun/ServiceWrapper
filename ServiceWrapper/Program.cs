namespace t3h.ServiceWrapper
{
    using System;
    using CodeForService;

    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        private static void Main()
        {
#if DEBUG
            var serviceRun = new ServiceRun();
            serviceRun.Start();
            while (!Console.KeyAvailable)
            {
                
            }
            serviceRun.Stop();
            Console.WriteLine(@"bye bye");

#else
            var servicesToRun = new ServiceBase[]
            {
                new WrapperService()
            };
            ServiceBase.Run(servicesToRun);
#endif
        }
    }
}