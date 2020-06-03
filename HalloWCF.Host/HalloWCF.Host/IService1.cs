using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace HalloWCF.Host
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int GetFive();

        [OperationContract]
        int Sum(int a, int b);

        [OperationContract]
        IEnumerable<Pizza> GetAllPizza();

        [OperationContract]
        Drink GetOneDrink();
    }

    
    public class Drink
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public bool Alc { get; set; }
    }

    [DataContract]
    public class Pizza
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember(Name = "Price")]
        public decimal Preis { get; set; }

        [DataMember]
        public string Name { get; set; }

        public int NurIntern { get; set; }
    }
}
