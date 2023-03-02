using GraphQLDemoAPI.Schema;
using GraphQLDemoAPI.Schema.Mutations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();


app.UseEndpoints(endpoinst =>
{
    endpoinst.MapGraphQL();
});

app.Run();
