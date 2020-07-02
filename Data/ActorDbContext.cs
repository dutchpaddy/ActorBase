using ActorBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ActorBase.Data
{
    public  class ActorDbContext : IdentityDbContext<User>
    {

        public ActorDbContext(DbContextOptions<ActorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Actors> Actors { get; set; }
        public DbSet<User> ActorsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(m => m.Id );
            
            base.OnModelCreating(modelBuilder);
        }


    }
}
