using POC.TickerQ.Common.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace POC.TickerQ.Jobs.Helper;

public class VersionClient
{ 
    private readonly HttpClient _httpClient;

    public VersionClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<VersionEntity?> ActivateLatestVersionAsync()
    {
        var response = await _httpClient.PutAsync("api/version", content: null);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<VersionEntity>();
    }
}
