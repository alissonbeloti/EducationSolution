using AutoFixture;

using AutoMapper;

using Education.Application.Cursos;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace Education.Application.NUnitTests.Cursos;

[TestFixture]
public class GetCursoQueryNUnitTests
{

    private GetCursoQuery.GetCursoQueryHandler handlerAllCursos;

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

        handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(educationDbContextFake, mapper);
    }

    [Test]
    public async Task GetCursoQueryHandler_ConsultaCursos_ReturnsTrue()
    {
        // 1. Emular o context EF - OK
        // 2. Emular o Mapping Profile - OK
        // 3. Instanciar um objeto da classe GetCursoQuery.GetCursoQueryHandler e passar como
        //    parametro os objetos context e mapping
        //      GetCursoQueryHandler(context, mapping) => handler
        GetCursoQuery.GetCursoQueryRequest request = new();
        var resultados = await handlerAllCursos.Handle(request, new System.Threading.CancellationToken());   

        Assert.IsNotNull(resultados);
        Assert.True(resultados.Count > 0);
    }
}
