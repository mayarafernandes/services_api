using UserModel = Company.Services.Model.User;
using Microsoft.EntityFrameworkCore;
using System;

namespace Company.Services.User.Repository
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) 
        {
            
        }

        public virtual DbSet<UserModel.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel.User>()
                .HasData(
                    new UserModel.User(new Guid("220e7528-3cd7-493b-9ab3-d7f369bdb3dc"), "John"),
                    new UserModel.User(new Guid("b8b55a7b-c18a-4ee4-964b-f8f22bf93663"), "Mary"),
                    new UserModel.User(new Guid("8fcf47f5-b08b-4f3c-a78f-38b0ffedc822"), "Karen"),
                    new UserModel.User(new Guid("f3a5e45f-c627-4588-8c76-9ce908c44fd8"), "Steve"),
                    new UserModel.User(new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f"), "Lauren")
                ); 
        }
    }
}