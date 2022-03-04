using AutoMapper;

using Education.Application.VO;
using Education.Domain;
using Education.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos
{
    public class GetCursoQuery
    {
        public class GetCursoQueryRequest: IRequest<List<CursoVO>>
        {

        }

        public class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, List<CursoVO>>
        {
            private readonly EducationDbContext context;
            private readonly IMapper mapper;

            public GetCursoQueryHandler(EducationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<List<CursoVO>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
            {
                var cursos = await this.context.Cursos.ToListAsync();
                var cursosVO = this.mapper.Map<List<Curso>, List<CursoVO>>(cursos);
                return cursosVO;
            }
        }
    }
}
