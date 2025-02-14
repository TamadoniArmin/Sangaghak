using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Entities.Users;
using Connection.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Connection.Common
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ExpertConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguraion());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new UserBaseConfiguration());
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Expert>().ToTable("Experts");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Image> Imagies { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<UserBase> Users { get; set; }

    }
}
