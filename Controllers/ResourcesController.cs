using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterHelperAPI.Models;

namespace ShelterHelperAPI.Controllers
{

	[Route("api/resources")]
	[ApiController]
	public class ResourcesController : ControllerBase
	{
		private readonly ShelterContext _context;

		public ResourcesController(ShelterContext context)
		{
			_context = context;
		}

		//GET: api/resources
		[HttpGet]
		public async Task<ActionResult<StorageDto>> Get()
		{
			var attributesDto = new StorageDto();

			attributesDto.DietsList = await _context.Diet.ToListAsync();
			attributesDto.BeddingsList = await _context.Bedding.ToListAsync();
			attributesDto.ToysList = await _context.Toy.ToListAsync();
			attributesDto.AccessoriesList = await _context.Accessory.ToListAsync();

			return attributesDto;
		}

		#region Diet		

		//GET api/resources/diet/1
		[HttpGet("diet/{id}")]		
		public async Task<ActionResult<Diet>> GetDiet(int id)
		{
			var diet = await _context.Diet.FindAsync(id);
			if (diet == null)
			{
				return NotFound();
			}
			return diet;
		}

		//PATCH api/resources/diet/1
		[HttpPatch]
		[Route("diet/{id}")]
		public async void PatchDiet(int id, JsonPatchDocument patchDocument)
		{

		}
		// POST api/resources/diet
		[HttpPost]
		[Route("diet")]
		public async Task<ActionResult<Diet>> PostNewDiet(Diet diet)
		{
			_context.Diet.Add(diet);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new {id = diet.DietId}, diet);
		}
		#endregion

		#region Bedding
		//GET api/resources/beddings/1
		[HttpGet("beddings/{id}")]
		public async Task<ActionResult<Bedding>> GetBedding(int id)
		{
			var bedding = await _context.Bedding.FindAsync(id);
			if (bedding == null)
			{
				return NotFound();
			}
			return bedding;
		}

		// POST api/resources/beddings
		[HttpPost]
		[Route("beddings")]
		public async Task<ActionResult<Bedding>> PostNewBedding(Bedding bedding)
		{
			_context.Bedding.Add(bedding);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new { id = bedding.BeddingId }, bedding);
		}

		#endregion

		#region Toy
		//GET api/resources/toys/1
		[HttpGet("toys/{id}")]
		public async Task<ActionResult<Toy>> GetToy(int id)
		{
			var toy = await _context.Toy.FindAsync(id);
			if (toy == null)
			{
				return NotFound();
			}
			return toy;
		}

		// POST api/resources/toys
		[HttpPost]
		[Route("toys")]
		public async Task<ActionResult<Toy>> PostNewToy(Toy toy)
		{
			_context.Toy.Add(toy);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new { id = toy.ToyId}, toy);
		}
		#endregion

		#region Accessory
		//GET api/resources/accessories/1
		[HttpGet("accessories/{id}")]
		public async Task<ActionResult<Accessory>> GetAccessory(int id)
		{
			var accessory = await _context.Accessory.FindAsync(id);
			if (accessory == null)
			{
				return NotFound();
			}
			return accessory;
		}

		// POST api/resources/accessories
		[HttpPost]
		[Route("accessories")]
		public async Task<ActionResult<Accessory>> PostNewAccessory(Accessory accessory)
		{
			_context.Accessory.Add(accessory);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new { id = accessory.AccessoryId}, accessory);
		}
		#endregion
		
	}
}
