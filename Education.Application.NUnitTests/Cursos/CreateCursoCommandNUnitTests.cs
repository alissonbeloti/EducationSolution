using AutoFixture;

using AutoMapper;

using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace Education.Application.Cursos;

public class CreateCursoCommandNUnitTests
{
    private CreateCursoCommand.CreateCursoCommandHandle handlerCreateCurso;

    [SetUp]
    public void Setup()
    {
        var fixture = new Fixture();
        var cursoRecords = fixture.CreateMany<Curso>().ToList();

        cursoRecords.Add(fixture.Build<Curso>()
            .With(tr => tr.CursoId, Guid.Empty)
            .Create()
            );

        var options = new DbContextOptionsBuilder<EducationDbContext>()
            .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
            .Options;

        var educationDbContextFake = new EducationDbContext(options);
        educationDbContextFake.Cursos.AddRange(cursoRecords);
        educationDbContextFake.SaveChanges();

        var mapConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingTest());
        });

        var mapper = mapConfig.CreateMapper();

        handlerCreateCurso = new CreateCursoCommand.CreateCursoCommandHandle(educationDbContextFake);
    }

    [Test]
    public async Task CreateCursoCommand_InputCurso_ReturnsNumber()
    {

        CreateCursoCommand.CreateCursoCommandRequest request = new();
        request.DataPublicacao = DateTime.UtcNow.AddDays(-59);
        request.Titulo = "Livro de testes automatizados em NET";
        request.Descricao = "Aprenda a criar unit test desde o zero";
        request.Preco = 56;

        var resultados = await handlerCreateCurso.Handle(request, new System.Threading.CancellationToken());

        Assert.That(resultados, Is.EqualTo(Unit.Value));
        
    }
}
