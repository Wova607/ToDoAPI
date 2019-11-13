using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DAL
{
    public class ToDoContext : DbContext
    {

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ToDoContext>
        {
            public ToDoContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../ToDoAPI/appsettings.json").Build();
                var builder = new DbContextOptionsBuilder<ToDoContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new ToDoContext(builder.Options);
            }
        }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTeg>().HasKey(x => new { x.ToDoId, x.TegId });
            modelBuilder.Entity<ToDoTeg>().HasOne(tg => tg.Teg).WithMany(t => t.ToDos).HasForeignKey(tg => tg.TegId);
            modelBuilder.Entity<ToDoTeg>().HasOne(t => t.ToDo).WithMany(tg => tg.Tegs).HasForeignKey(t => t.ToDoId);

            //init entities
            //Category category1 = new Category()
            //{
            //    Id = 1,
            //    Name = "Work"
            //};
            //Teg teg1 = new Teg()
            //{
            //    Id = 1,
            //    Nema = "Project",

            //};

            //Teg teg2 = new Teg()
            //{
            //    Id = 2,
            //    Nema = "Task",

            //};
            //ToDo todo1 = new ToDo()
            //{
            //    Id = 1,
            //    Header = "DoDb",
            //    Description = "Create and fill DB",
            //    ExpireDate = DateTime.Now,
            //    Do = false,
            //    CategoryId = category1.Id,
            //    Category = category1,

            //};
            //ToDoTeg toDoTeg = new ToDoTeg()
            //{
            //    Teg = teg2,
            //    TegId = 2,
            //    ToDo = todo1,
            //    ToDoId = 1
            //};

            //todo1.Tegs.Add(toDoTeg);

            //Db Init
            //modelBuilder.Entity<Category>().HasData(category1);
            //modelBuilder.Entity<Teg>().HasData(teg1, teg2);
            //modelBuilder.Entity<ToDo>().HasData(todo1);
            //modelBuilder.Entity<ToDoTeg>().HasData(toDoTeg);


        }



        public DbSet<Category> Categories { get; set; }
        public DbSet<Teg> Tegs { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoTeg> ToDoTegs { get; set; }
    }
}
