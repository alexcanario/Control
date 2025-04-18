namespace Dima.Core.Models.Abstractions;

public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; } =  default(T)!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}