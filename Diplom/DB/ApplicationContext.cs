using Diplom.Models;
using Microsoft.EntityFrameworkCore;

namespace Diplom.DB
{
    public class ApplicationContext: DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<FileModel> Files { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options = null) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Определение новостей
            News New1 = new News
            {
                Id = 1,
                Name = "Новость 1",
                Text = "Текст новости",
                CreatedDate = DateTime.Now
            };            
            // Определение новостей
            Admin Admin1 = new Admin
            {
                Id = 1,
                Name = "admin",
                Email = "admin@admin.ru",
                Password = "admin"

            };
            // Определение кружков
            Club Club1 = new Club
            {
                Id = 1,
                Name = "Рисунок и живопись",
                Description = 
                "Рисование помогает ребенку познать окружающий мир, приучает внимательно наблюдать и анализировать форму предметов, развивает зрительную память, пространственное мышление и способность к образному мышлению. Оно учит точности расчета, учит познавать красоту природы, мыслить и чувствовать, воспитывает чувство доброты, сопереживания и сочувствия окружающим."
            };

            modelBuilder.Entity<News>().HasData(New1);
            modelBuilder.Entity<Club>().HasData(Club1);
            modelBuilder.Entity<Admin>().HasData(Admin1);
        }
        }
}
