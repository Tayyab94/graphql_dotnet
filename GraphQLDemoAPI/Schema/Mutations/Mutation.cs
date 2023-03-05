using GraphQLDemoAPI.Schema.Subscriptions;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLDemoAPI.Schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _courseResults;

        public Mutation ()
        {
            _courseResults = new List<CourseResult>();
        }

        public CourseResult CreateCourse(string name, Subjects subject, Guid InstructorId) {
            CourseResult courseResult = new CourseResult()
            {
                Name = name,
                Subject = subject,
                InstructorId = InstructorId,
                Id = Guid.NewGuid(),
            };
            _courseResults.Add(courseResult);
            return courseResult;
        }



        public async  Task<CourseResult> CreateNewCourse(CourseInputType course, [Service] ITopicEventSender topicEventSender)
        {

            CourseResult courseResult = new CourseResult()
            {
                Name = course.name,
                Subject = course.subject,
                InstructorId = course.InstructorId,
                Id = Guid.NewGuid(),
            };

            _courseResults.Add(courseResult);
            //await topicEventSender.SendAsync(nameof(subscription.CourseCreated),course);
            await topicEventSender.SendAsync("ExampleTopic", courseResult);
            return courseResult;
        }

        public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType course, [Service] ITopicEventSender topicEventSender) { 
        
            var data =_courseResults.FirstOrDefault(s=>s.Id == id);

            if(data is null)
            {
                throw new GraphQLException(new Error("Course Not FOudn", "COURSE_NOT_FOUND"));
            }

            data.Name = course.name;
            data.Subject =course.subject;
            data.InstructorId =course.InstructorId;

            string updateCoursTopic = $"{data.Id}_{nameof(subscription.CourseUpdate)}";

            await topicEventSender.SendAsync(updateCoursTopic, data);
            return data;
        }

        public bool DeleteCourseById(Guid id)
        {
            return _courseResults.RemoveAll(s=>s.Id==id)>1;
        }
    }
}
