using Amazon;
using Amazon.SQS;
using CleanArchitecture.Worker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IAmazonSQS>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    return new AmazonSQSClient(
        config["AWS:AccessKey"],
        config["AWS:SecretKey"],
        RegionEndpoint.APSoutheast2);
});

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Run();