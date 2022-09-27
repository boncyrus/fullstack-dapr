namespace Bcm.BcmAir.Infrastructure.Common.Messaging
{
    public record EventMessage
    {
        public Guid Id { get; }
        public DateTime CreatedDate { get; }

        public EventMessage()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
