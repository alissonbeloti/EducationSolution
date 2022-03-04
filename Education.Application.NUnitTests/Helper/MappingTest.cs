using AutoMapper;

using Education.Application.VO;
using Education.Domain;

namespace Education.Application.Helper
{
    public class MappingTest: Profile
    {
        public MappingTest()
        {
            CreateMap<Curso, CursoVO>();
        }
    }
}
