
using Microsoft.EntityFrameworkCore;

namespace TestForIS_23_02.DB
{
    public class DB_Context: DbContext
    {
        public DB_Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=Test.db");
        }
        public DbSet<User> Users { get; set; }


      
    }
}
