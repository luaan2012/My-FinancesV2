using Finances.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finances.Identity
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Users> MyUser { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Debts> Debts { get; set; }
        public DbSet<HistoryEvenue> HistoryEvenues { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<VisitorsCountries> VisitorsCountries { get; set; }
        public DbSet<Remember> Remembers { get; set; }
        public DbSet<Revenue> Revenues { get; set; }

    }
}