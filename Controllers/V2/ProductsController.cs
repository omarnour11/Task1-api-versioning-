using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Dtos;

namespace ProductsApi.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _repository;

    public ProductsController(ProductRepository repository) => _repository = repository;

    [HttpGet]
    public ActionResult<IEnumerable<ProductV2Dto>> GetAll() =>
        Ok(_repository.GetAll().Select(p =>
            new ProductV2Dto(p.Id, p.Name, p.Price, p.Category?.Name ?? string.Empty)));

    [HttpGet("{id:int}")]
    public ActionResult<ProductV2Dto> GetById(int id)
    {
        var p = _repository.GetById(id);
        return p is null
            ? NotFound()
            : Ok(new ProductV2Dto(p.Id, p.Name, p.Price, p.Category?.Name ?? string.Empty));
    }
}
