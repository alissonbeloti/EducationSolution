using Education.Application.Cursos;
using Education.Application.VO;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private IMediator mediator;

        public CursoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoVO>>> Get()
        {
            return await this.mediator.Send(new GetCursoQuery.GetCursoQueryRequest());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateCursoCommand.CreateCursoCommandRequest request)
        {
            return await this.mediator.Send(request);
        }
    }
}
