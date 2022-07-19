using EntityFrame.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.
//Services.
//AddDbContext<APIContext>(options => options.UseInMemoryDatabase("API"));

//NO pueden usarse dos configuraciones para un solo contexto, es decir, dos conexiones, ya que eso dará
//un error de conflicto porque 
builder.Services.AddNpgsql<APIContext>(builder.Configuration.GetConnectionString("API"));

var app = builder.Build();


app.MapGet("/", async ([FromServices] APIContext databasecontext ) => 
{
    databasecontext.Database.EnsureCreated();
    return Results.Ok("DB created " + databasecontext.Database.IsInMemory() );
});


app.Run();
