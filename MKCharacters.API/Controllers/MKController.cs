using MKCharacters.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MKCharacters.API.Controllers;

[ApiVersion("1.0")]
[Route("characters")]
[Authorize]
[ApiController]
public class MKV1Controller : ControllerBase
{
    private readonly MKContext _context;

    public MKV1Controller(MKContext context)
    {
        _context = context;

        _context.Database.EnsureCreated();
    }

    [HttpGet]
    public async Task<ActionResult> GetAllCharacters([FromQuery] CharacterQueryParameters queryParameters)
    {
        IQueryable<Character> characters = _context.Characters;

        if (queryParameters.MinDamage != null)
        {
            characters = characters.Where(
                p => p.Damage >= queryParameters.MinDamage.Value);
        }

        if (queryParameters.MaxDamage != null)
        {
            characters = characters.Where(
                p => p.Damage <= queryParameters.MaxDamage.Value);
        }

        if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
        {
            characters = characters.Where(
                p => p.Variant.ToLower().Contains(queryParameters.SearchTerm.ToLower()) ||
                     p.Name.ToLower().Contains(queryParameters.SearchTerm.ToLower()));
        }

        if (!string.IsNullOrEmpty(queryParameters.Variant))
        {
            characters = characters.Where(
                p => p.Variant == queryParameters.Variant);
        }

        if (!string.IsNullOrEmpty(queryParameters.Name))
        {
            characters = characters.Where(
                p => p.Name.ToLower().Contains(
                    queryParameters.Name.ToLower()));
        }

        if (!string.IsNullOrEmpty(queryParameters.SortBy))
        {
            if (typeof(Character).GetProperty(queryParameters.SortBy) != null)
            {
                characters = characters.OrderByCustom(
                    queryParameters.SortBy,
                    queryParameters.SortOrder);
            }
        }

        characters = characters
            .Skip(queryParameters.Size * (queryParameters.Page - 1))
            .Take(queryParameters.Size);

        return Ok(await characters.ToArrayAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCharacter(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character == null)
        {
            return NotFound();
        }
        return Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<Character>> PostCharacter(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            "GetCharacter",
            new { id = character.Id },
            character);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutCharacter(int id, Character character)
    {
        if (id != character.Id)
        {
            return BadRequest();
        }

        _context.Entry(character).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Characters.Any(p => p.Id == id))
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

    [HttpDelete("{id}")]
    public async Task<ActionResult<Character>> DeleteCharacter(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character == null)
        {
            return NotFound();
        }

        _context.Characters.Remove(character);
        await _context.SaveChangesAsync();

        return character;
    }

    [HttpPost]
    [Route("Delete")]
    public async Task<ActionResult> DeleteMultiple([FromQuery] int[] ids)
    {
        var characters = new List<Character>();
        foreach (var id in ids)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            characters.Add(character);
        }

        _context.Characters.RemoveRange(characters);
        await _context.SaveChangesAsync();

        return Ok(characters);
    }
}

[ApiVersion("2.0")]
[Route("characters")]
[ApiController]
public class MKV2Controller : ControllerBase
{
    private readonly MKContext _context;

    public MKV2Controller(MKContext context)
    {
        _context = context;

        _context.Database.EnsureCreated();
    }

    [HttpGet]
    public async Task<ActionResult> GetAllCharacters([FromQuery] CharacterQueryParameters queryParameters)
    {
        IQueryable<Character> characters =
            _context.Characters.Where(p => p.IsAvailable == true);

        if (queryParameters.MinDamage != null)
        {
            characters = characters.Where(
                p => p.Damage >= queryParameters.MinDamage.Value);
        }

        if (queryParameters.MaxDamage != null)
        {
            characters = characters.Where(
                p => p.Damage <= queryParameters.MaxDamage.Value);
        }

        if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
        {
            characters = characters.Where(
                p => p.Variant.ToLower().Contains(queryParameters.SearchTerm.ToLower()) ||
                     p.Name.ToLower().Contains(queryParameters.SearchTerm.ToLower()));
        }

        if (!string.IsNullOrEmpty(queryParameters.Variant))
        {
            characters = characters.Where(
                p => p.Variant == queryParameters.Variant);
        }

        if (!string.IsNullOrEmpty(queryParameters.Name))
        {
            characters = characters.Where(
                p => p.Name.ToLower().Contains(
                    queryParameters.Name.ToLower()));
        }

        if (!string.IsNullOrEmpty(queryParameters.SortBy))
        {
            if (typeof(Character).GetProperty(queryParameters.SortBy) != null)
            {
                characters = characters.OrderByCustom(
                    queryParameters.SortBy,
                    queryParameters.SortOrder);
            }
        }

        characters = characters
            .Skip(queryParameters.Size * (queryParameters.Page - 1))
            .Take(queryParameters.Size);

        return Ok(await characters.ToArrayAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCharacter(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character == null)
        {
            return NotFound();
        }
        return Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<Character>> PostCharacter(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            "GetCharacter",
            new { id = character.Id },
            character);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutCharacter(int id, Character character)
    {
        if (id != character.Id)
        {
            return BadRequest();
        }

        _context.Entry(character).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Characters.Any(p => p.Id == id))
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

    [HttpDelete("{id}")]
    public async Task<ActionResult<Character>> DeleteCharacter(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character == null)
        {
            return NotFound();
        }

        _context.Characters.Remove(character);
        await _context.SaveChangesAsync();

        return character;
    }

    [HttpPost]
    [Route("Delete")]
    public async Task<ActionResult> DeleteMultiple([FromQuery] int[] ids)
    {
        var characters = new List<Character>();
        foreach (var id in ids)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            characters.Add(character);
        }

        _context.Characters.RemoveRange(characters);
        await _context.SaveChangesAsync();

        return Ok(characters);
    }
}