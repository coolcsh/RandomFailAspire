using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RetryApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHttpClientFactory _clientFactory;
    public string Data { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _clientFactory = clientFactory;
    }

    public void OnGet()
    {
        var api = _clientFactory.CreateClient("api");
        Data = api.GetStringAsync("http://failapi/weatherforecast").Result;
    }
}
