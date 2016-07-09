using System;

using Craswell.Common;
using log4net;

namespace Craswell.ServiceBase
{
    /// <summary>
    /// The service.
    /// </summary>
    public class Service : Disposable, IService
    {
        /// <summary>
        /// The service logger.
        /// </summary>
        private ILog serviceLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Craswell.Service.Service"/> class.
        /// </summary>
        /// <param name="serviceLogger">The service logger.</param>
        public Service(
            ILog serviceLogger,
            ServiceConfiguration serviceConfiguration)
        {
            if (serviceLogger == null)
            {
                throw new ArgumentNullException(nameof(serviceLogger));
            }

            this.serviceLogger = serviceLogger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Craswell.Service.Service"/> class.
        /// </summary>
        public Service()
            : this(
                LogManager.GetLogger(nameof(Service)),
                new ServiceConfiguration())
        {
        }

        /// <summary>
        /// Tests the service.
        /// </summary>
        public Result Test()
        {
            this.serviceLogger.Info("Test method called.");

            return new Result()
            {
                Number = 0
            };
        }

        /// <summary>
        /// Disposes managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">A value indicating whether the instance is disposing.</param>
        protected override void Dispose(bool disposing)
        {
        }
    }
}

