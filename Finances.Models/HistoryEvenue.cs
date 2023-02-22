namespace Finances.Models
{
    public class HistoryEvenue : Entity
    {
        public string NameTransfer { get; set; }
        public DateTime HourTransfer { get; set; }
        public double Money { get; set; }
        public Guid UsersId { get; set; }
    }
}
