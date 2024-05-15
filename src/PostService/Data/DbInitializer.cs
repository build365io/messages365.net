using PostService.Entities;
using Microsoft.EntityFrameworkCore;

namespace PostService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<DataContext>());
    }

    private static void SeedData(DataContext context)
    {
        context.Database.Migrate();

        if (context.Posts.Any() && context.Messages.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var posts = new List<Post>()
        {
            new Post
            {
                Title = "Title",
                Content = "Content",
                ImageUrl = "https://unsplash.com/photos/XfKj1KBI0hY/download?ixid=M3wxMjA3fDB8MXxhbGx8MXx8fHx8fDJ8fDE3MTAyOTMzNzF8&force=true",
            },
            new Post
            {
                Title = "Title2",
                Content = "Content2",
                ImageUrl = "https://unsplash.com/photos/743SKdZBsHk/download?ixid=M3wxMjA3fDB8MXxhbGx8fHx8fHx8fHwxNzEwMzMyNzIzfA&force=true",
            },
            new Post
            {
                Title = "Title3",
                Content = "Content3",
                ImageUrl = "https://images.unsplash.com/photo-1610375229632-c7158c35a537?q=80&w=1742&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            },
            new Post
            {
                Title = "Title4",
                Content = "Content4",
                ImageUrl = "https://plus.unsplash.com/premium_photo-1661963274554-1e0a04d24428?q=80&w=1742&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            },
            new Post
            {
                Title = "Title5",
                Content = "Content5",
                ImageUrl = "https://unsplash.com/photos/fcwZsjyqp0s/download?ixid=M3wxMjA3fDB8MXx0b3BpY3x8Ym84alFLVGFFMFl8fHx8fDJ8fDE3MTEwOTI4Njd8&force=true",
            },
            new Post
            {
                Title = "Title6",
                Content = "Content6",
                ImageUrl = "https://unsplash.com/photos/743SKdZBsHk/download?ixid=M3wxMjA3fDB8MXxhbGx8fHx8fHx8fHwxNzEwMzMyNzIzfA&force=true",
            },
            new Post
            {
                Title = "Title7",
                Content = "Content7",
                ImageUrl = "https://images.unsplash.com/photo-1610375229632-c7158c35a537?q=80&w=1742&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            },
            new Post
            {
                Title = "Title8",
                Content = "Content8",
                ImageUrl = "https://plus.unsplash.com/premium_photo-1661963274554-1e0a04d24428?q=80&w=1742&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            }
        };

        var messages = new List<Message>()
        {
            new Message
            {
                Content = "Bacon ipsum dolor amet chuck brisket capicola pork chop. Hamburger t-bone tri-tip ham hock salami cow tongue, drumstick flank. Bresaola boudin alcatra tenderloin brisket pastrami fatback chuck.",
                CreatedAt = DateTime.UtcNow.AddDays(10),
                Author = "Kenneth"
            },
            new Message
            {
                Content = "CBacon ipsum dolor amet chuck brisket capicola pork chop. Hamburger t-bone tri-tip ham hock salami cow tongue, drumstick flank. Bresaola boudin alcatra tenderloin brisket pastrami fatback chuck.t",
                CreatedAt = DateTime.UtcNow.AddDays(10),
                Author = "Kenneth"
            },
            new Message
            {
                Content = "Bacon ipsum dolor amet chuck brisket capicola pork chop. Hamburger t-bone tri-tip ham hock salami cow tongue, drumstick flank. Bresaola boudin alcatra tenderloin brisket pastrami fatback chuck.",
                CreatedAt = DateTime.UtcNow.AddDays(10),
                Author = "Kenneth"
            },
            new Message
            {
                Content = "CBacon ipsum dolor amet chuck brisket capicola pork chop. Hamburger t-bone tri-tip ham hock salami cow tongue, drumstick flank. Bresaola boudin alcatra tenderloin brisket pastrami fatback chuck.t",
                CreatedAt = DateTime.UtcNow.AddDays(10),
                Author = "Kenneth"
            },
            new Message
            {
                Content = "Bacon ipsum dolor amet chuck brisket capicola pork chop. Hamburger t-bone tri-tip ham hock salami cow tongue, drumstick flank. Bresaola boudin alcatra tenderloin brisket pastrami fatback chuck.",
                CreatedAt = DateTime.UtcNow.AddDays(10),
                Author = "Kenneth"
            },
            new Message
            {
                Content = "CBacon ipsum dolor amet chuck brisket capicola pork chop. Hamburger t-bone tri-tip ham hock salami cow tongue, drumstick flank. Bresaola boudin alcatra tenderloin brisket pastrami fatback chuck.t",
                CreatedAt = DateTime.UtcNow.AddDays(10),
                Author = "Kenneth"
            },
            new Message
            {
                Content = "Bacon ipsum dolor amet chuck brisket capicola pork chop. Hamburger t-bone tri-tip ham hock salami cow tongue, drumstick flank. Bresaola boudin alcatra tenderloin brisket pastrami fatback chuck.",
                CreatedAt = DateTime.UtcNow.AddDays(10),
                Author = "Kenneth"
            },
            new Message
            {
                Content = "CBacon ipsum dolor amet chuck brisket capicola pork chop. Hamburger t-bone tri-tip ham hock salami cow tongue, drumstick flank. Bresaola boudin alcatra tenderloin brisket pastrami fatback chuck.t",
                CreatedAt = DateTime.UtcNow.AddDays(10),
                Author = "Kenneth"
            }
        };
        
        context.AddRange(posts);
        context.AddRange(messages);

        context.SaveChanges();
    }
}
