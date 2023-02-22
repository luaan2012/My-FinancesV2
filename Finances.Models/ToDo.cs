namespace Finances.Models
{
    public class ToDo : Entity
    {
        public string Name { get; set; }
        public bool Complete { get; set; }
        public Guid UsersId { get; set; }

    }
}
