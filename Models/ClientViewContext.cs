using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    public class ClientViewContext : DbContext
    {
        public DbSet<ClientView> ClientViews { get; set; }

        public ClientViewContext(DbContextOptions<ClientViewContext> options) :base(options)
        {}
    }
}