using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace WCFChat.Contracts
{
    [ServiceContract]
    public interface IClient
    {
        [OperationContract(IsOneWay = true)]
        void ShowText(string text);

        [OperationContract(IsOneWay = true)]
        void ShowImage(Stream image);

        [OperationContract(IsOneWay = true)]
        void ShowVoice(Stream voice);

        [OperationContract(IsOneWay = true)]
        void ShowUserlist(IEnumerable<string> users);

        [OperationContract(IsOneWay = true)]
        void LoginResponse(bool ok);

        [OperationContract(IsOneWay = true)]
        void LogoutResponse(bool ok);

    }
}
