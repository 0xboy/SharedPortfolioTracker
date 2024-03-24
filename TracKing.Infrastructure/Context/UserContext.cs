using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracKing.Infrastructure.Aggregate;

namespace TracKing.Infrastructure.Context
{
    public class UserContext : BaseContext
    {
        public UserContext() : base("Data Source=users.db")
        {
            Database.Migrate();
        }

        public virtual DbSet<User> Users {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
