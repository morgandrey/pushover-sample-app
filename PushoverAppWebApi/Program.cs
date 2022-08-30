var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/SendNotification", async (
    IHttpClientFactory _httpClientFactory,
    string tokenKey,
    string userKey,
    string message) =>
{
    var httpRequestMessage = new HttpRequestMessage(
        HttpMethod.Post,
        $"https://api.pushover.net/1/messages.json?token={tokenKey}&user={userKey}&message={message}");

    var httpClient = _httpClientFactory.CreateClient();
    var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

    return httpResponseMessage.IsSuccessStatusCode ? Results.Ok() : Results.BadRequest();
});

app.Run();