using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentsApp.Domain;
using StudentsApp.Infrastructure.Data;
using System;
using System.Linq;

namespace StudentsApp.Infrastructure
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new StudentsDbContext(serviceProvider.GetRequiredService<DbContextOptions<StudentsDbContext>>());
            if (context.Students.Any()) return;

            context.Students.AddRange
            (
                new Student
                {
                    Gender = GenderTypeEnum.Male,
                    IDNumber = "01213425667",
                    Name = "Luka",
                    Surname = "Surmava",
                    DateOfBirth = new DateTime(1995, 09, 10)
                },
                new Student
                {
                    Gender = GenderTypeEnum.Male,
                    IDNumber = "12738481234",
                    Name = "Levan",
                    Surname = "Dvali",
                    DateOfBirth = new DateTime(1995,10,18)
                }
            );

            context.SaveChanges();
        }
    }
}