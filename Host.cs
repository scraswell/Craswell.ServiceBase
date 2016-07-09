using System;
using System.ServiceModel;

using log4net;

namespace Craswell.ServiceBase
{
    /// <summary>
    /// The service host.
    /// </summary>
    public class Host<T>
        : System.ServiceProcess.ServiceBase
    {
        /// <summary>
        /// The service logger.
        /// </summary>
        private ILog serviceLogger = LogManager.GetLogger(typeof(T));

        /// <summary>
        /// The service host.
        /// </summary>
        private ServiceHost serviceHost = new ServiceHost(typeof(T));

        /// <summary>
        /// The service configuration.
        /// </summary>
        private ServiceConfiguration serviceConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Craswell.ServiceBase.Host`1"/> class.
        /// </summary>
        /// <param name="serviceConfiguration">The service configuration.</param>
        public Host(ServiceConfiguration serviceConfiguration)
        {
            if (serviceConfiguration == null)
            {
                throw new ArgumentNullException(nameof(serviceConfiguration));
            }

            this.serviceConfiguration = serviceConfiguration;
            this.ServiceName = this.serviceConfiguration.Name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Craswell.ServiceBase.Host`1"/> class.
        /// </summary>
        public Host()
            : this(new ServiceConfiguration())
        {
        }

        /// <summary>
        /// Runs the service with the specified arguments.
        /// </summary>
        /// <param name="args">Arguments supplied at the command prompt.</param>
        public void Run(string[] args)
        {
            this.OnStart(args);
        }

        /// <summary>
        /// Halts the service.
        /// </summary>
        public void Halt()
        {
            this.OnStop();
        }

        /// <summary>
        /// Handles the request to start the service.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            this.serviceLogger.InfoFormat(
                "Starting {0}...",
                this.ServiceName);

            try
            {
                this.serviceHost.Open();
            }
            catch (Exception e)
            {
                var exception = new ServiceHostConfigurationException(
                    "Failed to open the service host.",
                    e);

                this.serviceLogger.Error(
                    exception.Message,
                    exception);

                throw exception;
            }
        }

        /// <summary>
        /// Handles the request to stop the service.
        /// </summary>
        protected override void OnStop()
        {
            this.serviceLogger.InfoFormat(
                "Stopping {0}...",
                this.ServiceName);

            this.serviceHost.Close();

            base.OnStop();
        }

        /// <summary>
        /// Disposes of managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">A value indicating whether the instance is disposing.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (this.serviceHost != null)
            {
                this.serviceHost.Close();
                ((IDisposable)this.serviceHost).Dispose();

                this.serviceHost = null;
            }
        }
    }
}

