using Finances.Enums;
using Microsoft.AspNetCore.Http;

namespace Finances.Models
{
    public class Users : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public TypeUser TypeUser { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Imagem { get; set; }
        public DateTime RegisterHour { get; set; }
        public DateTime ReceiveSalary { get; set; }
        public double Salary { get; set; }
        public bool FirtsLogin { get; set; }
        public bool Notification { get; set; }
        public IEnumerable<Debts> Debts { get; set; }
        public IEnumerable<HistoryEvenue> HistoryEvenues { get; set; }
        public IEnumerable<Projects> Projects { get; set; }
        public IEnumerable<Remember> Remembers { get; set; }
        public IEnumerable<Revenue> Revenues { get; set; }
        public IEnumerable<ToDo> ToDos { get; set; }
        public IEnumerable<VisitorsCountries> VisitorsCountries { get; set; }
    }
}
