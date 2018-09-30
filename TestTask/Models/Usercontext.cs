using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class Usercontext : DbContext
    {
        public DbSet<Users> Users { get; set; }

    }
}