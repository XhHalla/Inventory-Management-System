﻿using Microsoft.EntityFrameworkCore;
using UsersAdmin.Models.Entities;

namespace UsersAdmin.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
