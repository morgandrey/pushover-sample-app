using Microsoft.AspNetCore.Mvc;

namespace PushoverAppWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(ILogger<NotificationController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    [HttpPost]
    public async Task<IResult> Post(string tokenKey, string userKey, string message)
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Post,
            $"https://api.pushover.net/1/messages.json?token={tokenKey}&user={userKey}&message={message}");

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        return httpResponseMessage.IsSuccessStatusCode ? Results.Ok() : Results.BadRequest();
    }
}