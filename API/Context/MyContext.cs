using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }//representasi tiap table, tambah table tambah dbset
        public DbSet<University> Universities { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Profilling> Profillings { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRole { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>()
                .HasMany(education => education.Educations)
                .WithOne(university => university.University);

            modelBuilder.Entity<Profilling>()
                .HasOne(e => e.Education)
                .WithMany(profilling => profilling.Profillings)
                .HasForeignKey(ed => ed.EducationId);

           /* modelBuilder.Entity<Profilling>()
                .HasOne(a => a.Account)
                .WithOne(p => p.Profilling)
                .HasForeignKey<Profilling>(nik => nik.NIK);
            modelBuilder.Entity<Profilling>().ToTable("tb_m_profilling");
            modelBuilder.Entity<Account>().ToTable("tb_m_profilling");*/

            modelBuilder.Entity<Account>()
                .HasOne(profilling => profilling.Profilling)
                .WithOne(account => account.Account)
                .HasForeignKey<Profilling>(nik => nik.NIK);
            //modelBuilder.Entity<Account>().ToTable("tb_m_account");
            //modelBuilder.Entity<Profilling>().ToTable("tb_m_account");

             modelBuilder.Entity<Employee>()
               .HasOne(account => account.Account)
               .WithOne(employee => employee.Employee)
               .HasForeignKey<Account>(nik => nik.NIK);

            modelBuilder.Entity<AccountRole>()
               .HasOne(ar => ar.Account)
               .WithMany(a => a.AccountRole);

            modelBuilder.Entity<AccountRole>()
               .HasOne(ar => ar.Role)
               .WithMany(r => r.AccountRole);


        }
    }
}
