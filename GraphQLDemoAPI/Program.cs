using GraphQLDemoAPI.Schema;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<Query>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();


app.UseEndpoints(endpoinst =>
{
    endpoinst.MapGraphQL();
});

app.Run();
