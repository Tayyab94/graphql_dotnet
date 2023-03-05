using Bogus;
using GraphQLDemoAPI.Models;

namespace GraphQLDemoAPI.Schema
{
    public class Query
    {
        private readonly Faker<StudentType> _studentFaker;
        private readonly Faker<InstructorType> _instructorFaker;
        private readonly Faker<CourseType> _courseFaker;

        public Query()
        {
            _instructorFaker = new Faker<InstructorType>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Salary, f => f.Random.Double(0, 10000));


                 _studentFaker = new Faker<StudentType>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.GPA, f => f.Random.Double(1, 4));
                
            _courseFaker = new Faker<CourseType>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.Name, f => f.Name.FirstName())
                .RuleFor(s => s.Subject, f => f.PickRandom<Subjects>())
                .RuleFor(s => s.Instructor, f => _instructorFaker.Generate())
                .RuleFor(s => s.Students, f => _studentFaker.Generate(2));
        }
        // Install Bugus package 
        public async Task<IEnumerable<CourseType>> GetCoursesAsync()
        {
            await Task.Delay(1000);

            return _courseFaker.Generate(2);
        }


        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            await Task.Delay(1000);

            CourseType course = _courseFaker.Generate();
            course.Id = id;

            return course;
        }


        [GraphQLDeprecated("This Query is deprecated")]
        public string Instruction => "Smash that like button and subscribe";
    }
}
