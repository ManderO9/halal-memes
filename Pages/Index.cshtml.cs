using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HalalMemes.Pages;

public class IndexModel : PageModel
{
    public List<Post> Posts { get; set; } = [];

    public void OnGet()
    {
        Posts = [
            new ()
            {
                VideoPath = "/content/videos/bro-did-me-dirty.mp4"
            },
            new ()
            {
                VideoPath = "/content/videos/bros-internet-skills.mp4"
            },

        ];
    }
}
