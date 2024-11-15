using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly BlogRepository _repository;

    public BlogController()
    {
        _repository = new BlogRepository();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPost>>> GetAll() {
     var Blogs = await _repository.GetAll();
     return Ok(Blogs);

}

    [HttpGet("{id}")]
    public ActionResult<BlogPost> GetById(int id)
    {
        var blog = _repository.GetById(id);
        if (blog == null) return NotFound();
        return Ok(blog);
    }

    [HttpPost]
    public ActionResult Add(BlogPost blog)
    {
        _repository.Add(blog);
        return CreatedAtAction(nameof(GetById), new { id = blog.id }, blog);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, BlogPost blog)
    {
        if (id != blog.id) return BadRequest();
        _repository.Update(blog);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _repository.Delete(id);
        return NoContent();
    }
}
