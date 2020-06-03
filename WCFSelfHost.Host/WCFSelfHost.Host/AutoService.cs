using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.ServiceModel;

namespace WCFSelfHost.Host
{



    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AutoService : IAutoService
    {
        List<Auto> db = new List<Auto>();
        int errCount = 0;
        public void AddAuto(Auto auto)
        {
            if (auto.Farbe.ToLower().Contains("rosa"))
            {
                System.Console.WriteLine($"Rosa Autos sind unerwünscht!!!11");
                //throw new FaultException("Rosa Autos sind unerwünscht!!!11");#
                throw new FaultException<RosaAutoFault>(new RosaAutoFault() { Auto = auto, ErrorCount = errCount++ },"Weil isso!");
            }
            else
            {
                db.Add(auto);
                System.Console.WriteLine($"Neues Auto mit {auto.PS}PS");
            }
        }

        public IEnumerable<Auto> GetAutos()
        {
            return db;
        }

        public AutoService()
        {
            db.Add(new Auto() { Hersteller = "Baudi", Modell = "B7", Farbe = "Gelb", PS = 462 });
            db.Add(new Auto() { Hersteller = "Besla", Modell = "B17", Farbe = "Blau", PS = 1462 });
            db.Add(new Auto() { Hersteller = "Bercedes", Modell = "B00", Farbe = "Rot", PS = 212 });
        }
    }


}
