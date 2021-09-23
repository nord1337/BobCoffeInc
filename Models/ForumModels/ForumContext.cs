using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BobCoffeInc.Models.ForumModels
{
    public class ForumContext:DbContext
    {
        public DbSet<ForumCategories> ForumCategories { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}