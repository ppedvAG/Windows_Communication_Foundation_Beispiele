using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using WCFChat.Contracts;

namespace WCFChat.Host
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class ChatServer : IServer
    {
        Dictionary<string, IClient> users = new Dictionary<string, IClient>();

        public void Login(string username)
        {
            Console.WriteLine($"Login {username}");

            users.Add(username, OperationContext.Current.GetCallbackChannel<IClient>());

            OperationContext.Current.GetCallbackChannel<IClient>().LoginResponse(true);
            OperationContext.Current.GetCallbackChannel<IClient>().ShowText($"Hallo {username}");

            CallAll(x => x.ShowUserlist(users.Select(y => y.Key)));
        }

        public void Logout()
        {
            Console.WriteLine($"Logout");

            var usr = users.FirstOrDefault(x => x.Value == OperationContext.Current.GetCallbackChannel<IClient>());
            usr.Value.LogoutResponse(true);
            Logout(usr.Key);
        }

        private void Logout(string user)
        {
            Console.WriteLine($"Logout {user}");

            if (users.ContainsKey(user))
            {
                users.Remove(user);
                CallAll(x => x.ShowUserlist(users.Select(y => y.Key)));
            }
        }

        public void CallAll(Action<IClient> act)
        {
            foreach (var usr in users.ToList())
            {
                try
                {
                    act.Invoke(usr.Value);
                }
                catch (Exception)
                {
                    Logout(usr.Key);
                }
            }
        }


        public void SendImage(Stream image)
        {
            Console.WriteLine($"SendImage bytes");

            var ms = new MemoryStream();
            image.CopyTo(ms);
            CallAll(x =>
            {
                ms.Position = 0;
                x.ShowImage(ms);
            });
        }

        public void SendText(string text)
        {
            var usr = users.FirstOrDefault(x => x.Value == OperationContext.Current.GetCallbackChannel<IClient>());
            var msg = $"({DateTime.Now:T}) [{usr.Key}] {text}";
            Console.WriteLine($"SendText {msg}");
            CallAll(x => x.ShowText(msg));
        }

        public void SendVoice(Stream voice)
        {
            Console.WriteLine($"SendImage {voice.Length}bytes");
            //todo

        }
    }
}
