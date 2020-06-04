using System.IO;
using System.ServiceModel;

namespace WCFChat.Contracts
{
    [ServiceContract(CallbackContract = typeof(IClient))]
    public interface IServer
    {
        [OperationContract(IsOneWay = true)]
        void SendText(string text);

        [OperationContract(IsOneWay = true)]
        void SendImage(Stream image);

        [OperationContract(IsOneWay = true)]
        void SendVoice(Stream voice);

        [OperationContract(IsOneWay = true)]
        void Login(string username);

        [OperationContract(IsOneWay = true)]
        void Logout();
    }
}
