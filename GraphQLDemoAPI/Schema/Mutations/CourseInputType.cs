using GraphQLDemoAPI.Models;

namespace GraphQLDemoAPI.Schema.Mutations
{
    public class CourseInputType
    {
      public string name { get; set; } public Subjects subject { get; set; } public Guid InstructorId { get; set; }
    }
}
