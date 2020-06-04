using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFSessions.Host
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IService1
    {

        [OperationContract(IsInitiating = true)]
        void InitData();


        [OperationContract(IsInitiating = false)]
        void AddData(string txt);


        [OperationContract(IsInitiating = false)]
        IEnumerable<string> GetData();


        [OperationContract(IsInitiating = false)]
        void WaitFor(int sekunden);

     //   [OperationContract(IsInitiating = false, AsyncPattern = true)]
     //   IAsyncResult WaitForIAsyncResult(int sekunden, AsyncCallback callback, object state);


        [OperationContract(IsInitiating = false, IsTerminating = true)]
        void Reset();
    }


}
