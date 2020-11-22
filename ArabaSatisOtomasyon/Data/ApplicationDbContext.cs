using ArabaSatisOtomasyon.Entities;
using ArabaSatisOtomasyon.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ArabaSatisOtomasyon.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {      
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
        }
        public virtual DbSet<Araba> Araba { get; set; }
        public virtual DbSet<Ilan> Ilan { get; set; }
        public virtual DbSet<YakitTurleri> YakitTurleri { get; set; }
        public virtual DbSet<VitesTurleri> VitesTurleris { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// configures one-to-many relationship
            //modelBuilder.Entity<Ilan>()
            //    .HasRequired<>(s => s.CurrentGrade)
            //    .WithMany(g => g.Students)
            //    .HasForeignKey<int>(s => s.CurrentGradeId);
        }


    }

}