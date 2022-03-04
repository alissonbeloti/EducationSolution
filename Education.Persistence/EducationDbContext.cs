using Education.Domain;

using Microsoft.EntityFrameworkCore;

namespace Education.Persistence
{
    public class EducationDbContext: DbContext
    {
        public EducationDbContext()
        {

        }
        public EducationDbContext(DbContextOptions<EducationDbContext> options): base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost;Initial catalog=Education; Integrated Security=true;User Id=sa;Password=Alisson1012$;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .Property(c => c.Preco)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId= Guid.NewGuid(),
                    Descricao = "Curso C# Basic",
                    Titulo = "C# do 0 ao avançado",
                    DataCriacao = DateTime.Now,
                    DataPublicacao = DateTime.Now.AddYears(2),
                    Preco = 56
                },
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descricao = "Curso Java",
                    Titulo = "Master in Java Springs desde as raizes",
                    DataCriacao = DateTime.Now,
                    DataPublicacao = DateTime.Now.AddYears(2),
                    Preco = 25
                },
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descricao = "Curso de Unit Test para Net Core",
                    Titulo = "Master in Unit Test com CQRS",
                    DataCriacao = DateTime.Now,
                    DataPublicacao = DateTime.Now.AddYears(2),
                    Preco = 1000
                }
            );
        }
    }
}
