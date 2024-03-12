using minibank_client_api.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFileLogger(config =>
        {
    config.FolderPath = builder.Configuration.GetSection("Logging").GetSection("File").GetSection("Options").GetSection("FolderPath").Value ?? "";
    config.FilePath = builder.Configuration.GetSection("Logging").GetSection("File").GetSection("Options").GetSection("FilePath").Value ?? "";
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseHsts();

app.UseAuthorization();

app.MapControllers();

app.Run();

