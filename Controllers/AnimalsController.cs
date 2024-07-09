using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterHelperAPI.Models;

namespace ShelterHelperAPI.Controllers
{
	[Route("api/animals")]
	[ApiController]
	public class AnimalsController : ControllerBase
	{
		private readonly ShelterContext _context;


		public AnimalsController(ShelterContext context)
		{
			_context = context;
		}

		// GET: api/animals
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalsDb()
		{
			return await _context.AnimalsDb.ToListAsync();
		}

		// GET: api/animals/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Animal>> GetAnimal(int id)
		{
			var animal = await _context.AnimalsDb.FindAsync(id);

			if (animal == null)
			{
				return NotFound();
			}

			return animal;
		}

		// PUT: api/animals/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAnimal(int id, Animal animal)
		{
			if (id != animal.Id)
			{
				return BadRequest();
			}

			_context.Entry(animal).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AnimalExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/animals
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
		{
			_context.AnimalsDb.Update(animal);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
		}

		// DELETE: api/Animals/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAnimal(int id)
		{
			var animal = await _context.AnimalsDb.FindAsync(id);
			if (animal == null)
			{
				return NotFound();
			}

			_context.AnimalsDb.Remove(animal);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool AnimalExists(int id)
		{
			return _context.AnimalsDb.Any(e => e.Id == id);
		}
	}
}
