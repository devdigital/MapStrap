namespace Spine
{
    public interface IMapToDomain<out TDomain>
    {
        TDomain ToDomainModel();
    }
}
