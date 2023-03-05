
using GraphQLDemoAPI.Schema.Mutations;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
namespace GraphQLDemoAPI.Schema.Subscriptions
{
    public class subscription
    {
        [Subscribe]
        [Topic("ExampleTopic")]
        public CourseResult CourseCreated([EventMessage] CourseResult result) => result;


        //[Subscribe]
        
        //public async ValueTask<ISourceStream<CourseResult>>CourseUpdate(Guid id, [Service] ITopicEventReceiver topicEventReceiver)
        //{
        //    string topicName = $"{id}_{nameof(subscription.CourseUpdate)}";
        //   return await topicEventReceiver.SubscribeAsync<string, CourseResult>(topicName);
        //}

        //[Subscribe]
        //public ValueTask<ISourceStream<CourseResult>>
        //    CourseUpdated(Guid courseId, [Service] ITopicEventReceiver topicEventReceiver)
        //{
        //    string topicName = $"{courseId}_{nameof(subscription.CourseUpdated)}";

        //    return topicEventReceiver.SubscribeAsync<string,CourseResult>(topicName);
        //}
    }
}
