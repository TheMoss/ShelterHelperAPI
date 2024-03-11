# ShelterHelper API
## Documentation

'public async Task<ActionResult<(IEnumerable<Species>, List<Diet> dietNames, List<Toy> toyNames, List<Bedding> beddingNames, List<Accessory> accessoriesNames)>> GetSpeciesDb()' needs to return all these list so the dropdown lists, when creating a new species, can be populated.

public async Task<ActionResult<Diet>> PostNewDiet(Diet diet)
		{
			_context.Diet.Add(diet);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(Get), new {id = diet.DietId}, diet);
		}

-> return CreatedAtAction(nameof(Get), new {id = diet.DietId}, diet);
CreatedAtAction returns 201 code if successful, Get action is referenced to create location header's uri

## Lessons learned
It's difficult to avoid the repetition of GetAttribute methods for each table, even though switching on type is possible in C# now. For each table, the list's type would've had to be different. If a list was declared within the case statement, it won't be accessible because of scope. A Data Transfer Object can achieve carrying data between processes so I can use it to transfer parts of different objects together.

Using a [JsonIgnore] attribute will cause the navigation properties to be omitted, it's necessary because I don't want to give the whole table row's data when creating a new record, only the foreign key ID's. Turns out, in my case I can't use it because then the requested data won't properly deserialize and I used nullable value type instead, so it's not a problem if the specified value is null.

