using Bogus;
using Data.DAL.Context;
using Data.DAL.Entities;
using VisitorGenerated.Context;

namespace Test;

public static class Program
{
    public static void Main()
    {
        using var dbContext = new GeneratedContext();
        // Удаление существующих записей из таблицы
        // dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE public.\"VisitorGenerated\" RESTART IDENTITY");
        var patronymics = File.ReadAllLines("..\\..\\..\\rus_midname.txt").ToList();
        var names = File.ReadAllLines("..\\..\\..\\russian_names.txt").ToList();
        var surnames = File.ReadAllLines("..\\..\\..\\russian_surnames.txt").ToList();

        var faker = new Faker<Visitor>("ru")
            .RuleFor(p => p.FirstName, f => f.PickRandom(names))
            .RuleFor(p => p.LastName, f => f.PickRandom(surnames))
            .RuleFor(p => p.FatherName, f => f.PickRandom(patronymics))
            .RuleFor(p => p.City, f => f.Address.City())
            .RuleFor(p => p.Gender, f => f.PickRandom("ЖЕН", "МУЖ"))
            .RuleFor(p => p.BirthDate, f => f.Date.Past(30, DateTime.Now.AddYears(-18)).ToUniversalTime().Date)
            .RuleFor(p => p.Nationality, "RU")
            .RuleFor(p => p.PassportSeries, f => f.Random.Number(1000, 9999))
            .RuleFor(p => p.PassportNumber, f => f.Random.Number(100000, 999999))
            .RuleFor(p => p.PhotoBase64, "passport.jpg")
            .RuleFor(p => p.DateIssue, f => f.Date.Past(5).ToUniversalTime().Date);

        var visitors = new List<Visitor>();
        const int duplicateCount = 15;

        foreach (var originalVisitor in faker.Generate(1000))
        {
            visitors.Add(originalVisitor);

            for (var i = 0; i < duplicateCount; i++)
            {
                Visitor duplicateVisitor = new()
                {
                    FirstName = GenerateRandomNameWithError(originalVisitor.FirstName, names),
                    LastName = GenerateRandomNameWithError(originalVisitor.LastName, surnames),
                    FatherName = GenerateRandomNameWithError(originalVisitor.FatherName, patronymics),
                    City = originalVisitor.City,
                    Gender = originalVisitor.Gender,
                    BirthDate = originalVisitor.BirthDate,
                    Nationality = originalVisitor.Nationality,
                    PassportSeries = GenerateRandomPassportNumber(originalVisitor.PassportSeries),
                    PassportNumber = GenerateRandomPassportNumber(originalVisitor.PassportNumber),
                    PhotoBase64 = originalVisitor.PhotoBase64,
                    DateIssue = originalVisitor.DateIssue
                };

                visitors.Add(duplicateVisitor);
            }
        }

        dbContext.VisitorsGenerated.AddRange(visitors);
        dbContext.SaveChanges();

        Console.WriteLine("Данные успешно добавлены в базу данных.");
    }

    private static string GenerateRandomNameWithError(string orig, List<string> nameList)
    {
        Random random = new();
        var randomIndex = random.Next(0, nameList.Count - 1);
        string originalName;
        originalName = (randomIndex % 2 == 0) ? nameList[randomIndex] : orig;

        var nameChars = originalName.ToCharArray();
        randomIndex = random.Next(0, originalName.Length);
        if (randomIndex % 2 == 0)
        {
            (nameChars[0], nameChars[randomIndex]) = (nameChars[randomIndex], nameChars[0]);
        }

        return new string(nameChars);
    }

    private static int GenerateRandomPassportNumber(int originalNumber)
    {
        Random random = new();
        var randomIndex = random.Next(0, 500);
        return (randomIndex % 2 == 0) ? originalNumber : originalNumber - originalNumber % 10;
    }
}


/*using Data.DAL.Entities;

string cmd = "C:/Python311/python.exe";
string arg = "D:/учёба/qoollo-practice/backend/PolyclinicBackend/PythonService/code.py D:/passport.jpg false";
Visitor visitor = PythonService.PythonService.GetDataFromPhoto(cmd, arg);
Console.WriteLine(visitor.Gender);*/