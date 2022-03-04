using AutoFixture;

using AutoMapper;

using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace Education.Application.Cursos
{
    public class GetCursoByIdQuery_NUnitTests
    {
        private GetCursoByIdQuery.GetCursoByIdQueryHandler handlerCurso;
        private Guid cursoIdTest;

        [SetUp]
        public void Setup()
        {
            cursoIdTest = Guid.NewGuid();
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>()
                .With(tr => tr.CursoId, cursoIdTest)
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

            handlerCurso = new GetCursoByIdQuery.GetCursoByIdQueryHandler(educationDbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoByIdQueryHandler_InputCursoId_ReturnsNotNull()
        {
            // 1. Emular o context EF - OK
            // 2. Emular o Mapping Profile - OK
            // 3. Instanciar um objeto da classe GetCursoQuery.GetCursoQueryHandler e passar como
            //    parametro os objetos context e mapping
            //      GetCursoQueryHandler(context, mapping) => handler
            GetCursoByIdQuery.GetCursoByIdQueryRequest request = new()
            {
                Id= cursoIdTest
            };
            var resultados = await handlerCurso.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(resultados);
        }
    }
}
