namespace Spine.UnitTests.Models
{
    internal class Admin
    {
        private readonly int id;

        public Admin(int id)
        {
            this.id = id;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }
    }
}