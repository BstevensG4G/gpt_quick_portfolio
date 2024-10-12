namespace PostApiSeperateFile;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

public static class PostEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/api/posts", async (AppDbContext db) =>
        {
            var posts = await db.Posts.ToListAsync();
            return posts;
        });

        app.MapPost("/api/posts", async (Post newPost, AppDbContext db) =>
        {
            if (string.IsNullOrWhiteSpace(newPost.Title) || string.IsNullOrWhiteSpace(newPost.Content))
            {
                return Results.BadRequest("Title and content are required.");
            }

            db.Posts.Add(newPost);
            await db.SaveChangesAsync();
            return Results.Created($"/api/posts/{newPost.Id}", newPost);
        });

        app.MapPut("/api/posts/{id}", async (int id, Post updatedPost, AppDbContext db) =>
        {
            var post = await db.Posts.FindAsync(id);
            if (post is null) return Results.NotFound();

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;
            post.PublishedDate = updatedPost.PublishedDate;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        app.MapDelete("/api/posts/{id}", async (int id, AppDbContext db) =>
        {
            var post = await db.Posts.FindAsync(id);
            if (post is null) return Results.NotFound();

            db.Posts.Remove(post);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}