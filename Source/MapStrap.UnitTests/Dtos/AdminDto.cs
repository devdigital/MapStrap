namespace MapStrap.UnitTests.Dtos
{    
    using AutoMapper;

    using global::MapStrap.UnitTests.Models;    

    internal class AdminDto : IHaveCustomConfiguration
    {
        public int Id { get; set; }

        public void Configure(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Admin, AdminDto>();
        }
    }
}