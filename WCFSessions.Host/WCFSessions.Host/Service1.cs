using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCFSessions.Host
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,ConcurrencyMode =ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        List<string> data = new List<string>();

        public void AddData(string txt)
        {
            data.Add(txt);
            Debug.WriteLine($"Add s{OperationContext.Current.SessionId}");
        }

        public IEnumerable<string> GetData()
        {
            Debug.WriteLine($"Get s{OperationContext.Current.SessionId}");
            return data;
        }

        public void InitData()
        {
            Debug.WriteLine($"init s{OperationContext.Current.SessionId}");
            data.Add("hallo");
        }

        public void Reset()
        {
            Debug.WriteLine($"Reset s{OperationContext.Current.SessionId}");
            data = new List<string>();
        }

        public void WaitFor(int sekunden)
        {
            Thread.Sleep(sekunden * 1000);
        }

        public IAsyncResult WaitForIAsyncResult(int sekunden, AsyncCallback callback, object state)
        {
            var res = new WaitAsyncResult();
            
            Task.Delay(sekunden * 1000).ContinueWith(t => Fertig(callback, res));

            return res;
        }

        private void Fertig(AsyncCallback callback, WaitAsyncResult res)
        {
            callback.Invoke(res);
        }
    }

    class WaitAsyncResult : IAsyncResult
    {
        public bool IsCompleted { get; set; }

        public WaitHandle AsyncWaitHandle { get; set; }

        public object AsyncState { get; set; }

        public bool CompletedSynchronously { get; set; }
    }
}
