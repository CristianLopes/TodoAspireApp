﻿using Microsoft.EntityFrameworkCore;
using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<UserTodos> UserTodos { get; set; }
        public DbSet<RequestLinkAccount> RequestLinkAccounts { get; set; }
        public DbSet<LinkedAccount> LinkedAccounts { get; set; }
    }
}