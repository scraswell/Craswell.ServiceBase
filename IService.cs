using System.ServiceModel;

namespace Craswell.ServiceBase
{
    /// <summary>
    /// The service interface.
    /// </summary>
    [ServiceContract]////(Namespace = "http://craswell.net/servicebase/service")]
    public interface IService
    {
        /// <summary>
        /// The service test method.
        /// </summary>
        [OperationContract]
        Result Test();
    }
}

