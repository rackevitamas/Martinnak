using Kreata.Backend.Datas.Enums;

namespace Kreata.Backend.Datas.Entities
{
    public class Drink
    {
        public Drink(Guid id, string name, string italCsalad, bool isAlcohol, int price)
        {
            Id = id;
            Name = name;
            ItalCsalad = italCsalad;
            IsAlcohol = isAlcohol;
            Price = price;
        }

        public Drink(string name, string italCsalad, bool isAlcohol, int price)
        {
            Id = new Guid();
            Name = name;
            ItalCsalad = italCsalad;
            IsAlcohol = isAlcohol;
            Price = price;
        }

        public Drink()
        {
            Id = new Guid();
            Name = string.Empty;
            ItalCsalad = string.Empty;
            IsAlcohol = false;
            Price = 0;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ItalCsalad { get; set; }
        public bool IsAlcohol { get; set; }
        public int Price { get; set; }


        public override string ToString()
        {
            return $"{Name}: fajta: {ItalCsalad}, Alkohol-e: {IsAlcohol}, �ra: {Price}";
        }
    }
}