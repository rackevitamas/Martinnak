namespace Kreata.Backend.Datas.Entities
{
    public class Product
    {
        public Product(Guid id, string name, string csalad, string datumLejarat)
        {
            Id = id;
            string Name = name;
            string Csalad = csalad;
            string DatumLejarat = datumLejarat;
        }

        public Product(string name, string csalad, string datumLejarat)
        {
            Id = new Guid();
            string Name = name;
            string Csalad = csalad;
            string DatumLejarat = datumLejarat;
        }

        public Product()
        {
            Id = new Guid();
            Name = string.Empty;
            Csalad = string.Empty;
            DatumLejarat = string.Empty;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Csalad { get; set; }
        public string DatumLejarat { get; set; }


        public override string ToString()
        {
            return $"{Name} {Csalad}, szavatossági lejárat: {DatumLejarat}";
        }
    }
}
