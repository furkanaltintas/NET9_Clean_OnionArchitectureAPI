using Microsoft.AspNetCore.Mvc;
using OnionDemo.Application.Interfaces.UnitOfWorks;
using OnionDemo.Domain.Entities;
using System.Threading.Tasks;

namespace OnionDemo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly IUnitOfWork _uow;

        public ValuesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await _uow.GetReadRepository<Product>().GetAllAsync());
        }
    }
}
