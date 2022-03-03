using DistributedEcomm.Core.Projections;
using Eventuous;

namespace DistributedEcomm.Core.Aggregates;

public interface IAggregate : IAggregate<Aggregate>
{
}

public interface IAggregate<out T> : IProjection
{
    T Id { get; }
    int Version { get; }
}