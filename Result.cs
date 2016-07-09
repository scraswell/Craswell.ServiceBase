using System.Runtime.Serialization;

namespace Craswell.ServiceBase
{
    /// <summary>
    /// A result.
    /// </summary>
    [DataContract]
    public class Result
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [DataMember]
        public int Number { get; set; }
    }
}

