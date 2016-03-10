using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniprojektRAM.DataAccessLayer
{
    public class ItemContext : DbContext
    {
        public ItemContext() : base("DefaultConnection") { }

        public DbSet<Models.Question> Question { get; set; }
        public DbSet<Models.QuestionCategory> QuestionCategory { get; set; }
    }
}