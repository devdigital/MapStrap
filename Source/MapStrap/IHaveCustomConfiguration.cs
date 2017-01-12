namespace MapStrap
{
    using AutoMapper;    

    public interface IHaveCustomConfiguration
    {
        void Configure(IMapperConfigurationExpression configuration);
    }
}