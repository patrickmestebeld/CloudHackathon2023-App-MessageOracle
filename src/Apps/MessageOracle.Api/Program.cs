using MessageFlow.Infra;
using MessageOracle.Infra.Personal.Fakers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
GeneratorConstants.IsRealistic = builder.Configuration.GetValue<bool>("Realistic");
builder.Services.AddControllers();
builder.Services.AddInfraModule();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
