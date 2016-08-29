using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TA.Data
{
    public class OrderDBContext : DbContext
    {
        public DbSet<Order> order { get; set; }
    }
}
