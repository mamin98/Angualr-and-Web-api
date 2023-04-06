﻿using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class StoreContext:DbContext

    {
        public StoreContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
