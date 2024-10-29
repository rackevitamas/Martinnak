using Kreata.Backend.Datas.Enums;

namespace Kreata.Backend.Datas.Entities
{
    public class Dolgozo
    {
        public Dolgozo(Guid id, string name, int age, string hataskor)
        {
            Id = id;
            Name = name;
            Age = age;
            Hataskor = hataskor;
        }

        public Dolgozo(string name, int age, string hataskor)
        {
            Id = new Guid();
            Name = name;
            Age = age;
            Hataskor = hataskor;
        }

        public Dolgozo()
        {
            Id = new Guid();
            Name = string.Empty;
            Age = 0;
            Hataskor = string.Empty;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Hataskor { get; set; }


        public override string ToString()
        {
            return $"{Name}: {Age} �ves, hat�sk�re: {Hataskor}";
        }
    }
}