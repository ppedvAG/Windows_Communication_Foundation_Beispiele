using System.Collections.Generic;

namespace HalloWCF.Host
{
    public class Service1 : IService1
    {
        public IEnumerable<Pizza> GetAllPizza()
        {
            yield return new Pizza() { Id = 1, Name = "Salami", Preis = 12.8m };
            yield return new Pizza() { Id = 2, Name = "Schinken", Preis = 16.2m };
            yield return new Pizza() { Id = 6, Name = "Hawai", Preis = 6.2m };
        }

        public int GetFive()
        {
            return 5;
        }

        public Drink GetOneDrink()
        {
            return new Drink() { Id = 5, Name = "Jim Beam", Price = 4m, Alc = true };
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
