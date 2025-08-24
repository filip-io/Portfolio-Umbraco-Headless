var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        // Wide-open CORS for local development
        options.AddPolicy("AllowAllOrigins", policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    }
    else
    {
        // Restrictive CORS for production
        options.AddPolicy("FrontendPolicy", policy =>
        {
            policy.WithOrigins("https://filip-io.github.io/.github.io")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    }
});

// Configure Umbraco
builder.CreateUmbracoBuilder()
       .AddBackOffice()
       .AddWebsite()
       .AddDeliveryApi()
       .AddComposers()
       //.AddAzureBlobMediaFileSystem()
       //.AddAzureBlobImageSharpCache()
       .Build();

var app = builder.Build();
await app.BootUmbracoAsync();

// --- Diagnostic snippet for Azure configuration ---
var config = app.Services.GetRequiredService<IConfiguration>();

var section = config.GetSection("Umbraco:Storage:AzureBlob:Media");
foreach (var kv in section.GetChildren())
{
    Console.WriteLine($"[DIAGNOSTIC] {kv.Key} = {kv.Value}");
}
// --- end diagnostic ---

app.UseHttpsRedirection();

// Apply CORS
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAllOrigins");
}
else
{
    app.UseCors("FrontendPolicy");
}

// Configure Umbraco middleware and endpoints
app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
