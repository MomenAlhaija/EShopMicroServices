namespace Order.Domain.Events;

public record OrderCreatedEvent(Model.Order order) : IDomainEvent;
