using System;
using System.Configuration;

using Craswell.Common;

namespace Craswell.ServiceBase
{
    /// <summary>
    /// The service configuration.
    /// </summary>
    public class ServiceConfiguration
    {
        /// <summary>
        /// The service name key.
        /// </summary>
        private const string ServiceNameKey = "ServiceName";

        /// <summary>
        /// The logging configuration file name key.
        /// </summary>
        private const string LoggingConfigurationFileNameKey = "LoggingConfigurationFileName";

        /// <summary>
        /// The logging configuration file name default.
        /// </summary>
        private const string LoggingConfigurationFileNameDefault = "logging.config";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Craswell.ServiceBase.ServiceConfiguration"/> class.
        /// </summary>
        public ServiceConfiguration()
        {
            this.Name = ConfigurationManager.AppSettings
                .Get<string>(ServiceNameKey);

            this.LoggingConfigurationFileName = ConfigurationManager.AppSettings
                .Get<string>(LoggingConfigurationFileNameKey, LoggingConfigurationFileNameDefault);
        }

        /// <summary>
        /// Gets the service name.
        /// </summary>
        /// <value>The service name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the name of the logging configuration file.
        /// </summary>
        /// <value>The name of the logging configuration file.</value>
        public string LoggingConfigurationFileName { get; private set; }
    }
}

