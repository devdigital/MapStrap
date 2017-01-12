namespace MapStrap.UnitTests.Dtos
{
    using global::MapStrap.UnitTests.Models;

    internal class UserDto : IMapFromDomain<User>
    {
        public int Id { get; set; }
    }
}