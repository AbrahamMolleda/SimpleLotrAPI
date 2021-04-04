using System;
using System.Linq;
using LotrAPI.Data;
using LOTRAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LotrAPI.Controllers
{
    [Route("personajes")]
    [ApiController]
    public class PersonajesControllers : Controller
    {
        private readonly LotrContext _context;
        public PersonajesControllers(LotrContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetPersonajes()
        {
            return Ok(_context.personajes.ToList());
        }

        [HttpGet("{id}", Name = "GetPersonajeId")]
        public ActionResult GetPersonajeById(int id)
        {
            var personaje = _context.personajes.FirstOrDefault(p => p.IdPersonaje == id);
            return Ok(personaje);
        }

        [HttpPost]
        public ActionResult CreatePersonaje([FromBody] Personaje personaje)
        {
            _context.personajes.Add(personaje);
            _context.SaveChanges();
            return CreatedAtRoute("GetPersonajeId", new { id = personaje.IdPersonaje }, personaje);
        }

        [HttpPut("{id}")]
        public ActionResult ChangePersonaje(int id, [FromBody] Personaje personaje)
        {
            try
            {
                if (personaje.IdPersonaje == id)
                {
                    _context.Entry(personaje).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetPersonajeId", new { id = personaje.IdPersonaje }, personaje);
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePersonaje(int id)
        {
            try
            {
                var personaje = _context.personajes.FirstOrDefault(p => p.IdPersonaje == id);
                if (personaje != null)
                {
                    _context.personajes.Remove(personaje);
                    _context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}