using ASS02EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS02EF
{
    internal class ApplicationDbContest:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=localhost;Database=MyAppDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        #region Dbset 
        public DbSet<Orginazer> orginazers {  get; set; }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Badge> badges { get; set; }
        public DbSet<Attendee> attendees { get; set; }
        #endregion
        #region Fluent Api 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Event 
            modelBuilder.Entity<Event>
            (eve =>
            {
                eve.HasKey(k => k.Id);
                eve.Property(p => p.Title).HasMaxLength(50).IsRequired();
                eve.Property(p => p.Description).HasMaxLength(300);
                eve.Property(p => p.startdate).HasColumnType("datetime").IsRequired();
                eve.Property(p => p.enddate).HasColumnType("datetime");
                eve.Property(p => p.MaxAttendees).HasColumnType("int");
            });
            #endregion
        }

        #endregion

    }
}
