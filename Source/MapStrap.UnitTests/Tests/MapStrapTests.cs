namespace MapStrap.UnitTests.Tests
{
    using AutoMapper;

    using global::MapStrap.UnitTests.Dtos;
    using global::MapStrap.UnitTests.Models;

    using Xunit;

    public class MapStrapTests
    {
        [Fact]
        public void CreateConventionMaps()
        {
            var config = new MapperConfiguration(
                cfg => { cfg.CreateConventionMaps(new AssemblyTypeResolver(new[] { typeof(UserDto).Assembly }, publicOnly: false)); });

            var mapper = config.CreateMapper();

            var user = new User(5);
            var userDto = mapper.Map<User, UserDto>(user);
            Assert.Equal(5, userDto.Id);
        }

        [Fact]
        public void CreateCustomMaps()
        {
            var config = new MapperConfiguration(
             cfg => { cfg.CreateCustomMaps(new AssemblyTypeResolver(new[] { typeof(UserDto).Assembly }, publicOnly: false)); });

            var mapper = config.CreateMapper();

            var employee = new Employee(5);
            var employeeDto = mapper.Map<Employee, EmployeeDto>(employee);
            Assert.Equal(5, employeeDto.Id);
        }

        [Fact]
        public void CreateCustomConfigurations()
        {
            var config = new MapperConfiguration(
             cfg => { cfg.CreateCustomConfigurations(new AssemblyTypeResolver(new[] { typeof(UserDto).Assembly }, publicOnly: false)); });

            var mapper = config.CreateMapper();

            var admin = new Admin(5);
            var adminDto = mapper.Map<Admin, AdminDto>(admin);
            Assert.Equal(5, adminDto.Id);
        }

        [Fact]
        public void CreateMaps()
        {
            var config = new MapperConfiguration(
                cfg => { cfg.CreateMaps(new AssemblyTypeResolver(new[] { typeof(UserDto).Assembly }, publicOnly: false)); });

            var mapper = config.CreateMapper();

            var user = new User(5);
            var userDto = mapper.Map<User, UserDto>(user);

            var employee = new Employee(5);
            var employeeDto = mapper.Map<Employee, EmployeeDto>(employee);

            var admin = new Admin(5);
            var adminDto = mapper.Map<Admin, AdminDto>(admin);

            Assert.Equal(5, userDto.Id);
            Assert.Equal(5, employeeDto.Id);
            Assert.Equal(5, adminDto.Id);
        }        
    }
}