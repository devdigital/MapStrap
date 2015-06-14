namespace Spine.UnitTests.Dtos
{
    using global::Spine.UnitTests.Models;

    internal class UserDto : IMapFromDomain<User>
    {
        public int Id { get; set; }
    }
}
