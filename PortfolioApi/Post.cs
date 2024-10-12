using System.ComponentModel.DataAnnotations;

public class Post
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; } = string.Empty;

    public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
}
