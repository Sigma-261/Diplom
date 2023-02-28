using Diplom.Models;
using Microsoft.EntityFrameworkCore;

namespace Diplom.DB
{
    public class ApplicationContext: DbContext
    {
        public DbSet<News> News { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options = null) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Определение локации
            News New1 = new News
            {
                Id = 1,
                Name = "Новость 1",
                Text = "Текст новости",
                CreatedDate = DateTime.Now
            };
            modelBuilder.Entity<News>().HasData(New1);
        }
        }
}
