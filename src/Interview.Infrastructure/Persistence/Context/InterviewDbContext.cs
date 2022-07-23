using Interview.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Interview.Infrastructure.Persistence.Context
{
    public class InterviewDbContext : DbContext
    {
        public InterviewDbContext(DbContextOptions<InterviewDbContext> options) : base(options) { }
        public DbSet<Interviewer> Interviewer { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<AvailabilitySlots> AvailabilitySlots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interviewer>()
                .HasMany(b => b.Availabilities)
                .WithOne(c => c.Interviewer)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Interviewer>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Interviewer>()
                .Property(b => b.CreatedAt)
                .IsRequired();


            modelBuilder.Entity<Candidate>()
                .HasMany(b => b.Availabilities)
                .WithOne(c => c.Candidate)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Candidate>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Candidate>()
                .Property(b => b.CreatedAt)
                .IsRequired();


            modelBuilder.Entity<AvailabilitySlots>()
                .Property(b => b.Start)
                .IsRequired();

            modelBuilder.Entity<AvailabilitySlots>()
                .Property(b => b.End)
                .IsRequired();

            modelBuilder.Entity<AvailabilitySlots>()
                .Property(b => b.CreatedAt)
                .IsRequired();
        }
    }
}
