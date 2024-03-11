using minibank_client_api.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFileLogger(config =>
        {
    config.FolderPath = Path.Combine(Directory.GetCurrentDirectory(), builder.Configuration.GetSection("Logging").GetSection("File").GetSection("Options").GetSection("FolderPath").Value ?? "");
    config.FilePath = builder.Configuration.GetSection("Logging").GetSection("File").GetSection("Options").GetSection("FilePath").Value ?? "";
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHttpsRedirection(options => { options.HttpsPort = 8080; });

using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = loggerFactory.CreateLogger<Program>();
logger.LogInformation("Current directory {0}", Directory.GetCurrentDirectory());
logger.LogInformation("Base directory {0}", AppDomain.CurrentDomain.BaseDirectory);

//Path.Combine(AppDomain.CurrentDomain.BaseDirectory, builder.Configuration.GetSection("Logging").GetSection("File").GetSection("Options").GetSection("FolderPath").Value ?? "")

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseHsts();

app.UseAuthorization();

app.MapControllers();

app.Run();

