using ApiMinimal.Data;
using ApiMinimal.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ApiMinimal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();

#region Api

app.MapPost("AdicionarCliente", async (Cliente cliente, Contexto contexto) => 
{ 
    contexto.clientes.Add(cliente); 
    await contexto.SaveChangesAsync();
});

app.MapPost("RemoverCliente/{id}", async (int id, Contexto contexto) => 
{
    var clienteRemover = await contexto.clientes.FirstOrDefaultAsync(x => x.Id == id);
    if (clienteRemover ! == null)
    {
        contexto.clientes.Remove(clienteRemover);
        await contexto.SaveChangesAsync();
    }

});


app.MapPost("ListCliente", async ( Contexto contexto) =>
{
   return await contexto.clientes.ToListAsync();

});

app.MapPost("obterCliente/{id}", async (int id, Contexto contexto) =>
{
  await contexto.clientes.FirstOrDefaultAsync(x => x.Id == id);
   

});

#endregion

app.UseSwaggerUI();

app.Run();
