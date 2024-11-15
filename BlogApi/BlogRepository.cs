using System.Text.Json;

public class BlogRepository
{
    private readonly string _filePath = "blogs.json";
    private List<BlogPost> _blogs;

    public BlogRepository()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _blogs = JsonSerializer.Deserialize<List<BlogPost>>(json) ?? new List<BlogPost>();
        }
        else
        {
            _blogs = new List<BlogPost>();
        }
    }


public async Task<List<BlogPost>> GetAll()
    {
        if (!File.Exists(_filePath))
        {
            return new List<BlogPost>();
        }

        var json = await File.ReadAllTextAsync(_filePath);
         var data = JsonSerializer.Deserialize<List<BlogPost>>(json);
         return data;
    }
    
    public BlogPost GetById(int id) => _blogs.FirstOrDefault(b => b.id == id);
    public void Add(BlogPost blog)
    {
        blog.id = _blogs.Any() ? _blogs.Max(b => b.id) + 1 : 1;
        _blogs.Add(blog);
        Save();
    }
    public void Update(BlogPost blog)
    {
        var index = _blogs.FindIndex(b => b.id == blog.id);
        if (index != -1) _blogs[index] = blog;
        Save();
    }
    public void Delete(int id)
    {
        var blog = _blogs.FirstOrDefault(b => b.id == id);
        if (blog != null) _blogs.Remove(blog);
        Save();
    }
    private void Save() => File.WriteAllText(_filePath, JsonSerializer.Serialize(_blogs));
}
