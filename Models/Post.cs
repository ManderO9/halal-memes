namespace HalalMemes;

/// <summary>
/// A post in the site
/// </summary>
public class Post
{
    /// <summary>
    /// The text of the post
    /// </summary>
    public string? Text { get; set; }
    
    /// <summary>
    /// Path to an image if the post contains an image
    /// </summary>
    public string? ImagePath { get; set; }

    /// <summary>
    /// Path to a video if the post contains a video
    /// </summary>
    public string? VideoPath { get; set; }
}
