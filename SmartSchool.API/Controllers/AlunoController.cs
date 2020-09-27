using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        public List<Models.Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Dalmera",
                Sobrenome = "Almeira",
                Telefone = "1234566777"
            },
            new Aluno(){
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "2352342544"
            },
            new Aluno(){
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Maria",
                Telefone = "4567456778"
            }
        };

        public AlunoController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // api/aluno/1
        // Esta sintaxe funciona [HttpGet("{id:int}")]. Mas a maioria utiliza essa outra sintaxe abaixo:
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        // api/aluno/Dalmera
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }

}