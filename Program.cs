using MyApi.Interfaces;
using MyApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar el servicio IDataRepository
builder.Services.AddSingleton<IDataRepository, MemoryDataRepository>();

// Registrar servicios para Equipo, Juez, Participante, Evento y Disciplina
builder.Services.AddScoped<IEquipoService, EquipoService>();
builder.Services.AddScoped<IJuezService, JuezService>();
builder.Services.AddScoped<IParticipanteService, ParticipanteService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();

var app = builder.Build();

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
