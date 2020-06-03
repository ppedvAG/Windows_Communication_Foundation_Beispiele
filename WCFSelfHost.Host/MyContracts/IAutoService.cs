using System.Collections.Generic;
using System.ServiceModel;

namespace WCFSelfHost.Host
{
    [ServiceContract]
    public interface IAutoService
    {
        [OperationContract]
        IEnumerable<Auto> GetAutos();

        [OperationContract]
        [FaultContract(typeof(RosaAutoFault))]
        void AddAuto(Auto auto);
    }

    public class RosaAutoFault
    {
        public Auto Auto { get; set; }

        public int ErrorCount { get; set; }
    }

}
