namespace DistributedEcomm.Core.Projections;

public interface IVersionedProjection : IProjection
{
    public ulong LastProcessedPosition { get; set; }
}