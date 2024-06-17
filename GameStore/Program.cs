//very first lines that execute when you run your application
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

//Connect to the sqlite database. Builder object ot register services

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString); // register IServiceProvider with scope lifetime
//builder.Services.AddScoped<GameStoreContext>              //improve performance, db connections are expensive

//configuration for our request pipeline so this sets up
// what is going to happen when requests come in, how should we handle those requests
//app is host of your application. Purpose: introduce an HTTP 
//server implementation for your app so that you can start 
//listening for HTTP request
var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenreEndpoints();

await app.MigrateDbAsync();


app.Run();
