using System;
using System.IO;
using System.Configuration;

using log4net;
using log4net.Config;
using Craswell.Common;

namespace Craswell.ServiceBase
{
    /// <summary>
    /// The service wrapper, derive a class with a Main(string[] args) method
    /// and call StartService(args) to start the service.
    /// </summary>
    public abstract class ServiceWrapper<T, TService>
        where T : Host<TService>, new()
        where TService : Service, IService, new()
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        protected static void StartService(string[] args)
        {
            InitializeLogging();

            if (args.Length == 1
                && (args[0].ToLowerInvariant() == "--interactive"
                    || args[0].ToLowerInvariant() == "-i"))
            {
                RunServiceInteractively(args);
            }
            else
            {
                RunService(args);
            }
        }

        /// <summary>
        /// Runs the service interactively.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        private static void RunServiceInteractively(string[] args)
        {
            using (var service = new T())
            {
                service.Run(args);

                Console.WriteLine("Press a key to stop the service.");
                Console.ReadKey();
                service.Halt();
            }
        }

        /// <summary>
        /// Runs the service.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        private static void RunService(string[] args)
        {
            System.ServiceProcess
                  .ServiceBase.Run(new T());
        }

        /// <summary>
        /// Initializes Log4Net.
        /// </summary>
        private static void InitializeLogging()
        {
            if (!LogManager.GetRepository().Configured)
            {
                XmlConfigurator.ConfigureAndWatch(
                    GetLoggingConfigurationFile());
            }
        }

        /// <summary>
        /// Gets the logging configuration.
        /// </summary>
        /// <returns>The logging configuration.</returns>
        private static FileInfo GetLoggingConfigurationFile()
        {
            var configuration = new ServiceConfiguration();
            var loggingConfigurationFile = new FileInfo(
                configuration.LoggingConfigurationFileName);

            if (!loggingConfigurationFile.Exists)
            {
                throw new FileNotFoundException(
                    loggingConfigurationFile.FullName);
            }

            return loggingConfigurationFile;
        }
    }
}
