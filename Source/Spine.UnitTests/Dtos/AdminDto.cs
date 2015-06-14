namespace Spine.UnitTests.Dtos
{
    using AutoMapper;

    using global::Spine.UnitTests.Models;

    internal class AdminDto : IHaveCustomConfiguration
    {
        public int Id { get; set; }

        public void Configure(IConfiguration configuration)
        {
            configuration.CreateMap<Admin, AdminDto>();
        }
    }
}