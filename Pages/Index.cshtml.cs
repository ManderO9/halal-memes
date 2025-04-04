using Microsoft.AspNetCore.Components;
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
                Text = "Bro did him dirty.",
                VideoPath = "./content/videos/bro-did-me-dirty.mp4"
            },
            new () {
                Text = "Bro wants to open an online business.",
                VideoPath = "./content/videos/bros-internet-skills.mp4" },
            new () { VideoPath = "./content/videos/coward.mp4" },
            new () { VideoPath = "./content/videos/candace.mp4" },
            new () { VideoPath = "./content/videos/balloons.mov" },
            new () { VideoPath = "./content/videos/cats-problems.mov" },
            new () { VideoPath = "./content/videos/e-cigarette.mp4" },
            new () { VideoPath = "./content/videos/fortnite-cimon-head.mp4" },
            new () { VideoPath = "./content/videos/watermelon-huh.mp4" },

        ];
    }
}
