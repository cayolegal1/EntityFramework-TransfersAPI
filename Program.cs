using EntityFrame.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrame.Models;

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


//ejemplo de get con data. FromServices nos permite acceder a los servicios y al contexto 
//de EntityFramework, dandonos acceso a los modelos y los registros
app.MapGet("/api/clients", async ([FromServices] APIContext dbContext) => {

    return Results.Ok(dbContext.Clients);
});


//------------------------------------------------CLIENTES----------------------------------------------------

//ejemplo de get con filtrado
app.MapGet("/api/clients/filter", async ([FromServices] APIContext dbContext) => {

    return Results.Ok(dbContext.Clients.Where(c => c.nombre_apellido == "cayo legal"));
});


//ejemplo de filtrado dinámico
app.MapGet("/api/clients/{cedula}", async ([FromServices] APIContext dbContext, string cedula ) => {

    var findClient = dbContext.Clients.Find(cedula);

    if(findClient == null)
    {
        return Results.NotFound("Cliente no registrado");
    }

    return Results.Ok(dbContext.Clients.Where(c => c.cedula == cedula));

});



//ejemplo de envio de datos 
app.MapPost("api/clients", async ([FromServices] APIContext dbContext, [FromBody] Client client) => {

    var newClientValidate = dbContext.Clients.Find(client.cedula);

    if (newClientValidate != null)
    {
        return Results.Conflict("Cliente ya se encuentra registrado");
    }

    await dbContext.AddAsync(client);

    //luego de hacer cualquier cambio sobre el contexto, debemos guardar los datos,
    //con el método asíncrono de SaveChanges
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});


//ejemplo de actualización de registro
app.MapPut("api/clients/{cedula}",
async ([FromServices] APIContext dbContext,
[FromBody] Client client,[FromRoute] string cedula) => {

    var findClient = dbContext.Clients.Find(cedula);

    if(findClient != null)
    {
        findClient.tipo_doc = client.tipo_doc;
        findClient.nombre_apellido = client.nombre_apellido;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound("Cliente no registrado");

});

//ejemplo de eliminación de registro
app.MapDelete("api/clients/{cedula}",
async ([FromServices] APIContext dbContext,[FromRoute] string cedula) => {

    var findClient = dbContext.Clients.Find(cedula);

    if (findClient != null)
    {
        dbContext.Remove(findClient);

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound("Cliente no registrado");

});

//----------------------------------------------------CLIENTES----------------------------------------------------




//-----------------------------------------------------BANCOS-----------------------------------------------------

app.MapGet("/api/banks", async ([FromServices] APIContext dbContext) => {

    return Results.Ok(dbContext.Banks);
});


//-----------------------------------------------------BANCOS------------------------------------------------




//-----------------------------------------------------CUENTAS------------------------------------------------

app.MapGet("/api/accounts", async ([FromServices] APIContext dbContext) => {

    return Results.Ok(dbContext.Accounts);
});

//-----------------------------------------------------CUENTAS------------------------------------------------




//-----------------------------------------------------TRANSFERENCIAS-----------------------------------------

app.MapGet("/api/transfers", async ([FromServices] APIContext dbContext) => {

    return Results.Ok(dbContext.Transfers);
});




app.Run();