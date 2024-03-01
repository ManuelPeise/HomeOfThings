using Microsoft.EntityFrameworkCore;

namespace Database.HotContext
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions opt):base(opt) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
