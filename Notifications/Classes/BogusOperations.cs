using Bogus;
using Notifications.Models;

namespace Notifications.Classes;

#pragma warning disable CS8619
public class BogusOperations
{
    public static List<Taxpayer> Taxpayers(int count = 1000)
    {

        Faker<Taxpayer> fakeTaxpayer = new Faker<Taxpayer>()
            .RuleFor(t => t.FirstName, f =>
                f.Person.FirstName)

            .RuleFor(t => t.LastName, f =>
                f.Person.LastName)

            .RuleFor(t => t.SSN, f =>
                f.Random.Replace("#########"))

            .RuleFor(t => t.Pin, f =>
                f.Random.Replace("####"))

            .RuleFor(t => t.CategoryId, f =>
                f.Random.Int(1, 4))

            .RuleFor(t => t.StartDate, f =>
                f.Date.BetweenDateOnly(
                    new DateOnly(2000, 1, 1),
                    new DateOnly(2022, 12, 1)));


        return fakeTaxpayer.Generate(count);

    }
}