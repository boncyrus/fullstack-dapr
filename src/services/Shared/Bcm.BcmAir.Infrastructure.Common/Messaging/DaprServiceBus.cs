using Bcm.BcmAir.Infrastructure.Common.Constants;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace Bcm.BcmAir.Infrastructure.Common.Messaging
{
    public class DaprServiceBus : IServiceBus
    {
        private DaprClient _dapr;
        private ILogger<DaprServiceBus> _logger;
        private const string PubSubName = PubSubConstants.BcmAirPubSub;

        public DaprServiceBus(DaprClient dapr, ILogger<DaprServiceBus> logger)
        {
            _dapr = dapr;
            _logger = logger;
        }

        public async Task Publish(EventMessage message)
        {
            var topicName = message.GetType().Name;

            _logger.LogInformation(
                "Publishing message {Message} to {PubsubName}.{TopicName}",
                message,
                PubSubName,
                topicName);

            // We need to make sure that we pass the concrete type to PublishEventAsync,
            // which can be accomplished by casting the event to dynamic. This ensures
            // that all event fields are properly serialized.
            await _dapr.PublishEventAsync(PubSubName, topicName, (object)message);
        }
    }
}
