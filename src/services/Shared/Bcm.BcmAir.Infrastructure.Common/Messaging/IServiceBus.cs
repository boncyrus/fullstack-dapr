namespace Bcm.BcmAir.Infrastructure.Common.Messaging
{
    public interface IServiceBus
    {
        Task Publish(EventMessage message);
    }
}
