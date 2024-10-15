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
                    BirthsDay=new DateTime(2022,10,10),
                    SchoolYear=9,
                    SchoolClass = SchoolClassType.ClassA,
                    EducationLevel="érettségi"
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szonja",
                    LastName="Stréber",
                    BirthsDay=new DateTime(2021,4,4),
                    SchoolYear=10,
                    SchoolClass = SchoolClassType.ClassB,
                    EducationLevel="érettségi"
                }
            };

            List<Teacher> teachers = new()
            {
                new Teacher
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Feri",
                    LastName = "Földrajz",
                    BirthsDay= new DateTime(2010, 10, 10),
                    IsWoomen = false,
                    IsHeadTeacher = false
                },
                new Teacher
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bori",
                    LastName = "Biológia",
                    BirthsDay= new DateTime(2005, 5, 5),
                    IsWoomen = true,
                    IsHeadTeacher = true
                }
            };

            List<Parent> parents = new()
            {
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName = "Ferenc",
                    LastName = "Arabik",
                    IsWomen = false,
                    Lakcim = "6725, Szeged, Bécsi krt. 15"
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName = "Zsuzsanna",
                    LastName = "Tóth",
                    IsWomen = true,
                    Lakcim = "6725, Szeged, Bécsi krt. 39"
                }
            };

            List<Product> products = new()
            {
                new Product
                {
                    Id=Guid.NewGuid(),
                    Name = "Tej",
                    Csalad = "Tejtermék",
                    DatumLejarat = "2025.1.28"
                },
                new Product
                {
                    Id=Guid.NewGuid(),
                    Name = "Snicker",
                    Csalad = "Édesség",
                    DatumLejarat = "2025.4.28"
                }
            };


            // Students
            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Teacher>().HasData(teachers);
            modelBuilder.Entity<Parent>().HasData(parents);
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
