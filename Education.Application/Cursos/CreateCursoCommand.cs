using Education.Domain;
using Education.Persistence;

using FluentValidation;

using MediatR;

namespace Education.Application.Cursos
{
    public class CreateCursoCommand
    {
        public class CreateCursoCommandRequest : IRequest 
        {
            public string? Titulo { get; set; }
            public string? Descricao { get; set; }
            public DateTime DataPublicacao { get; set; }
            public decimal Preco { get; set; }
        }

        public class CreateCursoCommandRequestValidation: AbstractValidator<CreateCursoCommandRequest>
        {
            public CreateCursoCommandRequestValidation()
            {
                RuleFor(x => x.Descricao).NotEmpty();
                RuleFor(x => x.Titulo).NotEmpty();

            }
        }

        public class CreateCursoCommandHandle : IRequestHandler<CreateCursoCommandRequest>
        {
            private readonly EducationDbContext context;

            public CreateCursoCommandHandle(EducationDbContext educationDbContext)
            {
                this.context = educationDbContext;
            }
            public async Task<Unit> Handle(CreateCursoCommandRequest request, CancellationToken cancellationToken)
            {
                var curso = new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = request.Titulo,
                    Descricao = request.Descricao,
                    DataCriacao = DateTime.UtcNow,
                    DataPublicacao = request.DataPublicacao,
                    Preco = request.Preco,
                };

                context.Add(curso);

                var valor = await context.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Não foi possível inserir o curso.");
            }
        }
    }
}
