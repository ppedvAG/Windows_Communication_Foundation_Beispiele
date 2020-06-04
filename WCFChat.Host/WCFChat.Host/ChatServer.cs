using System;
using System.IO;
using System.ServiceModel;
using WCFChat.Contracts;

namespace WCFChat.Host
{
    class ChatServer : IServer
    {
        public void Login(string username)
        {
            Console.WriteLine($"Login {username}");

            OperationContext.Current.GetCallbackChannel<IClient>().LoginResponse(true);
            OperationContext.Current.GetCallbackChannel<IClient>().ShowText($"Hallo {username}");
        }

        public void Logout()
        {
            Console.WriteLine($"Logout");

            OperationContext.Current.GetCallbackChannel<IClient>().LogoutResponse(true);

        }

        public void SendImage(Stream image)
        {
            Console.WriteLine($"SendImage {image.Length}bytes");
        }

        public void SendText(string text)
        {
            Console.WriteLine($"SendText {text}");
        }

        public void SendVoice(Stream voice)
        {
            Console.WriteLine($"SendImage {voice.Length}bytes");
        }
    }
}
