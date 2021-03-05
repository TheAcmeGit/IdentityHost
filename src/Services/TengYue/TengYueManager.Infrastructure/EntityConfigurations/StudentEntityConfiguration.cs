using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TengYueManager.Domain.StudentAggregate;

namespace TengYueManager.Infrastructure.EntityConfigurations
{
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(f => f.Id);
            builder.OwnsOne(f=>f.Address,a=> {
                a.WithOwner();
                a.Property(f => f.City).HasMaxLength(100);
                a.Property(f => f.Street).HasMaxLength(200);
            });
        }
    }
}
