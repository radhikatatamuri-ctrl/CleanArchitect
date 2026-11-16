using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using CleanArchitecture.Domain.Interface;
using Microsoft.Extensions.Configuration;
public class SnsService : ISnsService
{
    private readonly IAmazonSimpleNotificationService _sns;
    private readonly IConfiguration _config;

    public SnsService(
        IAmazonSimpleNotificationService sns,
        IConfiguration config)
    {
        _sns = sns;
        _config = config;
    }

    public async Task PublishAsync(string message)
    {
        var arn = _config["AWS:TopicArn"];
       // Console.WriteLine($"ARN=[{arn}]");

        // throw new Exception($"ARN = {arn}");
        await _sns.PublishAsync(new PublishRequest
        {
            TopicArn = _config["AWS:TopicArn"],
            Message = message
           
        });
    }
}