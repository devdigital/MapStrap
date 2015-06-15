namespace MapStrap
{
    public interface IMapToAlternativeDomain<TDomain>
    {
        void ToDomainModel(out TDomain result);
    }
}
