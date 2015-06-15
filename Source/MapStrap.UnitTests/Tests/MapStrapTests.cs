﻿namespace MapStrap.UnitTests.Tests
{
    using AutoMapper;

    using global::MapStrap.UnitTests.Dtos;
    using global::MapStrap.UnitTests.Models;

    using Xunit;

    public class MapStrapTests
    {
        [Fact]
        public void CreateMapsMapsConvention()
        {            
            new MapStrap()                      
                .SelectDtosFromAssemblies(new[] { typeof(UserDto).Assembly }, publicOnly: false)
                .CreateMaps();

            var user = new User(5);
            var userDto = Mapper.Map<User, UserDto>(user);
            Assert.Equal(5, userDto.Id);
        }

        [Fact]
        public void CreateMapsMapsCustom()
        {
            new MapStrap()
                .SelectDtosFromAssemblies(new[] { typeof(EmployeeDto).Assembly }, publicOnly: false)
                .CreateMaps();

            var employee = new Employee(5);
            var employeeDto = Mapper.Map<Employee, EmployeeDto>(employee);
            Assert.Equal(5, employeeDto.Id);
        }

        [Fact]
        public void CreateMapsMapsConfiguration()
        {
            new MapStrap()
                .SelectDtosFromAssemblies(new[] { typeof(AdminDto).Assembly }, publicOnly: false)
                .CreateMaps();

            var admin = new Admin(5);
            var adminDto = Mapper.Map<Admin, AdminDto>(admin);
            Assert.Equal(5, adminDto.Id);
        }
    }
}