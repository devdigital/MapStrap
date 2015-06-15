namespace MapStrap
{
    public interface IMapToDomain<out TDomain>
    {
        TDomain ToDomainModel();
    }
}
