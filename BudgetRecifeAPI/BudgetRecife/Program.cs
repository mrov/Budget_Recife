var builder = WebApplication.CreateBuilder(args);
var IsSeedEnabled = builder.Configuration["SeedDatabase:Enabled"];

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Condition to show swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

if (!String.IsNullOrEmpty(IsSeedEnabled) && IsSeedEnabled.Equals("true", StringComparison.OrdinalIgnoreCase))
{
    seedDatabase();
}


app.Run();

void seedDatabase()
{

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            var dbContext = services.GetRequiredService<MyDbContext>();

            string CsvPath = builder.Configuration["SeedDatabase:CSVPath"];

            dbContext.SeedDatabase(CsvPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while accessing the DbContext: " + ex.Message);
        }
    }
}