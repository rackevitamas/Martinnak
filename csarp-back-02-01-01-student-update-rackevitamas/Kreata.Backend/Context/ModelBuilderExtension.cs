using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Enums;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="János",
                    LastName="Jegy",
                    BirthsDay=new DateTime(2011,10,10),
                    SchoolYear=9,
                    SchoolClass = SchoolClassType.ClassA,
                    EducationLevel="érettségi"
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szonja",
                    LastName="Stréber",
                    BirthsDay=new DateTime(2012,4,4),
                    SchoolYear=10,
                    SchoolClass = SchoolClassType.ClassB,
                    EducationLevel="érettségi"
                }
            };

            // Students
            modelBuilder.Entity<Student>().HasData(students);

            List<Teacher> techers = new List<Teacher>
            {
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Feleltető",
                    LastName="Ferenc",
                    BirthsDay=new DateTime(2001,8,1),
                    IsWoomen=false,
                    IsHeadTeacher=false
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Aranyos",
                    LastName="Aranka",
                    BirthsDay=new DateTime(2002,2,24),
                    IsWoomen=true,
                    IsHeadTeacher=true
                }
            };

            List<Product> products = new()
            {
                new Product
                {
                    Id=Guid.NewGuid(),
                    Name = "Tej",
                    Csalad = "Tejtermék",
                    DatumLejarat = "2025.1.28",
                    Price = 359
                },
                new Product
                {
                    Id=Guid.NewGuid(),
                    Name = "Snicker",
                    Csalad = "Édesség",
                    DatumLejarat = "2025.4.28",
                    Price = 379
                }
            };

            List<Drink> drinks = new()
            {
                new Drink
                {
                    Id=Guid.NewGuid(),
                    Name = "XIXO Tea Eper ízű",
                    ItalCsalad = "Tea",
                    IsAlcohol = false,
                    Price = 449
                },
                new Drink
                {
                    Id=Guid.NewGuid(),
                    Name = "Coca Cola",
                    ItalCsalad = "Kóla",
                    IsAlcohol = false,
                    Price = 749
                }
            };

            List<Dolgozo> dolgozok = new()
            {
                new Dolgozo
                {
                    Id=Guid.NewGuid(),
                    Name = "Hari István",
                    Age = 48,
                    Hataskor = "Fönők"
                },
                new Dolgozo
                {
                    Id=Guid.NewGuid(),
                    Name = "Loli Krisztina",
                    Age = 31,
                    Hataskor = "Pultos"
                }
            };

            modelBuilder.Entity<Teacher>().HasData(techers);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Drink>().HasData(drinks);
            modelBuilder.Entity<Dolgozo>().HasData(dolgozok);
        }
    }
}
