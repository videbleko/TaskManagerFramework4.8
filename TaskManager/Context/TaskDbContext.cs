using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.Context
{
    public class TaskDbContext:DbContext
    {
        public TaskDbContext() : base("name=LocalDB") { }
        public DbSet<Tasks> Tasks { get; set; }
    }
}