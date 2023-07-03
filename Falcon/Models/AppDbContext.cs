﻿using System;
using Microsoft.EntityFrameworkCore;

namespace Falcon.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UpSolveProblem> Problems { get; set; }
    }
}
