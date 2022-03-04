using AutoMapper;

using Education.Application.VO;
using Education.Domain;
using Education.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos;

public class GetCursoByIdQuery
{
    public class GetCursoByIdQueryRequest : IRequest<CursoVO>
    {
        public Guid Id { get; set; }
    }

    public class GetCursoByIdQueryHandler : IRequestHandler<GetCursoByIdQueryRequest, CursoVO>
    {
        private readonly EducationDbContext context;
        private readonly IMapper mapper;

        public GetCursoByIdQueryHandler(EducationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<CursoVO> Handle(GetCursoByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var curso = await this.context.Cursos.FirstOrDefaultAsync(x => x.CursoId == request.Id);
            var cursosVO = this.mapper.Map<Curso, CursoVO>(curso);
            return cursosVO;
        }
    }
}
