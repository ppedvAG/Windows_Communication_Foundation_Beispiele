using System.Collections.Generic;
using System.Linq;
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
            auto.Id = db.Max(x => x.Id) + 1;

            if (auto.Farbe.ToLower().Contains("rosa"))
            {
                System.Console.WriteLine($"Rosa Autos sind unerwünscht!!!11");
                //throw new FaultException("Rosa Autos sind unerwünscht!!!11");#
                throw new FaultException<RosaAutoFault>(new RosaAutoFault() { Auto = auto, ErrorCount = errCount++ }, "Weil isso!");
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

        public void UpdateAuto(Auto auto)
        {
            int oldId = auto.Id;
            DeleteAuto(auto);
            AddAuto(auto);
            auto.Id = oldId;
        }

        public void DeleteAuto(Auto auto)
        {
            db.Remove(db.First(x => x.Id == auto.Id));
        }

        public AutoService()
        {
            db.Add(new Auto() { Id = 1, Hersteller = "Baudi", Modell = "B7", Farbe = "Gelb", PS = 462 });
            db.Add(new Auto() { Id = 2, Hersteller = "Besla", Modell = "B17", Farbe = "Blau", PS = 1462 });
            db.Add(new Auto() { Id = 3, Hersteller = "Bercedes", Modell = "B00", Farbe = "Rot", PS = 212 });
        }
    }


}
