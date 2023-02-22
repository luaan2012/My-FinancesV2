namespace Finances.Models
{
    public class VisitorsCountries : Entity
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double ValueGoal { get; set; }
        public Guid UsersId { get; set; }

    }
}
