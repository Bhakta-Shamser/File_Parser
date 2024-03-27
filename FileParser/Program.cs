using FileParser;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "Codewrinkle service";
    })
    .ConfigureServices(services => { services.AddHostedService<FileParser.FileParser>(); })
    .Build();

host.Run();
