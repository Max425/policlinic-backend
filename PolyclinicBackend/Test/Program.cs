/*using Bogus;
using Data.DAL.Context;
using Data.DAL.Entities;


using (var dbContext = new GeneratedContext())
{
    // Удаление существующих записей из таблицы
    //dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE public.\"VisitorGenerated\" RESTART IDENTITY");
    List<string> patronymics = File.ReadAllLines("..\\..\\..\\rus_midname.txt").ToList();
    // Генерация случайных данных
    var faker = new Faker<Visitor>("ru")
        .RuleFor(p => p.FirstName, f => f.Name.FirstName())
        .RuleFor(p => p.LastName, f => f.Name.LastName())
        .RuleFor(p => p.FatherName, f => f.PickRandom(patronymics))
        .RuleFor(p => p.City, f => f.Address.City())
        .RuleFor(p => p.Gender, f => f.PickRandom("M", "F"))
        .RuleFor(p => p.BirthDate, f => f.Date.Past(30, DateTime.Now.AddYears(-18)).ToUniversalTime().Date)
        .RuleFor(p => p.Nationality, "RU")
        .RuleFor(p => p.PassportSeries, f => f.Random.Number(1000, 9999))
        .RuleFor(p => p.PassportNumber, f => f.Random.Number(100000, 999999))
        .RuleFor(p => p.PhotoBase64, f => Convert.ToBase64String(f.Random.Bytes(10)))
        .RuleFor(p => p.DateIssue, f => f.Date.Past(5).ToUniversalTime().Date);

    // Генерация 100 записей и добавление их в базу данных
    var visitors = faker.Generate(1000);
    dbContext.VisitorsGenerated.AddRange(visitors);
    dbContext.SaveChanges();

    Console.WriteLine("Данные успешно добавлены в базу данных.");
}*/

using Data.DAL.Entities;

string cmd = "C:/Python311/python.exe";
string arg = "D:/учёба/qoollo-practice/backend/PolyclinicBackend/PythonService/code.py D:/passport.jpg false";
Visitor visitor = PythonService.PythonService.GetDataFromPhoto(cmd, arg);
Console.WriteLine(visitor.Gender);