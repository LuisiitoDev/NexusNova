using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;

namespace NexusNova.Api.Config;

public sealed class ApiKeyEndpointFilter : IEndpointFilter
{
    private readonly ApiKeyOptions _options;
    private readonly ILogger<ApiKeyEndpointFilter> _logger;

    public ApiKeyEndpointFilter(IOptions<ApiKeyOptions> options, ILogger<ApiKeyEndpointFilter> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        if (string.IsNullOrWhiteSpace(_options.Value))
        {
            _logger.LogError("No API key is configured. Rejecting the request.");
            return Results.Problem(
                title: "Server misconfiguration.",
                statusCode: StatusCodes.Status500InternalServerError);
        }

        var provided = context.HttpContext.Request.Headers[_options.HeaderName].ToString();

        if (string.IsNullOrEmpty(provided) || !AreEqual(provided, _options.Value))
        {
            return Results.Problem(
                title: "Invalid or missing API key.",
                statusCode: StatusCodes.Status401Unauthorized);
        }

        return await next(context);
    }

    private static bool AreEqual(string provided, string expected)
    {
        var providedBytes = Encoding.UTF8.GetBytes(provided);
        var expectedBytes = Encoding.UTF8.GetBytes(expected);
        return CryptographicOperations.FixedTimeEquals(providedBytes, expectedBytes);
    }
}
