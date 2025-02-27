using App.Domain.Core.Sangaghak.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Connection.Configurations
{
    public class UserBaseConfiguration 
    {
        public static void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<UserBase>();

            //SeedUsers
            var users = new List<UserBase>
        {
            new UserBase()
            {
                Id = 1,
                UserName = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                Mobile = "09377507920",
                SecurityStamp = "ada9a37d-4e66-4f49-a14e-bf1f4bd0e6f0",
                CityId = 3,
                //AdminId = 1,
                RoleId = 1,
                ConcurrencyStamp ="e975c22f-8ab0-44e3-805f-7fdd0dd974c7",
                PasswordHash="AQAAAAIAAYagAAAAENZzgudddM6uMKVrN6RXQO9fhzSGKyginx5emR1QIKySt7TAfPHMHbsonZfYcotxbA==",
                RegisteredAt=new DateTime(2025,1,1)
            },
            new UserBase()
            {
                Id = 2,
                UserName = "Customer@gmail.com",
                NormalizedUserName = "CUSTOMER@GMAIL.COM",
                Email = "Customer@gmail.com",
                NormalizedEmail = "CUSTOMER@GMAIL.COM",
                LockoutEnabled = false,
                Mobile = "09222222222",
                SecurityStamp = "bd984d87-783f-4230-9797-4c37e661373b",
                CityId = 1,
                //CustomerId = 1,
                RoleId = 2,
                ConcurrencyStamp ="9f860973-8ca8-4f36-8aaf-9dc177c92bac",
                PasswordHash="AQAAAAIAAYagAAAAEHKRtQ90vsbb39tRXod/l3TdKUV4dN+SoRhYrRCgQYgesUOEVcWcBotKpqNf7OIujw==",
                RegisteredAt=new DateTime(2025,1,1)
            },
            new UserBase()
            {
                Id = 3,
                UserName = "Expert@gmail.com",
                NormalizedUserName = "EXPERT@GMAIL.COM",
                Email = "Expert@gmail.com",
                NormalizedEmail = "EXPERT@GMAIL.COM",
                LockoutEnabled = false,
                Mobile = "09333333333",
                SecurityStamp = "56da5aa9-24c0-4932-8688-1c49e8aad93d",
                CityId = 1,
                //ExpertId = 1,
                RoleId = 3,
                ConcurrencyStamp ="27965def-0d29-4833-90d6-1a59788a1525",
                PasswordHash="AQAAAAIAAYagAAAAEDNGogG29TzbpfXR8dEyW54z9msx39N5p7J60B8qFXsXyqn3wlEH2YyTrCo/r898MQ==",
                RegisteredAt=new DateTime(2025,1,1)
            }
        };

            foreach (var user in users)
            {
                //var passwordHasher = new PasswordHasher<UserBase>();
                //user.PasswordHash = passwordHasher.HashPassword(user, "123456");
                builder.Entity<UserBase>().HasData(user);
            }

            // Seed Roles
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int>() { Id = 2, Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole<int>() { Id = 3, Name = "Expert", NormalizedName = "EXPERT" }
            );

            //Seed Role To Users
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
                new IdentityUserRole<int>() { RoleId = 3, UserId = 3 }
            );
        }
    }
}
