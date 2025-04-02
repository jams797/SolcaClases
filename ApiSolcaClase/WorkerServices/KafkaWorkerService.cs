using Confluent.Kafka;

namespace ApiSolcaClase.WorkerServices
{

    public class KafkaWorkerService : BackgroundService
    {
        private readonly ILogger<KafkaWorkerService> _logger;
        private readonly ProducerConfig _config;
        private readonly string _topic;

        public KafkaWorkerService(ILogger<KafkaWorkerService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = new ProducerConfig
            {
                BootstrapServers = configuration["kafka:server"]
            };
            _topic = configuration["kafka:topic"];
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var producer = new ProducerBuilder<Null, string>(_config).Build();

            while (!stoppingToken.IsCancellationRequested)
            {
                var message = $"Hola Mundo, Mensaje generado a las {DateTime.Now}";

                try
                {
                    // Envía el mensaje a Kafka
                    var result = await producer.ProduceAsync(_topic,
                        new Message<Null, string> { Value = message }, stoppingToken);

                    _logger.LogInformation($"Mensaje enviado: {message} - Entregado a {result.TopicPartitionOffset}");
                }
                catch (ProduceException<Null, string> ex)
                {
                    _logger.LogError($"Error al enviar mensaje: {ex.Message}");
                }

                // Espera antes de enviar el siguiente mensaje
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
