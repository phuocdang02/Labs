using api.Models;
using Bogus;

namespace api.Services;

/// <summary>
/// Fake data using for testing purpose
/// </summary>
public class FakeDataService
{
    /// <summary>
    /// Generate fake data for teacher
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<Teacher> GenerateFakeTeachers(int count)
    {
        var faker = new Faker<Teacher>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.FullName, f => f.Name.FullName())
            .RuleFor(x => x.Phone, f => f.Name.FullName())
            .RuleFor(x => x.PersonalEmailAddress, f => f.Internet.Email())
            .RuleFor(x => x.BusinessEmailAddress, f => f.Internet.Email());

        return faker.Generate(count);
    }

    /// <summary>
    /// Generate fake data for schedule
    /// </summary>
    /// <param name="count"></param>
    /// <param name="teachers"></param>
    /// <returns></returns>
    public List<Schedule> GenerateFakeSchedules(int count, List<Teacher> teachers)
    {
        var faker = new Faker<Schedule>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.TeacherId, f => f.PickRandom(teachers).Id)
        .RuleFor(x => x.ClassName, f => f.Name.JobTitle())
        .RuleFor(x => x.StartDate, f => f.Date.Recent())
        .RuleFor(x => x.EndDate, f => f.Date.Recent());

        return faker.Generate(count);
    }
}
