using Dapper;
using DeaDXoxoton;
using DeaDXoxoton.Implementation;

DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOptions<ConfigureMvcOptions>();
builder.Services.AddTransient<DbConnection>();
builder.Services.AddTransient<LeaderboardScoreDb>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseDefaultFiles();
app.UseStaticFiles();
// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();