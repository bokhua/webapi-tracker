using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    public class ClientViewContext : DbContext
    {
        public DbSet<ClientView> ClientViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sqlite.db");
        } 
    }
}