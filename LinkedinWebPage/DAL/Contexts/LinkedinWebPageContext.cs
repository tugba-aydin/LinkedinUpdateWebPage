using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexts
{
    public class LinkedinWebPageContext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Experience> Experiences { get; set; }
        DbSet<Education> Educations { get; set; }
        DbSet<Skill> Skills { get; set; }
        DbSet<About>Abouts{get;set;}

        public LinkedinWebPageContext(DbContextOptions<LinkedinWebPageContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Contact>(c=>c.UserId);
            
            modelBuilder.Entity<Experience>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ex => ex.UserId);
            
            modelBuilder.Entity<Education>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ed => ed.UserId);

            modelBuilder.Entity<Skill>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(sk=>sk.UserId);
          
            modelBuilder.Entity<About>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<About>(a => a.UserId);
        }
    }
}
