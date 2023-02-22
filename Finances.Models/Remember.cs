namespace Finances.Models
{
    public class Remember : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateRemember { get; set; }
        public Guid UsersId { get; set; }

    }
}
