namespace GraphQLDemoAPI.Schema
{
    public enum Subjects
    {
        Mathematics,
        Science,
        History
    }

    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public Subjects Subject { get; set; }
        [GraphQLNonNullType]
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }  = Enumerable.Empty<StudentType>();
    }
}
