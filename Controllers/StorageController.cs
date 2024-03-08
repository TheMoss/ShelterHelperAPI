using Microsoft.AspNetCore.Mvc;
using ShelterHelperAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShelterHelperAPI.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class StorageController : ControllerBase
	{
		private readonly ShelterContext _context;

		public StorageController(ShelterContext context)
		{
			_context = context;
		}

		// GET: api/<StorageController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<StorageController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<StorageController>/Diet
		[HttpPost]
		[Route("Diet")]
		public async Task<ActionResult<Diet>> PostNewDiet(Diet diet)
		{
			_context.Diet.Add(diet);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new {id = diet.DietId}, diet);
		}

		// POST api/<StorageController>/Bedding
		[HttpPost]
		[Route("Bedding")]
		public async Task<ActionResult<Bedding>> PostNewBedding(Bedding bedding)
		{
			_context.Bedding.Add(bedding);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new { id = bedding.BeddingId }, bedding);
		}

		// POST api/<StorageController>/Toy
		[HttpPost]
		[Route("Toy")]
		public async Task<ActionResult<Toy>> PostNewToy(Toy toy)
		{
			_context.Toy.Add(toy);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new { id = toy.ToyId}, toy);
		}

		// POST api/<StorageController>/Accessory
		[HttpPost]
		[Route("Accessory")]
		public async Task<ActionResult<Accessory>> PostNewAccessory(Accessory accessory)
		{
			_context.Accessory.Add(accessory);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new { id = accessory.AccessoryId}, accessory);
		}

		// PUT api/<StorageController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<StorageController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
