using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JALLPITABlazor.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JALLPITABlazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await context.Personas.ToListAsync();
        }

        [HttpGet("{id}", Name = "obtenerPersona")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            return await context.Personas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerPersona", new { id = persona.Id, }, persona);
        }
    }
}