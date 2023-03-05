using GraphQLDemoAPI.Models;

namespace GraphQLDemoAPI.Schema.Mutations
{
    public class CourseResult
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public Subjects Subject {
            get; set;
         }

        public Guid InstructorId { get;set; }
    }
}
