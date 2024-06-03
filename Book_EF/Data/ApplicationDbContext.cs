using Book_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_EF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op) 
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
