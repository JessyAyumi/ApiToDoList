using ApiToDoList.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiToDoList.Database.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Password).IsRequired().HasMaxLength(500).HasColumnType("varchar(500)");
        }
    }
}