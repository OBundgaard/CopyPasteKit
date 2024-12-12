using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MyClassController(IRepository<MyClass> repository) : Controller
{
    [HttpPost("post")]
    public async Task<ActionResult<MyClass>> Post([FromBody] MyClass entry)
    {
        // Verify entry
        if (entry == null)
            return BadRequest("Entry cannot be null."); // Return 400

        // Post and verify existence
        var myObject = await repository.Post(entry);
        if (myObject == null)
            return BadRequest("Failed to create the object. Please verify the input data and try again."); // Return 400

        // Return 201
        return Created(Url.Action(nameof(Get), new { id = myObject.ID }), myObject);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<MyClass>> Get(int id)
    {
        // Get and verify existence
        var myObject = await repository.Get(id);
        if (myObject == null)
            return NotFound($"Object with ID: {id} is not found."); // Return 404

        // Return 200
        return Ok(myObject);
    }

    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<MyClass>>> GetAll()
    {
        // Get all
        var myObjects = await repository.GetAll();

        // Return 200
        return Ok(myObjects);
    }

    [HttpPut("put/{id}")]
    public async Task<ActionResult<MyClass>> Put(int id, [FromBody] MyClass entry)
    {
        // Verify entry
        if (entry == null)
            return BadRequest("Entry cannot be null."); // Return 400

        // Verify id
        if (id != entry.ID)
            return BadRequest("ID does not match Entry ID."); // Return 400

        // Get and verify existence
        var myObject = await repository.Get(id);
        if (myObject == null)
            return NotFound($"Object with ID: {id} is not found."); // Return 404 - (OPTIONAL)

        // Put
        myObject = await repository.Put(entry);

        // Return 200
        return Ok(myObject);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        // Get and verify existence
        var myObject = await repository.Get(id);
        if (myObject == null)
            return NotFound($"Object with ID: {id} is not found."); // Return 404

        // Delete
        await repository.Delete(id);

        // Return 204
        return NoContent();
    }
}
