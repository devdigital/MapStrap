namespace MapStrap.UnitTests.Dtos
{
    using AutoMapper;

    using global::MapStrap.UnitTests.Models;
    
    internal class EmployeeDto : IHaveCustomMap<Employee, EmployeeDto>
    {
        public int Id { get; set; }

        public void Map(IMappingExpression<Employee, EmployeeDto> mapping)
        {
            mapping.ForMember(e => e.Id, cfg => cfg.MapFrom(e => e.Id));
        }
    }
}