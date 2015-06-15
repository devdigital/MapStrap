namespace MapStrap
{
    using AutoMapper;

    public interface IHaveCustomMap<TSource, TDestination>
    {
        void Map(IMappingExpression<TSource, TDestination> mapping);
    }
}