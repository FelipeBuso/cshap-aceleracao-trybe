using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//adicionando o arquivo ocelot.json ao projeto
builder.Configuration.AddJsonFile("ocelot.json");
builder.WebHost.UseUrls("http://localhost:6000");

//adicionando o conteúdo do arquivo às configurações do Ocelot
builder.Services.AddOcelot(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//espera até a inicialização do Ocelot
await app.UseOcelot();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
