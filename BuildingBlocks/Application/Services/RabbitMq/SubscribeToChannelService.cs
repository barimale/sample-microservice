using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BuildingBlocks.Application.Services.RabbitMq
{
    public class SubscribeToChannelService : BaseChannelService
    {
        public SubscribeToChannelService(string hostName)
            : base(hostName)
        {
            // intentionally left blank
        }

        public IModel Channel => _channel;

        public bool Consume(EventingBasicConsumer consumer)
        {
            try
            {
                _channel.BasicConsume(queue: ChannelName,
                                     autoAck: true,
                                     consumer: consumer);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
