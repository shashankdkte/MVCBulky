using Microsoft.EntityFrameworkCore;
using MVCBulkyWeb.Models;

namespace MVCBulkyWeb.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

    }
}
