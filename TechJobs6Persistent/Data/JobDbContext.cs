using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.Controllers;

namespace TechJobs6Persistent.Data
{
	public class JobDbContext : DbContext
	{
        public DbSet<Job>? Jobs { get; set; }
        public DbSet<Employer>? Employers { get; set; }
        public DbSet<Skill>? Skills { get; set; }

        public JobDbContext(DbContextOptions<JobDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //connecting job and employer (one to many)
            modelBuilder.Entity<Job>()
                .HasOne(e => e.Employer)
                .WithMany(j => j.Jobs);

            //connecting jobs to skills (many to many)
            modelBuilder.Entity<Job>()
                .HasMany(j => j.Skills)
                .WithMany(j => j.Jobs)
                .UsingEntity(js => js.ToTable("JobSkills"));
        }
    }
}

/*
 * 
 * every job has 1 employer, and one employer can have multiple jobs
 * every job knows of one employer
 *  one => many == employer => job
 *  many => one == job => employer
 * 
 * every job can have multiple skills, and every skill can have multiple jobs
 * every job knows multiple skills and every skills can know multiple jobs
 *  many => many == skill => job
 *  many => many == job => skill
 *  
 *  
 */