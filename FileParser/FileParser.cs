namespace FileParser
{
    public class FileParser : BackgroundService
    {
        private readonly ILogger<FileParser> _logger;
        private const string _folderPath = @"E:\BC_development\brand_Dump\New folder";
        public FileParser(ILogger<FileParser> logger)
        {   
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                //if (_logger.IsEnabled(LogLevel.Information))
                //{
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //}
                foreach(var file in Directory.EnumerateFiles(_folderPath))
                {
                    _logger.LogInformation("Processing {fileName}", file);
                    var filePath = Path.Combine(_folderPath, file);
                    //File.Delete(filePath);
                    _logger.LogInformation("Processing completed. The file {FileName} was deleted ", file);
                }
            }
        }
    }
}
