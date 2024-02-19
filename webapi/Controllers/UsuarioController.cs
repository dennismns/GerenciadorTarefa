using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;
using webapi.Repository;

namespace webapi.Controllers
{
    [ApiController]
    [Route("Usuario/v1")]
    public class UsuarioController : Controller
    {


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(int id, [FromServices] DataContext context)
        {
            UsuarioRepository user = new UsuarioRepository();
            var usuarios = user.Get().ToList();
            return Ok(usuarios);
        }
    }
}
