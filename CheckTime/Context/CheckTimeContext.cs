using CheckTime.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckTime.Context
{
    public class CheckTimeContext :DbContext
    {
        public CheckTimeContext(DbContextOptions<CheckTimeContext> options) : base(options) { }

        public DbSet<TimeCheck> TimeCheck { get; set; }
    }
}
