namespace Order.Domain.Events;

public record OrderUpdatedEvent(Model.Order order):IDomainEvent;
