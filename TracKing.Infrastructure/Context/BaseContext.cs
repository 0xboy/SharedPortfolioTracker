using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.Context
{
    public class BaseContext : DbContext
    {
        private readonly string _connString;

        public BaseContext(string connString) 
        {
            _connString = connString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connString);
        }

    }
}
