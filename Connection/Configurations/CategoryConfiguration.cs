using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.Subcategories)
                .WithOne(x => x.ParentCategory)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(new List<Category>()
            {
                new Category() { Id = 1, Title = "بنایی", ParentId = null },
                new Category() { Id = 2, Title = "برقکاری", ParentId = null},
                new Category() { Id = 3, Title = "نقاشی", ParentId = null},
                new Category() { Id = 4, Title = "لوله کشی", ParentId = null},
                new Category() { Id = 5, Title = "دکوراسیون داخلی", ParentId = null},

                new Category() { Id = 6, Title = "گچ کاری", ParentId = 1},
                new Category() { Id = 7, Title = "آجرچینی", ParentId = 1},

                new Category() { Id = 8, Title = "رنگزنی دیوار و سقف", ParentId = 3},
                new Category() { Id = 9, Title = "کاغذ دیواری", ParentId = 5},

            });

        }
    }
}
