using GraphQLDemoAPI.Schema;
using GraphQLDemoAPI.Schema.Mutations;
using GraphQLDemoAPI.Schema.Subscriptions;
using GraphQLDemoAPI.Services;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>().AddSubscriptionType<subscription>().AddInMemorySubscriptions();

builder.Services.AddPooledDbContextFactory<SchoolDbContext>(p => p.UseSqlite(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddSingleton<ITopicEventReceiver>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.UseWebSockets();
app.UseEndpoints(endpoinst =>
{
    endpoinst.MapGraphQL();
});

app.Run();
