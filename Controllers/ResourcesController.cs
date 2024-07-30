using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterHelperAPI.Models;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

		#region Diets

		//GET api/resources/diets/1
		[HttpGet("diets/{id}")]
		[EnableCors("AllowSpecificOrigin")]
		public async Task<ActionResult<Diet>> GetDiet(int id)
		{
			var diet = await _context.Diet.FindAsync(id);
			if (diet == null)
			{
				return NotFound();
			}
			return diet;
		}

		// POST api/resources/diets
		[HttpPost]
		[Route("diets")]

		public async Task<ActionResult<Diet>> PostNewDiet(Diet diet)
		{

			_context.Diet.Add(diet);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new { id = diet.DietId }, diet);
		}

		//PATCH api/resources/diets/1
		[HttpPatch]
		[Route("diets/{id}")]
		[EnableCors("AllowSpecificOrigin")]
		public async Task<ActionResult> PatchDiet(int id, JsonPatchDocument<Diet> patch)
		{
			Diet diet = await _context.Diet.FindAsync(id);
			patch.ApplyTo(diet);
			_context.Diet.Update(diet);
			await _context.SaveChangesAsync();
			return Ok(diet);

		}

		//POST : api/resources/diets/5
		[HttpPost]
		[Route("diets/{id}")]
		public async Task<ActionResult<Accessory>> EditDiet(int id, Diet diet)
		{
			if (id != diet.DietId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Diet.Update(diet);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}

			}
			return NoContent();
		}
			#endregion

			#region Beddings
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

		//POST : api/resources/beddings/5
		[HttpPost]
		[Route("beddings/{id}")]
		public async Task<ActionResult<Accessory>> EditBedding(int id, Bedding bedding)
		{
			if (id != bedding.BeddingId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Bedding.Update(bedding);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}

			}
			return NoContent();
		}
			#endregion

			#region Toys
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
			return CreatedAtAction(nameof(Get), new { id = toy.ToyId }, toy);
		}

		//POST : api/resources/toys/5
		[HttpPost]
		[Route("toys/{id}")]
		public async Task<ActionResult<Accessory>> EditToy(int id, Toy toy)
		{
			if (id != toy.ToyId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Toy.Update(toy);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}

			}
			return NoContent();
		}
			#endregion

			#region Accessories
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
			return CreatedAtAction(nameof(Get), new { id = accessory.AccessoryId }, accessory);
		}

		//POST : api/resources/accessories/5
		[HttpPost]
		[Route("accessories/{id}")]
		public async Task<ActionResult<Accessory>> EditAccessory(int id, Accessory accessory)
		{
			if (id != accessory.AccessoryId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Accessory.Update(accessory);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}

			}
			return NoContent();
			#endregion Accessories
		}
		}
}
