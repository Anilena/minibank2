using Microsoft.Extensions.Options;

namespace minibank_account_api.Helpers
{
    [ProviderAlias("File")]
    public class FileLoggerProvider : ILoggerProvider
    {
        public readonly FileLoggerOptions Options;
        public FileLoggerProvider(IOptions<FileLoggerOptions> _options)
        {
            Options = _options.Value;

            if (!Directory.Exists(Options.FolderPath))
            {
                Directory.CreateDirectory(Options.FolderPath);
            }
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(this);
        }
        public void Dispose()
        {
        }
    }
}
