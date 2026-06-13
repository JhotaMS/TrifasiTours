namespace TrifasiTours.Domain.Abstractions;
public interface IEntityBase<T> {
    T Id { get; init; }
}
