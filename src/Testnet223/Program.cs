var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// The production gate probes /health after a deployment, so this endpoint
// is part of the pipeline contract rather than a convenience.
app.MapGet("/health", () => Results.Ok(new HealthResponse("ok", ServiceInfo.Name)));

app.MapGet("/", () => Results.Ok(new HealthResponse("ready", ServiceInfo.Name)));

app.Run();

public record HealthResponse(string Status, string Service);

public static class ServiceInfo
{
    public const string Name = "testnet223";
}

// Exposed so the test project can host the application in memory.
public partial class Program;
