using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;

namespace NexusNova.Api.Config;

/// <summary>
/// Endpoint filter that rejects requests without a valid API key.
/// </summary>
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
        // Fail closed when no API key has been configured.
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

    // Constant-time comparison to avoid leaking the key through timing side channels.
    private static bool AreEqual(string provided, string expected)
    {
        var providedBytes = Encoding.UTF8.GetBytes(provided);
        var expectedBytes = Encoding.UTF8.GetBytes(expected);
        return CryptographicOperations.FixedTimeEquals(providedBytes, expectedBytes);
    }
}
