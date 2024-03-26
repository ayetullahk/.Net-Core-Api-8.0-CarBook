using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommadHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly UpdateBrandCommadHandler _updateBrandCommadHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommadHandler;

        public BrandsController(CreateBrandCommandHandler createBrandCommadHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, UpdateBrandCommadHandler updateBrandCommadHandler, RemoveBrandCommandHandler removeBrandCommadHandler)
        {
            _createBrandCommadHandler = createBrandCommadHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _updateBrandCommadHandler = updateBrandCommadHandler;
            _removeBrandCommadHandler = removeBrandCommadHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var values = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommadHandler.Handle(command);
            return Ok("Marka Bilgisi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbount(int id)
        {
            await _removeBrandCommadHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Marka Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand commad)
        {
            await _updateBrandCommadHandler.Handle(commad);
            return Ok("Hakkımızda Bilgisi Güncellendi");
        }
    }
}
