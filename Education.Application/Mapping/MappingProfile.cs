using AutoMapper;

using Education.Application.VO;
using Education.Domain;

namespace Education.Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Curso, CursoVO>();
        }
    }
}
