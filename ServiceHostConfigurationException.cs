using System;
using System.Runtime.Serialization;

namespace Craswell.ServiceBase
{
    /// <summary>
    /// An exception thrown when the servicehost fails to open.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class ServiceHostConfigurationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHostConfigurationException"/> class.
        /// </summary>
        public ServiceHostConfigurationException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHostConfigurationException"/> class.
        /// </summary>
        /// <param name="message">The appSettings key that does not have a configured value.</param>
        public ServiceHostConfigurationException(
            string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHostConfigurationException"/> class.
        /// </summary>
        /// <param name="message">The appSettings key that does not have a configured value.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ServiceHostConfigurationException(
            string message,
            Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHostConfigurationException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization information.</param>
        /// <param name="streamingContext">The streaming context.</param>
        protected ServiceHostConfigurationException(
            SerializationInfo serializationInfo,
            StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
