using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace WCFSelfHost.Host
{
    [ServiceContract]
    public interface IAutoService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Autos")]
        IEnumerable<Auto> GetAutos();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "Autos")]
        [FaultContract(typeof(RosaAutoFault))]
        void AddAuto(Auto auto);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "AddAuto")]
        void UpdateAuto(Auto auto);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DelAuto")]
        void DeleteAuto(Auto auto);
    }

    public class RosaAutoFault
    {
        public Auto Auto { get; set; }

        public int ErrorCount { get; set; }
    }

}
