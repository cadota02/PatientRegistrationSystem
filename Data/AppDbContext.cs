using Microsoft.EntityFrameworkCore;
using PatientRegistrationSystem.Models;

namespace PatientRegistrationSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
    }
}