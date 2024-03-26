using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommadHandler _createAboutCommadHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly UpdateAboutCommadHandler _updateAboutCommadHandler;
        private readonly RemoveAboutCommadHandler _removeAboutCommadHandler;

        public AboutsController(CreateAboutCommadHandler createAboutCommadHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommadHandler updateAboutCommadHandler, RemoveAboutCommadHandler removeAboutCommadHandler)
        {
            _createAboutCommadHandler = createAboutCommadHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutCommadHandler = updateAboutCommadHandler;
            _removeAboutCommadHandler = removeAboutCommadHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values=await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createAboutCommadHandler.Handle(command);
            return Ok("Hakkımda Bilgisi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbount(int id)
        {
            await _removeAboutCommadHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımızda Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommad commad)
        {
            await _updateAboutCommadHandler.Handle(commad);
            return Ok("Hakkımızda Bilgisi Güncellendi");
        }
    }
}
