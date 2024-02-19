using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Data;
var builder = WebApplication.CreateBuilder(args);

//var server = builder.Configuration["DBServer"] ?? "localhost";

//var port = builder.Configuration["DbPort"] ?? "1450";

//var user = builder.Configuration["DbUser"] ?? "SA";

//var password = builder.Configuration["Password"] ?? "teste#2024";

//var database = builder.Configuration["Database"] ?? "Projetos";


//var connectionString = $"Server ={server},{port};Initial Catalog={database};User ID={user};Password={password};TrustServerCertificate=True";

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));


var startup = new Startup(builder.Configuration);

startup.ConfigureService(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.MapPost("/pedido", ProjetoEndpoint.AddProjeto);
app.MapPost("/tarefa", TarefaEndPoint.AddProjeto);


app.Run();

