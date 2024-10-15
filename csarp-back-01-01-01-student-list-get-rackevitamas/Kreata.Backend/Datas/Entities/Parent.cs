using Kreata.Backend.Datas.Enums;

namespace Kreata.Backend.Datas.Entities
{
    public class Parent
    {
        public Parent(Guid id, string firstName, string lastName, bool isWoman, string lakcim)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName; 
            IsWomen = isWoman;
            Lakcim = lakcim;
        }

        public Parent(string firstName, string lastName, bool isWoman, string lakcim)
        {
            Id = new Guid();
            FirstName = firstName;
            LastName = lastName;
            IsWomen = isWoman;
            Lakcim = lakcim;
        }

        public Parent()
        {
            Id = new Guid();
            FirstName = string.Empty;
            LastName = string.Empty;
            IsWomen = false;
            Lakcim = string.Empty;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsWomen { get; set; }
        public string Lakcim { get; set; }


        public override string ToString()
        {
            return $"{LastName} {FirstName}, Anya: {IsWomen}, Lakcíme: {Lakcim}";
        }
    }
}
