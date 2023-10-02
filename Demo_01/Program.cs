using Demo_01.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<TrainerRepository>();
// Une seule instance est créée pour toute l'API
builder.Services.AddScoped<TrainerRepository>();
// Une instance par demande
//builder.Services.AddTransient<TrainerRepository>();
// Une instance par demande, par tâches à faire pour la demande
builder.Services.AddScoped<CourseRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
