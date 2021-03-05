using Shared.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MediatR;
using TengYueManager.Domain.StudentAggregate;
using TengYueManager.Infrastructure.EntityConfigurations;

namespace TengYueManager.Infrastructure
{
    public class TengYueManagerDbContext : SharedEFContext
    {
        public TengYueManagerDbContext(DbContextOptions<TengYueManagerDbContext> options,IMediator mediator):base(options, mediator)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
    }
}
