using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace medAPI.Entities
{
    public class MedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<User> Users { get; set; }

        public  DbSet<Appointment> Appointments { get; set; }


        public MedDbContext(DbContextOptions<MedDbContext> options, IConfiguration configuration) :base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Doctors>()
         .HasKey(d => d.DoctorId);

             modelBuilder.Entity<Doctors>()
         .HasOne(d => d.User)
         .WithOne(u => u.Doctors)
         .HasForeignKey<Doctors>(d => d.UserId);


             modelBuilder.Entity<Doctors>()
         .HasMany(d => d.Patients)
         .WithOne(p => p.Doctors)
         .HasForeignKey(p => p.doctorId);


             modelBuilder.Entity<Patients>()
                 .HasOne(p => p.User)
                 .WithMany()
                 .HasForeignKey(p => p.userId)
                 .OnDelete(DeleteBehavior.Restrict);



             modelBuilder.Entity<Specialization>()
                 .HasKey(s => s.SpecId);*/

            modelBuilder.Entity<Doctor>()
              .HasMany(d => d.Appointments)
              .WithOne(p => p.Doctor)
              .HasForeignKey(p => p.DoctorId)
              .OnDelete(DeleteBehavior.Restrict);

            

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithMany(u => u.Patients)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Doctor>()
         .HasOne(d => d.User) // Jeden Doctor ma jednego Usera
         .WithOne(u => u.Doctor) // Jeden User ma jednego Doctora
         .HasForeignKey<Doctor>(d => d.UserId) // Klucz obcy w tabeli Doctor
         .OnDelete(DeleteBehavior.Cascade); // Możesz ustawić kaskadowe usuwanie


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
