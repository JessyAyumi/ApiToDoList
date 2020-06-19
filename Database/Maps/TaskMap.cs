using ApiToDoList.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiToDoList.Database.Maps
{
    public class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Concluded).IsRequired().HasColumnType("tinyint");
        }
    }
}