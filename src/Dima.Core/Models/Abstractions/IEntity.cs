namespace Dima.Core.Models.Abstractions;

public interface IEntity
{
    public DateTime CreatedAt { get; set; }
}

public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}