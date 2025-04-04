using HalalMemes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapGet("/generate", async (HttpContext context, IEnumerable<EndpointDataSource> endpointSources) =>
{
    // Create http client to send requests
    var httpClient = new HttpClient();

    // Get base url to get requests from
    var baseUrl = app.Urls.First(x => x.StartsWith("https"));

    // List of endpoints to get
    var endpoints = new List<string>{
        "/index",
    };

    // Get output folder to write to
    var outputFolder = app.Environment.ContentRootPath + "/docs";

    // Delete any content in it if it already exists
    if(Directory.Exists(outputFolder))
        Directory.Delete(outputFolder, true);
    
    // Copy wwwroot into the output folder
    Helpers.CopyDirectory(app.Environment.WebRootPath, outputFolder);

    // For each endpoint
    foreach(var endpoint in endpoints)
    {
        // Get the content of the endpoint
        var response = await httpClient.GetAsync(baseUrl + endpoint);

        // Get file path to write into
        var filePath = outputFolder + endpoint + ".html";

        // Create parent directories if they don't already exist
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        // Write the result into the file
        File.WriteAllText(filePath, await response.Content.ReadAsStringAsync());
    }

    // Return success
    await context.Response.WriteAsync($"Done generating : {endpoints.Count} endpoints:"
        + Environment.NewLine + string.Join(Environment.NewLine, endpoints));
});

app.Run();
