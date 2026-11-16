using Amazon.SQS;

namespace CleanArchitecture.Worker
{
    public class Worker1 : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IAmazonSQS _sqs;
        private readonly IConfiguration _config;

        public Worker1(
            ILogger<Worker> logger,
            IAmazonSQS sqs,
            IConfiguration config)
        {
            _logger = logger;
            _sqs = sqs;
            _config = config;
        }

        protected override async Task ExecuteAsync(
    CancellationToken stoppingToken)
        {
            var queueUrl = _config["AWS:QueueUrl"];

            _logger.LogInformation("QueueUrl = {QueueUrl}", queueUrl);

            while (!stoppingToken.IsCancellationRequested)
            {
                var response = await _sqs.ReceiveMessageAsync(
                    queueUrl,
                    stoppingToken);

                if (response?.Messages == null)
                {
                    _logger.LogWarning("No messages returned from SQS");
                    await Task.Delay(5000, stoppingToken);
                    continue;
                }

                foreach (var message in response.Messages)
                {
                    _logger.LogInformation(
                        "Received Message: {Message}",
                        message.Body);

                    await _sqs.DeleteMessageAsync(
                        queueUrl,
                        message.ReceiptHandle,
                        stoppingToken);
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
