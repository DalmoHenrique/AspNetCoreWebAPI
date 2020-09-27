using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    // Neste [controller] que tem acima, será o mesmo nome da classe que tem logo abaixo. Por exemplo: Se estiver escrito 'ProfessorController', o sistema
    // irá entender que antes da palavra 'Controller' será exatamente o nome que irá na URL, ou seja, apenas 'professor'
    public class ProfessorController : ControllerBase
    {
        public ProfessorController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professores: Marta, Paula, Lucas, Rafa");
        }
    }

}