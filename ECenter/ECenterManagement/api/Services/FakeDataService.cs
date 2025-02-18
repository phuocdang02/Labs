using api.Models;
using Bogus;

namespace api.Services
{
    public class FakeDataService
    {
        public List<Teachers> GenerateFakeTeachers(int count)
        {
            var faker = new Faker<Teachers>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.FullName, f => f.Name.FullName())
                .RuleFor(x => x.Phone, f => f.Name.FullName())
                .RuleFor(x => x.PersonalEmailAddress, f => f.Internet.Email())
                .RuleFor(x => x.BusinessEmailAddress, f => f.Internet.Email());

            return faker.Generate(count);
        }

        public List<Schedules> GenerateFakeSchedules(int count, List<Teachers> teachers)
        {
            var faker = new Faker<Schedules>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.TeacherId, f => f.PickRandom(teachers).Id)
            .RuleFor(x => x.ClassName, f => f.Name.JobTitle())
            .RuleFor(x => x.StartDate, f => f.Date.Recent())
            .RuleFor(x => x.EndDate, f => f.Date.Recent());

            return faker.Generate(count);
        }
    }
}
