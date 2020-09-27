using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.WebAPI.Models;
using System.Linq;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    // Neste [controller] que tem acima, será o mesmo nome da classe que tem logo abaixo. Por exemplo: Se estiver escrito 'ProfessorController', o sistema
    // irá entender que antes da palavra 'Controller' será exatamente o nome que irá na URL, ou seja, apenas 'professor'
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        // Consultar
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // Consultar por Id
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var prof = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("O professor não foi encontrado");
            return Ok(prof);
        }

        // Cadastrar
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // Alterar
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("O professor não foi encontrado");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // Alterar (Patch)
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("O professor não foi encontrado");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("O professor não foi encontrado");
            _context.Remove(prof);
            _context.SaveChanges();
            return Ok(prof);
        }

    }

}