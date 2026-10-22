using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Dtos;

namespace ProductsApi.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _repository;

    public ProductsController(ProductRepository repository) => _repository = repository;

    [HttpGet]
    public ActionResult<IEnumerable<ProductV1Dto>> GetAll() =>
        Ok(_repository.GetAll().Select(p => new ProductV1Dto(p.Id, p.Name, p.Price)));

    [HttpGet("{id:int}")]
    public ActionResult<ProductV1Dto> GetById(int id)
    {
        var p = _repository.GetById(id);
        return p is null ? NotFound() : Ok(new ProductV1Dto(p.Id, p.Name, p.Price));
    }
}
