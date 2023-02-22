namespace Finances.Models
{
    public class Revenue : Entity
    {
        public double LastEarns { get; set; }
        public double CurrentEarns { get; set; }
        public double DayEarn { get; set; }
        public double CurrenteRevenue { get; set; }
        public Guid UsersId { get; set; }
    }
}
