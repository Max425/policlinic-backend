using System;
using System.Linq;
using Bogus;
using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;

using (var dbContext = new GeneratedContext())
{
    // Удаление существующих записей из таблицы
    dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE public.\"VisitorGenerated\" RESTART IDENTITY");

    // Генерация случайных данных
    var faker = new Faker<Visitor>("ru")
        .RuleFor(p => p.FirstName, f => f.Name.FirstName())
        .RuleFor(p => p.LastName, f => f.Name.LastName())
        .RuleFor(p => p.FatherName, f => f.Name.FirstName())
        .RuleFor(p => p.City, f => f.Address.City())
        .RuleFor(p => p.Gender, f => f.PickRandom("Male", "Female"))
        .RuleFor(p => p.BirthDate, f => f.Date.Past(30, DateTime.Now.AddYears(-18)).ToUniversalTime())
        .RuleFor(p => p.Nationality, f => f.Address.Country())
        .RuleFor(p => p.PassportSeries, f => f.Random.Number(1000, 9999))
        .RuleFor(p => p.PassportNumber, f => f.Random.Number(100000, 999999))
        .RuleFor(p => p.PhotoBase64, f => Convert.ToBase64String(f.Random.Bytes(10)))
        .RuleFor(p => p.DateIssue, f => f.Date.Past(5).ToUniversalTime());

    // Генерация 100 записей и добавление их в базу данных
    var visitors = faker.Generate(100);
    dbContext.VisitorGenerated.AddRange(visitors);
    dbContext.SaveChanges();

    Console.WriteLine("Данные успешно добавлены в базу данных.");
}

Console.ReadLine();
