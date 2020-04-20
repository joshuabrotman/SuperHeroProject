using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperHero.Models;

namespace SuperHero.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            DbSet<Superhero> Superheroes;
        }
        public DbSet<SuperHero.Models.Superhero> Superhero { get; set; }
    }
}
