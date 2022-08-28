using Microsoft.AspNetCore.Mvc;

namespace PushoverAppWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(ILogger<NotificationController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostNotification")]
    public IEnumerable<string> Post()
    {
        throw new NotImplementedException();
    }
}